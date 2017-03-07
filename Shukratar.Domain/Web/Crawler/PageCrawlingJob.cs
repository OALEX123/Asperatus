using System;
using System.Diagnostics;
using Shukratar.Domain.Common;
using Shukratar.Domain.Parser;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Website;

namespace Shukratar.Domain.Web.Crawler
{
    public class PageCrawlingJob : IPageCrawlingJob
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClient _httpClient;
        private readonly IWebPageParser _pageParser;
        private readonly IRepository<FeedItem> _feedItems;

        public PageCrawlingJob(IUnitOfWork unitOfWork, IHttpClient httpClient, IWebPageParser pageParser,
            IRepository<FeedItem> feedItems)
        {
            _unitOfWork = unitOfWork;
            _httpClient = httpClient;
            _pageParser = pageParser;
            _feedItems = feedItems;
        }

        public void Crawl(FeedItem feedItem)
        {
            try
            {
                _feedItems.Attach(feedItem);

                var webPage = _httpClient.Get(feedItem.LinkUri);

                if (webPage == null) return;

                var newsPage = new NewsPage(webPage) {FeedItem = feedItem};

                _pageParser.Parse(newsPage);

                feedItem.NewsPage = newsPage;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
        }
    }
}
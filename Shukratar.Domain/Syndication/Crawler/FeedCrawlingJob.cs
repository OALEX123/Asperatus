using System;
using System.Diagnostics;
using System.Linq;
using Shukratar.Domain.Common;
using Shukratar.Domain.Html;
using Shukratar.Domain.Language;

namespace Shukratar.Domain.Syndication.Crawler
{
    public class FeedCrawlingJob : IFeedCrawlingJob
    {
        private readonly IRepository<Feed> _feeds;
        private readonly IRepository<FeedItem> _feedItems;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFeedReader _feedReader;
        private readonly IHtmlConverter _htmlConverter;
        private readonly ILanguageIdentifier _languageIdentifier;

        public FeedCrawlingJob(IRepository<FeedItem> feedItems, IUnitOfWork unitOfWork, IFeedReader feedReader,
            IHtmlConverter htmlConverter, IRepository<Feed> feeds, ILanguageIdentifier languageIdentifier)
        {
            _feedItems = feedItems;
            _unitOfWork = unitOfWork;
            _feedReader = feedReader;
            _htmlConverter = htmlConverter;
            _feeds = feeds;
            _languageIdentifier = languageIdentifier;
        }

        public void Crawl(Feed feed)
        {
            try
            {
                _feeds.Attach(feed);

                feed.LastUpdatedDate = DateTime.Now;

                var items = _feedReader.LoadItems(feed.Link);

                if (items == null) return;

                var loadedItemsLinks = items.Select(x => x.Link);

                var processedItemsLinks =
                    _feedItems.Where(item => loadedItemsLinks.Contains(item.Link)).Select(x => x.Link).ToArray();

                var unprocessedItems = items.Where(item => !processedItemsLinks.Contains(item.Link));

                foreach (var feedItem in unprocessedItems)
                {
                    _feedItems.Add(feedItem);

                    feedItem.Description = _htmlConverter.ToPlainText(feedItem.Summary);
                    feedItem.Language = _languageIdentifier.Identify(feedItem.FullText);
                    feedItem.CreatedDate = DateTime.Now;
                    feedItem.Feed = feed;
                }

                feed.Status = FeedStatus.Success;
            }
            catch (Exception e)
            {
                feed.Status = FeedStatus.Failure;

                Trace.TraceError("An error occured when crawling feed {0}: {1}", feed.Link, e.Message);
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
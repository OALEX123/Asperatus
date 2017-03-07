using Shukratar.Domain.Syndication;

namespace Shukratar.Domain.Web.Crawler
{
    public interface IPageCrawlingJob
    {
        void Crawl(FeedItem feedItem);
    }
}
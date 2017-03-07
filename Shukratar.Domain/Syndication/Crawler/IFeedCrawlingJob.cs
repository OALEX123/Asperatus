namespace Shukratar.Domain.Syndication.Crawler
{
    public interface IFeedCrawlingJob
    {
        void Crawl(Feed feed);
    }
}
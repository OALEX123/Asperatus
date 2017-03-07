using System.Linq;
using System.Threading.Tasks;
using Shukratar.Domain.Common;

namespace Shukratar.Domain.Syndication.Crawler
{
    public class FeedCrawler : IFeedCrawler
    {
        private readonly IQueryable<Feed> _feeds;
        private readonly IContainer _container;

        public FeedCrawler(IQueryable<Feed> feeds, IContainer container)
        {
            _feeds = feeds;
            _container = container;
        }

        public void Crawl()
        {
            var feeds = _feeds.AsNoTracking().OrderBy(x => x.LastUpdatedDate).ToArray();

            var options = new ParallelOptions {MaxDegreeOfParallelism = 10};

            Parallel.ForEach(feeds, options, feed => _container.Resolve<IFeedCrawlingJob>().Crawl(feed));
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Shukratar.Domain.Common;
using Shukratar.Domain.Syndication;

namespace Shukratar.Domain.Web.Crawler
{
    public class PageCrawler : IPageCrawler
    {
        private readonly IQueryable<FeedItem> _feedItems;
        private readonly IContainer _container;

        public PageCrawler(IQueryable<FeedItem> feedItems, IContainer container)
        {
            _feedItems = feedItems;
            _container = container;
        }

        public void Crawl()
        {
            var feedItems = _feedItems.AsNoTracking().Where(x => x.NewsPage == null).ToArray().Randomize();

            var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };

            Parallel.ForEach(feedItems, options, feedItem => _container.Resolve<IPageCrawlingJob>().Crawl(feedItem));
        }
    }
}
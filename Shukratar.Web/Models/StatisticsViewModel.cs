using System.Linq;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Video;
using Shukratar.Shared.Job;

namespace Shukratar.Web.Models
{
    public class StatisticsViewModel
    {
        private readonly IQueryable<FeedItem> _feedItems;
        private readonly IQueryable<Video> _videos;

        public StatisticsViewModel(IQueryable<FeedItem> feedItems, IQueryable<Feed> feeds, Job job,
            IQueryable<Video> videos)
        {
            _feedItems = feedItems;

            Feeds = feeds.Select(x => new FeedStatisticsViewModel
            {
                Feed = x,
                ItemsCount = x.FeedItems.Count,
                VideoItemsCount = x.FeedItems.Count(y => y.NewsPage.Video != null),
                CategoryItemsCount = x.FeedItems.Count(y => y.Categories.Any())
            }).ToArray();

            Job = job;
            _videos = videos;
        }

        public int TotalNews => _feedItems.Count();

        public int TotalVideosCount => _videos.Count();

        public int YouTubeVideosCount
        {
            get { return _videos.Count(x => x is YouTubeVideo); }
        }

        public int YouTubeVideosMetadataCount
        {
            get { return _videos.Count(x => x is YouTubeVideo); }
        }

        public int TotalNewsToday => _feedItems.Count();

        public int VideoNewsToday
        {
            get { return _feedItems.Count(x => x.NewsPage.VideoLink != null); }
        }

        public int TotalPages => _feedItems.Count(x => x.NewsPage != null);

        public int ErrorPages => _feedItems.Count(x => x.NewsPage != null && x.NewsPage.Status != null);

        public FeedStatisticsViewModel[] Feeds { get; }

        public Job Job { get; }

        public class FeedStatisticsViewModel
        {
            public Feed Feed { get; set; }

            public int ItemsCount { get; set; }

            public int VideoItemsCount { get; set; }

            public int CategoryItemsCount { get; set; }
        }
    }
}
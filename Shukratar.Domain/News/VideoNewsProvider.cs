using System;
using System.Linq;
using Shukratar.Domain.Common;

namespace Shukratar.Domain.News
{
    public class VideoNewsProvider : IVideoNewsProvider
    {
        private readonly IQueryable<Video.Video> _videos;
        private readonly ICache _cache;

        public VideoNewsProvider(IQueryable<Video.Video> videos, ICache cache)
        {
            _videos = videos;
            _cache = cache;
        }

        private IQueryable<VideoNews> VideoNews
        {
            get { return _cache.Get(nameof(VideoNews)) as IQueryable<VideoNews>; }
            set { _cache.Set(nameof(VideoNews), value, DateTimeOffset.Now.AddMinutes(20)); }
        }

        public IQueryable<VideoNews> Get()
        {
            if (VideoNews == null) Update();

            return VideoNews;
        }

        private void Update()
        {
            var twoWeeksFromNow = DateTime.Now.AddDays(-14);

            VideoNews = _videos.AsNoTracking()
                .Where(x=> x.PublishDate > twoWeeksFromNow)
#if DEBUG
                .Take(10)
#endif
                .Select(x => new VideoNews
                {
                    Video = x,
                    FeedItems = x.NewsPages.Select(i => i.FeedItem).ToList(),
                    Categories = x.NewsPages.SelectMany(i => i.FeedItem.Categories).ToList(),
                    VideoFiles = x.VideoFiles.OrderByDescending(i => i.Resolution)
                        .ThenByDescending(i => i.AudioBitrate).Take(1).ToList()
                }).ToList().AsQueryable();
        }
    }
}
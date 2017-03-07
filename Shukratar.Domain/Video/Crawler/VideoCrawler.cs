using System;
using System.Diagnostics;
using System.Linq;
using Shukratar.Domain.Common;
using Shukratar.Domain.Website;

namespace Shukratar.Domain.Video.Crawler
{
    public class VideoCrawler : IVideoCrawler
    {
        private readonly IQueryable<NewsPage> _newsPages;
        private readonly IQueryable<Video> _videos;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IYouTubeProvider _youTubeProvider;

        public VideoCrawler(IQueryable<NewsPage> newsPages,
            IUnitOfWork unitOfWork, IYouTubeProvider youTubeProvider, IQueryable<Video> videos)
        {
            _newsPages = newsPages;
            _unitOfWork = unitOfWork;
            _youTubeProvider = youTubeProvider;
            _videos = videos;
        }

        public void Crawl()
        {
            var newsPages = _newsPages
                .Where(x => x.VideoLink != null)
                .Where(x => x.Video == null).ToArray();

            foreach (var newsPage in newsPages)
            {
                try
                {
                    if (newsPage.Video != null) return;

                    var id = YouTubeVideo.ParseId(newsPage.VideoLink);

                    var video = _videos.FirstOrDefault(x => x.ExternalId == id);

                    newsPage.Video = video ?? _youTubeProvider.Get(id);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }

                _unitOfWork.SaveChanges();
            }
        }
    }
}
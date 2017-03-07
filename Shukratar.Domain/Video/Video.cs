using System;
using System.Collections.Generic;
using Shukratar.Domain.Website;

namespace Shukratar.Domain.Video
{
    public abstract class Video
    {
        public const string Selector =
            "iframe[src*='youtube.com/embed/'],iframe[src*='player.vimeo.com/video/']";

        protected Video()
        {
            Statistics = new VideoStatistics();
        }

        public int Id { get; set; }

        public string Link { get; set; }

        public virtual List<NewsPage> NewsPages { get; set; }

        public string Title { get; set; }

        public VideoStatistics Statistics { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        public string FullText => $"{Title}{Environment.NewLine}{Description}";

        public int? CategoryId { get; set; }

        public virtual VideoCategory VideoCategory { get; set; }

        public string ExternalId { get; set; }

        public abstract string GetLink();

        public abstract string GetEmbedLink();

        public virtual List<VideoFile> VideoFiles { get; set; }
    }
}
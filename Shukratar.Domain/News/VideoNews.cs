using System.Collections.Generic;
using System.Linq;
using Shukratar.Domain.Category.Intelligence;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Video;

namespace Shukratar.Domain.News
{
    public class VideoNews
    {
        public Video.Video Video { get; set; }

        public List<FeedItem> FeedItems { private get; set; }

        public List<VideoFile> VideoFiles { get; set; }

        public List<FeedItem> RelevantFeedItems
        {
            get { return FeedItems.GroupBy(x => x.LinkHost, (k, x) => x.First()).ToList(); }
        }

        public List<Category.Category> Categories { get; set; }

        public List<string> OriginalCategories
        {
            get { return Categories.OfType<FeedItemCategory>().GroupBy(x => x.Name).Select(x => x.Key).ToList(); }
        }

        public List<string> IntelligentCategories
        {
            get { return Categories.OfType<IntelligentCategory>().GroupBy(x => x.Name).Select(x => x.Key).ToList(); }
        }
    }
}
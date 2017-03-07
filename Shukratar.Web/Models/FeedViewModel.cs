using Shukratar.Domain.Syndication;

namespace Shukratar.Web.Models
{
    public class FeedViewModel
    {
        public string Link { get; set; }

        public string Title { get; set; }

        public Feed ToFeed()
        {
            var feed = Feed.Create(Link);

            feed.Title = Title;

            return feed;
        }
    }
}
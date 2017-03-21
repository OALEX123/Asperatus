using Shukratar.Domain.Syndication;

namespace Shukratar.Web.Models
{
    public class FeedViewModel
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public string Title { get; set; }

        public int CountryId { get; set; }

        public int CategoryId { get; set; }

        public Feed ToFeed()
        {
            var feed = Feed.Create(Link);

            feed.Id = Id;
            feed.Title = Title;
            feed.CategoryId = CategoryId;
            feed.CountryId = CountryId;

            return feed;
        }
    }
}
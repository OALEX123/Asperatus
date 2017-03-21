using System;
using System.Collections.Generic;

namespace Shukratar.Domain.Syndication
{
    public class Feed
    {
        private ICollection<FeedItem> _feedItems;

        protected Feed()
        {
            _feedItems = new List<FeedItem>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public virtual ICollection<FeedItem> FeedItems
        {
            get { return _feedItems; }
            set { _feedItems = value; }
        }

        public int WebsiteId { get; set; }

        public int CountryId { get; set; }

        public int CategoryId { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public FeedStatus? Status { get; set; }

        public static Feed Create(string link)
        {
            return new Feed
            {
                Link = link
            };
        }

        public virtual FeedCountry Country { get; set; }

        public virtual FeedCategory Category { get; set; }
    }
}
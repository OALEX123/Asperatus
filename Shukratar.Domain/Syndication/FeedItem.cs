using System;
using System.Collections.Generic;
using Shukratar.Domain.Website;

namespace Shukratar.Domain.Syndication
{
    public class FeedItem
    {
        public FeedItem()
        {
            Language = new Language.Language();
        }

        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public Uri LinkUri => new Uri(Link);

        public string LinkHost => LinkUri.Host;

        public virtual NewsPage NewsPage { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public string Author { get; set; }

        public int FeedId { get; set; }

        public virtual Feed Feed { get; set; }

        public string Copyright { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public string FullText => $"{Title}{Environment.NewLine}{Description}";

        public virtual ICollection<Category.Category> Categories { get; set; }

        public Language.Language Language { get; set; }
    }
}
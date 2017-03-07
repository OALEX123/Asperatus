using System;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Web;

namespace Shukratar.Domain.Website
{
    public class NewsPage : WebPage
    {
        public NewsPage()
        {
        }

        public NewsPage(WebPage page)
        {
            Content = page.Content;
            Uri = page.Uri;
            CreatedDate = DateTime.Now;
            ContentLength = page.ContentLength;
            ContentType = page.ContentType;
            Status = page.Status;
        }

        public int Id { get; set; }

        public int? VideoId { get; set; }

        public virtual Video.Video Video { get; set; }

        public virtual FeedItem FeedItem { get; set; }

        public DateTime CreatedDate { get; set; }

        public string VideoLink { get; set; }
    }
}
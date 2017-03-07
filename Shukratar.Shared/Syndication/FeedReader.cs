using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Shukratar.Domain.Syndication;

namespace Shukratar.Shared.Syndication
{
    public class FeedReader : IFeedReader
    {
        public List<FeedItem> LoadItems(string url)
        {
            Trace.TraceInformation($"Request {url}");

            var reader = XmlReader.Create(url);

            var feed = SyndicationFeed.Load(reader);

            var newses = new List<FeedItem>();

            if (feed == null) return null;

            foreach (var item in feed.Items)
            {
                var news = new FeedItem
                {
                    Guid = item.Id,
                    Title = item.Title?.Text,
                    PublishDate = item.PublishDate,
                    Summary = item.Summary?.Text,
                    Copyright = item.Copyright?.Text,
                    LastUpdatedTime = item.LastUpdatedTime,
                    Link = item.Links.FirstOrDefault()?.Uri.OriginalString,
                    Categories = item.Categories
                        .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                        .Select(x => new FeedItemCategory {Name = x.Name}).ToArray()
                };

                newses.Add(news);
            }

            return newses;
        }
    }
}
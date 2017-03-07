using System.Collections.Generic;

namespace Shukratar.Domain.Syndication
{
    public interface IFeedReader
    {
        List<FeedItem> LoadItems(string url);
    }
}
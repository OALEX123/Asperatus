using System;
using System.Collections.Generic;
using System.Linq;
using Shukratar.Domain.Common;
using Shukratar.Domain.Syndication;

namespace Shukratar.Domain.Language
{
    public class LanguageProvider : ILanguageProvider
    {
        private readonly IQueryable<FeedItem> _feedItems;
        private readonly ICache _cache;

        public LanguageProvider(IQueryable<FeedItem> feedItems, ICache cache)
        {
            _feedItems = feedItems;
            _cache = cache;
        }

        private List<string> Languages
        {
            get { return _cache.Get(nameof(Languages)) as List<string>; }
            set { _cache.Set(nameof(Languages), value, DateTimeOffset.Now.AddMinutes(20)); }
        }

        public List<string> Get()
        {
            if (Languages == null) Update();

            return Languages;
        }

        private void Update()
        {
            Languages = _feedItems.AsNoTracking()
                .Where(x => x.Language.Code != null && x.NewsPage.Video != null)
                .GroupBy(x => x.Language.Code).OrderByDescending(x => x.Count())
                .Select(x => x.Key).ToList();
        }
    }
}
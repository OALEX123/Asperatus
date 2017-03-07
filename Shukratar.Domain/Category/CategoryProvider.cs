using System;
using System.Collections.Generic;
using System.Linq;
using Shukratar.Domain.Common;
using Shukratar.Domain.Syndication;

namespace Shukratar.Domain.Category
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly IQueryable<FeedItemCategory> _feedItemCategories;
        private readonly ICache _cache;

        public CategoryProvider(IQueryable<FeedItemCategory> feedItemCategories, ICache cache)
        {
            _feedItemCategories = feedItemCategories;
            _cache = cache;
        }

        private List<string> Categories
        {
            get { return _cache.Get(nameof(Categories)) as List<string>; }
            set { _cache.Set(nameof(Categories), value, DateTimeOffset.Now.AddMinutes(20)); }
        }

        public List<string> Get()
        {
            if (Categories == null) Update();

            return Categories;
        }

        private void Update()
        {
            Categories = _feedItemCategories.AsNoTracking()
                .Where(x => x.FeedItem.NewsPage.Video != null)
                .GroupBy(x => x.Name).OrderByDescending(x => x.Count())
                .Take(10).Select(x => x.Key).ToList();
        }
    }
}
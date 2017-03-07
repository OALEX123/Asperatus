using System;
using System.Runtime.Caching;
using Shukratar.Domain.Common;

namespace Shukratar.Shared.Cache
{
    public class Cache : ICache
    {
        private readonly MemoryCache _cache;

        public Cache()
        {
            _cache = MemoryCache.Default;
        }

        public void Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }
    }
}
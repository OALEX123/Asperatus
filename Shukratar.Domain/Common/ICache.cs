using System;

namespace Shukratar.Domain.Common
{
    public interface ICache
    {
        void Set(string key, object value, DateTimeOffset absoluteExpiration);

        object Get(string key);
    }
}
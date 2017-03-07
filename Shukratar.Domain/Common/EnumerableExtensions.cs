using System;
using System.Collections.Generic;
using System.Linq;

namespace Shukratar.Domain.Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            var random = new Random();

            return source.OrderBy(item => random.Next());
        }
    }
}
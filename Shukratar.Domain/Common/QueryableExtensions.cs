using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shukratar.Domain.Common
{
    public static class QueryableExtensions
    {
        public static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).ToListAsync();
        }

        public static Task<TSource[]> ToArrayAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).ToArrayAsync();
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IQueryable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return AsAsyncQueryable(source).ToDictionaryAsync(keySelector);
        }

        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).FirstAsync();
        }

        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate)
        {
            return AsAsyncQueryable(source).FirstAsync(predicate);
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).FirstOrDefaultAsync();
        }

        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate)
        {
            return AsAsyncQueryable(source).FirstOrDefaultAsync(predicate);
        }

        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).SingleAsync();
        }

        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate)
        {
            return AsAsyncQueryable(source).SingleAsync(predicate);
        }

        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).SingleOrDefaultAsync();
        }

        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate)
        {
            return AsAsyncQueryable(source).SingleOrDefaultAsync(predicate);
        }

        public static Task<int> CountAsync<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).CountAsync();
        }

        public static IQueryable<TSource> AsNoTracking<TSource>(this IQueryable<TSource> source)
        {
            return AsAsyncQueryable(source).AsNoTracking();
        }

        private static IQuery<T> AsAsyncQueryable<T>(IEnumerable<T> source)
        {
            return source as IQuery<T>;
        }
    }
}
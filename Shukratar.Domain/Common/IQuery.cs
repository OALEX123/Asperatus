using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shukratar.Domain.Common
{
    public interface IQuery<T> : IQueryable<T>
    {
        Task<T> FirstAsync();

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync();

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> SingleAsync();

        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefaultAsync();

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> ToListAsync();

        Task<T[]> ToArrayAsync();

        Task<Dictionary<TKey, T>> ToDictionaryAsync<TKey>(Func<T, TKey> keySelector);

        Task<int> CountAsync();

        IQueryable<T> AsNoTracking();
    }
}
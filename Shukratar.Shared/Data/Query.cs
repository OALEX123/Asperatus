using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shukratar.Domain.Common;

namespace Shukratar.Shared.Data
{
    public class Query<TEntity> : IOrderedQueryable<TEntity>, IQuery<TEntity>
    {
        private readonly IQueryable<TEntity> _queryable;

        public Query(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        public Expression Expression => _queryable.Expression;

        public Type ElementType => _queryable.ElementType;

        public IQueryProvider Provider => new QueryProvider(_queryable.Provider);

        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(_queryable, predicate);
        }

        public Task<TEntity> FirstAsync()
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(_queryable);
        }

        public Task<TEntity> FirstOrDefaultAsync()
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(_queryable);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(_queryable, predicate);
        }

        public Task<TEntity> SingleAsync()
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(_queryable);
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(_queryable, predicate);

        }

        public Task<TEntity> SingleOrDefaultAsync()
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(_queryable);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(_queryable, predicate);
        }

        public Task<List<TEntity>> ToListAsync()
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(_queryable);
        }

        public Task<TEntity[]> ToArrayAsync()
        {
            return System.Data.Entity.QueryableExtensions.ToArrayAsync(_queryable);
        }

        public Task<Dictionary<TKey, TEntity>> ToDictionaryAsync<TKey>(Func<TEntity, TKey> keySelector)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(_queryable, keySelector);
        }

        public Task<int> CountAsync()
        {
            return System.Data.Entity.QueryableExtensions.CountAsync(_queryable);
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            var queryable = (object) _queryable;

            return (IQueryable<TEntity>) System.Data.Entity.QueryableExtensions.AsNoTracking((IQueryable) queryable);
        }
    }
}
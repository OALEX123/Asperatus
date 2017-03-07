using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shukratar.Domain.Common
{
    public interface IRepository<TEntity> : IQueryable<TEntity>
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Attach(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities, int? batchSize = null);

        int RemoveRange(Expression<Func<TEntity, bool>> filterExpression);
    }
}
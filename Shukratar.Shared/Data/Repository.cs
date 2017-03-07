using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using Shukratar.Domain.Common;

namespace Shukratar.Shared.Data
{
    public class Repository<TEntity> : Query<TEntity>, IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public Repository(DbContext context) : base(context.Set<TEntity>())
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities, int? batchSize = null)
        {
            _context.BulkInsert(entities, batchSize);
        }

        public int RemoveRange(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _dbSet.Where(filterExpression).Delete();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }
    }
}
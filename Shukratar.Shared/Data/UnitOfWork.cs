using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Shukratar.Domain.Common;

namespace Shukratar.Shared.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int? CommandTimeout
        {
            get { return ObjectContext.CommandTimeout; }
            set { ObjectContext.CommandTimeout = value; }
        }

        private ObjectContext ObjectContext => ((IObjectContextAdapter) _context).ObjectContext;


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
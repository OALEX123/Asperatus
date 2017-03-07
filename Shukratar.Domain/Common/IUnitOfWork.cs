using System;
using System.Threading.Tasks;

namespace Shukratar.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        int? CommandTimeout { get; set; }
    }
}
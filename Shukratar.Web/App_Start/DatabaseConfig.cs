using System.Data.Entity.Infrastructure.Interception;
using Shukratar.Shared.Data;
using Shukratar.Shared.Diagnostics;

namespace Shukratar.Web
{
    public static class DatabaseConfig
    {
        public static void Configure()
        {
            DbInterception.Add(new FullTextSearchInterceptor());
            DbInterception.Add(new TraceDbCommandInterceptor());
        }
    }
}

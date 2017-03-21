using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shukratar.Data.Mapping
{
    internal class DbInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            base.Seed(context);
        }
    }
}

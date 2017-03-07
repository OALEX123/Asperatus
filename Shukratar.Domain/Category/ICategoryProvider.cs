using System.Collections.Generic;

namespace Shukratar.Domain.Category
{
    public interface ICategoryProvider
    {
        List<string> Get();
    }
}

using System.Web.Mvc;
using Shukratar.Web.Filters;

namespace Shukratar.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}

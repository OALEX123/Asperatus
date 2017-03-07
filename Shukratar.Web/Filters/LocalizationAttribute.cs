using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using Shukratar.Web.Properties;

namespace Shukratar.Web.Filters
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = new CultureInfo("ru-RU");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Resources.Culture = culture;

            base.OnActionExecuting(filterContext);
        }
    }
}
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return this.RedirectToAction<NewsController>(c=>c.Index());
            return RedirectToAction("Index", "News");
        }
    }
}
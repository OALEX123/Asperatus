using System.Web.Mvc;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "News");
        }
    }
}
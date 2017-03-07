using System.Web.Mvc;
using Shukratar.Shared.Job;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public ActionResult Run()
        {
            _jobService.Run();

            return RedirectToAction("Index", "Admin");
        }
    }
}
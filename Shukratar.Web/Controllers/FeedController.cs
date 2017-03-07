using System.Linq;
using System.Web.Mvc;
using Shukratar.Domain.Common;
using Shukratar.Domain.Syndication;
using Shukratar.Web.Models;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class FeedController : Controller
    {
        private readonly IRepository<Feed> _feeds;
        private readonly IUnitOfWork _unitOfWork;

        public FeedController(IRepository<Feed> feeds, IUnitOfWork unitOfWork)
        {
            _feeds = feeds;
            _unitOfWork = unitOfWork;
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Submit(FeedViewModel feedViewModel)
        {
            _feeds.Add(feedViewModel.ToFeed());

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        public RedirectToRouteResult Delete(int id)
        {
            var feed = _feeds.Single(x => x.Id == id);

            _feeds.Remove(feed);

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using Shukratar.Domain.Common;
using Shukratar.Domain.Syndication;
using Shukratar.Web.Models;
using WebGrease.Css.Extensions;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class FeedController : Controller
    {
        private readonly IRepository<Feed> _feeds;
        private readonly IRepository<FeedCategory> _categories;
        private readonly IRepository<FeedCountry> _countries;
        private readonly IUnitOfWork _unitOfWork;

        public FeedController(IRepository<Feed> feeds, IRepository<FeedCountry> countries, IRepository<FeedCategory> categories, IUnitOfWork unitOfWork)
        {
            _feeds = feeds;
            _categories = categories;
            _countries = countries;
            _unitOfWork = unitOfWork;
        }

        public ViewResult Add()
        {
            var model = loadManageFeedViewModel();

            return View(model);
        }

        public ViewResult Edit(int id)
        {
            var feed = _feeds.Single(x => x.Id == id);

            var model = loadManageFeedViewModel();
            model.Feed = new FeedViewModel
            {
                Id = feed.Id,
                Link = feed.Link,
                CategoryId = feed.CategoryId,
                CountryId = feed.CountryId
            };
               
            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult Submit(FeedViewModel feedViewModel)
        {
            var feed = feedViewModel.ToFeed();

            if (feed.Id > 0)
            {
                var feedDb = _feeds.Single(x => x.Id == feed.Id);
                feedDb.Link = feed.Link;
                feedDb.CategoryId = feed.CategoryId;
                feedDb.CountryId = feed.CountryId;
            }
            else
            {
                _feeds.Add(feed);
            }

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

        private ManageFeedViewModel loadManageFeedViewModel()
        {
            return new ManageFeedViewModel
            {
                Categories = _categories.ToList().Select(c => new FeedCategoryViewModel { Id = c.Id, Name = c.Name }).ToList(),
                Countries = _countries.ToList().Select(c => new FeedCountryViewModel { Id = c.Id, Name = c.Name }).ToList()
            };
        }
    }
}
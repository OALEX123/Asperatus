using System;
using System.Linq;
using System.Web.Mvc;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Video;
using Shukratar.Shared.Job;
using Shukratar.Web.Models;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IQueryable<FeedItem> _feedItems;
        private readonly IQueryable<Feed> _feeds;
        private readonly IQueryable<Video> _videos;

        private readonly IJobService _jobService;

        public AdminController(IQueryable<FeedItem> feedItems, IQueryable<Feed> feeds, IJobService jobService, IQueryable<Video> videos)
        {
            _feedItems = feedItems;
            _feeds = feeds;
            _jobService = jobService;
            _videos = videos;
        }

        public ViewResult Index()
        {
            var jobState = _jobService.GetState();

            var job = new Job
            {
                Name = "Service Job",
                //RunCommand = "RunCommand",
                RunState = jobState.RunState,
                LatestRun = new JobRun
                {
                    Name = "LatestRun"
                }
            };

            return View(new StatisticsViewModel(_feedItems, _feeds, job, _videos));

        }
    }
}
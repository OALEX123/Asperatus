using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shukratar.Domain.News;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Video;
using Shukratar.Domain.Website;

namespace Shukratar.Web.Models
{
    public class NewsViewModel
    {
        public const int PageSize = 15;
        private readonly int? _page;
        private readonly string _language;
        private readonly int? _period;
        private readonly Stopwatch _requestTimeStopwatch;
        private readonly IQueryable<VideoNews> _videoNews;
        private readonly List<string> _languages;

        public NewsViewModel(IQueryable<VideoNews> videoNews, List<string> categories, List<string> languages,
            string query, string category, int? page, string language, int? period)
        {
            Query = query;
            Category = category;
            _page = page;
            _language = language;
            _period = period;
            _videoNews = videoNews;
            _languages = languages;
            Categories = categories;
            _requestTimeStopwatch = new Stopwatch();
            _requestTimeStopwatch.Start();

            VideoNews = GetItems().OrderByDescending(x => x.Video.PublishDate).Skip(Skip(Page)).Take(PageSize).ToArray();
            TotalCount = GetItems().Count();

            _requestTimeStopwatch.Stop();

            Pager = new PagerViewModel(TotalCount, _page, PageSize);
        }

        public string Category { get; }

        public PagerViewModel Pager { get; private set; }

        public int PagesCount => TotalCount/PageSize;

        public VideoNews[] VideoNews { get; }

        public int? Page => _page ?? 1;

        public string Query { get; }

        public TimeSpan RequestTime => _requestTimeStopwatch.Elapsed;

        public int TotalCount { get; }

        public List<string> Categories { get; }

        public List<string> Languages => _languages;

        public string Language => _language;

        public int? Period => _period;

        private IQueryable<VideoNews> GetItems()
        {
            var query = _videoNews;

            if (!string.IsNullOrEmpty(Query))
                query = query.Where(x => x.Video.FullText.Contains(Query)
                                         || x.RelevantFeedItems.Any(y => y.FullText.Contains(Query)));

            if (!string.IsNullOrEmpty(Category))
                query = query.Where(x => x.Categories.Any(y => y.Name == Category));

            if (!string.IsNullOrEmpty(Language))
                query = query.Where(x => x.RelevantFeedItems.Any(y => y.Language.Code == Language));

            if (Period != null)
                query = query.Where(x => x.Video.PublishDate > DateTime.Now.AddDays(-Period.Value));

            return query;
        }

        private static int Skip(int? page)
        {
            return (page.GetValueOrDefault() - 1)*PageSize;
        }

        public class NewsItemViewModel
        {
            public FeedItem FeedItem { get; set; }

            public NewsPage NewsPage { get; set; }

            public Feed Feed { get; set; }
        }

        public class VideoViewModel
        {
            public Video Video { get; set; }

            public IEnumerable<NewsItemViewModel> Items { get; set; }
        }
    }
}
using System.Web.Mvc;
using Shukratar.Domain.Category;
using Shukratar.Domain.Language;
using Shukratar.Domain.News;
using Shukratar.Web.Models;

namespace Shukratar.Web.Controllers
{
    [AllowAnonymous]
    public class NewsController : Controller
    {
        private readonly IVideoNewsProvider _videoNewsProvider;
        private readonly ICategoryProvider _categoryProvider;
        private readonly ILanguageProvider _languageProvider;

        public NewsController(IVideoNewsProvider videoNewsProvider, ICategoryProvider categoryProvider,
            ILanguageProvider languageProvider)
        {
            _videoNewsProvider = videoNewsProvider;
            _categoryProvider = categoryProvider;
            _languageProvider = languageProvider;
        }

        public ViewResult Index(string query, string category, int? page, string language, int? period)
        {
            var categories = _categoryProvider.Get();
            var videoNewsProvider = _videoNewsProvider.Get();
            var languages = _languageProvider.Get();

            return
                View(new NewsViewModel(videoNewsProvider, categories, languages, query, category, page, language, period));
        }
    }
}
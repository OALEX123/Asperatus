using System.Data.Entity;
using System.Linq;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using Shukratar.Data.Mapping;
using Shukratar.Domain.Category;
using Shukratar.Domain.Common;
using Shukratar.Domain.Html;
using Shukratar.Domain.Language;
using Shukratar.Domain.Language.Lemma;
using Shukratar.Domain.News;
using Shukratar.Domain.Parser;
using Shukratar.Domain.Syndication;
using Shukratar.Domain.Syndication.Crawler;
using Shukratar.Domain.Video;
using Shukratar.Domain.Video.Crawler;
using Shukratar.Domain.Web;
using Shukratar.Domain.Web.Crawler;
using Shukratar.Shared.Data;
using Shukratar.Shared.Job;
using Shukratar.Shared.Language;
using Shukratar.Shared.Language.Lemma;
using Shukratar.Shared.Security;
using Shukratar.Shared.Syndication;
using Shukratar.Shared.VideoHosting.YouTube;
using Shukratar.Shared.Web;

namespace Shukratar.Shared.Bootstrap
{
    public class AppContainer : UnityContainer, IContainer
    {
        public AppContainer(bool isFromWin = false) : this(new PerThreadLifetimeManager(), isFromWin)
        {
        }

        public AppContainer(LifetimeManager lifetimeManager, bool isFromWin = false)
        {
            var container = this;

            container.RegisterType<IFeedReader, FeedReader>();
            container.RegisterType<IHtmlConverter, HtmlConverter>();
            container.RegisterType<IFeedCrawler, FeedCrawler>();
            container.RegisterType<IFeedCrawlingJob, FeedCrawlingJob>();
            container.RegisterType<IPageCrawler, PageCrawler>();
            container.RegisterType<IVideoCrawler, VideoCrawler>();
            container.RegisterType<IYouTubeProvider, YouTubeProvider>(new InjectionConstructor());
            container.RegisterType<IHttpClient, HttpClient>();
            container.RegisterType<IWebPageParser, WebPageParser>();
            container.RegisterType<IHtmlSelector, HtmlSelector>();
            container.RegisterType<IUserStore<ApplicationUser, int>, UserStore>();
            container.RegisterType<UserManager<ApplicationUser, int>, ApplicationUserManager>();
            container.RegisterType<ICache, Cache.Cache>();
            container.RegisterType<ICategoryProvider, CategoryProvider>();
            container.RegisterType<IVideoNewsProvider, VideoNewsProvider>();
            container.RegisterType<ILanguageIdentifier, LanguageIdentifier>();
            container.RegisterType<ILanguageProvider, LanguageProvider>();
            container.RegisterType<ILemmatizer, Lemmatizer>();

            //container.RegisterType<IJobService, AzureJobService>(
            //    new InjectionConstructor(new Uri("https://asperatus.scm.azurewebsites.net"), "", ""));
            if (!isFromWin)
            {
                container.RegisterType<IJobService, WinJobService>(
                    new InjectionConstructor(ConfigurationManager.AppSettings["Crawler.ServiceProcessName"], ConfigurationManager.AppSettings["Crawler.ServiceExecutionPath"]));
            }


            container.RegisterType<IPageCrawlingJob, PageCrawlingJob>();

            container.RegisterType<DbContext, DataContext>(lifetimeManager, new InjectionConstructor());

            container.RegisterType(typeof(IQueryable<>), typeof(Repository<>));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterInstance<IContainer>(this);
        }

        public T Resolve<T>()
        {
            return UnityContainerExtensions.Resolve<T>(this);
        }
    }
}
using System;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using Shukratar.Domain.Syndication.Crawler;
using Shukratar.Domain.Video.Crawler;
using Shukratar.Domain.Web.Crawler;
using Shukratar.Shared.Bootstrap;
using Shukratar.Shared.Diagnostics;

namespace Shukratar.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var appContainer = new AppContainer(isFromWin: true);

            DbInterception.Add(new TraceDbCommandInterceptor());

            try
            {
                appContainer.Resolve<IFeedCrawler>().Crawl();
                appContainer.Resolve<IPageCrawler>().Crawl();
                appContainer.Resolve<IVideoCrawler>().Crawl();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);

                throw;
            }
        }
    }
}
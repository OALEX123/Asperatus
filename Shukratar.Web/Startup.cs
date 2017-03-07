using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Shukratar.Web.Startup))]

namespace Shukratar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

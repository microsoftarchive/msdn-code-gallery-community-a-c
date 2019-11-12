using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PDM.Web.Startup))]
namespace PDM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

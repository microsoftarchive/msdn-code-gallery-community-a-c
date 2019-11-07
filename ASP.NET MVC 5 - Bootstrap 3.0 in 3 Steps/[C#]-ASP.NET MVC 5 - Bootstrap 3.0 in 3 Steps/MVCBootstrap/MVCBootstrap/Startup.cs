using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBootstrap.Startup))]
namespace MVCBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

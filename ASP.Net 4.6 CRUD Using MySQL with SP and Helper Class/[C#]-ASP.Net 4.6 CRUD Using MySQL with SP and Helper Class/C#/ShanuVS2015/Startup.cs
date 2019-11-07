using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShanuVS2015.Startup))]
namespace ShanuVS2015
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

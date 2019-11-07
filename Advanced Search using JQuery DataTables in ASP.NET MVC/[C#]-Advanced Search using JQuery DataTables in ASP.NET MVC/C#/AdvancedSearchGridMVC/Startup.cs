using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GridAdvancedSearchMVC.Startup))]
namespace GridAdvancedSearchMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

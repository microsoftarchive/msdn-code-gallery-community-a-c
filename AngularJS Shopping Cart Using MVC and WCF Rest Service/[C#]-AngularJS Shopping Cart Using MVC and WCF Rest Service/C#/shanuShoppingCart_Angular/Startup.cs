using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shanuShoppingCart_Angular.Startup))]
namespace shanuShoppingCart_Angular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

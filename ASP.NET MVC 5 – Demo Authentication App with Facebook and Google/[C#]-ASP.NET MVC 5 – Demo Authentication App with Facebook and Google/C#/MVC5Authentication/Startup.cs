using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Authentication.Startup))]
namespace MVC5Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

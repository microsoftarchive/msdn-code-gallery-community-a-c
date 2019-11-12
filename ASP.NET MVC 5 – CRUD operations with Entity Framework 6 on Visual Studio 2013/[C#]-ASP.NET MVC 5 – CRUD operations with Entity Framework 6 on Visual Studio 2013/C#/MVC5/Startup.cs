using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5.Startup))]
namespace MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

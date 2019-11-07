using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleEF6.Startup))]
namespace SampleEF6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

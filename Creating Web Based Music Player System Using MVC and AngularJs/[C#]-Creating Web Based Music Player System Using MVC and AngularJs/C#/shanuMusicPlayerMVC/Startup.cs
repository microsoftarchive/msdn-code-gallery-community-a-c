using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shanuMusicPlayerMVC.Startup))]
namespace shanuMusicPlayerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

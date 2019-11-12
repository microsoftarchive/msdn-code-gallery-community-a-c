using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaferPasswordProject.Startup))]
namespace SaferPasswordProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

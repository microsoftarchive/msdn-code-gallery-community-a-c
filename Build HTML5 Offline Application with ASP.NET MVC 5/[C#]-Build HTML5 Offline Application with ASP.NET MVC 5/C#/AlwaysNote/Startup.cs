using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlwaysNote.Startup))]
namespace AlwaysNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

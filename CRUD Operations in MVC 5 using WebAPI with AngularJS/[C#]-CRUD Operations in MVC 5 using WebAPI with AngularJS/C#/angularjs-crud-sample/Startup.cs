using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(angularjs_crud_sample.Startup))]
namespace angularjs_crud_sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

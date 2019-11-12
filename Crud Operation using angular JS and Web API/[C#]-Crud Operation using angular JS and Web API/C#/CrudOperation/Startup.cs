using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudOperation.Startup))]
namespace CrudOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

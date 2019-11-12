using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeManagement.Web.Startup))]
namespace EmployeeManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

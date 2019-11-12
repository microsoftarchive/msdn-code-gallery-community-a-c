using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeManagement.Startup))]
namespace EmployeeManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

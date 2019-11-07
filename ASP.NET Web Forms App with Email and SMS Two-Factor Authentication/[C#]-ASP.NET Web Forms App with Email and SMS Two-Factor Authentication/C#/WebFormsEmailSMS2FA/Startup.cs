using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsEmailSMS2FA.Startup))]
namespace WebFormsEmailSMS2FA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

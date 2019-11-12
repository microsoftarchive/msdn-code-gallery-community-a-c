using Hangfire;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(HangFire.Startup))]
namespace HangFire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration
                .UseSqlServerStorage("connectionString");

            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}

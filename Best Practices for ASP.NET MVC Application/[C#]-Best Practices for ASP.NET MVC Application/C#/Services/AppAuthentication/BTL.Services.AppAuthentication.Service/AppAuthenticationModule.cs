#region

using Autofac;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Services.AppAuthentication.Service
{
    public class AppAuthenticationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<ExConfigurationManager>().As<IExConfigurationManager>().PropertiesAutowired();
        }
    }
}
#region

using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using BTL.Application.Facade.AppAuthentication;
using BTL.Application.Facade.AppSecurity;
using BTL.Application.Web.Infrastructure;
using BTL.Application.Web.Infrastructure.Security.Authentications;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts.FacebookAuthentication;
using BTL.Application.Web.Infrastructure.Security.Authentications.Models;
using BTL.Application.Web.Infrastructure.Themes;
using BTL.Infrastructure.Configuration;
using DotNetOpenAuth.ApplicationBlock;
using Module = Autofac.Module;

#endregion

namespace BTL.Application.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ExConfigurationManager>().As<IExConfigurationManager>().SingleInstance();
            builder.RegisterType<ThemeProvider>().As<IThemeProvider>().SingleInstance();
            builder.RegisterType<FormsAuthenticationService>().As<IFormsAuthenticationService>().InstancePerDependency();

            // authentication instances
            builder.RegisterType<FacebookUserInformation>().As<IFacebookAuthRequestRole>().PropertiesAutowired();
            builder.RegisterType<FacebookClient>().AsSelf();
            builder.RegisterType<TwitterUserInformation>().AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterType<GoogleUserInformation>().AsImplementedInterfaces().PropertiesAutowired();

            // Facade instances
            builder.RegisterType<AppSecurityFacade>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<AppAuthenticationFacade>().AsImplementedInterfaces().InstancePerDependency();

            var mySettings = SectionConfiguration.GetInstance<MySettings>(MySettings.SECTION_NAME);
            builder.RegisterInstance(mySettings).As<MySettings>();
        }
    }
}
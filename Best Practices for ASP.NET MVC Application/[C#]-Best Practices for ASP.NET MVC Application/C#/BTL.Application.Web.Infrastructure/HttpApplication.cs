#region

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using BTL.DataAccess;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    public class ExHttpApplication : HttpApplication
    {
        protected IContainer Container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            RegisterObjectFactory();

            ControllerBuilder.Current.SetControllerFactory(GetControllerFactory());

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(GetViewEngine());

            BindModels();
        }

        protected virtual void RegisterAllAreas()
        {
        }

        protected virtual void RegisterRoutes(RouteCollection routeCollection)
        {
        }

        protected virtual void RegisterObjectFactory()
        {
            PluginBootstrapper.Initialize();

            new SchemaSynchronizer(() => HttpContext.Current.IsDebuggingEnabled).Execute();

            Container = new ConfigureContainer(
                            x => DependencyResolver.SetResolver(new AutofacDependencyResolver(x)))
                            .GetContainerInstance();

            AutoMapperConfiguration.Configure();
        }

        protected virtual IControllerFactory GetControllerFactory()
        {
            return new DefaultControllerFactory();
        }

        protected virtual IViewEngine GetViewEngine()
        {
            return new RazorViewEngine();
        }

        protected virtual void BindModels()
        {
        }
    }
}
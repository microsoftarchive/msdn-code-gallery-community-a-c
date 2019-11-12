#region

using System.Web.Mvc;
using System.Web.Routing;
using BTL.Application.Web.Infrastructure;
using BTL.Application.Web.Infrastructure.Controller;
using BTL.Application.Web.Infrastructure.View;

#endregion

namespace BTL.Application.Web
{
    public class MvcApplication : ExHttpApplication
    {
        protected override void RegisterAllAreas()
        {
            AreaRegistration.RegisterAllAreas();
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected override IControllerFactory GetControllerFactory()
        {
            return new ExControllerFactory(Container);
        }

        protected override IViewEngine GetViewEngine()
        {
            return new ExRazorViewEngine();
        }
    }
}
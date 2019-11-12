using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Groupdocs.Web.UI.Comparison;

namespace ComparisonDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }

        protected void Application_Start()
        {
            ComparisonWidgetSettings cws = new ComparisonWidgetSettings()
            {
                RootStoragePath = Server.MapPath("~/App_Data/"),
                //LicensePath = @"I:\<path>\license.lic",
                Locale = Groupdocs.Web.UI.SupportedLocales.enUS                
            };
            this.Application["cws"] = cws;
            GroupdocsComparison.Init(cws);

            AreaRegistration.RegisterAllAreas();

            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
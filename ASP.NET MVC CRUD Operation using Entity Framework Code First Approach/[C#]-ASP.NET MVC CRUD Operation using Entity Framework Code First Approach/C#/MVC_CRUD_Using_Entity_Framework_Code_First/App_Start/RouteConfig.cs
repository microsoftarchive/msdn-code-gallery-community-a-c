using MVC_CRUD_Using_Entity_Framework_Code_First.DAL;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_CRUD_Using_Entity_Framework_Code_First
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EmployeeDetails", action = "Index", id = UrlParameter.Optional }
            );

            using (var context = new EmployeeDetailsDbContext())
            {
                Database.SetInitializer<EmployeeDetailsDbContext>(new ModelInitializer());
            }
        }
    }
}

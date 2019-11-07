using System.Net.Http.Headers;
using System.Web.Http;

namespace CRUDWithWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ServerDataByType",
                routeTemplate: "api/{controller}/type/{type}"
            );

            config.Routes.MapHttpRoute(
                name: "ServerDataByIP",
                routeTemplate: "api/{controller}/ip/{ip}"
            );

            //return JSON response by default
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}

using ContactManager.Formatters;
using ContactManager.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Formatter;
using WebApiContrib.IoC.Ninject;

namespace ContactManager
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IContactRepository>().To<ContactManagerRepository>();
            Register(config, kernel);
        }

        public static void Register(HttpConfiguration config, IKernel kernel)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            var vcard = new VCardFormatter();
            vcard.MediaTypeMappings.Add(new UriPathExtensionMapping("vcf", "text/directory"));
            config.Formatters.Add(vcard);

            var png = new ContactPngFormatter();
            png.MediaTypeMappings.Add(new UriPathExtensionMapping("png", "image/png"));
            config.Formatters.Add(png);
            
            config.DependencyResolver = new NinjectResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "ControllerWithExt",
                routeTemplate: "api/{controller}.{ext}");
            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

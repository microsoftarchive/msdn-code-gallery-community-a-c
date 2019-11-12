using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using WebApiHelpPage;

namespace SampleWebApiSelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080";
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(baseAddress);
            config.Routes.MapHttpRoute("Default", "{controller}/{id}", new { id = RouteParameter.Optional });

            // Configure help page
            HelpPageConfig.Register(config);

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Service listening at: {0}", baseAddress);
            Console.WriteLine("Help page available at: {0}/help", baseAddress);
            Console.WriteLine("Press Enter to shutdown the service.");
            Console.ReadLine();
        }
    }

    // Change the controller name if you want a different URI.
    public class HelpController : HelpControllerBase { }
}
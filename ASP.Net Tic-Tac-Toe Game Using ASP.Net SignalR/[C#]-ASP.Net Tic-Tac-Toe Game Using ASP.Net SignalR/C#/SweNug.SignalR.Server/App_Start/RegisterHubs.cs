using System.Web;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(SweNug.SignalR.RegisterHubs), "Start")]

namespace SweNug.SignalR
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();            
        }
    }
}

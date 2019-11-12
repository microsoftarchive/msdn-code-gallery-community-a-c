using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication1.Hubs
{
    public class CustomerHub : Hub
    {
        [HubMethodName("broadcastData")]
        public static void BroadcastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.updatedData();
        }
    }
}
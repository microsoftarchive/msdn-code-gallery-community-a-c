using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using NServiceBus;
using Microsoft.Practices.Unity;
using CrossCutting.Repository;
using System.Reflection;
using Messages.Commands;

namespace LocationTracker
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IBus bus;

        private IStartableBus startableBus;
        

        public static IBus Bus
        {
            get { return bus; }
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            BusConfiguration busConfiguration = new BusConfiguration();
            var container = UnityConfig.GetConfiguredContainer();
                     
            container.RegisterType(typeof(IHandleMessages<>));
            container.RegisterType(typeof(ICommand));
            busConfiguration.UseContainer<UnityBuilder>();           
            busConfiguration.UseContainer<UnityBuilder>(c => c.UseExistingContainer(container));
            busConfiguration.UsePersistence<InMemoryPersistence>();            
            startableBus = NServiceBus.Bus.Create(busConfiguration);
            bus = startableBus.Start();

        }

        protected void Application_End()
        {
            startableBus.Dispose();
        }
    }
}
 
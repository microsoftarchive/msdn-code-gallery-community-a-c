using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("TestingConfiguration", typeof(EmployeeStartup))]
    public class EmployeeStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();          
        }
    }


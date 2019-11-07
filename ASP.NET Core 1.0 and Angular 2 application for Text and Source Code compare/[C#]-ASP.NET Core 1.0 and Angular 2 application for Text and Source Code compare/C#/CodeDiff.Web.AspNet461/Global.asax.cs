using System;
using System.Web.Http;
using AutoMerge.Web;

namespace MsdrRu.CodeDiff.Web.AspNet461
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
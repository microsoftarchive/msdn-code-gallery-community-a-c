using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GroupDocsViewerWebFormsSample
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Groupdocs.Web.UI.Viewer.SetRootStoragePath(Server.MapPath("~/App_Data/"));
            //Groupdocs.Web.UI.Viewer.SetLicensePath(@"<path_to_yours>/license.lic");
            Groupdocs.Web.UI.Viewer.SetLogFilePath(FileRepository.RootStorage+"log.txt");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
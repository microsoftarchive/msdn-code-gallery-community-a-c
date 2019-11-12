using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NReco.PivotData.Examples.PivotTableWebForms
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			// workaround for SQLite DLL load issue under IISExpress
			Environment.SetEnvironmentVariable("PreLoadSQLite_NoSearchForDirectory", "true");
			Environment.SetEnvironmentVariable("PreLoadSQLite_BaseDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"bin") );			
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.WebApp.EmpService;


namespace Test.WebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpClient proxy = new EmpClient();
            try
            {
                
                EmpInfo[] items = proxy.GetEmps();
                gvItems.DataSource = items;
                gvItems.DataBind();
                proxy.Close();
            }
            catch (Exception ex)
            {
                proxy.Abort();
                Response.Write(ex.ToString());
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace WebApplication1.Admin
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Super Administrator")] 
    public partial class admin : System.Web.UI.MasterPage
    {

               protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
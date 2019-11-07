using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Permissions;

namespace WebApplication1.Admin
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated=true, Role="Super Administrator" )] 
    public partial class profiles : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
           
           }


        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if (!Roles.RoleExists(tbRoleName.Text))
            {
                Roles.CreateRole(tbRoleName.Text);
                tbRoleName.Text = "";
                GridView1.DataBind();
            }
        }

        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}
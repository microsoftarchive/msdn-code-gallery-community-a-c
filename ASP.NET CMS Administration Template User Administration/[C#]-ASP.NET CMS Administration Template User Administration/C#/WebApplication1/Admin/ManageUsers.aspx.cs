using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Web.Security;

namespace WebApplication1.Admin
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Super Administrator")]
    public partial class ManageUsers : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Guid aID = getApplicationID();
            SqlDataSource1.SelectParameters["ApplicationId"].DefaultValue = aID.ToString();

            GridView1.DataBind();

        }

        // Get the applicationID from Applications table.
        private Guid getApplicationID()
        {
            string appName = "cmsCCSLABS";
            Guid aID = new Guid();

            try
            {
                // Connect to Database
                SqlConnection conn = new SqlConnection(SqlDataSource1.ConnectionString);
                SqlCommand command = new SqlCommand("SELECT (ApplicationId) FROM aspnet_Applications WHERE ApplicationName='" + appName + "';", conn);
                conn.Open();
                aID = (Guid)command.ExecuteScalar();
                conn.Close();
            }
            catch (Exception ex)
            {
                // Add the error message on the page here.

            }

            return aID;
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            panelMessages.Visible = false;
            lblMessages.Text = "";

            try
            {
                Membership.CreateUser(tbMembersName.Text, tbPassword.Text, "2Unique@Email.com"); // Email address must be unique - see web.config
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                panelMessages.Visible = true;

            }
            tbMembersName.Text = "";
            tbPassword.Text = "";
        }

        protected void textChanged(object sender, EventArgs e)
        {
            panelMessages.Visible = false;
            lblMessages.Text = "";
        }
    }
}
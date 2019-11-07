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
using System.Threading.Tasks;

namespace WebApplication1.Admin
{
    [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Super Administrator")]
    public partial class ManageUsers : System.Web.UI.Page
    {

        private CheckBox[] cbs; // used later for adding users to roles
        private int counter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid aID = getApplicationID();
            SqlDataSource1.SelectParameters["ApplicationId"].DefaultValue = aID.ToString();

            GridView1.DataBind();
            cbs = new CheckBox[Roles.GetAllRoles().Count()]; // size the array
            foreach (string r in Roles.GetAllRoles())
            {
                CheckBox cb = new CheckBox();
                
                cb.ID = r;
                cb.Text = r;
                if (cb.ID == "Guest") cb.Checked = true; // Everyone is a guest
                panelRoles.Controls.Add(cb); // Add the checkbox to the panel
               cbs[counter] = cb; // keep track of what checkboxes we have - saves work later.
                counter++;
            }

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

        // Add the user and assign the user to their roles !
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            AddUser();
            AddUserToRoles();

            tbMembersName.Text = "";
            tbPassword.Text = "";
            tbEmailAddress.Text = "";
            
        }

        // using parallel foreach just to show you how to do this.
        protected void AddUserToRoles()
        {
            Parallel.ForEach(cbs, cb =>
             {
                 if (cb.Checked)
                 {
                     Roles.AddUserToRole(tbMembersName.Text, cb.ID);
                     cb.Checked = false;
                 }
             }); // look carefully at how you close this lambda

           
        }

        protected void AddUser()
        {
            panelMessages.Visible = false;
            lblMessages.Text = "";

            try
            {
                // Email address must be unique - see web.config
                Membership.CreateUser(tbMembersName.Text, tbPassword.Text, tbEmailAddress.Text);
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                panelMessages.Visible = true;

            }

           
            GridView1.DataBind();
        }

        protected void textChanged(object sender, EventArgs e)
        {
            panelMessages.Visible = false;
            lblMessages.Text = "";
        }
    }
}
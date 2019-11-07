using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label mpLabel;

            
            mpLabel =
              (Label)Master.FindControl("lblLoggedOnUser");
            if (mpLabel != null)
            {
                mpLabel.Text = Page.User.Identity.Name;
            }

        }

        protected void AlertInfo(string msg)
        {
            messagesText.Attributes["class"] = "alert_info";
            lblMessage.Text = msg;
            panelMessage.Visible = true;
        }

        protected void AlertWarning(string msg)
        {
            messagesText.Attributes["class"] = "alert_warning";
            lblMessage.Text = msg;
            panelMessage.Visible = true;
        }

        protected void AlertError(string msg)
        {
            messagesText.Attributes["class"] = "alert_error";
            lblMessage.Text = msg;
            panelMessage.Visible = true;
        }

        protected void AlertSuccess(string msg)
        {
            messagesText.Attributes["class"] = "alert_success";
            lblMessage.Text = msg;
            panelMessage.Visible = true;
        }
    }
}
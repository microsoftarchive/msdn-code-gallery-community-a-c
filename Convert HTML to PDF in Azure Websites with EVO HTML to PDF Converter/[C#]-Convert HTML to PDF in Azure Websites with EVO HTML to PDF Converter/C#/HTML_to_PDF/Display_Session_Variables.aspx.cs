using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvoHtmlToPdfDemo.HTML_to_PDF
{
    public partial class Display_Session_Variables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                firstNameLabel.Text = Session["firstName"] != null ? (String)Session["firstName"] : String.Empty;
                lastNameLabel.Text = Session["lastName"] != null ? (String)Session["lastName"] : String.Empty;
                genderLabel.Text = Session["gender"] != null ? (String)Session["gender"] : String.Empty;

                bool iHaveCar = Session["haveCar"] != null ? (bool)Session["haveCar"] : false;
                haveCarLabel.Text = iHaveCar ? "Yes" : "No";
                carTypePanel.Visible = iHaveCar;
                carTypeLabel.Text = iHaveCar && Session["carType"] != null ? (String)Session["carType"] : String.Empty;

                commentsLabel.Text = Session["comments"] != null ? (String)Session["comments"] : String.Empty;
            }
        }
    }
}
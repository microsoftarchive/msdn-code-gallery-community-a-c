using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class Alumni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AlumniGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var alumnus = e.Row.DataItem as Alumnus;
                var donationsGridView = (GridView)e.Row.FindControl("DonationsGridView");
                donationsGridView.DataSource = alumnus.Donations.ToList();
                donationsGridView.DataBind();
            }
        }
    }
}
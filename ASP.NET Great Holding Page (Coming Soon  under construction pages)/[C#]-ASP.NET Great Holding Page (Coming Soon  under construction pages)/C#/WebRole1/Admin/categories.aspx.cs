using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // remember to do validation AND error checking /:P
        protected void lbAddCategory_Click(object sender, EventArgs e)
        {
            if (tbCategoryName.Text != "")
            {
                SqlDataSource1.InsertParameters[0].DefaultValue = tbCategoryName.Text;
                SqlDataSource1.Insert();
                tbCategoryName.Text = ""; // Clear the textbox for the next parameter
            }
        }
    }
}
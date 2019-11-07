using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchUnit_Basics_CSharp
{
    public partial class RecipeViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDataSource1.XPath = "Recipes/Recipe[@id='" + Request["id"] + "']";
        }
    }
}

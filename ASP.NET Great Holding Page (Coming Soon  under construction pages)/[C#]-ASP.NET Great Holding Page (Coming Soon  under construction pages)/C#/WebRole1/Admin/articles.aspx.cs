using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // Requires error checking and validation !!
        protected void lbSaveArticle_Click(object sender, EventArgs e)
        {
            // The Insert Parameters... click the SqlDataSource1 in design view - in properties click Insert Query button
            // and you will see the following

            // INSERT INTO [Content] ([Title], [CategoryID], [MenuName], [MenuNumber], [SubTitle], [MainBody], 
            // [Footer], [Published]) VALUES (@Title, @CategoryID, @MenuName, @MenuNumber, @SubTitle, @MainBody, @Footer, @Published)

            SqlDataSource1.InsertParameters[0].DefaultValue = tbTitle.Text;
            SqlDataSource1.InsertParameters[1].DefaultValue = lbCategory.SelectedIndex.ToString();
            SqlDataSource1.InsertParameters[2].DefaultValue = tbMenuName.Text;
            SqlDataSource1.InsertParameters[3].DefaultValue = tbMenuPosition.Text;
            SqlDataSource1.InsertParameters[4].DefaultValue = tbSubTitle.Text;
            SqlDataSource1.InsertParameters[5].DefaultValue = CKEditor1.Text;
            SqlDataSource1.InsertParameters[6].DefaultValue = tbFooter.Text;

            SqlDataSource1.InsertParameters[7].DefaultValue = cbPublished.Checked.ToString();
           
            SqlDataSource1.Insert();
            GridView1.DataBind();
        }
    }
}
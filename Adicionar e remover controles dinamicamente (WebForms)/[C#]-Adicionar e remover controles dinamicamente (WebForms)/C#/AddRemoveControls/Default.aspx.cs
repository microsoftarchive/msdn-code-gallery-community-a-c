using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddRemoveControls
{
    public partial class Default : System.Web.UI.Page
    {
        DataTable myTable = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            myTable.Columns.Add("DESCRIPTION");

            if (!this.IsPostBack)
            {
                for (int i = 0; i < 3; i++) // LOAD THREE TEXTBOX FOR EXAMPLE
                {
                    myTable.Rows.Add(myTable.NewRow());
                }

                Bind();
            }
        }

        protected void Bind()
        {
            Repeater1.DataSource = myTable;
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
                lblMessage.Text = "Click the button to add more descriptions. <img src='images/emoticon_smile.png'/>";
            else
                lblMessage.Text = "";
        }

        protected void PopulateDataTable()
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                TextBox txtDescription = (TextBox)item.FindControl("txtDescription");
                DataRow row = myTable.NewRow();
                row["DESCRIPTION"] = txtDescription.Text;
                myTable.Rows.Add(row);
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PopulateDataTable();
            myTable.Rows[e.Item.ItemIndex].Delete();
            Bind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopulateDataTable();
            myTable.Rows.Add(myTable.NewRow());

            Bind();
        }
    }
}
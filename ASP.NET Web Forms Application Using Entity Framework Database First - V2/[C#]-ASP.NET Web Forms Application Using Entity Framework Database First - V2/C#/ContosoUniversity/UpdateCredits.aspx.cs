using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class UpdateCredits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void ExecuteButton_Click(object sender, EventArgs e)
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                RowsAffectedLabel.Text = context.ExecuteStoreCommand("UPDATE Course SET Credits = Credits * {0}", CreditsMultiplierTextBox.Text).ToString();
            }
        }
    }
}
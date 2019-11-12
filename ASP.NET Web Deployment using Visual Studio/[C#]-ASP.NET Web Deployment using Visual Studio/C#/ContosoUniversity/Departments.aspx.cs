using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class Departments : System.Web.UI.Page
    {
        private DropDownList administratorsDropDownList;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            DepartmentsGridView.EnableDynamicData(typeof(Department));
        }

        protected void DepartmentsDropDownList_Init(object sender, EventArgs e)
        {
            administratorsDropDownList = sender as DropDownList;
        }

        protected void DepartmentsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            e.NewValues["PersonID"] = administratorsDropDownList.SelectedValue;
        }
    }
}
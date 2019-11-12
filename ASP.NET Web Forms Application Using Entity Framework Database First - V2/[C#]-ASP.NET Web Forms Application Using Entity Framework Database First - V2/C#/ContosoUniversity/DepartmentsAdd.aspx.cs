using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;
using ContosoUniversity.BLL;

namespace ContosoUniversity
{
    public partial class DepartmentsAdd : System.Web.UI.Page
    {
        private DropDownList administratorsDropDownList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            DepartmentsDetailsView.EnableDynamicData(typeof(Department));
        }

        protected void DepartmentsDropDownList_Init(object sender, EventArgs e)
        {
            administratorsDropDownList = sender as DropDownList;
        }

        protected void DepartmentsDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["Administrator"] = administratorsDropDownList.SelectedValue;
        }

        protected void DepartmentsObjectDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                if (e.Exception.InnerException is DuplicateAdministratorException)
                {
                    var duplicateAdministratorValidator = new CustomValidator();
                    duplicateAdministratorValidator.IsValid = false;
                    duplicateAdministratorValidator.ErrorMessage = "Insert failed: " + e.Exception.InnerException.Message;
                    Page.Validators.Add(duplicateAdministratorValidator);
                    e.ExceptionHandled = true;
                }
            }
        }
    }
}
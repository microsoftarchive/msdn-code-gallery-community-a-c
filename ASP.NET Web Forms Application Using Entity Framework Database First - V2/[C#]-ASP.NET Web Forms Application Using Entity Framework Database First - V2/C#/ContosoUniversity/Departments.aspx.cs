using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;
using ContosoUniversity.BLL;
using System.Data;

namespace ContosoUniversity
{
    public partial class Departments : System.Web.UI.Page
    {
        private DropDownList administratorsDropDownList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartmentsGridView.Sort("Name", SortDirection.Ascending);
            }
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
            e.NewValues["Administrator"] = administratorsDropDownList.SelectedValue;
        }

        protected void DepartmentsObjectDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                CheckForOptimisticConcurrencyException(e, "update");
                if (e.Exception.InnerException is DuplicateAdministratorException)
                {
                    var duplicateAdministratorValidator = new CustomValidator();
                    duplicateAdministratorValidator.IsValid = false;
                    duplicateAdministratorValidator.ErrorMessage = "Update failed: " + e.Exception.InnerException.Message;
                    Page.Validators.Add(duplicateAdministratorValidator);
                    e.ExceptionHandled = true;
                }
            }
        }

        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var department = e.Row.DataItem as Department;
                var coursesGridView = (GridView)e.Row.FindControl("CoursesGridView");
                coursesGridView.DataSource = department.Courses.ToList();
                coursesGridView.DataBind();
            }
        }

        protected void DepartmentsObjectDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                CheckForOptimisticConcurrencyException(e, "delete");
            }
        }

        private void CheckForOptimisticConcurrencyException(ObjectDataSourceStatusEventArgs e, string function)
        {
            if (e.Exception.InnerException is OptimisticConcurrencyException)
            {
                var concurrencyExceptionValidator = new CustomValidator();
                concurrencyExceptionValidator.IsValid = false;
                concurrencyExceptionValidator.ErrorMessage =
                    "The record you attempted to edit or delete was modified by another " +
                    "user after you got the original value. The edit or delete operation was canceled " +
                    "and the other user's values have been displayed so you can " +
                    "determine whether you still want to edit or delete this record.";
                Page.Validators.Add(concurrencyExceptionValidator);
                e.ExceptionHandled = true;
            }
        }
    }
}
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Departments
    Inherits System.Web.UI.Page
    Private administratorsDropDownList As DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DepartmentsGridView.Sort("Name", SortDirection.Ascending)
        End If
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        DepartmentsGridView.EnableDynamicData(GetType(Department))
    End Sub

    Protected Sub DepartmentsDropDownList_Init(ByVal sender As Object, ByVal e As EventArgs)
        administratorsDropDownList = TryCast(sender, DropDownList)
    End Sub

    Protected Sub DepartmentsGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs) Handles DepartmentsGridView.RowUpdating
        e.NewValues("Administrator") = administratorsDropDownList.SelectedValue
    End Sub

    Protected Sub DepartmentsObjectDataSource_Updated(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles DepartmentsObjectDataSource.Updated
        If e.Exception IsNot Nothing Then
            CheckForOptimisticConcurrencyException(e, "update")
            If TypeOf e.Exception.InnerException Is DuplicateAdministratorException Then
                Dim duplicateAdministratorValidator = New CustomValidator()
                duplicateAdministratorValidator.IsValid = False
                duplicateAdministratorValidator.ErrorMessage = "Update failed: " & e.Exception.InnerException.Message
                Page.Validators.Add(duplicateAdministratorValidator)
                e.ExceptionHandled = True
            End If
        End If
    End Sub

    Protected Sub DepartmentsGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles DepartmentsGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim department = TryCast(e.Row.DataItem, Department)
            Dim coursesGridView = CType(e.Row.FindControl("CoursesGridView"), GridView)
            coursesGridView.DataSource = department.Courses.ToList()
            coursesGridView.DataBind()
        End If
    End Sub

    Protected Sub DepartmentsObjectDataSource_Deleted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles DepartmentsObjectDataSource.Deleted
        If e.Exception IsNot Nothing Then
            CheckForOptimisticConcurrencyException(e, "delete")
        End If
    End Sub

    Private Sub CheckForOptimisticConcurrencyException(ByVal e As ObjectDataSourceStatusEventArgs, ByVal [function] As String)
        If TypeOf e.Exception.InnerException Is OptimisticConcurrencyException Then
            Dim concurrencyExceptionValidator = New CustomValidator()
            concurrencyExceptionValidator.IsValid = False
            concurrencyExceptionValidator.ErrorMessage =
                "The record you attempted to edit or delete was modified by another " &
                "user after you got the original value. The edit or delete operation was canceled " &
                "and the other user's values have been displayed so you can " &
                "determine whether you still want to edit or delete this record."
            Page.Validators.Add(concurrencyExceptionValidator)
            e.ExceptionHandled = True
        End If
    End Sub
End Class

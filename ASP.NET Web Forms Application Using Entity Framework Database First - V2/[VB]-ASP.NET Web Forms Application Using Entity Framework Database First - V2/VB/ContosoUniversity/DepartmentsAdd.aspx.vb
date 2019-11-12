Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class DepartmentsAdd
    Inherits System.Web.UI.Page
    Private administratorsDropDownList As DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        DepartmentsDetailsView.EnableDynamicData(GetType(Department))
    End Sub

    Protected Sub DepartmentsDropDownList_Init(ByVal sender As Object, ByVal e As EventArgs)
        administratorsDropDownList = TryCast(sender, DropDownList)
    End Sub

    Protected Sub DepartmentsDetailsView_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs) Handles DepartmentsDetailsView.ItemInserting
        e.Values("Administrator") = administratorsDropDownList.SelectedValue
    End Sub

    Protected Sub DepartmentsObjectDataSource_Inserted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles DepartmentsObjectDataSource.Inserted
        If e.Exception IsNot Nothing Then
            If TypeOf e.Exception.InnerException Is DuplicateAdministratorException Then
                Dim duplicateAdministratorValidator = New CustomValidator()
                duplicateAdministratorValidator.IsValid = False
                duplicateAdministratorValidator.ErrorMessage = "Insert failed: " & e.Exception.InnerException.Message
                Page.Validators.Add(duplicateAdministratorValidator)
                e.ExceptionHandled = True
            End If
        End If
    End Sub
End Class

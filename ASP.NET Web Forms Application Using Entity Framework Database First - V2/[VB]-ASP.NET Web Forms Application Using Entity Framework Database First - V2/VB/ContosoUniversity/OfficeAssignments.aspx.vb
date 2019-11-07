Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class OfficeAssignments
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        OfficeAssignmentsGridView.EnableDynamicData(GetType(OfficeAssignment))
    End Sub

    Protected Sub OfficeAssignmentsObjectDataSource_Updated(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles OfficeAssignmentsObjectDataSource.Updated
        If e.Exception IsNot Nothing Then
            Dim concurrencyExceptionValidator = New CustomValidator()
            concurrencyExceptionValidator.IsValid = False
            concurrencyExceptionValidator.ErrorMessage =
                "The record you attempted to " &
                "update has been modified by another user since you last visited this page. " &
                "Your update was canceled to allow you to review the other user's " &
                "changes and determine if you still want to update this record."
            Page.Validators.Add(concurrencyExceptionValidator)
            e.ExceptionHandled = True
        End If
    End Sub
End Class

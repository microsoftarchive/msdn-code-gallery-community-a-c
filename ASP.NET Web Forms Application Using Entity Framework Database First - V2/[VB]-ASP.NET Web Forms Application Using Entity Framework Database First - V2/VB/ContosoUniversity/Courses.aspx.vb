Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Courses
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub CoursesEntityDataSource_Updated(ByVal sender As Object, ByVal e As EntityDataSourceChangedEventArgs) Handles CoursesEntityDataSource.Updated
        CheckForOptimisticConcurrencyException(e, "update")
    End Sub

    Protected Sub CoursesEntityDataSource_Deleted(ByVal sender As Object, ByVal e As EntityDataSourceChangedEventArgs) Handles CoursesEntityDataSource.Deleted
        CheckForOptimisticConcurrencyException(e, "delete")
    End Sub

    Private Sub CheckForOptimisticConcurrencyException(ByVal e As EntityDataSourceChangedEventArgs, ByVal [function] As String)
        If e.Exception IsNot Nothing AndAlso TypeOf e.Exception Is OptimisticConcurrencyException Then
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

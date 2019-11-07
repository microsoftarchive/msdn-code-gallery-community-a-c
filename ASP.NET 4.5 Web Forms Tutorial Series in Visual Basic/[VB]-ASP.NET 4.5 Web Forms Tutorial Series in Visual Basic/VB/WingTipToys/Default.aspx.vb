Public Class _Default
    Inherits Page

    Private Sub Page_Error(sender As Object, e As EventArgs) Handles Me.Error
        ' Get last error from the server.
        Dim exc As Exception = Server.GetLastError()

        ' Handle specific exception.
        If TypeOf exc Is InvalidOperationException Then
            ' Pass the error on to the error page.
            Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx", True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

End Class
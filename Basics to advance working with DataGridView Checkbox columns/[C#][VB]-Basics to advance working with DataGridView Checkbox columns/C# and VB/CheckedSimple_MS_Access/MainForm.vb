Public Class frmMainForm
    Private Sub cmdCustomers_Click(sender As Object, e As EventArgs) Handles cmdCustomers.Click
        Dim f As New frmCustomers
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub cmdAdmin_Click(sender As Object, e As EventArgs) Handles cmdAdmin.Click
        Dim f As New frmAdministrator
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
End Class
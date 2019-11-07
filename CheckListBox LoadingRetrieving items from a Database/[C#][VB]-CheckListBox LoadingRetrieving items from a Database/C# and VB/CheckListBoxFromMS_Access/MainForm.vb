Public Class MainForm
    Private Sub cmdFromDatabaseExample_Click(sender As Object, e As EventArgs) Handles cmdFromDatabaseExample.Click
        Dim f As New frmCheckListBoxFormDemo
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub

    Private Sub cmdStaticDataTableExample_Click(sender As Object, e As EventArgs) Handles cmdStaticDataTableExample.Click
        Dim f As New frmDataTable
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
End Class
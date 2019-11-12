Public Class GetLastColumnRowAndInsertForm
    Private Sub GetLastColumnRowAndInsertForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDateColumn.Items.AddRange(Enumerable.Range(0, 26).Select(Function(i) (Chr(Asc("A") + i)).ToString()).ToArray())
        cboDateColumn.SelectedIndex = 3
        cboTimeColumn.Items.AddRange(Enumerable.Range(0, 26).Select(Function(i) (Chr(Asc("A") + i)).ToString()).ToArray())
        cboTimeColumn.SelectedIndex = 4
    End Sub
    Private ops As New Operations
    Private Sub executeButton_Click(sender As Object, e As EventArgs) Handles executeButton.Click
        Dim excelFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample3.xlsx")
        If ops.WriteDateAndTime(excelFileName, cboDateColumn.Text, cboTimeColumn.Text, Now) Then
            If chkOpenExcel.Checked Then
                Process.Start(excelFileName)
            End If
        Else
            MessageBox.Show($"Failed:{ops.Exception.Message}")
        End If
    End Sub
End Class
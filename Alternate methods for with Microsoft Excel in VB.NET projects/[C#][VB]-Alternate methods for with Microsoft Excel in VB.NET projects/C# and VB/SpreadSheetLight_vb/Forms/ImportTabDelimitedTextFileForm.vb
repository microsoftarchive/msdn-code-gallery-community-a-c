Public Class ImportTabDelimitedTextFileForm
    Private ops As New Operations
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim excelFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImportedFromTextFile.xlsx")
        Dim textFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImportMe.txt")
        Dim sheetName As String = "ImportedFromTextFile"

        If ops.ImportTabDelimitedTextFile(textFileName, excelFileName, sheetName) Then
            Process.Start(excelFileName)
            Close()
        Else
            MessageBox.Show($"Import failed.{Environment.NewLine}{ops.Exception.Message}")
        End If
    End Sub
End Class
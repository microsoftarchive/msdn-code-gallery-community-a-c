Imports SpreadsheetLight
Public Class SetCellValueDateTimeForm
    Private fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample1.xlsx")
    Private Sub SetValueButton_Click(sender As Object, e As EventArgs) Handles SetValueButton.Click
        ' ensure both text boxes have values
        If Controls.OfType(Of TextBox).Any(Function(tb) String.IsNullOrWhiteSpace(tb.Text)) Then
            MessageBox.Show("Requires a valid cell address e.g. A1 and a value for the cell")
        Else
            Using sl As New SLDocument(fileName)
                ' ensure we have a valid cell address
                If SLConvert.ToColumnIndex(cellAddressTextBox.Text) <> -1 Then
                    ' select the worksheet to work with
                    sl.SelectWorksheet(cboSheetNames.Text)

                    ' there are over 30 overloads for various types and options
                    sl.SetCellValue(cellAddressTextBox.Text, DateTimePicker1.Value)
                    '
                    ' Set the format of the date time
                    '
                    Dim style = sl.CreateStyle
                    style.FormatCode = "mm-dd-yyyy"
                    sl.SetCellStyle(cellAddressTextBox.Text, style)

                    ' save the workbook
                    sl.Save()
                Else
                    MessageBox.Show("Invalid cell address")
                End If
            End Using
        End If
    End Sub
    Private Sub openExcelFile_Click(sender As Object, e As EventArgs) Handles openExcelFile.Click
        Process.Start(fileName)
    End Sub
    Private Sub SetCellValueDateTimeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Using sl As New SLDocument(fileName)
                cboSheetNames.DataSource = sl.GetSheetNames(False)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
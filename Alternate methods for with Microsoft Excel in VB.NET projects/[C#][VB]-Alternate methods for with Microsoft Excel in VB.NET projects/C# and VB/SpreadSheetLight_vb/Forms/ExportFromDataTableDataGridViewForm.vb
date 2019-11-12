Imports UtilityLibrary

Public Class ExportFromDataTableDataGridViewForm
    Private ops As New Operations
    Private Sub ExportFromDataTableDataGridViewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = ops.ReadCustomersFromXml()
        Dim helper = New StringHelpers
        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = helper.AddSpacesToSentence(col.HeaderText, True)
        Next
        DataGridView1.ExpandColumns
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        DataGridView1.Columns(0).Width = 130
    End Sub
    Private Sub exportToExcelButton_Click(sender As Object, e As EventArgs) Handles exportToExcelButton.Click
        If ops.ExportDataTable(CType(DataGridView1.DataSource, DataTable)) Then
            MessageBox.Show("Exported")
        Else
            MessageBox.Show($"Failed{Environment.NewLine}{ops.Exception.Message}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
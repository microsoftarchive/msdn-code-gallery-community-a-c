Public Class ImportFromExcelToDataTableForm
    Private bsSheet As New BindingSource
    Private FileName As String = IO.Path.Combine(Application.StartupPath, "Sample2.xlsx")
    Private ops As New Operations
    ''' <summary>
    ''' DataGridView1 is loaded via OleDb
    ''' DataGridView2 is loaded via SpreadSheetLight
    ''' 
    ''' Both have merits which is the reason for showing them.
    ''' If all you need is data then I would use OleDb.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ImportFromExcelToDataTableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = BuilderCode.ConnectionString(FileName)}
            Using cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(<Statement>SELECT * FROM [Customers$]</Statement>.Value, cn)
                cn.Open()
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using

        DataGridView1.DataSource = dt
        bsSheet.DataSource = ops.ImportFromExcel()
        DataGridView2.DataSource = bsSheet
        columnNamesInCustomersWorkSheet.Items.AddRange(ops.UsedCellsInCustomerWorkSheet)
        columnNamesInCustomersWorkSheet.SelectedIndex = 0

        If ops.GetInformation Then
            If ops.UsedRowsColumns.ContainsKey("Customers") Then
                lastUsedCellLabel.Text = ops.UsedRowsColumns("Customers")
            End If
        End If

        ColumnHeaderComboBox.DataSource = ops.ColumnHeaders()

    End Sub
End Class


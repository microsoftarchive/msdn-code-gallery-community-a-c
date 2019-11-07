
Imports FormDialogs

Public Class WorkSheetAddDeleteRenameForm
    Private ops As New Operations
    Private Sub newWorkSheetButton_Click(sender As Object, e As EventArgs) Handles newWorkSheetButton.Click
        If Not String.IsNullOrWhiteSpace(txtNewWorkSheetName.Text) Then
            Dim sheetname = txtNewWorkSheetName.Text
            If ops.AddNewSheet(sheetname) Then
                ListBox1.DataSource = Nothing
                ListBox1.DataSource = ops.SheetNames
                Dim index As Integer = ListBox1.Items.IndexOf(sheetname)
                If index > -1 Then
                    ListBox1.SelectedIndex = index
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Check to see if the file to work with is currently open, if in
    ''' use (perhaps opened in Excel). If can open then load sheet names
    ''' into ListBox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WorkSheetAddDeleteRenameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not ops.CanOpen(ops.AddDeleteRenameFileName) Then
            MessageBox.Show($"Can not open {ops.AddDeleteRenameFileName}")
            Application.Exit()
        Else
            ListBox1.DataSource = ops.SheetNames
            ListBox1.SelectedIndex = 0
        End If
    End Sub
    Private Sub removeWorkSheetButton_Click(sender As Object, e As EventArgs) Handles removeWorkSheetButton.Click
        If ListBox1.Items.Count > 1 Then
            Dim sheetname = ListBox1.Text
            If KarenDialogs.Question($"Remove '{sheetname}'") Then
                ops.RemoveWorkSheet(sheetname)
                ListBox1.DataSource = Nothing
                Dim sheets = ops.SheetNames
                ListBox1.DataSource = sheets
                ListBox1.SelectedIndex = 0
            End If
        Else
            MessageBox.Show($"Can not remove '{ListBox1.Text}' because an Excel Workbook requires at least one WorkSheet")
        End If
    End Sub
    Private Sub renameWorkSheetButton_Click(sender As Object, e As EventArgs) Handles renameWorkSheetButton.Click
        If ListBox1.Items.Count > 1 AndAlso Not String.IsNullOrWhiteSpace(txtNewSheetName.Text) Then
            Dim sheetname = ListBox1.Text
            If KarenDialogs.Question($"Remove '{sheetname}'") Then
                ops.RenameWorkSheet(sheetname, txtNewSheetName.Text)
                ListBox1.DataSource = Nothing
                ListBox1.DataSource = ops.SheetNames
                Dim index As Integer = ListBox1.Items.IndexOf(sheetname)
                If index > -1 Then
                    ListBox1.SelectedIndex = index
                End If
            End If
        Else
            MessageBox.Show("Requires a existing sheetname and a new sheetname")
        End If
    End Sub
    ''' <summary>
    ''' Insert data into first row pushing existing data down one row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' See method in Operations.vb
    ''' </remarks>
    Private Sub insertNewRowButton_Click(sender As Object, e As EventArgs) Handles insertNewRowButton.Click
        If GroupBox1.Controls.OfType(Of TextBox).Any(Function(tb) String.IsNullOrWhiteSpace(tb.Text)) Then
            MessageBox.Show("Enter data for each text box")
        Else
            Dim rowData = GroupBox1.Controls.OfType(Of TextBox).Select(Function(tb) tb.Text).ToList
            If ops.InsertNewRow(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InsertNewRow.xlsx"), "Sheet1", rowData) Then
                MessageBox.Show("Inserted new data in first row")
            Else
                MessageBox.Show("Failed to inserted new data in first row")
            End If
        End If
    End Sub
End Class
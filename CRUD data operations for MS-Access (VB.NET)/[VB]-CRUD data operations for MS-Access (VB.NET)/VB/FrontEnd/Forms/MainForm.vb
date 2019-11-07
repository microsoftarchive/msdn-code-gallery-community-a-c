Public Class frmMainForm

    WithEvents bsCustomers As New BindingSource
    Private mTitleList As List(Of String)
    ''' <summary>
    ''' Load data from Customers table.
    ''' If an exception is thrown it's available in
    ''' ops.HasException and checked via ops.IsSuccessFul
    ''' 
    ''' We don't show a message on failure until the form
    ''' is shown in the Shown event (below this event) as doing
    ''' so prior to the form being shown does not look good.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bsCustomers.DataSource = ops.LoadCustomers()
        If ops.IsSuccessFul Then
            mTitleList = ops.LoadContactTitles()
            BindingNavigator1.BindingSource = bsCustomers

            DataGridView1.AllowUserToAddRows = False
            DataGridView1.DataSource = bsCustomers


            DataGridView1.Columns("CompanyName").HeaderText = "Company"
            DataGridView1.Columns("ContactName").HeaderText = "Contact"

            DataGridView1.ExpandColumns()

            bsCustomers.Sort = "CompanyName"
        End If
    End Sub
    ''' <summary>
    ''' If there was an exception thrown in the data class on loading
    ''' data in form load we respond by showing the exception message.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not ops.IsSuccessFul Then
            MessageBox.Show($"Failed to load data: {ops.LastExceptionMessage}")
        End If
    End Sub
    ''' <summary>
    ''' Add new row, do only two fields, add more as desired
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddNewRow_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripButton2.Click
        Dim f As New frmEditor

        Try
            f.cboTitle.DataSource = mTitleList
            If f.ShowDialog = DialogResult.OK Then
                Dim Identifier As Int32 = 0
                ' if the row was added, insert it to the current DataTable
                If ops.AddNewRow(f.txtCompanyName.Text, f.txtContactName.Text, f.cboTitle.Text, Identifier) Then
                    bsCustomers.DataTable.Rows.Add(New Object() {Identifier, f.txtCompanyName.Text, f.txtContactName.Text, f.cboTitle.Text})
                    bsCustomers.Locate("Identifier", Identifier.ToString)
                Else
                    If Not ops.IsSuccessFul Then
                        MessageBox.Show($"Failed to add new record: {ops.LastExceptionMessage}")
                    End If
                End If
            End If
        Finally
            f.Dispose()
        End Try
    End Sub
End Class

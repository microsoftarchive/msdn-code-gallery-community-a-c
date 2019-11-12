Imports BackEnd

Partial Class frmMainForm
    Private ops As New DatabaseOperations
    ''' <summary>
    ''' This is debatable to invoke a edit dialog on double click as this
    ''' can conflict with double clicking the DataGridView column header to
    ''' expand a column width.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex <> -1 Then
            EditCurrentCustomer()
        End If
    End Sub
    ''' <summary>
    ''' Invokes code to show a edit dialog when the user presses ENTER on
    ''' the DataGridView. Many developers never consider this and should
    ''' as it makes editing easy for a user who likes using the keyboard
    ''' rather then the mouse e.g. like in high speed data entry and if that
    ''' was the case we would also we would follow suite with TextBox and ComboBox
    ''' controls on the editor form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyData = Keys.Enter Then
            EditCurrentCustomer()
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' Invoke the edit dialog when the user clicks the edit button in the
    ''' BindingNavigator.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdToolStripEditCurrentCustomer_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
        Handles cmdToolStripEditCurrentCustomer.Click

        If CType(sender, ToolStripButton).Name = "cmdToolStripEditCurrentCustomer" Then
            EditCurrentCustomer()
        End If

    End Sub
    ''' <summary>
    ''' This method shows a child form with data from the current row
    ''' of the DataGridView which uses a BindingSource as it's DataSource.
    ''' </summary>
    Private Sub EditCurrentCustomer()

        Dim f As New frmEditor

        Try
            ' Generally we don't bind data like this but instead pass data via
            ' a custom new constructor, place the data into a class e.g. a Customer
            ' class then populate controls from this. The class would be public
            ' so when the form is closed we would get the values. I wanted to show
            ' data binding as another option.
            '
            ' Two fields are bound while the third (the combo box) is manually set.
            '
            f.txtCompanyName.DataBindings.Add("Text", bsCustomers, "CompanyName")
            f.txtContactName.DataBindings.Add("Text", bsCustomers, "ContactName")
            f.cboTitle.DataSource = mTitleList

            ' Display the current Contact title by locating
            ' the title in a list of titles. We could optimize
            ' this by having a ContactTitle table yet I'm simply using
            ' a pre-existing table from Microsoft.
            f.cboTitle.SelectedIndex = mTitleList.IndexOf(bsCustomers.CurrentRow.Field(Of String)("ContactTitle"))

            f.ActiveControl = f.cmdCancel

            If f.ShowDialog = DialogResult.OK Then

                bsCustomers.CurrentRow.SetField(Of String)("ContactTitle", f.cboTitle.Text)

                If ops.UpdateRow(bsCustomers.CurrentRow) Then
                    bsCustomers.DataTable.AcceptChanges()
                Else
                    If Not ops.IsSuccessFul Then
                        MessageBox.Show($"Edit failed: {ops.LastExceptionMessage}")
                    End If
                End If
            Else
                bsCustomers.CancelEdit()
            End If
        Finally
            f.Dispose()
        End Try

    End Sub
    Private Sub cmdRemoveCurrentRow_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
        Handles ToolStripButton1.Click

        If My.Dialogs.Question("Remove current customer?") Then
            If ops.RemoveCurrentCustomer(bsCustomers.CurrentRow.Field(Of Int32)("Identifier")) Then
                bsCustomers.RemoveCurrent()
                bsCustomers.DataTable.AcceptChanges()
            Else
                If Not ops.IsSuccessFul Then
                    MessageBox.Show($"Removal failed: {ops.LastExceptionMessage}")
                End If
            End If
        End If
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class


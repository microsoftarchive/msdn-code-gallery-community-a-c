Imports System.Data.Objects

Public Class FormSalesOrders
    'Define a long running object context used by the form.
    'This context must be persisted because controls are bound to
    'data in this ObjectContext instance.
    Private objCtx As New AdventureWorksEntities

    'Define the SalesOrderHeader object for the selected order.
    Private currentOrder As SalesOrderHeader

    Private Sub GetOrderBindResults(ByVal orderId As Integer)
        'Get the SalesOrderHeader and related SalesOrderDetails object for the order
        'with the specified SalesOrderID value, overwriting local changes with
        'values from the database.
        Dim orderQuery = objCtx.SalesOrderHeader.Include("SalesOrderDetail") _
            .Where("it.SalesOrderID = @p", New ObjectParameter("p", orderId))

        orderQuery.MergeOption = MergeOption.OverwriteChanges
        'Bind the SalesOrderHeader binding source to execution of the first returned object.
        bindingSourceOrders.DataSource = orderQuery.First

        'Set the current order to the bound object.
        currentOrder = DirectCast(bindingSourceOrders.Current, SalesOrderHeader)
        Me.Refresh()
    End Sub

    Private Sub buttonGetOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonGetOrder.Click
        Dim orderNumber As Integer
        buttonDeleteDetail.Enabled = False

        Try
            'Get the order number
            orderNumber = CInt(txtOrderNumber.Text)

            'Call the method that gets the order and items.
            GetORderBindResults(orderNumber)

            buttonAddSalesOrder.Enabled = True
        Catch ex As FormatException
            MsgBox(String.Format("Ensure that the supplied SalesOrderID " & _
                                          "value {0} is a valid order number.", txtOrderNumber.Text), _
                                          "Invalid Order Number")
            resetform()
        Catch ex As InvalidOperationException
            MsgBox(String.Format("No orders were found with the SalesOrderID value {0}", _
                                          txtOrderNumber.Text), "Order Does Not Exist")
            resetform()
        Catch ex As Exception
            MsgBox(ex.Message, "An error has occured")
            resetform()
        End Try
    End Sub


    Private Sub buttonAddSalesOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonAddSalesOrder.Click
        Dim formAddSODetail As New FormAddSalesOrderDetail(objCtx, currentOrder)
        Dim dlgResult = formAddSODetail.ShowDialog(Me)
        If dlgResult.Equals(DialogResult.Cancel) Then
            'Call the method that gets the order and items.
            MsgBox("The item was not added to the order.", _
                            "Item Addition Canceled")
        End If
    End Sub

    Private Sub SaveChanges()
        Try
            'Save changes to the database.
            objCtx.SaveChanges()
            MsgBox("All pending changes saved to the database.", _
                            "Changes Saved")

            'Re-execute the query for the current order and 
            'rebind the controls to the latest results.
            GetORderBindResults(currentOrder.SalesOrderID)
        Catch ex As InvalidOperationException
            MsgBox(String.Format("An error has occured when trying to save changes to the sales order {0}{1}" & _
                                          "The changes have been rolled-back. {1}Requery for sales order '{0}' and retry the operation.", _
                                          currentOrder.SalesOrderID, ControlChars.CrLf), _
                                          "Changes Not Saved")
        Catch ex As OptimisticConcurrencyException
            MsgBox(String.Format("An error has occured when trying to save changes to the sales order {0}{1}" & _
                                          "The changes have been rolled-back.{1}Requery for sales order '{0}' and retry the operation.", _
                                          currentOrder.SalesOrderID, ControlChars.CrLf, _
                                          "Concurrency Violation"))

        End Try
    End Sub


    Private Sub buttonDeleteDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonDeleteDetail.Click
        Try
            'Get the selected detail from the grid
            Dim selectedDetail = DirectCast(bindingSourceOrderDetails.Current, SalesOrderDetail)

            'Call the method to delete the specific order detail.
            objCtx.DeleteObject(selectedDetail)

            'Update the order total
            currentOrder.UpdateOrderTotal()
        Catch ex As Exception
            MsgBox("The following error has occured: " & ControlChars.CrLf & _
                            ControlChars.Tab & ex.Message, "Error")
        End Try
    End Sub

    Private Sub buttonSaveChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSaveChanges.Click
        Try
            SaveChanges()
        Catch ex As Exception
            MsgBox("The following error has occured: " & ControlChars.CrLf & _
                            ControlChars.Tab & ex.Message, "Error")
        End Try
    End Sub

    Private Sub buttonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonClose.Click
        'Check the state manager to ensure that we don't have any unsaved changes.
        If objCtx.ObjectStateManager.GetObjectStateEntries(EntityState.Added Or EntityState.Deleted Or EntityState.Modified).Count > 0 Then
            Select Case MsgBox("There are unsaved changes. Do you want to save changes before you exit?", _
                                        "Unsaved Changes", _
                                        MessageBoxButtons.YesNoCancel)
                Case Windows.Forms.DialogResult.Yes
                    SaveChanges()
                Case Windows.Forms.DialogResult.No
                    Close()
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Close()
    End Sub

    Private Sub FormSalesOrders_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dispose the long running object context
        objCtx.Dispose()
    End Sub

    Private Sub ResetForm()
        buttonAddSalesOrder.Enabled = False
        buttonGetOrder.Enabled = False
        txtOrderNumber.Focus()
        txtOrderNumber.SelectAll()
    End Sub


    Private Sub txtOrderNumber_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtOrderNumber.PreviewKeyDown
        If e.KeyCode.Equals(Keys.Return) Then
            buttonGetOrder_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtOrderNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderNumber.TextChanged
        buttonGetOrder.Enabled = True
    End Sub

    Private Sub dataGridViewOrderDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dataGridViewOrderDetails.DataError
        If e.Exception IsNot Nothing Then
            MsgBox(e.Exception.Message, "Validation Error")
            e.Cancel = True
        End If
    End Sub


    Private Sub dataGridViewOrderDetails_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridViewOrderDetails.RowHeaderMouseClick
        buttonDeleteDetail.Enabled = True
    End Sub
End Class

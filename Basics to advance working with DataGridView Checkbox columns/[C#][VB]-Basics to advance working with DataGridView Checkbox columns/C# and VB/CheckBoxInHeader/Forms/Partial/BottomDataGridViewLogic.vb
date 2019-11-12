Partial Class frmMainForm
   ''' <summary>
   ''' This event takes each row in the bottom DataGridView and saves the ID column
   ''' to an XML file unless there are of course no rows in the bottom DataGridView
   ''' which causes the XML file to be deleted. On form load all items in the XML
   ''' file are restored by checking them.
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks>
   ''' If there are no items in the bottom DataGridView then the XML file is removed
   ''' as nothing was processed.
   ''' </remarks>
   Private Sub cmdProcessCheckedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessCheckedRows.Click
      PopulateBottomDataGridView()
   End Sub
   Private Sub PopulateBottomDataGridView()
      Dim Count As Integer = DataGridView1.CheckBoxCount(CheckBoxColName, True)

      Dim CheckedRowsInTopDataGridView = _
      ( _
          From Rows In DataGridView1.Rows.Cast(Of DataGridViewRow)() _
          Where CBool(Rows.Cells(CheckBoxColName).Value) _
          Select Company = Rows.Cells("CompanyName").Value, _
                 ID = Rows.Cells("Identifier").Value _
      ).ToList

      If Count > 0 Then
         DataGridView2.DataSource = CheckedRowsInTopDataGridView
         DataGridView2.AutoResizeColumns()
         ProcessedGroupBox.Text = String.Format("There are {0} companies for processing", Count.ToString)
      Else
         DataGridView2.DataSource = Nothing
         ProcessedGroupBox.Text = ""
      End If

      cmdClearBottomDataGridView.Enabled = True

   End Sub
   Private Sub cmdClearBottomDataGridView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBottomDataGridView.Click
      DataGridView2.DataSource = Nothing
      cmdClearBottomDataGridView.Enabled = False
   End Sub
End Class

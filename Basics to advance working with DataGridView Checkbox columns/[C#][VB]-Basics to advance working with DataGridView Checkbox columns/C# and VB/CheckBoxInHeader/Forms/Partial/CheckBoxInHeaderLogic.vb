Partial Class frmMainForm
   Private Sub AddHeaderCheckBox()
      HeaderCheckBox = New CheckBox()
      HeaderCheckBox.Size = New Size(15, 15)
      DataGridView1.Controls.Add(HeaderCheckBox)
   End Sub
   Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)

      'Get the column header cell bounds
      Dim Rect As Rectangle = DataGridView1.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)

      Dim Pt As New Point()

      Pt.X = Rect.Location.X + (Rect.Width - HeaderCheckBox.Width) \ 2 + 1
      Pt.Y = Rect.Location.Y + (Rect.Height - HeaderCheckBox.Height) \ 2 + 1

      'Change the location of the CheckBox to make it stay on the header
      HeaderCheckBox.Location = Pt
   End Sub
   Private Sub HeaderCheckBoxClick(ByVal HCheckBox As CheckBox)
      IsHeaderCheckBoxClicked = True

      For Each Row As DataGridViewRow In DataGridView1.Rows
         DirectCast(Row.Cells(CheckBoxColName), DataGridViewCheckBoxCell).Value = _
             HCheckBox.Checked
      Next

      DataGridView1.RefreshEdit()

      TotalCheckedCheckBoxes = If(HCheckBox.Checked, TotalCheckBoxes, 0)

      IsHeaderCheckBoxClicked = False
   End Sub
   Private Sub dgvSelectAll_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
      If (Not IsHeaderCheckBoxClicked) Then
         RowCheckBoxClick(DirectCast(DataGridView1(e.ColumnIndex, e.RowIndex), DataGridViewCheckBoxCell))
      End If
   End Sub
   Private Sub dgvSelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs)
      If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
         DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
      End If
   End Sub
   Private Sub HeaderCheckBox_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
      HeaderCheckBoxClick(DirectCast(sender, CheckBox))
   End Sub
   Private Sub HeaderCheckBox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
      If e.KeyCode = Keys.Space Then
         HeaderCheckBoxClick(DirectCast(sender, CheckBox))
      End If
   End Sub
   Private Sub dgvSelectAll_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
      If e.RowIndex = -1 AndAlso e.ColumnIndex = 0 Then
         ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
      End If
   End Sub
   Private Sub RowCheckBoxClick(ByVal RCheckBox As DataGridViewCheckBoxCell)
      If RCheckBox IsNot Nothing Then
         'Modifiy Counter;
         If CBool(RCheckBox.Value) AndAlso TotalCheckedCheckBoxes < TotalCheckBoxes Then
            TotalCheckedCheckBoxes += 1
         ElseIf TotalCheckedCheckBoxes > 0 Then
            TotalCheckedCheckBoxes -= 1
         End If

         'Change state of the header CheckBox.
         If TotalCheckedCheckBoxes < TotalCheckBoxes Then
            HeaderCheckBox.Checked = False
         ElseIf TotalCheckedCheckBoxes = TotalCheckBoxes Then
            HeaderCheckBox.Checked = True
         End If
      End If
   End Sub
End Class

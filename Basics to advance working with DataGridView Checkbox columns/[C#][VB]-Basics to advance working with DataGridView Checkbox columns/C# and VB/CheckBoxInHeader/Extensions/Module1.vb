Module Module1
   <System.Runtime.CompilerServices.Extension()> _
       Public Function ToDataTable(Of T)(ByVal value As IEnumerable(Of T)) As DataTable

      Dim returnTable As New DataTable
      Dim firstRecord = value.First

      For Each pi In firstRecord.GetType.GetProperties
         returnTable.Columns.Add(pi.Name, pi.GetValue(firstRecord, Nothing).GetType)
      Next

      For Each result In value
         Dim nr = returnTable.NewRow
         For Each pi In result.GetType.GetProperties
            nr(pi.Name) = pi.GetValue(result, Nothing)
         Next
         returnTable.Rows.Add(nr)
      Next
      Return returnTable
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <Runtime.CompilerServices.Extension()> _
   Public Function CheckBoxCount(ByVal GridView As DataGridView, ByVal ColumnIndex As Integer, ByVal Checked As Boolean) As Integer
      Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnIndex).Value) = Checked).Count
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <Runtime.CompilerServices.Extension()> _
   Public Function CheckBoxCount(ByVal GridView As DataGridView, ByVal ColumnName As String, ByVal Checked As Boolean) As Integer
      Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnName).Value) = Checked).Count
   End Function
   'Where Not DirectCast(row, DataGridViewRow).IsNewRow
   <System.Diagnostics.DebuggerStepThrough()> _
   <Runtime.CompilerServices.Extension()> _
   Public Function GetCheckedRows(ByVal GridView As DataGridView, ByVal ColumnName As String) As List(Of DataGridViewRow)
      Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() _
              Where CBool(Rows.Cells(ColumnName).Value) = True).ToList
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <Runtime.CompilerServices.Extension()> _
   Public Function GetCheckedRows1(ByVal GridView As DataGridView, ByVal ColumnName As String) As List(Of DataGridViewRow)
      Dim Temp = (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where Not Rows.IsNewRow).ToList
      Return (From SubRows In Temp Where CBool(SubRows.Cells(ColumnName).Value) = True).ToList
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function ColumnValue(ByVal sender As BindingSource, ByVal Row As Integer, ByVal ColumnName As String) As String
      Return DirectCast(sender.Item(Row), DataRowView).Item(ColumnName).ToString
   End Function
End Module

Module DataGridviewExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function CurrentRowCellValue(ByVal sender As DataGridView, ByVal ColumnName As String) As String
        Dim Result As String = ""

        If Not sender.Rows(sender.CurrentRow.Index).Cells(ColumnName).Value Is Nothing Then
            Result = sender.Rows(sender.CurrentRow.Index).Cells(ColumnName).Value.ToString
        End If

        Return Result

    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function CurrentCellValue(ByVal sender As DataGridView) As DataGridViewCell
        Return sender(sender.SelectedColumnNameIndex, sender.CurrentRow.Index)
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function SelectedColumnName(ByVal sender As DataGridView) As String
        Return sender.Columns(sender.CurrentCellValue.ColumnIndex).Name
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function SelectedColumnNameIndex(ByVal sender As DataGridView) As Int32
        Return sender.Columns(sender.CurrentCell.ColumnIndex).Index
    End Function
End Module

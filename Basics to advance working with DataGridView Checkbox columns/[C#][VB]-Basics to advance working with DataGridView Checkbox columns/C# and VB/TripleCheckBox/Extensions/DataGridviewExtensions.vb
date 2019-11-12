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
        Return sender(sender.Columns(sender.CurrentCell.ColumnIndex).Index, sender.CurrentRow.Index)
    End Function
End Module

Module Module1
    <System.Runtime.CompilerServices.Extension()> _
    Public Function AppendIfNeeded(ByVal sender As String, ByVal Character As Char) As String
        Return IIf(sender.Last = Character, sender, String.Concat(sender, Character)).ToString
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Public Function GetChecked(ByVal GridView As DataGridView, ByVal ColumnName As String) As List(Of DataGridViewRow)
        Return (From Rows In GridView.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells(ColumnName).Value) = True).ToList
    End Function
End Module

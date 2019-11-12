Module MiscExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub WriteCurrentRowHireDateToNothing(ByVal sender As BindingSource)
        CType((CType(sender.Current, DataRowView)).Row, DataRow).Item("HiredDate") = DBNull.Value
    End Sub
End Module

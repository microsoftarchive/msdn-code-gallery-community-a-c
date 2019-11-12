Module BindingSourceExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        If sender.DataSource.GetType.Equals(GetType(System.Data.DataTable)) Then
            Return DirectCast(sender.DataSource, DataTable)
        Else
            Throw New Exception("DataSource is not a DataTable")
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
        Return CType((CType(sender.Current, DataRowView)).Row, DataRow)
    End Function


End Module

Module BindingSourceExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRowIsValid(ByVal sender As BindingSource) As Boolean
        Return Not (sender.Current Is Nothing)
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
        Return DirectCast(sender.Current, DataRowView).Row
    End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function CurrentRow(ByVal sender As BindingSource, ByVal Column As String, _
                              ByVal Trim As Boolean) As String
      Dim Result As String = DirectCast(sender.Current, DataRowView).Row(Column).ToString
      Return IIf(Trim, Result.Trim, Result).ToString
   End Function
End Module

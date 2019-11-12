Public Module DataSetExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function FlattenTableNames(ByVal sender As DataSet) As String
        Return String.Join(",", (From T In sender.Tables.Cast(Of DataTable)() Select T.TableName).ToArray)
    End Function
End Module

Module DataTableExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Public Function GetRowCount(ByVal dt As DataTable) As Integer

        If String.IsNullOrWhiteSpace(dt.TableName) Then
            Throw New Exception("Please give your table a name")
        End If

        Dim dataView As New DataView

        dataView.Table = dt
        dataView.RowStateFilter = DataViewRowState.CurrentRows

        Return dataView.Count

    End Function

End Module

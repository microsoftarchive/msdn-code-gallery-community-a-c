Module BindingSourceExtensions
    ''' <summary>
    ''' Return the DataSource as a DataTable
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
End Module

''' <summary>
''' These extension methods usage if for no other
''' reason permit code to be method base and cleaner
''' were used.
''' </summary>
Public Module ExtensionMethods

    ''' <summary>
    ''' Get underlying DataTable
    ''' </summary>
    ''' <param name="pBindingSource"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' This version does not check if the DataSource is a DataTable.
    ''' </remarks>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function DataTable(ByVal pBindingSource As BindingSource) As DataTable
        Return DirectCast(pBindingSource.DataSource, DataTable)
    End Function
    ''' <summary>
    ''' Locate a value in the DataSource of the BindingSource
    ''' </summary>
    ''' <param name="pBindingSource"></param>
    ''' <param name="pKey"></param>
    ''' <param name="pValue"></param>
    ''' <returns>
    ''' Row index if found, minus 1 if not located.
    ''' </returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function Locate(ByVal pBindingSource As BindingSource, ByVal pKey As String, ByVal pValue As String) As Integer
        Dim Position As Integer = -1

        Position = pBindingSource.Find(pKey, pValue)
        If Position > -1 Then
            pBindingSource.Position = Position
        End If

        Return Position

    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function CurrentRow(ByVal pBindingSource As BindingSource) As DataRow
        Return DirectCast(pBindingSource.Current, DataRowView).Row
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function CurrentRowValue(ByVal pBindingSource As BindingSource, ByVal pColumn As String) As String
        Return DirectCast(pBindingSource.Current, DataRowView).Row(pColumn).ToString
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module

Module BindingSourceExtensions

    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
    ''' <summary>
    ''' Accepts changes for the underlying DataTable
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub AcceptChanges(ByVal sender As BindingSource)
        sender.DataTable.AcceptChanges()
    End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As String) As Integer
        Dim Position As Integer = -1

        Position = sender.Find(Key, Value)
        If Position > -1 Then
            sender.Position = Position
        End If

        Return Position
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As Integer) As Integer
        Dim Position As Integer = -1

        Position = sender.Find(Key, Value)
        If Position > -1 Then
            sender.Position = Position
        End If

        Return Position
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
        Return DirectCast(sender.Current, DataRowView).Row
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource, ByVal Column As String) As String
        Return DirectCast(sender.Current, DataRowView).Row(Column).ToString
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRowCode(ByVal sender As BindingSource) As String
        Return DirectCast(sender.Current, DataRowView).Row("Code").ToString
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRowShownName(ByVal sender As BindingSource) As String
        Return DirectCast(sender.Current, DataRowView).Row("ShownName").ToString
    End Function

End Module

Imports System.Windows.Forms
Public Module BindingSourceExtensions
    ''' <summary>
    ''' Used for selection of like condition in LikeFilter extension
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LikeOptions
        ''' <summary>
        ''' Field starts with chars
        ''' </summary>
        ''' <remarks></remarks>
        StartsWith
        ''' <summary>
        ''' Field ends with chars
        ''' </summary>
        ''' <remarks></remarks>
        EndsWith
        ''' <summary>
        ''' Field contains chars
        ''' </summary>
        ''' <remarks></remarks>
        Contains
    End Enum
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub LikeFilter(ByVal sender As BindingSource, ByVal Value As String)
        Dim dt = sender.DataTable
        Dim dv = dt.DefaultView

        If Value.Length > 0 Then
            dv.RowFilter = "LastName like  '" & Value & "%'"
        Else
            dv.RowFilter = ""
        End If
    End Sub
    ''' <summary>
    ''' Used to filter a BindingSource via the data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="FieldName">name of field to filter</param>
    ''' <param name="Value">value to filter on or an empty string to remove filter</param>
    ''' <param name="Which">direction of filter</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub LikeFilter(
        ByVal sender As BindingSource,
        ByVal FieldName As String,
        ByVal Value As String,
        ByVal Which As LikeOptions)

        Dim dt = sender.DataTable
        Dim dv = dt.DefaultView

        If Value.Length > 0 Then

            Value = Value.Replace("'", "''")

            Dim Filter As String = FieldName & " like  '"
            Select Case Which
                Case LikeOptions.StartsWith
                    Filter = FieldName & " like  '" & Value & "%'"
                Case LikeOptions.EndsWith
                    Filter = FieldName & " like  '%" & Value & "'"
                Case LikeOptions.Contains
                    Filter = FieldName & " like  '%" & Value & "%'"
            End Select

            Try
                dv.RowFilter = Filter
            Catch ex As Exception
                '
                ' Should not land here but...
                ' So how did we get here :-)
                ' How do you think the exception should be handled ?
                '
                Console.WriteLine(ex.Message)
            End Try
            '
            ' If dv.Count is 0 you could change the behavior if so 
            ' desired as 0 means nothing met the current condition.
            '
        Else
            dv.RowFilter = ""
        End If
    End Sub
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
    ''' <summary>
    ''' Get the current row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
        Return DirectCast(sender.Current, DataRowView).Row
    End Function

    ''' <summary>
    ''' Incremental search on field the DataSource is sorted on
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Value">partial or full text to locate</param>
    ''' <returns>Postion or -1 if no matches</returns>
    ''' <remarks>
    ''' Designed for single column sort, case insensitive
    ''' </remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function FindFirst(ByVal sender As BindingSource, ByVal Value As String) As Integer
        Dim Result As Integer = -1

        If sender.SupportsSorting Then
            If sender.IsSorted Then
                Dim dr() As DataRow
                dr = sender.DataTable.Select(String.Format("{0} like '{1}%'", sender.Sort, Value))
                If dr.Count > 0 Then
                    Result = sender.DataTable.DefaultView.Find(dr(0)(sender.Sort))
                End If
            Else
                Throw New Exception("No column set for sorting")
            End If

            Return Result

        Else
            Throw New Exception("Sorting not supported which is required for FindIncremental to function")
        End If

    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As String) As Integer
        Dim Position As Integer = -1

        Position = sender.Find(Key, Value)
        If Position > -1 Then
            sender.Position = Position
        End If

        Return Position
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As Integer) As Integer
        Dim Position As Integer = -1

        Position = sender.Find(Key, Value)
        If Position > -1 Then
            sender.Position = Position
        End If

        Return Position
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As Date) As Integer
        Dim Position As Integer = -1
        Position = sender.Find(Key, Value.ToString(DateCultureInfo.CurrentDateFormat))
        If Position > -1 Then
            sender.Position = Position
        End If

        Return Position
    End Function
End Module

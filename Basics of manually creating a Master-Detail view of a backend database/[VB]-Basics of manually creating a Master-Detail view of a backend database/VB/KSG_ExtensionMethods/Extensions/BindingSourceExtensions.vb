Imports System.Windows.Forms
Imports DataAccess.ProjectGlobals

Public Module BindingSourceExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataView(ByVal sender As BindingSource) As DataView
        Return DirectCast(sender.List, DataView)
    End Function
    ''' <summary>
    ''' Return a column value as a string
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Column"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentRow(ByVal sender As BindingSource, ByVal Column As String) As String
        Return DirectCast(sender.Current, DataRowView).Row(Column).ToString
    End Function
    ''' <summary>
    ''' Accepts changes to the current row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SaveCurrentRow(ByVal sender As BindingSource)
        DirectCast(sender.Current, DataRowView).Row.AcceptChanges()
    End Sub
    ''' <summary>
    ''' Primary key for Customers
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentCustomerIdentifier(ByVal sender As BindingSource) As String
        Return sender.CurrentRow(CustomerIdentifier)
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentCustomerName(ByVal sender As BindingSource) As String
        Return sender.CurrentRow("CompanyName")
    End Function
    ''' <summary>
    ''' Primary key for Orders
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CurrentOrderIdentifier(ByVal sender As BindingSource) As String
        Return sender.CurrentRow(OrderIdentifier)
    End Function
    ''' <summary>
    ''' An example of going out of one's way because they do not take
    ''' time to understand their data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Identifier"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Absolutely no reason for this, see comments in it's usage
    ''' in MainformLoadData.vb
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function OrderDetailsTotalRows(ByVal sender As BindingSource, ByVal Identifier As String) As Int32
        Return _
        (
            From T In
            DirectCast(DirectCast(sender.DataSource, BindingSource).DataSource, DataSet).Tables("Orders").AsEnumerable
            Where T.Field(Of String)(CustomerIdentifier) = Identifier
        ).Count
    End Function
End Module

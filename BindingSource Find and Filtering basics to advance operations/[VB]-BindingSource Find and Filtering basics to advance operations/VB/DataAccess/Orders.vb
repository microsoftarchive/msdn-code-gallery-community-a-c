Imports System.Data.OleDb
Public Class Orders
    ''' <summary>
    ''' Return all rows and fields in the Orders table
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataTable As DataTable
    ''' <summary>
    ''' A List of distinct dates in the Orders table
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DistinctDates As List(Of String)

    Public Sub New()
        Using cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb;")
            Me.DataTable = New DataTable

            Using cmd As New OleDbCommand("SELECT Identifier, OrderNumber, OrderDate FROM Orders", cn)
                cn.Open()

                Me.DataTable.Load(cmd.ExecuteReader())
                Me.DataTable.Columns("Identifier").ColumnMapping = MappingType.Hidden
            End Using

        End Using

        DistinctDates =
            (
                From T In New DataView(Me.DataTable.DefaultView.ToTable("MyDates", True, "OrderDate")).ToTable.AsEnumerable
                Select T.Field(Of Date)("OrderDate").ToShortDateString
            ).ToList

    End Sub
End Class

Imports System.Data.OleDb

Public Class Customers
    Public Property ColumnNames As List(Of String)
    Public Property DataTable As DataTable

    Public Sub New()
        Using cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb;")
            Me.DataTable = New DataTable

            Using cmd As New OleDbCommand("SELECT ID, FirstName, LastName, City, State FROM Customers Order By LastName", cn)
                cn.Open()

                Me.DataTable.Load(cmd.ExecuteReader())
                Me.DataTable.Columns("ID").ColumnMapping = MappingType.Hidden
                Me.ColumnNames =
                    (
                        From T In cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
                                                         New Object() {Nothing, Nothing, "Customers", Nothing}
                                                         ).AsEnumerable
                        Where T.Field(Of Int32)("DATA_TYPE") = OleDb.OleDbType.WChar
                        Select T.Field(Of String)("COLUMN_NAME")
                    ).ToList
            End Using

        End Using
    End Sub


End Class

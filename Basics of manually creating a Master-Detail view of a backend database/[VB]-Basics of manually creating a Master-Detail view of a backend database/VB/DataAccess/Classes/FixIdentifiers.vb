''' <summary>
''' The original MS-Access Customer table had a strange primary key
''' which I felt was not good for demoing so this could fixed this.
''' </summary>
''' <remarks>
''' This is only left here in the event someone wants to know "how it was done"
''' </remarks>
Public Class FixIdentifiers
    Public Sub New()
        Throw New Exception("Best not to run me again!!!")
    End Sub
    Public Sub Execute()
        Dim cn As OleDb.OleDbConnection = Nothing

        '
        ' Setup Singleton instance
        '
        Dim conn As MS_AccessConnection = MS_AccessConnection.GetInstance()
        cn = conn.GetConnection(Builder.ConnectionString)

        Dim dtCustomers As New DataTable
        Dim dt As New DataTable
        Dim cmdUpdate As New OleDb.OleDbCommand
        Dim Affected As Integer = 0

        Using cmd As New OleDb.OleDbCommand With
            {
                .Connection = cn,
                .CommandText = "SELECT CustomerID, Identifier FROM Customers"
            }

            dtCustomers.Load(cmd.ExecuteReader)

            cmd.CommandText = "SELECT Orders.CustomerID, Orders.CustomerIdentifier FROM Orders WHERE (((Orders.CustomerID)=@P1));"
            cmd.Parameters.Add(New OleDb.OleDbParameter With {.DbType = DbType.String})

            cmdUpdate.Connection = cn
            cmdUpdate.CommandText = "UPDATE ORDERS SET CustomerIdentifier=@P1 WHERE CustomerID=@P2"
            cmdUpdate.Parameters.Add(New OleDb.OleDbParameter With {.DbType = DbType.String})
            cmdUpdate.Parameters.Add(New OleDb.OleDbParameter With {.DbType = DbType.String})

            For Each row As DataRow In dtCustomers.Rows

                cmd.Parameters(0).Value = row.Field(Of String)("CustomerID")

                dt.Load(cmd.ExecuteReader)
                If dt.Rows.Count > 0 Then

                    cmdUpdate.Parameters(0).Value = row.Field(Of Int32)("Identifier").ToString
                    cmdUpdate.Parameters(1).Value = row.Field(Of String)("CustomerID")

                    Affected = cmdUpdate.ExecuteNonQuery()
                    '
                    ' Display results to the IDE output window.
                    '
                    Console.WriteLine("[{0}] [{1}]  -> [{2}]  --> [{3}]",
                                              row.Field(Of String)("CustomerID"),
                                              row.Field(Of Int32)("Identifier"),
                                              dt.Rows.Count,
                                              Affected
                                            )
                End If

                dt.Rows.Clear()

            Next
        End Using
    End Sub
End Class

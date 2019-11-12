Module DataAccess
    Private Builder As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.accdb")
        }

    ''' <summary>
    ''' Return data from MS-Access database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData() As DataTable
        Dim dt As New DataTable
        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT Identifier, PeopleNames, HiredDate FROM People"
                }

                cn.Open()
                dt.Load(cmd.ExecuteReader)
                dt.Columns("Identifier").ColumnMapping = MappingType.Hidden

            End Using
        End Using

        Return dt

    End Function
#If ReallyWantMoreRows Then
    Public Sub AddRows()
        Dim Items As New Dictionary(Of String, Date) From
            {
                {"Chris Christianson", #1/1/2013 12:23:00 PM#},
                {"Christine Manley", #1/1/2013 12:33:00 PM#},
                {"Gary Jannis", #1/1/2014 12:11:00 PM#},
                {"Alexander Mast", #2/2/1999 6:23:00 AM#}
            }

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText = "INSERT INTO People (PeopleNames,HiredDate) VALUES (@PeopleNames,@HiredDate)"
                cmd.Parameters.Add(New OleDb.OleDbParameter With {.ParameterName = "@PeopleNames", .DbType = DbType.String})
                cmd.Parameters.Add(New OleDb.OleDbParameter With {.ParameterName = "@HiredDate", .DbType = DbType.DateTime})
                cn.Open()
                Dim Affected As Integer = 0
                For Each pair As KeyValuePair(Of String, Date) In Items
                    cmd.Parameters(0).Value = pair.Key
                    cmd.Parameters(1).Value = pair.Value
                    Affected = cmd.ExecuteNonQuery
                    Console.WriteLine(Affected)
                Next
            End Using
        End Using
    End Sub
#End If
End Module

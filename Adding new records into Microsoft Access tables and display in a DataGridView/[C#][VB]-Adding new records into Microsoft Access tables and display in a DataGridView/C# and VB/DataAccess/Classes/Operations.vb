''' <summary>
''' Responsible for all database loading and inserting
''' </summary>
''' <remarks>
''' LoadSingleRow and AddNewRow(ByVal CompanyName As String, ByVal ContactName As String...)
''' were added in for assisting with a online question where the person was using VS2008
''' so there are differences with object initialization to fit into VS2008 syntax
''' </remarks>
Public Class Operations

    ''' <summary>
    ''' Creates our connection string to the database which is easy to follow
    ''' and there is no string concatenation done here
    ''' </summary>
    ''' <remarks></remarks>
    Private Builder As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
        }

    ''' <summary>
    ''' Used to get all customers at program startup
    ''' </summary>
    ''' <remarks></remarks>
    Private SelectStatement As String =
    <SQL>
        SELECT 
            Identifier, 
            CompanyName, 
            ContactName, 
            ContactTitle
        FROM Customer;
    </SQL>.Value

    ''' <summary>
    ''' Responsible for inserting rows into the customer table
    ''' </summary>
    ''' <remarks></remarks>
    Private InsertStatement As String =
    <SQL>
    INSERT INTO Customer 
        (
            CompanyName,
            ContactName,
            ContactTitle
        ) 
    Values
        (
            @CompanyName,
            @ContactName,
            @ContactTitle
        )
    </SQL>.Value

    ''' <summary>
    ''' Get a list of titles, in this case there are only two.
    ''' For a real app we would have a contact title table rather
    ''' then get them from existing row. 
    ''' </summary>
    ''' <returns></returns>
    Public Function ContactTitles() As List(Of String)
        Dim titleList As New List(Of String)
        Using cn As New OleDb.OleDbConnection(Builder.ConnectionString)
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn, .CommandText = "SELECT DISTINCT ContactTitle FROM Customer"}
                cn.Open()
                Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    While reader.Read
                        titleList.Add(reader.GetString(0))
                    End While
                    reader.Close()
                End If
            End Using
        End Using

        Return titleList

    End Function

    ''' <summary>
    ''' Used to open the database in Windows Explorer
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ViewDatabase()
        Process.Start(Builder.DataSource)
    End Sub

    ''' <summary>
    ''' Load existing customers into a BindingSource which becomes
    ''' the DataSource for a DataGridView
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadCustomers() As DataTable
        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT 
                            Identifier, 
                            CompanyName, 
                            ContactName, 
                            ContactTitle
                        FROM Customer;
                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "Customer"}

                cn.Open()
                dt.Load(cmd.ExecuteReader)

                Return dt

            End Using
        End Using
    End Function
    Public Function LoadSingleRow(ByVal Identifier As Integer) As String
        Dim sb As New Text.StringBuilder
        Using cn As New OleDb.OleDbConnection(Builder.ConnectionString)
            Using cmd As New OleDb.OleDbCommand("", cn)
                cmd.CommandText = "SELECT CompanyName, ContactName, ContactTitle FROM Customer WHERE Identifier =" & Identifier.ToString
                cn.Open()
                Dim Reader As OleDb.OleDbDataReader = cmd.ExecuteReader
                If Reader.HasRows Then
                    Reader.Read()

                    sb.AppendLine("Company name [" & Reader.GetString(0) & "]")
                    sb.AppendLine("Contact [" & Reader.GetString(1) & "]")
                    sb.AppendLine("Contact name [" & Reader.GetString(2) & "]")
                Else
                    sb.AppendLine("Operation failed")
                End If
            End Using
        End Using

        Return sb.ToString
    End Function
    ''' <summary>
    ''' Used to add one row to the Customer table and on success
    ''' return the new primary key.
    ''' 
    ''' Here we pass in a customer but could have very well passed in
    ''' an object array or one parameter for each field.
    ''' 
    ''' All fields are of type string but you can add other types
    ''' too.
    ''' 
    ''' AddWithValue is used here but we could also use Add and
    ''' control the parameters.
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Identfier"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewRow(ByVal sender As Customer, ByRef Identfier As Integer) As Boolean
        Dim Success As Boolean = True

        Try
            Using cn As New OleDb.OleDbConnection With {.ConnectionString = Builder.ConnectionString}
                Using cmd As New OleDb.OleDbCommand With {.Connection = cn}

                    cmd.CommandText = InsertStatement

                    cmd.Parameters.AddWithValue("@CompanyName", sender.CompanyName)
                    cmd.Parameters.AddWithValue("@ContactName", sender.ContactName)
                    cmd.Parameters.AddWithValue("@ContactTitle", sender.ContactTitle)

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Select @@Identity"
                    Identfier = CInt(cmd.ExecuteScalar)

                End Using
            End Using

        Catch ex As Exception
            Success = False
        End Try

        Return Success

    End Function
    Public Function AddNewRow(ByVal CompanyName As String, ByVal ContactName As String, ByVal ContactTitle As String, ByRef Identfier As Integer) As Boolean
        Dim Success As Boolean = True

        Try
            Using cn As New OleDb.OleDbConnection(Builder.ConnectionString)
                Using cmd As New OleDb.OleDbCommand("", cn)

                    cmd.CommandText = "INSERT INTO Customer (CompanyName,ContactName,ContactTitle) Values (@CompanyName,@ContactName,@ContactTitle)"

                    cmd.Parameters.AddWithValue("@CompanyName", CompanyName.Trim)
                    cmd.Parameters.AddWithValue("@ContactName", ContactName.Trim)
                    cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle.Trim)

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Select @@Identity"
                    Identfier = CInt(cmd.ExecuteScalar)

                End Using
            End Using

        Catch ex As Exception
            Success = False
        End Try

        Return Success

    End Function
    Public Sub New()
    End Sub
    Public Overrides Function ToString() As String
        Return "Demo adding rows"
    End Function
End Class

Imports System.Data.OleDb

' Contains BaseExceptionProperties class
Imports KarensBaseClasses

Public Class DatabaseOperations
    Inherits BaseExceptionProperties

    Private Builder As New OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0"
        }
    ''' <summary>
    ''' Default our connection to a database in the executable folder
    ''' </summary>
    Public Sub New()
        Builder.DataSource = IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    ''' <summary>
    ''' Use a different database then the one in the executable folder.
    ''' When using this the database must have the same table and fields.
    ''' </summary>
    ''' <param name="pDataSource"></param>
    Public Sub New(ByVal pDataSource As String)
        Builder.DataSource = pDataSource
    End Sub
    ''' <summary>
    ''' Read USA customers from database into a DataTable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Database is assumed to be in the Bin\Debug folder.
    ''' </remarks>
    Public Function LoadCustomers() As DataTable

        Using cn As New OleDbConnection(Builder.ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT 
                            Identifier, 
                            CompanyName, 
                            ContactName, 
                            ContactTitle
                        FROM Customer ORDER BY CompanyName;

                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "Customer"}

                Try

                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    dt.Columns("Identifier").ColumnMapping = MappingType.Hidden

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

                Return dt

            End Using
        End Using
    End Function
    ''' <summary>
    ''' Load a list of contact titles.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' In a well normalized database we would have a contact tile
    ''' table and the customer table would have a integer field that
    ''' would join to the contact title table.
    ''' </remarks>
    Public Function LoadContactTitles() As List(Of String)

        Dim titleList As New List(Of String)

        Using cn As New OleDbConnection(Builder.ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                        SELECT DISTINCT ContactTitle
                        FROM Customer
                    </SQL>.Value

                Try

                    cn.Open()

                    Dim reader As OleDbDataReader = cmd.ExecuteReader

                    While reader.Read
                        titleList.Add(reader.GetString(0))
                    End While

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using

        Return titleList

    End Function
    ''' <summary>
    ''' Remove a customer by primary key
    ''' </summary>
    ''' <param name="pIdentfier"></param>
    ''' <returns></returns>
    Public Function RemoveCurrentCustomer(ByVal pIdentfier As Integer) As Boolean
        Try
            Using cn As New OleDbConnection(Builder.ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}

                    cmd.CommandText = "DELETE FROM Customer WHERE Identifier = @Identifier"

                    Dim IdentifierParameter As New OleDbParameter With
                        {
                            .DbType = DbType.Int32,
                            .ParameterName = "@Identifier",
                            .Value = pIdentfier
                        }
                    cmd.Parameters.Add(IdentifierParameter)

                    Try
                        cn.Open()

                        Dim Affected = cmd.ExecuteNonQuery
                        Return Affected = 1

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
            Return IsSuccessFul
        End Try
    End Function
    ''' <summary>
    ''' Add a new customer to the database table
    ''' </summary>
    ''' <param name="pName"></param>
    ''' <param name="pContact"></param>
    ''' <param name="pContactTitle"></param>
    ''' <param name="pIdentfier"></param>
    ''' <returns></returns>
    Public Function AddNewRow(
        ByVal pName As String,
        ByVal pContact As String,
        ByVal pContactTitle As String,
        ByRef pIdentfier As Integer) As Boolean

        Dim Success As Boolean = True

        Try
            Using cn As New OleDbConnection(Builder.ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
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

                    cmd.Parameters.AddWithValue("@CompanyName", pName)
                    cmd.Parameters.AddWithValue("@ContactName", pContact)
                    cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle)

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Select @@Identity"
                    pIdentfier = CInt(cmd.ExecuteScalar)

                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
            Success = False
        End Try

        Return Success

    End Function
    ''' <summary>
    ''' Update a row
    ''' </summary>
    ''' <param name="pDataRow"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' I used Parameters.Add instead of Parameters.AddWithValue
    ''' where Parameters.AddWithValue is usually best yet wanted to
    ''' show Parameters.Add as many don't realize this is a viable
    ''' way to add parameters and really shines when doing multiple
    ''' adds or updates in say a for-each or for-next.
    ''' </remarks>
    Public Function UpdateRow(ByVal pDataRow As DataRow) As Boolean

        Try
            Using cn As New OleDbConnection(Builder.ConnectionString)

                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                            UPDATE 
                                Customer 
                            SET 
                                CompanyName = @CompanyName, 
                                ContactName = @ContactName,
                                ContactTitle = @ContactTitle
                            WHERE Identifier = @Identifier
                        </SQL>.Value

                    Dim CompanyNameParameter As New OleDbParameter With
                        {
                            .DbType = DbType.String,
                            .ParameterName = "@CompanyName",
                            .Value = pDataRow.Field(Of String)("CompanyName")
                        }

                    cmd.Parameters.Add(CompanyNameParameter)

                    Dim ContactNameParameter As New OleDbParameter With
                        {
                            .DbType = DbType.String,
                            .ParameterName = "@ContactName",
                            .Value = pDataRow.Field(Of String)("ContactName")
                        }

                    cmd.Parameters.Add(ContactNameParameter)

                    Dim ContactTitleParameter As New OleDbParameter With
                        {
                            .DbType = DbType.String,
                            .ParameterName = "@ContactTitle",
                            .Value = pDataRow.Field(Of String)("ContactTitle")
                        }

                    cmd.Parameters.Add(ContactTitleParameter)

                    Dim IdentifierParameter As New OleDbParameter With
                        {
                            .DbType = DbType.Int32,
                            .ParameterName = "@Identifier",
                            .Value = pDataRow.Field(Of Int32)("Identifier")
                        }

                    cmd.Parameters.Add(IdentifierParameter)

                    Try
                        cn.Open()

                        Dim Affected = cmd.ExecuteNonQuery
                        Return Affected = 1

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                        Return IsSuccessFul

                    End Try
                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex

            Return IsSuccessFul

        End Try
    End Function
End Class

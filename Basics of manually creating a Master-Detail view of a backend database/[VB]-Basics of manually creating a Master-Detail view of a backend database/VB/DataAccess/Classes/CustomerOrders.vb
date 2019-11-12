Imports System.Windows.Forms
''' <summary>
''' Responsible for loading data from MS-Access followed 
''' by setting up BindingSource components and data relationships
''' which will be used in a Win-form project.
''' </summary>
''' <remarks>
''' 
''' </remarks>
Public Class CustomerOrdersSetup
    ''' <summary>
    ''' This is the master data
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Master As New BindingSource
    ''' <summary>
    ''' This is the details to the Master 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Details As New BindingSource

    Public Sub New()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ErrorMessage"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' There are some extra assertion on failure to open a table
    ''' in the event a developer while coding had one of the tables
    ''' opened exclusively, it happens :-)
    ''' </remarks>
    Public Function Load(ByRef ErrorMessage As String) As Boolean
        Dim Result As Boolean
        Dim cn As OleDb.OleDbConnection = Nothing

        Dim conn As MS_AccessConnection = MS_AccessConnection.GetInstance()
        cn = conn.GetConnection(Builder.ConnectionString)

        '
        ' At this point our database connection is open and will stay
        ' stay open until the app quits or you close the connection. If 
        ' you close the connection and use conn above the connection is
        ' re-opened for you. Same thing if you were to use a Using Statement
        ' which closes a connection, MS_AccessConnection class will re-open
        ' as needed.
        '

        Try
            Dim da As OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            da = New OleDb.OleDbDataAdapter(
            <SQL>
                SELECT   
                    Identifier, 
                    CompanyName, 
                    Address, 
                    City, 
                    PostalCode, 
                    Phone
                FROM     
                    Customers 
                ORDER BY 
                    CompanyName;
            </SQL>.Value, _
            cn)

            Try
                da.Fill(ds, "Customers")
            Catch oex As OleDb.OleDbException
                If oex.Message.Contains("exclusively locked") Then
                    ErrorMessage = "You have the Customer table open"
                    Return False
                End If
            End Try

            '
            ' Note an alias is done in the SQL
            '
            da = New OleDb.OleDbDataAdapter(
            <SQL>
                SELECT 
                    Identifier, 
                    OrderDate, 
                    ShippedDate, 
                    ShipName, 
                    ShipAddress, 
                    ShipCity, 
                    ShipRegion, 
                    ShipPostalCode, 
                    Freight, 
                    OrderID, 
                    Orders.EmployeeID, 
                    Employees.FirstName + ' '+ Employees.LastName As Employee,
                    Employees.HomePhone + ' ' + Employees.Extension As Phone
                FROM Employees INNER JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID
                ORDER BY Orders.ShippedDate DESC;
            </SQL>.Value,
            cn)

            Try
                da.Fill(ds, "Orders")
                ds.Tables("Orders").Columns.Add(New DataColumn With {.ColumnName = "Process", .DataType = GetType(Boolean)})
                For Each row As DataRow In ds.Tables("Orders").Rows
                    row.SetField(Of Boolean)("Process", False)
                Next
            Catch oex As OleDb.OleDbException
                If oex.Message.Contains("exclusively locked") Then
                    ErrorMessage = "You have the orders or employee table open"
                    Return False
                End If
            End Try

            ds.Tables("Orders").Columns("EmployeeID").ColumnMapping = MappingType.Hidden

            '
            ' Handy dandy language extension
            '
            ds.SetRelation("Customers", "Orders", "Identifier")

            '
            ' Let's create a DataColumn Expression on the customer table reaching down
            ' into the details table via 'Child' in FreightExpression below.
            '
            Dim FreightExpression As String = "Sum(Child(CustomersOrders).Freight) "

            ds.Tables("Customers").Columns.Add(
                New DataColumn With
                {
                    .ColumnName = "Freight",
                    .DataType = GetType(String),
                    .Expression = FreightExpression
                }
            )

            Master.DataSource = ds
            Master.DataMember = ds.Tables(0).TableName

            Details.DataSource = Master
            Details.DataMember = ds.Relations(0).RelationName
            Result = True
        Catch ex As Exception
            ErrorMessage = ex.Message
            Result = False
        End Try

        Return Result

    End Function

End Class

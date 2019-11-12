''' <summary>
''' Database1.accdb has been setup to be copied to Bin\Debug folder
''' each time you run this demo so we start fresh each time.
''' 
''' Run the oproject, press Demo button.
''' Close the app
''' 
''' </summary>
''' <remarks></remarks>
Public Class Form1

    ''' <summary>
    ''' Access to database operations
    ''' </summary>
    ''' <remarks></remarks>
    Private DataOpts As New DataAccess.Operations

    ''' <summary>
    ''' Used for the data source for the DataGridView
    ''' </summary>
    ''' <remarks></remarks>
    WithEvents bsCustmers As New BindingSource

    ''' <summary>
    ''' Load data from back end database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bsCustmers.DataSource = DataOpts.LoadCustomers
        DataGridView1.DataSource = bsCustmers
    End Sub
    ''' <summary>
    ''' Add new rows to the cutomer table, we get the new primary key via the method
    ''' AddNewRow.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAddRows_Click(sender As Object, e As EventArgs) Handles cmdAddRows.Click
        Dim SeconaryTry As Boolean = False
        Dim Customers As New List(Of Customer) From
            {
                New Customer With {.CompanyName = "BDF Inc.", .ContactName = "Anne", .ContactTitle = "Owner"},
                New Customer With {.CompanyName = "Bill's shoes", .ContactName = "Bill", .ContactTitle = "Owner"},
                New Customer With {.CompanyName = "Salem Fishing Corp", .ContactName = "Debbie", .ContactTitle = "Sales"}
            }

        Dim NewIdentifier As Integer = 0
        Dim dt As DataTable = CType(bsCustmers.DataSource, DataTable)

        For Each Customer In Customers
            '
            ' See if the row already exists
            '
            If bsCustmers.Find("CompanyName", Customer.CompanyName) = -1 Then
                If DataOpts.AddNewRow(Customer, NewIdentifier) Then
                    dt.Rows.Add(New Object() {NewIdentifier, Customer.CompanyName, Customer.ContactName, Customer.ContactTitle})
                End If
            Else
                SeconaryTry = True
                Exit For
            End If
        Next

        If SeconaryTry Then
            MessageBox.Show("This was designed to work once :-)")
        End If
    End Sub
    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        DataOpts.ViewDatabase()
    End Sub
    ''' <summary>
    ''' This code was added 10/2016 to show using a modal dialog to add a record.
    ''' In this case unlike the original method on the same form I don't check for
    ''' if the company already exists.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmNewCustomer
        f.cboContactTitle.DataSource = DataOpts.ContactTitles
        If f.ShowDialog = DialogResult.OK Then
            If Not String.IsNullOrWhiteSpace(f.txtCompanyName.Text) OrElse Not String.IsNullOrWhiteSpace(f.txtContactName.Text) Then
                Dim NewIdentifier As Integer = 0
                If DataOpts.AddNewRow(f.txtCompanyName.Text, f.txtContactName.Text, f.cboContactTitle.Text, NewIdentifier) Then
                    Dim dt As DataTable = CType(bsCustmers.DataSource, DataTable)
                    dt.Rows.Add(New Object() {NewIdentifier, f.txtCompanyName.Text, f.txtContactName.Text, f.cboContactTitle.Text})
                End If
            End If
        End If
    End Sub
End Class

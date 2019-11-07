Imports LanguageExtensionsLibrary
''' <summary>
''' Simple example of adding a new row in a SQL-Server local database, get
''' the primary key. Once inserted pop the new row into our BindingSource
''' which then shows up in the DataGridView with assistance from a language
''' extension method
''' </summary>
''' <remarks>
''' </remarks>
Public Class Form1
    Private CurrentIdentifier As Int32
    Private Sub CustomersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NORTHWNDDataSet)
    End Sub
    Private Sub GetCustomers()
        Me.CustomersTableAdapter.Fill(Me.NORTHWNDDataSet.Customers)
        For Each col As DataGridViewColumn In CustomersDataGridView.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCustomers()
    End Sub
    Private NewIdentifier As Integer = 0
    ''' <summary>
    ''' The idea is to simply show how to use BindingSource.AddNew method
    ''' along with a language extension to make the new row current. No 
    ''' attempts are made to determine if the name already exists in the
    ''' backend database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAddRecord_Click(sender As Object, e As EventArgs) Handles cmdAddRecord.Click
        If Not String.IsNullOrWhiteSpace(txtNewCompanyname.Text) Then

            Using cn As New SqlClient.SqlConnection With {.ConnectionString = My.Settings.NORTHWNDConnectionString}
                Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(
                    "INSERT INTO Customers (CompanyName) VALUES (@CompanyName); SELECT SCOPE_IDENTITY ()", cn)

                    cn.Open()
                    cmd.Parameters.Add(New SqlClient.SqlParameter With {.DbType = DbType.String, .ParameterName = "@CompanyName"})
                    cmd.Parameters(0).Value = txtNewCompanyname.Text

                    NewIdentifier = CInt(cmd.ExecuteScalar)

                End Using
            End Using

            CustomersBindingSource.AddNew()
            CustomersBindingNavigatorSaveItem.PerformClick()
            GetCustomers()

            '
            ' Uses a language extension to locate the newly added row
            '
            CustomersBindingSource.Locate("Identifier", NewIdentifier)

            txtNewCompanyname.Text = ""

            ActiveControl = CustomersDataGridView

        End If
    End Sub
    Private Sub CustomersBindingSource_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles CustomersBindingSource.AddingNew
        Dim drv As DataRowView = DirectCast(CustomersBindingSource.List, DataView).AddNew()
        drv.Row.Item("Identifier") = NewIdentifier
        drv.Row.Item("CompanyName") = txtNewCompanyname.Text
        e.NewObject = drv
    End Sub
    ''' <summary>
    ''' Remember current primary key so when the DataGridView is sorted we can
    ''' make that row current after the sort.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' CurrentRow is a language extension
    ''' </remarks>
    Private Sub CustomersBindingSource_PositionChanged(sender As Object, e As EventArgs) Handles CustomersBindingSource.PositionChanged
        If CustomersBindingSource.Current IsNot Nothing Then
            CurrentIdentifier = CustomersBindingSource.CurrentRow.Field(Of Int32)("Identifier")
        End If
    End Sub
    ''' <summary>
    ''' At this point the row current prior to the sort is not current now
    ''' so let's fix it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CustomersDataGridView_Sorted(sender As Object, e As EventArgs) Handles CustomersDataGridView.Sorted
        CustomersBindingSource.Position = CustomersBindingSource.Find("Identifier", CurrentIdentifier)
    End Sub
End Class
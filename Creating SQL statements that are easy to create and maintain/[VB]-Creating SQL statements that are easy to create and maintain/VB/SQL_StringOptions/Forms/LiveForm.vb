Imports System.Data.OleDb
''' <summary>
''' Simple demonstration reading data from an MS-Access 2003 database table using XML literals and OleDb parameters.
''' </summary>
''' <remarks>
''' OleDbConnectionStringBuilder moves us away from string concatenation.
''' BindingSource allows us to easily position to a specfic row and also assist in keeping the current row
''' current after the user sorts the DataGridView via column header click.
''' </remarks>
Public Class frmLiveForm

    WithEvents bsCustomers As New BindingSource
    Private CurrentIdentifier As String = ""

    Private Sub frmLiveForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Purge As New CustomerDemo(True)
        Dim Builder As New OleDbConnectionStringBuilder With
            {
                .Provider = "Microsoft.Jet.OLEDB.4.0",
                .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.mdb")
            }

        Using cn As New OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDbCommand With {.Connection = cn}
                Dim SelectStatement =
                    <SQL>
                        SELECT 
                            Identifier,
                            CompanyName As Company, 
                            ContactName As Contact, 
                            ContactTitle As Title, 
                            Country, 
                            Phone
                        FROM 
                            Customer
                        WHERE Country= @Country1 OR Country = @Country2
                    </SQL>.Value

                cmd.CommandText = SelectStatement

                Dim CountryParm1 As New OleDbParameter With {.ParameterName = "@Country1", .OleDbType = OleDbType.LongVarChar}
                CountryParm1.Value = "Mexico"
                Dim CountryParm2 As New OleDbParameter With {.ParameterName = "@Country2", .OleDbType = OleDbType.LongVarChar}
                CountryParm2.Value = "USA"

                cmd.Parameters.AddRange(New OleDbParameter() {CountryParm1, CountryParm2})

                Dim dt As New DataTable

                cn.Open()

                dt.Load(cmd.ExecuteReader)
                dt.Columns("Identifier").ColumnMapping = MappingType.Hidden

                bsCustomers.DataSource = dt
                BindingNavigator1.BindingSource = bsCustomers

            End Using
        End Using

        DataGridView1.DataSource = bsCustomers
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        '
        ' Populate cboIdentifier ComboBox with each rows primary key so we can go to a specific row via 
        ' BindingSource Find method and Position property.
        '
        cboIdentifier.DisplayMember = "Identifier"
        cboIdentifier.DataSource = New DataView(bsCustomers.DataTable.DefaultView.ToTable("Customers", True, "Identifier")).ToTable

    End Sub
    Private Sub cmdSelectRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectRow.Click
        bsCustomers.Position = bsCustomers.Find("Identifier", cboIdentifier.Text)
    End Sub
    Private Sub bsCustomers_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsCustomers.PositionChanged
        CurrentIdentifier = CType(bsCustomers.Current, DataRowView).Item("Identifier").ToString()
    End Sub
    ''' <summary>
    ''' Utilized with Position Changed event of the BindingSource to keep the current row
    ''' current after doing a sort on the DataGridView by clicking on a column header.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        bsCustomers.Position = bsCustomers.Find("Identifier", CurrentIdentifier)
    End Sub
    ''' <summary>
    ''' Simple example which exports our DataTable to an xml structure using embedded expressions
    ''' and xml literals.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Dim Demo As New CustomerDemo
        If Demo.CreateXmlDocument(CType(bsCustomers.DataSource, DataTable)) Then
            Process.Start(Demo.FileName)
        Else
            My.Dialogs.ExceptionDialog(Demo.LastException, "See message below.", "Problem")
        End If
    End Sub
End Class

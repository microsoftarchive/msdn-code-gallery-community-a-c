''' <summary>
''' Demonstration for combining filtering and getting 
''' checked rows where the check column has been added 
''' to a DataTable and the other data comes from a 
''' database table. 
''' 
''' </summary>
''' <remarks>
''' In the get checked rows things get a little complicated 
''' as in the code logic works fine except when and if the 
''' user changes the filter item in the ComboBox but does not 
''' change the filter by pressing the filter button.
''' </remarks>
Public Class frmCustomers
    WithEvents bsCustomers As New BindingSource
    Private CurrentIdentifier As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
            {
                .Provider = "Microsoft.ACE.OLEDB.12.0",
                .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.accdb")
            }

        Dim dt As New DataTable
        Dim dtCountries As New DataTable

        dt.Columns.Add(New DataColumn With {.ColumnName = "Process", .DataType = GetType(Boolean)})

        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT Identifier, CompanyName, Country FROM Customer"
                }

                cn.Open()
                dt.Load(cmd.ExecuteReader)

                cmd.CommandText = "SELECT Country FROM Customer GROUP BY Country"
                dtCountries.Load(cmd.ExecuteReader)
                Dim AllRow As DataRow = dtCountries.NewRow
                AllRow.SetField(Of String)("Country", "ALL")
                dtCountries.Rows.InsertAt(AllRow, 0)

            End Using
        End Using

        For Each row As DataRow In dt.Rows
            row.SetField(Of Boolean)("Process", False)
        Next

        dt.AcceptChanges()

        bsCustomers.DataSource = dt
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsCustomers

        cboCountryFilter.DisplayMember = "Country"
        cboCountryFilter.DataSource = dtCountries

        If System.Diagnostics.Debugger.IsAttached Then
            Label1.Visible = True
            Label1.DataBindings.Add("Text", bsCustomers, "Country")
        End If

    End Sub
    Private Sub cmdFilter_Click(sender As Object, e As EventArgs) Handles cmdFilter.Click
        If cboCountryFilter.Text = "ALL" Then
            bsCustomers.Filter = ""
        Else
            bsCustomers.Filter = "Country = '" & cboCountryFilter.Text & "'"
        End If
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        bsCustomers.Position = bsCustomers.Find("Identifier", CurrentIdentifier)
    End Sub
    Private Sub bsCustomers_PositionChanged(sender As Object, e As EventArgs) Handles bsCustomers.PositionChanged
        CurrentIdentifier = DirectCast(bsCustomers.Current, DataRowView).Item("Identifier").ToString
    End Sub
    Private Sub cmdGetChecked_Click(sender As Object, e As EventArgs) Handles cmdGetChecked.Click
        Dim Rows As List(Of DataRow) = Nothing

        If cboCountryFilter.Text = "ALL" Then
            Rows =
                (
                    From T In CType(bsCustomers.DataSource, DataTable).AsEnumerable
                    Where T.Field(Of Boolean)("Process")
                ).ToList
        Else
            Console.WriteLine("[{0}]", bsCustomers.Filter)
            Rows =
                (
                    From T In CType(bsCustomers.DataSource, DataTable).AsEnumerable
                    Where T.Field(Of Boolean)("Process") AndAlso
                          T.Field(Of String)("Country") = cboCountryFilter.Text
                ).ToList
        End If

        If Rows.Count > 0 Then
            Dim sb As New System.Text.StringBuilder
            For Each item As DataRow In Rows
                sb.AppendLine(String.Join("-", item.ItemArray))
            Next
            MessageBox.Show(sb.ToString)
        Else
            MessageBox.Show("Nothing checked or you are trying to make me fail by changing the filter text but not changing the actve filter.")
        End If
    End Sub

    Private Sub Demo()
    End Sub


End Class

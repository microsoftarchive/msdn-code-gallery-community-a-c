''' <summary>
''' Simple examples of learning which rows have the CheckBox cell checked
''' via the DataTable and the Row collection in the DataGridView
''' </summary>
''' <remarks></remarks>
Public Class Form1
    WithEvents bsPeople As New BindingSource

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.AllowUserToAddRows = False

        Dim dt = GetMockedData()

        dt.Columns.Add(New DataColumn With {.DataType = GetType(Boolean), .ColumnName = "Process"})
        dt.Columns.Add(New DataColumn With {.DataType = GetType(String), .ColumnName = "Person",
                                            .Expression = " FirstName + ' ' + LastName"})

        dt.Columns("FirstName").ColumnMapping = MappingType.Hidden
        dt.Columns("LastName").ColumnMapping = MappingType.Hidden

        ' Position to first column is optional        
        dt.Columns("Process").SetOrdinal(0)

        ' give each row a value for the injected column
        For Each row As DataRow In dt.Rows
            row("Process") = False
        Next
        dt.AcceptChanges()

        bsPeople.DataSource = dt
        DataGridView1.DataSource = bsPeople
        BindingNavigator1.BindingSource = bsPeople

        ' Next 2 lines for showing row index in RowHeader of DataGridView
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        DataGridView1.EnableHeadersVisualStyles = False

    End Sub
    ''' <summary>
    ''' Simulate loading data from backend database since generally speaking
    ''' data from a database is loaded into a DataTable!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMockedData() As DataTable

        Dim dt As New DataTable()

        dt.Columns.Add("Identifier", GetType(Integer))
        dt.Columns.Add("FirstName", GetType(String))
        dt.Columns.Add("LastName", GetType(String))

        dt.Rows.Add(10, "John", "Smith")
        dt.Rows.Add(20, "Mary", "Willson")
        dt.Rows.Add(30, "Frank", "Mills")
        dt.Rows.Add(40, "Amy", "Jones")
        dt.Rows.Add(50, "Karen", "Starr")

        Return dt

    End Function
    ''' <summary>
    ''' By working with the DataSource of the DataGridView we can get 
    ''' more information unlike working from DataGridViewRow collection
    ''' where if say the ID column was set but not shown we do not
    ''' have access to the data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' We could get fancy with showing results but that is not what we
    ''' are how to learn about.
    ''' </remarks>
    Private Sub cmdCheckedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckedRows_1.Click

        Dim Rows As List(Of DataRow) =
            (
                From T In CType(bsPeople.DataSource, DataTable).AsEnumerable
                Where T.Field(Of Boolean)("Process")
            ).ToList

        If Rows.Count > 0 Then
            Dim sb As New System.Text.StringBuilder
            For Each item As DataRow In Rows
                sb.AppendLine(String.Join("-", item.ItemArray))
            Next
            MessageBox.Show(sb.ToString)
        Else
            MessageBox.Show("Nothing checked")
        End If

    End Sub
    ''' <summary>
    ''' Unlike getting checked rows above which returns the primary key the code
    ''' below does not as normally the primary key is excluded from shown in the
    ''' DataGridView.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdCheckedRows_2_Click(sender As Object, e As EventArgs) Handles cmdCheckedRows_2.Click

        Dim Names =
            (
                From T In DataGridView1.GetChecked("Process")
                Select CStr(T.Cells("Person").Value)
            ).ToArray

        If Names.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, Names))
        Else
            MessageBox.Show("Nothing checked")
        End If

    End Sub
    ''' <summary>
    ''' Show row index in row header cell of each row of the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If Not DataGridView1.Rows(e.RowIndex).IsNewRow Then
            DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        End If
    End Sub
End Class


Public Class frmIncSearch
    Private DataTable As DataTable
    WithEvents bsData As New BindingSource
    Public Sub New(dt As DataTable)
        InitializeComponent()
        Me.DataTable = dt.Copy
    End Sub
    Private Sub IncSearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataTable.DefaultView.Sort = "FirstName"
        bsData.DataSource = Me.DataTable

        DataGridView1.DataSource = bsData
        cboColumnNames.DataSource =
            (
                From T In Me.DataTable.Columns.Cast(Of DataColumn)()
                Where T.ColumnMapping <> MappingType.Hidden
                Select T.ColumnName
            ).ToList

    End Sub
    Private Sub cmdGo_Click(sender As Object, e As EventArgs) Handles cmdGo.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter some text.")
            Exit Sub
        End If

        Dim dt As DataTable = CType(bsData.DataSource, DataTable)

        If bsData.Sort <> cboColumnNames.Text Then
            bsData.Sort = cboColumnNames.Text
        End If

        Dim Result As Int32 = bsData.FindFirst(TextBox1.Text)
        If Result > -1 Then
            bsData.Position = Result
            DataGridView1.CurrentCell = DataGridView1(DataGridView1.Columns(cboColumnNames.Text).Index, bsData.Position)
        Else
            MessageBox.Show("Not located.")
        End If
    End Sub
End Class
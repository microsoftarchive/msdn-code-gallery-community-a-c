''' <summary>
''' Shows how to keep the current row in the DataGrdView current
''' after a sort operation on the DataGridView
''' </summary>
''' <remarks></remarks>
Public Class frmLocateSort
    Private DataTable As DataTable
    WithEvents bsData As New BindingSource
    Private CurrentIdentifier As Int32

    Public Sub New(dt As DataTable)
        InitializeComponent()
        Me.DataTable = dt.Copy
    End Sub
    Private Sub LocateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataTable.DefaultView.Sort = "FirstName"
        bsData.DataSource = Me.DataTable
        DataGridView1.DataSource = bsData
    End Sub
    Private Sub bsData_PositionChanged(sender As Object, e As EventArgs) Handles bsData.PositionChanged
        CurrentIdentifier = CInt(CType(bsData.Current, DataRowView).Item("ID"))
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        bsData.Position = bsData.Find("ID", CurrentIdentifier)
    End Sub
End Class
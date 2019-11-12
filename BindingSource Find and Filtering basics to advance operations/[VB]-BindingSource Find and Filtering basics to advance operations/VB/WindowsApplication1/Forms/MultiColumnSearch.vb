''' <summary>
''' Locate a row by two fields, LastName and State in the Shown event of this form
''' </summary>
''' <remarks></remarks>
Public Class frmMultiColumnSearch
    Private DataTable As DataTable
    WithEvents bsData As New BindingSource
    Private CurrentIdentifier As Int32

    Public Sub New(dt As DataTable)
        InitializeComponent()
        Me.DataTable = dt.Copy
    End Sub

    Private Sub MultiColumnSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataTable.DefaultView.Sort = "LastName"
        bsData.DataSource = Me.DataTable
        DataGridView1.DataSource = bsData
    End Sub

    Private Sub frmMultiColumnSearch_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim LastName As String = "Gallagher"
        Dim State As String = "OR"
        Dim Condition As String = String.Format("LastName = '{0}' AND State = '{1}'", LastName, State)
        Dim dr() As DataRow
        '
        ' Please note the sort and the condition fields match up
        '
        bsData.Sort = "LastName,State"
        dr = Me.DataTable.Select(Condition, bsData.Sort)

        If dr.Count > 0 Then
            Dim CompanyIdentifier As String = dr(0).Item("ID").ToString
            bsData.Locate("ID", CompanyIdentifier)
        Else
            '
            ' Only happens in this demo if someone messed with the data.
            '
            MessageBox.Show("Someone screwed with the backend database table data.")
        End If
    End Sub
End Class
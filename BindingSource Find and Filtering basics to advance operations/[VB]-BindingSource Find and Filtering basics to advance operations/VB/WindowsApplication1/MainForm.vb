Imports System.Data.OleDb
Imports DataAccess

Public Class MainForm
    WithEvents bsCustomers As New BindingSource
    Private NoFilterText As String = "No Filter"
    Private CustomerData As New Customers
    Private Sub cmdCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdCloseForm.Click, ExitToolStripMenuItem.Click

        Close()

    End Sub
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboConditions.DataSource = CType([Enum].GetNames(GetType(LikeOptions)), String()).ToList

        CustomerData.ColumnNames.Insert(0, NoFilterText)
        cboColumnNames.DataSource = CustomerData.ColumnNames

        bsCustomers.DataSource = CustomerData.DataTable
        bsCustomers.Sort = "LastName"

        DataGridView1.DataSource = bsCustomers

    End Sub
    ''' <summary>
    ''' Filter on LastName field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterLastName.Click
        bsCustomers.LikeFilter("LastName", txtLastName.Text, cboConditions.Text.ToEnum(Of LikeOptions))
    End Sub
    ''' <summary>
    ''' Filter on any text field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmdFilterGeneral_Click(sender As Object, e As EventArgs) Handles cmdFilterGeneral.Click
        If cboColumnNames.Text = "No Filter" Then
            bsCustomers.Filter = ""
        Else
            bsCustomers.LikeFilter(cboColumnNames.Text, txtGeneralSearch.Text, cboConditions.Text.ToEnum(Of LikeOptions))
        End If
    End Sub
    Private Sub cmdChildForm_Click(sender As Object, e As EventArgs) Handles cmdChildForm.Click
        Dim f As New frmIncSearch(CustomerData.DataTable)
        Try
            f.Owner = Me
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub SortingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SortingToolStripMenuItem.Click
        Dim f As New frmLocateSort(CustomerData.DataTable)
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub MultiColumnSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultiColumnSearchToolStripMenuItem.Click
        Dim f As New frmMultiColumnSearch(CustomerData.DataTable)
        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub DatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatesToolStripMenuItem.Click
        Dim f As New frmDateForm
        Try
            f.ActiveControl = f.cmdFind
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
End Class

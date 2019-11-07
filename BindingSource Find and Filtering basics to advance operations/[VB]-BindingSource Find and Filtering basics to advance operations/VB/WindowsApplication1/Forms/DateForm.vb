Imports DataAccess
''' <summary>
''' Demo for simple find a row with a specific date.
''' </summary>
''' <remarks></remarks>
Public Class frmDateForm
    WithEvents bsData As New BindingSource
    Private CurrentIdentifier As Int32
    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        '
        ' Make sure to study the code in Locate method and also
        ' how the date separators are done with code in DateCultureInfo
        ' code module
        '
        Dim Index As Int32 = bsData.Locate("OrderDate", CDate(cboDates.Text))
        If Index <> -1 Then
            bsData.Position = Index
        End If
    End Sub
    Private Sub DateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TheOrders As New Orders
        Dim dt As DataTable = TheOrders.DataTable

        bsData.DataSource = dt
        DataGridView1.DataSource = bsData
        cboDates.DataSource = TheOrders.DistinctDates
        cboDates.SelectedIndex = cboDates.Items.Count - 1

    End Sub
    Private Sub bsData_PositionChanged(sender As Object, e As EventArgs) Handles bsData.PositionChanged
        CurrentIdentifier = CInt(CType(bsData.Current, DataRowView).Item("Identifier"))
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        bsData.Position = bsData.Find("Identifier", CurrentIdentifier)
    End Sub
End Class
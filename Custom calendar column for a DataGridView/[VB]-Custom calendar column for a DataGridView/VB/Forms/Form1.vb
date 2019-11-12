Public Class Form1
    WithEvents bsPeople As New BindingSource
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub DGV_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If chkCalendarOneClick.Checked Then
            If DataGridView1(e.ColumnIndex, e.RowIndex).EditType IsNot Nothing Then
                If DataGridView1.IsCalendarCell(e) Then
                    SendKeys.Send("{F2}")
                End If
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bsPeople.DataSource = GetData()
        DataGridView1.DataSource = bsPeople
        AddHandler DataGridView1.CellEnter, AddressOf DGV_CellEnter
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub
    Private Sub cmdNullifyHireDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNullifyHireDate.Click
        bsPeople.WriteCurrentRowHireDateToNothing()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = CType(bsPeople.DataSource, DataTable)
        For Each row As DataRow In dt.Rows
            Console.WriteLine(String.Join(",", row.ItemArray))
        Next
    End Sub
End Class

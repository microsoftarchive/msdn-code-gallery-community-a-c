Public Class Form1
    WithEvents bsData As New BindingSource
    '
    ' Used to know a default for a row where the user
    ' ends up with nothing checked this will ensure
    ' there is a default checked
    '
    Public Defaults As New Dictionary(Of Int32, String)
    Private Function GetMockedData() As DataTable
        Defaults.Add(1, "Check2")
        Defaults.Add(2, "Check1")
        Defaults.Add(3, "Check2")
        Defaults.Add(4, "Check3")
        Defaults.Add(5, "Check3")

        Dim dt As New DataTable

        dt.Columns.AddRange(New DataColumn() _
            {
                New DataColumn("Identifier", GetType(Int32)),
                New DataColumn("Check1", GetType(Boolean)),
                New DataColumn("Check2", GetType(Boolean)),
                New DataColumn("Check3", GetType(Boolean))
            }
        )

        dt.Rows.Add(1, False, True, False)
        dt.Rows.Add(2, True, False, False)
        dt.Rows.Add(3, False, True, False)
        dt.Rows.Add(4, False, False, True)
        dt.Rows.Add(5, False, False, True)

        dt.AcceptChanges()

        Return dt

    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bsData.DataSource = GetMockedData()
        ' Columns are created in the IDE
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsData
    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged

        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        If DataGridView1.CurrentRow IsNot Nothing Then

            Dim SelectedColumnName = DataGridView1.Columns(DataGridView1.CurrentCellValue.ColumnIndex).Name

            If e.ColumnIndex = DataGridView1.Columns("Check1").Index OrElse _
               e.ColumnIndex = DataGridView1.Columns("Check2").Index OrElse _
               e.ColumnIndex = DataGridView1.Columns("Check3").Index Then

                Dim Row = CType((CType(bsData.Current, DataRowView)).Row, DataRow)

                If SelectedColumnName = "Check1" Then
                    If DataGridView1.CurrentRowCellValue("Check1") = "True" Then
                        Row.Item("Check2") = False
                        Row.Item("Check3") = False
                    End If
                ElseIf SelectedColumnName = "Check2" Then
                    If DataGridView1.CurrentRowCellValue("Check2") = "True" Then
                        Row.Item("Check1") = False
                        Row.Item("Check3") = False
                    End If
                ElseIf SelectedColumnName = "Check3" Then
                    If DataGridView1.CurrentRowCellValue("Check3") = "True" Then
                        Row.Item("Check1") = False
                        Row.Item("Check2") = False
                    End If
                End If

                CType(bsData.DataSource, DataTable).AcceptChanges()

                If CType(Row("Check1"), Boolean) = False AndAlso _
                   CType(Row("Check2"), Boolean) = False AndAlso _
                   CType(Row("Check3"), Boolean) = False Then

                    Row(Defaults(CInt(Row("Identifier")))) = True
                    CType(bsData.DataSource, DataTable).AcceptChanges()

                End If

                DataGridView1.CurrentCell = DataGridView1(e.ColumnIndex, e.RowIndex)

            End If
        End If
    End Sub
    Private Sub cmdCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseForm.Click
        Close()
    End Sub
End Class

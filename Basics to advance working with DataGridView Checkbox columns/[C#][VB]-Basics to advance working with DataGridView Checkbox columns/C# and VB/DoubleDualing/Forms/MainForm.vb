Imports System.Runtime.InteropServices

''' <summary>
''' Demonstrates how to toggle two Checkbox columns on a row of a 
''' DataGridView bound to a DataTable from a BindingSource control.
''' </summary>
''' <remarks>
''' * If your DataGridView is not bound to a DataSource then simply update
'''   the current cell value rather than as done here update the underlying data row.
''' 
''' * You could shrink the code used to perform various operations used here by 
'''   removing the language extensions but nothing is truly gained as the language 
'''   extensions cost you basically nothing and they make code easier to read. 
'''   These language extension methods were already coded and copies from a 
'''   central library I used in the form of a DLL with proper accessibility for 
'''   other projects in a solution to use.
''' </remarks>
Public Class frmMainForm
    WithEvents bsData As New BindingSource
    Private Sub cmdCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseForm.Click
        Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bsData.DataSource = GetMockedData()
        DataGridView1.AutoGenerateColumns = False

        DataGridView1.DataSource = bsData
        DataGridView1.Columns("QuestionColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    ''' <summary>
    ''' Logic which toggles the check state of two Checkbox columns on the same row.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.CurrentRow IsNot Nothing Then

            Dim CurrentRow As Int32 = DataGridView1.CurrentCell.RowIndex
            Dim CurrentCol As Int32 = DataGridView1.CurrentCell.ColumnIndex

            If e.ColumnIndex = DataGridView1.Columns("YesResponse").Index OrElse e.ColumnIndex = DataGridView1.Columns("NoResponse").Index Then
                Dim Row = bsData.CurrentRow
                If DataGridView1.SelectedColumnName = "YesResponse" Then
                    If DataGridView1.CurrentRowCellValue("YesResponse") = "True" Then
                        Row.Item("NoResponse") = False
                    Else
                        Row.Item("NoResponse") = True
                    End If
                End If
                If DataGridView1.SelectedColumnName = "NoResponse" Then
                    If DataGridView1.CurrentRowCellValue("NoResponse") = "True" Then
                        Row.Item("YesResponse") = False
                    Else
                        Row.Item("YesResponse") = True
                    End If
                End If

                bsData.DataTable.AcceptChanges()
                DataGridView1.CurrentCell = DataGridView1(CurrentCol, CurrentRow)
            End If
        End If
    End Sub
    Private Sub cmdResults_Click(sender As Object, e As EventArgs) Handles cmdResults.Click
        Dim dt As DataTable = CType(bsData.DataSource, DataTable)
        Dim sb As New System.Text.StringBuilder

        For Each row As DataRow In dt.Rows
            sb.AppendLine(
                String.Format("{0,-30}:{1}",
                              row.Field(Of String)("Question"),
                              CStr(If(row.Field(Of Boolean)("YesResponse"), "Yes", "No"))
                )
            )
        Next

        Dim f As New frmResponse
        Try
            f.TextBox1.Text = sb.ToString
            f.ActiveControl = f.cmdCloseForm
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try

    End Sub
End Class

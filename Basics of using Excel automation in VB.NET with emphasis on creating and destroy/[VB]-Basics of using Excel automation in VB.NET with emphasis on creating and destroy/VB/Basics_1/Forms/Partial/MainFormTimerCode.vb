Partial Class frmMainForm
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
    ''' <summary>
    ''' Not perfect, we are looking to show when Excel is in memory via automation.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ExcelInMemory() Then
            Me.ToolStripSplitButton1.Image = My.Resources.Excel1
        Else
            Me.ToolStripSplitButton1.Image = My.Resources.Excel2
        End If

        Me.ToolStripSplitButton1.Invalidate()
        Application.DoEvents()

        If IO.File.Exists(ExcelFileName) Then
            cmdOpenFile.Enabled = True
            cmdGetCellValue.Enabled = True
        Else
            cmdOpenFile.Enabled = False
            cmdGetCellValue.Enabled = False
        End If
    End Sub

End Class

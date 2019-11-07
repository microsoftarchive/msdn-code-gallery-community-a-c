Public Class frmMainForm
    Private Doc As New XDocument
    Private SettingsFile As String = IO.Path.Combine(Application.StartupPath, "Settings.xml")
    Private ShowMyDialog As Boolean = False


    Private Sub frmMainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Application.DoEvents()

        CreateFileIfMissing(ExcelFileName, True)

        Dim Info As New ExcelInfo(ExcelFileName)
        If Info.GetInformation Then

            cboSheetsNames1.DisplayMember = "Value"
            cboSheetsNames1.ValueMember = "Key"
            cboSheetsNames1.DataSource = Info.SheetsData.ToList

            cboSheetsNames2.DisplayMember = "Value"
            cboSheetsNames2.DataSource = Info.SheetsData.ToList

            If cboSheetsNames1.Items.Count > -1 Then
                cboSheetsNames1.SelectedIndex = 0
                cboCellAddress.SelectedIndex = 0
            End If
        End If

        ActiveControl = cmdGetCellValue


        Doc = XDocument.Load(SettingsFile)
        Dim Setting = From O In Doc...<Dialog>
        ShowMyDialog = Convert.ToBoolean(Setting.@Show)
        If ShowMyDialog Then
            Dim f As New frmMyDialog
            Try
                f.ShowDialog()
                ShowMyDialog = Not f.chkDoNoShow.Checked
                Setting.@Show = ShowMyDialog.ToString
                Doc.Save(SettingsFile)
            Finally
                f.Dispose()
            End Try
        End If



    End Sub
    ''' <summary>
    ''' Starts Excel (You must have Excel or Excel run time reader for this to work)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFile.Click
        Process.Start(ExcelFileName)
    End Sub
    Private Sub cmdGetCellValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetCellValue.Click
        OpenExcel(ExcelFileName, cboSheetsNames1.Text, cboCellAddress.Text)
    End Sub
    Private Sub cmdSelectSheetByOrdinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectSheetByOrdinal.Click
        OpenSheetByIndex(ExcelFileName, CInt(cboSheetsNames1.SelectedValue))
    End Sub
    Private Sub cmdSelectSheetByName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectSheetByName.Click
        OpenExcel(ExcelFileName, cboSheetsNames1.Text)
    End Sub
    ''' <summary>
    ''' Show a range using OleDb into a DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdShowInDataGridView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowInDataGridView.Click
        OpenSheetInDataGridView(ExcelFileName, cboSheetsNames2.Text)
    End Sub
    ''' <summary>
    ''' Returns number of used rows for a specific worksheet
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdUsedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsedRows.Click
        Dim Rows As Integer = UsedRows(ExcelFileName, cboSheetsNames1.Text)
        MessageBox.Show(String.Format("'{0}' in '{1}' used rows is {2}", cboSheetsNames1.Text, ExcelFileName, Rows.ToString))
    End Sub
    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick
        MessageBox.Show("When an Excel image being displayed Excel is in memory, A green dot image, Excel is not in memory.")
    End Sub
    Private Sub frmMainForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(Rect, Color.Beige, Color.LightSkyBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, Rect)
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub
End Class

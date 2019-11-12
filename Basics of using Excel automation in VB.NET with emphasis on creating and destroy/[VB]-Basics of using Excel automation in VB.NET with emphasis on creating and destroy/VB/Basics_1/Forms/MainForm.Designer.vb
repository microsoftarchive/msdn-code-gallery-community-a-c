<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cboSheetsNames1 = New System.Windows.Forms.ComboBox()
        Me.cmdGetCellValue = New System.Windows.Forms.Button()
        Me.cmdOpenFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdUsedRows = New System.Windows.Forms.Button()
        Me.cboCellAddress = New System.Windows.Forms.ComboBox()
        Me.cmdSelectSheetByOrdinal = New System.Windows.Forms.Button()
        Me.cmdSelectSheetByName = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSheetsNames2 = New System.Windows.Forms.ComboBox()
        Me.cmdShowInDataGridView = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 293)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(500, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.AutoSize = False
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = Global.Basics_1.My.Resources.Resources.Excel1
        Me.ToolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(50, 20)
        '
        'cboSheetsNames1
        '
        Me.cboSheetsNames1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetsNames1.FormattingEnabled = True
        Me.cboSheetsNames1.Location = New System.Drawing.Point(6, 19)
        Me.cboSheetsNames1.Name = "cboSheetsNames1"
        Me.cboSheetsNames1.Size = New System.Drawing.Size(152, 21)
        Me.cboSheetsNames1.TabIndex = 0
        '
        'cmdGetCellValue
        '
        Me.cmdGetCellValue.Location = New System.Drawing.Point(183, 19)
        Me.cmdGetCellValue.Name = "cmdGetCellValue"
        Me.cmdGetCellValue.Size = New System.Drawing.Size(75, 23)
        Me.cmdGetCellValue.TabIndex = 1
        Me.cmdGetCellValue.Text = "Get"
        Me.cmdGetCellValue.UseVisualStyleBackColor = True
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.Location = New System.Drawing.Point(7, 256)
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.Size = New System.Drawing.Size(75, 23)
        Me.cmdOpenFile.TabIndex = 2
        Me.cmdOpenFile.Text = "Open"
        Me.cmdOpenFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdUsedRows)
        Me.GroupBox1.Controls.Add(Me.cboCellAddress)
        Me.GroupBox1.Controls.Add(Me.cboSheetsNames1)
        Me.GroupBox1.Controls.Add(Me.cmdGetCellValue)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 83)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Read"
        '
        'cmdUsedRows
        '
        Me.cmdUsedRows.Location = New System.Drawing.Point(183, 46)
        Me.cmdUsedRows.Name = "cmdUsedRows"
        Me.cmdUsedRows.Size = New System.Drawing.Size(75, 23)
        Me.cmdUsedRows.TabIndex = 3
        Me.cmdUsedRows.Text = "Used Rows"
        Me.cmdUsedRows.UseVisualStyleBackColor = True
        '
        'cboCellAddress
        '
        Me.cboCellAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCellAddress.FormattingEnabled = True
        Me.cboCellAddress.Items.AddRange(New Object() {"A2", "A3", "A4", "A5", "A6", "A7", "B2", "B3", "B4", "B5", "B6", "B7"})
        Me.cboCellAddress.Location = New System.Drawing.Point(6, 46)
        Me.cboCellAddress.Name = "cboCellAddress"
        Me.cboCellAddress.Size = New System.Drawing.Size(152, 21)
        Me.cboCellAddress.TabIndex = 2
        '
        'cmdSelectSheetByOrdinal
        '
        Me.cmdSelectSheetByOrdinal.Location = New System.Drawing.Point(298, 54)
        Me.cmdSelectSheetByOrdinal.Name = "cmdSelectSheetByOrdinal"
        Me.cmdSelectSheetByOrdinal.Size = New System.Drawing.Size(160, 23)
        Me.cmdSelectSheetByOrdinal.TabIndex = 2
        Me.cmdSelectSheetByOrdinal.Text = "Select sheet by ordinal"
        Me.cmdSelectSheetByOrdinal.UseVisualStyleBackColor = True
        '
        'cmdSelectSheetByName
        '
        Me.cmdSelectSheetByName.Location = New System.Drawing.Point(298, 83)
        Me.cmdSelectSheetByName.Name = "cmdSelectSheetByName"
        Me.cmdSelectSheetByName.Size = New System.Drawing.Size(160, 23)
        Me.cmdSelectSheetByName.TabIndex = 3
        Me.cmdSelectSheetByName.Text = "Select sheet by Name"
        Me.cmdSelectSheetByName.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmdSelectSheetByName)
        Me.Panel1.Controls.Add(Me.cmdSelectSheetByOrdinal)
        Me.Panel1.Location = New System.Drawing.Point(7, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 127)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code within this panel is all done via automation"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdShowInDataGridView)
        Me.Panel2.Controls.Add(Me.cboSheetsNames2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(7, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(482, 100)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Code within this panel is all done via OleDb"
        '
        'cboSheetsNames2
        '
        Me.cboSheetsNames2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetsNames2.FormattingEnabled = True
        Me.cboSheetsNames2.Location = New System.Drawing.Point(21, 27)
        Me.cboSheetsNames2.Name = "cboSheetsNames2"
        Me.cboSheetsNames2.Size = New System.Drawing.Size(152, 21)
        Me.cboSheetsNames2.TabIndex = 1
        '
        'cmdShowInDataGridView
        '
        Me.cmdShowInDataGridView.Location = New System.Drawing.Point(198, 25)
        Me.cmdShowInDataGridView.Name = "cmdShowInDataGridView"
        Me.cmdShowInDataGridView.Size = New System.Drawing.Size(75, 23)
        Me.cmdShowInDataGridView.TabIndex = 2
        Me.cmdShowInDataGridView.Text = "Get"
        Me.cmdShowInDataGridView.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(414, 256)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 315)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdOpenFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Basics 1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cboSheetsNames1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGetCellValue As System.Windows.Forms.Button
    Friend WithEvents cmdOpenFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCellAddress As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUsedRows As System.Windows.Forms.Button
    Friend WithEvents cmdSelectSheetByOrdinal As System.Windows.Forms.Button
    Friend WithEvents cmdSelectSheetByName As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboSheetsNames2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdShowInDataGridView As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdChildForm = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboColumnNames = New System.Windows.Forms.ComboBox()
        Me.cboConditions = New System.Windows.Forms.ComboBox()
        Me.cmdFilterGeneral = New System.Windows.Forms.Button()
        Me.cmdFilterLastName = New System.Windows.Forms.Button()
        Me.txtGeneralSearch = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCloseForm = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DemosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiColumnSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(915, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdChildForm)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cboColumnNames)
        Me.Panel1.Controls.Add(Me.cboConditions)
        Me.Panel1.Controls.Add(Me.cmdFilterGeneral)
        Me.Panel1.Controls.Add(Me.cmdFilterLastName)
        Me.Panel1.Controls.Add(Me.txtGeneralSearch)
        Me.Panel1.Controls.Add(Me.txtLastName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdCloseForm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 339)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 150)
        Me.Panel1.TabIndex = 2
        '
        'cmdChildForm
        '
        Me.cmdChildForm.Location = New System.Drawing.Point(802, 62)
        Me.cmdChildForm.Name = "cmdChildForm"
        Me.cmdChildForm.Size = New System.Drawing.Size(100, 28)
        Me.cmdChildForm.TabIndex = 9
        Me.cmdChildForm.Text = "Child Form"
        Me.cmdChildForm.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(555, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(218, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "(Use this combo for both filtering)"
        '
        'cboColumnNames
        '
        Me.cboColumnNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumnNames.FormattingEnabled = True
        Me.cboColumnNames.Location = New System.Drawing.Point(388, 62)
        Me.cboColumnNames.Margin = New System.Windows.Forms.Padding(4)
        Me.cboColumnNames.Name = "cboColumnNames"
        Me.cboColumnNames.Size = New System.Drawing.Size(160, 24)
        Me.cboColumnNames.TabIndex = 6
        '
        'cboConditions
        '
        Me.cboConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConditions.FormattingEnabled = True
        Me.cboConditions.Location = New System.Drawing.Point(388, 11)
        Me.cboConditions.Margin = New System.Windows.Forms.Padding(4)
        Me.cboConditions.Name = "cboConditions"
        Me.cboConditions.Size = New System.Drawing.Size(160, 24)
        Me.cboConditions.TabIndex = 2
        '
        'cmdFilterGeneral
        '
        Me.cmdFilterGeneral.Location = New System.Drawing.Point(276, 62)
        Me.cmdFilterGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFilterGeneral.Name = "cmdFilterGeneral"
        Me.cmdFilterGeneral.Size = New System.Drawing.Size(100, 28)
        Me.cmdFilterGeneral.TabIndex = 5
        Me.cmdFilterGeneral.Text = "Filter"
        Me.cmdFilterGeneral.UseVisualStyleBackColor = True
        '
        'cmdFilterLastName
        '
        Me.cmdFilterLastName.Location = New System.Drawing.Point(277, 9)
        Me.cmdFilterLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFilterLastName.Name = "cmdFilterLastName"
        Me.cmdFilterLastName.Size = New System.Drawing.Size(100, 28)
        Me.cmdFilterLastName.TabIndex = 1
        Me.cmdFilterLastName.Text = "Filter"
        Me.cmdFilterLastName.UseVisualStyleBackColor = True
        '
        'txtGeneralSearch
        '
        Me.txtGeneralSearch.Location = New System.Drawing.Point(136, 68)
        Me.txtGeneralSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGeneralSearch.Name = "txtGeneralSearch"
        Me.txtGeneralSearch.Size = New System.Drawing.Size(132, 22)
        Me.txtGeneralSearch.TabIndex = 8
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(136, 12)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(132, 22)
        Me.txtLastName.TabIndex = 0
        Me.txtLastName.Text = "sm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Search for"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Partial last name"
        '
        'cmdCloseForm
        '
        Me.cmdCloseForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseForm.Location = New System.Drawing.Point(802, 105)
        Me.cmdCloseForm.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCloseForm.Name = "cmdCloseForm"
        Me.cmdCloseForm.Size = New System.Drawing.Size(100, 28)
        Me.cmdCloseForm.TabIndex = 10
        Me.cmdCloseForm.Text = "E&xit"
        Me.cmdCloseForm.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 28)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(915, 311)
        Me.DataGridView1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DemosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(915, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(102, 24)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DemosToolStripMenuItem
        '
        Me.DemosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SortingToolStripMenuItem, Me.MultiColumnSearchToolStripMenuItem, Me.DatesToolStripMenuItem})
        Me.DemosToolStripMenuItem.Name = "DemosToolStripMenuItem"
        Me.DemosToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.DemosToolStripMenuItem.Text = "Demos"
        '
        'SortingToolStripMenuItem
        '
        Me.SortingToolStripMenuItem.Name = "SortingToolStripMenuItem"
        Me.SortingToolStripMenuItem.Size = New System.Drawing.Size(217, 24)
        Me.SortingToolStripMenuItem.Text = "Sorting"
        '
        'MultiColumnSearchToolStripMenuItem
        '
        Me.MultiColumnSearchToolStripMenuItem.Name = "MultiColumnSearchToolStripMenuItem"
        Me.MultiColumnSearchToolStripMenuItem.Size = New System.Drawing.Size(217, 24)
        Me.MultiColumnSearchToolStripMenuItem.Text = "Multi-Column Search"
        '
        'DatesToolStripMenuItem
        '
        Me.DatesToolStripMenuItem.Name = "DatesToolStripMenuItem"
        Me.DatesToolStripMenuItem.Size = New System.Drawing.Size(217, 24)
        Me.DatesToolStripMenuItem.Text = "Dates"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 511)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdCloseForm As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFilterLastName As System.Windows.Forms.Button
    Friend WithEvents cboConditions As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFilterGeneral As System.Windows.Forms.Button
    Friend WithEvents txtGeneralSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboColumnNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdChildForm As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DemosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultiColumnSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

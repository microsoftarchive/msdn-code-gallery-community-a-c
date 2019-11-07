<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkSheetAddDeleteRenameForm
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewSheetName = New System.Windows.Forms.TextBox()
        Me.newWorkSheetButton = New System.Windows.Forms.Button()
        Me.removeWorkSheetButton = New System.Windows.Forms.Button()
        Me.renameWorkSheetButton = New System.Windows.Forms.Button()
        Me.txtNewWorkSheetName = New System.Windows.Forms.TextBox()
        Me.insertNewRowButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 25)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(384, 95)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "AddDeleteRename.xlsx WorkSheets"
        '
        'txtNewSheetName
        '
        Me.txtNewSheetName.Location = New System.Drawing.Point(121, 168)
        Me.txtNewSheetName.Name = "txtNewSheetName"
        Me.txtNewSheetName.Size = New System.Drawing.Size(247, 20)
        Me.txtNewSheetName.TabIndex = 2
        '
        'newWorkSheetButton
        '
        Me.newWorkSheetButton.Location = New System.Drawing.Point(24, 133)
        Me.newWorkSheetButton.Name = "newWorkSheetButton"
        Me.newWorkSheetButton.Size = New System.Drawing.Size(75, 23)
        Me.newWorkSheetButton.TabIndex = 3
        Me.newWorkSheetButton.Text = "New"
        Me.newWorkSheetButton.UseVisualStyleBackColor = True
        '
        'removeWorkSheetButton
        '
        Me.removeWorkSheetButton.Location = New System.Drawing.Point(24, 191)
        Me.removeWorkSheetButton.Name = "removeWorkSheetButton"
        Me.removeWorkSheetButton.Size = New System.Drawing.Size(75, 23)
        Me.removeWorkSheetButton.TabIndex = 4
        Me.removeWorkSheetButton.Text = "Remove"
        Me.removeWorkSheetButton.UseVisualStyleBackColor = True
        '
        'renameWorkSheetButton
        '
        Me.renameWorkSheetButton.Location = New System.Drawing.Point(24, 162)
        Me.renameWorkSheetButton.Name = "renameWorkSheetButton"
        Me.renameWorkSheetButton.Size = New System.Drawing.Size(75, 23)
        Me.renameWorkSheetButton.TabIndex = 5
        Me.renameWorkSheetButton.Text = "Rename"
        Me.renameWorkSheetButton.UseVisualStyleBackColor = True
        '
        'txtNewWorkSheetName
        '
        Me.txtNewWorkSheetName.Location = New System.Drawing.Point(121, 139)
        Me.txtNewWorkSheetName.Name = "txtNewWorkSheetName"
        Me.txtNewWorkSheetName.Size = New System.Drawing.Size(247, 20)
        Me.txtNewWorkSheetName.TabIndex = 6
        '
        'insertNewRowButton
        '
        Me.insertNewRowButton.Location = New System.Drawing.Point(6, 28)
        Me.insertNewRowButton.Name = "insertNewRowButton"
        Me.insertNewRowButton.Size = New System.Drawing.Size(75, 23)
        Me.insertNewRowButton.TabIndex = 7
        Me.insertNewRowButton.Text = "InsertRow"
        Me.insertNewRowButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.insertNewRowButton)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 231)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 106)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insert"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(103, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(156, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(103, 54)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(156, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(103, 80)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(156, 20)
        Me.TextBox3.TabIndex = 2
        '
        'WorkSheetAddDeleteRenameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtNewWorkSheetName)
        Me.Controls.Add(Me.renameWorkSheetButton)
        Me.Controls.Add(Me.removeWorkSheetButton)
        Me.Controls.Add(Me.newWorkSheetButton)
        Me.Controls.Add(Me.txtNewSheetName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "WorkSheetAddDeleteRenameForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WorkSheet Add Delete Rename"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNewSheetName As TextBox
    Friend WithEvents newWorkSheetButton As Button
    Friend WithEvents removeWorkSheetButton As Button
    Friend WithEvents renameWorkSheetButton As Button
    Friend WithEvents txtNewWorkSheetName As TextBox
    Friend WithEvents insertNewRowButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class

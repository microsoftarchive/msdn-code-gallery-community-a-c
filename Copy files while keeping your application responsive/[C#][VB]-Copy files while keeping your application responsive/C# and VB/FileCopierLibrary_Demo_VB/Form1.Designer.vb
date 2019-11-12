<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtEndDirectory = New System.Windows.Forms.TextBox()
        Me.txtStartDirectory = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCopyFiles = New System.Windows.Forms.Button()
        Me.chkSlowProcessDown = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtEndDirectory
        '
        Me.txtEndDirectory.Location = New System.Drawing.Point(162, 75)
        Me.txtEndDirectory.Name = "txtEndDirectory"
        Me.txtEndDirectory.Size = New System.Drawing.Size(316, 22)
        Me.txtEndDirectory.TabIndex = 3
        '
        'txtStartDirectory
        '
        Me.txtStartDirectory.Location = New System.Drawing.Point(162, 37)
        Me.txtStartDirectory.Name = "txtStartDirectory"
        Me.txtStartDirectory.Size = New System.Drawing.Size(316, 22)
        Me.txtStartDirectory.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destination folder"
        '
        'cmdCopyFiles
        '
        Me.cmdCopyFiles.Location = New System.Drawing.Point(28, 116)
        Me.cmdCopyFiles.Name = "cmdCopyFiles"
        Me.cmdCopyFiles.Size = New System.Drawing.Size(450, 29)
        Me.cmdCopyFiles.TabIndex = 4
        Me.cmdCopyFiles.Text = "Copy files in folder"
        Me.cmdCopyFiles.UseVisualStyleBackColor = True
        '
        'chkSlowProcessDown
        '
        Me.chkSlowProcessDown.AutoSize = True
        Me.chkSlowProcessDown.Location = New System.Drawing.Point(28, 160)
        Me.chkSlowProcessDown.Name = "chkSlowProcessDown"
        Me.chkSlowProcessDown.Size = New System.Drawing.Size(150, 21)
        Me.chkSlowProcessDown.TabIndex = 5
        Me.chkSlowProcessDown.Text = "Slow down process"
        Me.chkSlowProcessDown.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 207)
        Me.Controls.Add(Me.chkSlowProcessDown)
        Me.Controls.Add(Me.cmdCopyFiles)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEndDirectory)
        Me.Controls.Add(Me.txtStartDirectory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo with splash and custom class"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEndDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCopyFiles As System.Windows.Forms.Button
    Friend WithEvents chkSlowProcessDown As System.Windows.Forms.CheckBox

End Class

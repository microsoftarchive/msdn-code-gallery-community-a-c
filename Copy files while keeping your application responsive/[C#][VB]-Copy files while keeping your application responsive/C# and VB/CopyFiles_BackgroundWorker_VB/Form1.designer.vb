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
        Me.txtStartDirectory = New System.Windows.Forms.TextBox()
        Me.txtEndDirectory = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.cmdCopyFolder = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'txtStartDirectory
        '
        Me.txtStartDirectory.Location = New System.Drawing.Point(39, 12)
        Me.txtStartDirectory.Name = "txtStartDirectory"
        Me.txtStartDirectory.Size = New System.Drawing.Size(252, 22)
        Me.txtStartDirectory.TabIndex = 0
        '
        'txtEndDirectory
        '
        Me.txtEndDirectory.Location = New System.Drawing.Point(39, 40)
        Me.txtEndDirectory.Name = "txtEndDirectory"
        Me.txtEndDirectory.Size = New System.Drawing.Size(252, 22)
        Me.txtEndDirectory.TabIndex = 1
        '
        'BackgroundWorker1
        '
        '
        'cmdCopyFolder
        '
        Me.cmdCopyFolder.Location = New System.Drawing.Point(39, 97)
        Me.cmdCopyFolder.Name = "cmdCopyFolder"
        Me.cmdCopyFolder.Size = New System.Drawing.Size(252, 27)
        Me.cmdCopyFolder.TabIndex = 3
        Me.cmdCopyFolder.Text = "Copy folder"
        Me.cmdCopyFolder.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(39, 68)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(252, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 151)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cmdCopyFolder)
        Me.Controls.Add(Me.txtEndDirectory)
        Me.Controls.Add(Me.txtStartDirectory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple Backgrounder worker copy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDirectory As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdCopyFolder As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class

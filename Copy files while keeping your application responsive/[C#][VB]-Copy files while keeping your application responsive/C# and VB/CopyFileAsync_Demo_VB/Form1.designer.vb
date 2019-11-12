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
        Me.cmdCopyFilesAsync = New System.Windows.Forms.Button()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblToo = New System.Windows.Forms.Label()
        Me.txtStartDirectory = New System.Windows.Forms.TextBox()
        Me.txtEndDirectory = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCopyFilesAsync
        '
        Me.cmdCopyFilesAsync.Location = New System.Drawing.Point(23, 169)
        Me.cmdCopyFilesAsync.Name = "cmdCopyFilesAsync"
        Me.cmdCopyFilesAsync.Size = New System.Drawing.Size(315, 30)
        Me.cmdCopyFilesAsync.TabIndex = 6
        Me.cmdCopyFilesAsync.Text = "Copy files"
        Me.cmdCopyFilesAsync.UseVisualStyleBackColor = True
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(88, 22)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(51, 17)
        Me.lblFrom.TabIndex = 0
        Me.lblFrom.Text = "source"
        '
        'lblToo
        '
        Me.lblToo.AutoSize = True
        Me.lblToo.Location = New System.Drawing.Point(88, 48)
        Me.lblToo.Name = "lblToo"
        Me.lblToo.Size = New System.Drawing.Size(77, 17)
        Me.lblToo.TabIndex = 1
        Me.lblToo.Text = "destination"
        '
        'txtStartDirectory
        '
        Me.txtStartDirectory.Location = New System.Drawing.Point(145, 86)
        Me.txtStartDirectory.Name = "txtStartDirectory"
        Me.txtStartDirectory.Size = New System.Drawing.Size(193, 22)
        Me.txtStartDirectory.TabIndex = 3
        '
        'txtEndDirectory
        '
        Me.txtEndDirectory.Location = New System.Drawing.Point(145, 127)
        Me.txtEndDirectory.Name = "txtEndDirectory"
        Me.txtEndDirectory.Size = New System.Drawing.Size(193, 22)
        Me.txtEndDirectory.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Destination folder"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Source folder"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 239)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEndDirectory)
        Me.Controls.Add(Me.txtStartDirectory)
        Me.Controls.Add(Me.lblToo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.cmdCopyFilesAsync)
        Me.Name = "Form1"
        Me.Text = "Simple Async file copy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCopyFilesAsync As System.Windows.Forms.Button
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblToo As System.Windows.Forms.Label
    Friend WithEvents txtStartDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

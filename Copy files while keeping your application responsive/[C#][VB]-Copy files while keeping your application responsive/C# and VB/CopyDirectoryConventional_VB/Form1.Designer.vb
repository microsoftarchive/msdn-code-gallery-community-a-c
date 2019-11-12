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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEndDirectory = New System.Windows.Forms.TextBox()
        Me.txtStartDirectory = New System.Windows.Forms.TextBox()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destination folder"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source folder"
        '
        'txtEndDirectory
        '
        Me.txtEndDirectory.Location = New System.Drawing.Point(170, 69)
        Me.txtEndDirectory.Name = "txtEndDirectory"
        Me.txtEndDirectory.Size = New System.Drawing.Size(193, 22)
        Me.txtEndDirectory.TabIndex = 3
        Me.txtEndDirectory.Text = "C:\data\0Target"
        '
        'txtStartDirectory
        '
        Me.txtStartDirectory.Location = New System.Drawing.Point(170, 28)
        Me.txtStartDirectory.Name = "txtStartDirectory"
        Me.txtStartDirectory.Size = New System.Drawing.Size(193, 22)
        Me.txtStartDirectory.TabIndex = 1
        Me.txtStartDirectory.Text = "C:\data"
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(57, 107)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(315, 30)
        Me.cmdCopy.TabIndex = 4
        Me.cmdCopy.Text = "Copy files"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(12, 167)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(382, 44)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 220)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEndDirectory)
        Me.Controls.Add(Me.txtStartDirectory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEndDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDirectory As System.Windows.Forms.TextBox
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label

End Class

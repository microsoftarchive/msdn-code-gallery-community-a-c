<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class alarmSetter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.t1 = New System.Windows.Forms.TextBox
        Me.t2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        't1
        '
        Me.t1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.t1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t1.Location = New System.Drawing.Point(42, 50)
        Me.t1.MaxLength = 2
        Me.t1.Name = "t1"
        Me.t1.ShortcutsEnabled = False
        Me.t1.Size = New System.Drawing.Size(17, 19)
        Me.t1.TabIndex = 15
        Me.t1.Text = "12"
        Me.t1.WordWrap = False
        '
        't2
        '
        Me.t2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.t2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t2.Location = New System.Drawing.Point(64, 50)
        Me.t2.MaxLength = 2
        Me.t2.Name = "t2"
        Me.t2.ShortcutsEnabled = False
        Me.t2.Size = New System.Drawing.Size(18, 19)
        Me.t2.TabIndex = 16
        Me.t2.Text = "00"
        Me.t2.WordWrap = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(54, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(15, 19)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 16)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "Alarm On?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Location = New System.Drawing.Point(13, 92)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(83, 23)
        Me.Command1.TabIndex = 19
        Me.Command1.Text = "Test Alarm"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'alarmSetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.Label2)
        Me.Name = "alarmSetter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents t1 As System.Windows.Forms.TextBox
    Friend WithEvents t2 As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Command1 As System.Windows.Forms.Button

End Class

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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnalogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DigitalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AlarmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TypeToolStripMenuItem, Me.AlarmToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TypeToolStripMenuItem
        '
        Me.TypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnalogToolStripMenuItem, Me.DigitalToolStripMenuItem})
        Me.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem"
        Me.TypeToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.TypeToolStripMenuItem.Text = "Type"
        '
        'AnalogToolStripMenuItem
        '
        Me.AnalogToolStripMenuItem.CheckOnClick = True
        Me.AnalogToolStripMenuItem.Name = "AnalogToolStripMenuItem"
        Me.AnalogToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.AnalogToolStripMenuItem.Text = "Analog"
        '
        'DigitalToolStripMenuItem
        '
        Me.DigitalToolStripMenuItem.CheckOnClick = True
        Me.DigitalToolStripMenuItem.Name = "DigitalToolStripMenuItem"
        Me.DigitalToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.DigitalToolStripMenuItem.Text = "Digital"
        '
        'AlarmToolStripMenuItem
        '
        Me.AlarmToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TimeToolStripMenuItem})
        Me.AlarmToolStripMenuItem.Name = "AlarmToolStripMenuItem"
        Me.AlarmToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.AlarmToolStripMenuItem.Text = "Alarm"
        '
        'TimeToolStripMenuItem
        '
        Me.TimeToolStripMenuItem.Name = "TimeToolStripMenuItem"
        Me.TimeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TimeToolStripMenuItem.Text = "Time"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 536)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alarm Clock"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DigitalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlarmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

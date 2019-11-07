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
        Me.GroupBoxEx1 = New GroupBoxEx_Demo.GroupBoxEx
        Me.GroupBoxEx2 = New GroupBoxEx_Demo.GroupBoxEx
        Me.GroupBoxEx4 = New GroupBoxEx_Demo.GroupBoxEx
        Me.GroupBoxEx3 = New GroupBoxEx_Demo.GroupBoxEx
        Me.SuspendLayout()
        '
        'GroupBoxEx1
        '
        Me.GroupBoxEx1.BackgroundPanelImage = Nothing
        Me.GroupBoxEx1.DrawGroupBorder = True
        Me.GroupBoxEx1.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEx1.ForeColor = System.Drawing.Color.Red
        Me.GroupBoxEx1.GroupBorderColor = System.Drawing.Color.Black
        Me.GroupBoxEx1.GroupPanelColor = System.Drawing.SystemColors.Control
        Me.GroupBoxEx1.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Squared
        Me.GroupBoxEx1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxEx1.Name = "GroupBoxEx1"
        Me.GroupBoxEx1.Size = New System.Drawing.Size(180, 100)
        Me.GroupBoxEx1.TabIndex = 0
        Me.GroupBoxEx1.TabStop = False
        Me.GroupBoxEx1.Text = "GroupBoxEx1"
        Me.GroupBoxEx1.TextBackColor = System.Drawing.Color.White
        Me.GroupBoxEx1.TextBorderColor = System.Drawing.Color.Black
        '
        'GroupBoxEx2
        '
        Me.GroupBoxEx2.BackgroundPanelImage = Nothing
        Me.GroupBoxEx2.DrawGroupBorder = True
        Me.GroupBoxEx2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEx2.ForeColor = System.Drawing.Color.Lime
        Me.GroupBoxEx2.GroupBorderColor = System.Drawing.Color.Black
        Me.GroupBoxEx2.GroupPanelColor = System.Drawing.Color.Transparent
        Me.GroupBoxEx2.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Squared
        Me.GroupBoxEx2.Location = New System.Drawing.Point(12, 118)
        Me.GroupBoxEx2.Name = "GroupBoxEx2"
        Me.GroupBoxEx2.Size = New System.Drawing.Size(180, 100)
        Me.GroupBoxEx2.TabIndex = 1
        Me.GroupBoxEx2.TabStop = False
        Me.GroupBoxEx2.Text = "GroupBoxEx2"
        Me.GroupBoxEx2.TextBackColor = System.Drawing.Color.Black
        Me.GroupBoxEx2.TextBorderColor = System.Drawing.Color.Lime
        '
        'GroupBoxEx4
        '
        Me.GroupBoxEx4.BackgroundPanelImage = Global.GroupBoxEx_Demo.My.Resources.Resources.RedCircle
        Me.GroupBoxEx4.DrawGroupBorder = True
        Me.GroupBoxEx4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEx4.ForeColor = System.Drawing.Color.Red
        Me.GroupBoxEx4.GroupBorderColor = System.Drawing.Color.Black
        Me.GroupBoxEx4.GroupPanelColor = System.Drawing.Color.Transparent
        Me.GroupBoxEx4.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Rounded
        Me.GroupBoxEx4.Location = New System.Drawing.Point(207, 118)
        Me.GroupBoxEx4.Name = "GroupBoxEx4"
        Me.GroupBoxEx4.Size = New System.Drawing.Size(180, 100)
        Me.GroupBoxEx4.TabIndex = 3
        Me.GroupBoxEx4.TabStop = False
        Me.GroupBoxEx4.Text = "GroupBoxEx4"
        Me.GroupBoxEx4.TextBackColor = System.Drawing.Color.Yellow
        Me.GroupBoxEx4.TextBorderColor = System.Drawing.Color.Black
        '
        'GroupBoxEx3
        '
        Me.GroupBoxEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBoxEx3.BackgroundPanelImage = Global.GroupBoxEx_Demo.My.Resources.Resources.Blue_n_White
        Me.GroupBoxEx3.DrawGroupBorder = True
        Me.GroupBoxEx3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEx3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBoxEx3.GroupBorderColor = System.Drawing.Color.Black
        Me.GroupBoxEx3.GroupPanelColor = System.Drawing.SystemColors.Control
        Me.GroupBoxEx3.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Rounded
        Me.GroupBoxEx3.Location = New System.Drawing.Point(207, 12)
        Me.GroupBoxEx3.Name = "GroupBoxEx3"
        Me.GroupBoxEx3.Size = New System.Drawing.Size(180, 100)
        Me.GroupBoxEx3.TabIndex = 2
        Me.GroupBoxEx3.TabStop = False
        Me.GroupBoxEx3.Text = "GroupBoxEx3"
        Me.GroupBoxEx3.TextBackColor = System.Drawing.Color.White
        Me.GroupBoxEx3.TextBorderColor = System.Drawing.Color.Black
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GroupBoxEx_Demo.My.Resources.Resources.BackgroundImage
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(397, 231)
        Me.Controls.Add(Me.GroupBoxEx4)
        Me.Controls.Add(Me.GroupBoxEx3)
        Me.Controls.Add(Me.GroupBoxEx2)
        Me.Controls.Add(Me.GroupBoxEx1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "GroupBoxEx Demo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxEx1 As GroupBoxEx_Demo.GroupBoxEx
    Friend WithEvents GroupBoxEx2 As GroupBoxEx_Demo.GroupBoxEx
    Friend WithEvents GroupBoxEx3 As GroupBoxEx_Demo.GroupBoxEx
    Friend WithEvents GroupBoxEx4 As GroupBoxEx_Demo.GroupBoxEx

End Class

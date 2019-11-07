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
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdCustomers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdAdmin
        '
        Me.cmdAdmin.Image = Global.CheckedSimple_MS_Access.My.Resources.Resources.Administrator
        Me.cmdAdmin.Location = New System.Drawing.Point(267, 22)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(218, 167)
        Me.cmdAdmin.TabIndex = 1
        Me.cmdAdmin.UseVisualStyleBackColor = True
        '
        'cmdCustomers
        '
        Me.cmdCustomers.Image = Global.CheckedSimple_MS_Access.My.Resources.Resources.Customers
        Me.cmdCustomers.Location = New System.Drawing.Point(12, 22)
        Me.cmdCustomers.Name = "cmdCustomers"
        Me.cmdCustomers.Size = New System.Drawing.Size(218, 167)
        Me.cmdCustomers.TabIndex = 0
        Me.cmdCustomers.UseVisualStyleBackColor = True
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 213)
        Me.Controls.Add(Me.cmdAdmin)
        Me.Controls.Add(Me.cmdCustomers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCustomers As System.Windows.Forms.Button
    Friend WithEvents cmdAdmin As System.Windows.Forms.Button
End Class

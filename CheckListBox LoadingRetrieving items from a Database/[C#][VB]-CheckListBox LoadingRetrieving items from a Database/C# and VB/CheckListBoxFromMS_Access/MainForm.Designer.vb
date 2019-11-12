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
        Me.cmdFromDatabaseExample = New System.Windows.Forms.Button()
        Me.cmdStaticDataTableExample = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdFromDatabaseExample
        '
        Me.cmdFromDatabaseExample.Location = New System.Drawing.Point(12, 26)
        Me.cmdFromDatabaseExample.Name = "cmdFromDatabaseExample"
        Me.cmdFromDatabaseExample.Size = New System.Drawing.Size(147, 61)
        Me.cmdFromDatabaseExample.TabIndex = 0
        Me.cmdFromDatabaseExample.Text = "Load/Retrieve"
        Me.cmdFromDatabaseExample.UseVisualStyleBackColor = True
        '
        'cmdStaticDataTableExample
        '
        Me.cmdStaticDataTableExample.Location = New System.Drawing.Point(185, 26)
        Me.cmdStaticDataTableExample.Name = "cmdStaticDataTableExample"
        Me.cmdStaticDataTableExample.Size = New System.Drawing.Size(147, 61)
        Me.cmdStaticDataTableExample.TabIndex = 1
        Me.cmdStaticDataTableExample.Text = "Static DataTable"
        Me.cmdStaticDataTableExample.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 121)
        Me.Controls.Add(Me.cmdStaticDataTableExample)
        Me.Controls.Add(Me.cmdFromDatabaseExample)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFromDatabaseExample As System.Windows.Forms.Button
    Friend WithEvents cmdStaticDataTableExample As System.Windows.Forms.Button
End Class

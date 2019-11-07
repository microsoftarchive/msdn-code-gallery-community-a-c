<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewCustomer
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.cboContactTitle = New System.Windows.Forms.ComboBox()
        Me.cmdAddRows = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contact Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contact Title"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(102, 19)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(183, 20)
        Me.txtCompanyName.TabIndex = 1
        '
        'txtContactName
        '
        Me.txtContactName.Location = New System.Drawing.Point(102, 62)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(183, 20)
        Me.txtContactName.TabIndex = 3
        '
        'cboContactTitle
        '
        Me.cboContactTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContactTitle.FormattingEnabled = True
        Me.cboContactTitle.Location = New System.Drawing.Point(102, 94)
        Me.cboContactTitle.Name = "cboContactTitle"
        Me.cboContactTitle.Size = New System.Drawing.Size(183, 21)
        Me.cboContactTitle.TabIndex = 5
        '
        'cmdAddRows
        '
        Me.cmdAddRows.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdAddRows.Location = New System.Drawing.Point(167, 141)
        Me.cmdAddRows.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAddRows.Name = "cmdAddRows"
        Me.cmdAddRows.Size = New System.Drawing.Size(58, 30)
        Me.cmdAddRows.TabIndex = 6
        Me.cmdAddRows.Text = "Save"
        Me.cmdAddRows.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(229, 141)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 30)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmNewCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 182)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdAddRows)
        Me.Controls.Add(Me.cboContactTitle)
        Me.Controls.Add(Me.txtContactName)
        Me.Controls.Add(Me.txtCompanyName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Customer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents txtContactName As TextBox
    Friend WithEvents cboContactTitle As ComboBox
    Friend WithEvents cmdAddRows As Button
    Friend WithEvents Button1 As Button
End Class

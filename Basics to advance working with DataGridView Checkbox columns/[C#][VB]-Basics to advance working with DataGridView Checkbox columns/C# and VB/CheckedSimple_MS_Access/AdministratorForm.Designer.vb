<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrator
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewPasswordTextBoxColumn1 = New CheckedSimple_MS_Access.DataGridViewPasswordTextBoxColumn()
        Me.UserNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserPasswordColumn = New CheckedSimple_MS_Access.DataGridViewPasswordTextBoxColumn()
        Me.AdminColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 193)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 62)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserNameColumn, Me.UserPasswordColumn, Me.AdminColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(478, 193)
        Me.DataGridView1.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "UserName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewPasswordTextBoxColumn1
        '
        Me.DataGridViewPasswordTextBoxColumn1.DataPropertyName = "UserPassword"
        Me.DataGridViewPasswordTextBoxColumn1.HeaderText = "Password"
        Me.DataGridViewPasswordTextBoxColumn1.Name = "DataGridViewPasswordTextBoxColumn1"
        Me.DataGridViewPasswordTextBoxColumn1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.DataGridViewPasswordTextBoxColumn1.UseSystemPasswordChar = False
        '
        'UserNameColumn
        '
        Me.UserNameColumn.DataPropertyName = "UserName"
        Me.UserNameColumn.HeaderText = "Name"
        Me.UserNameColumn.Name = "UserNameColumn"
        '
        'UserPasswordColumn
        '
        Me.UserPasswordColumn.DataPropertyName = "UserPassword"
        Me.UserPasswordColumn.HeaderText = "Password"
        Me.UserPasswordColumn.Name = "UserPasswordColumn"
        Me.UserPasswordColumn.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPasswordColumn.UseSystemPasswordChar = True
        '
        'AdminColumn
        '
        Me.AdminColumn.DataPropertyName = "IsAdmin"
        Me.AdminColumn.HeaderText = "Admin"
        Me.AdminColumn.Name = "AdminColumn"
        Me.AdminColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'frmAdministrator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 255)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAdministrator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administrator Simple"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewPasswordTextBoxColumn1 As CheckedSimple_MS_Access.DataGridViewPasswordTextBoxColumn
    Friend WithEvents UserNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserPasswordColumn As CheckedSimple_MS_Access.DataGridViewPasswordTextBoxColumn
    Friend WithEvents AdminColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class

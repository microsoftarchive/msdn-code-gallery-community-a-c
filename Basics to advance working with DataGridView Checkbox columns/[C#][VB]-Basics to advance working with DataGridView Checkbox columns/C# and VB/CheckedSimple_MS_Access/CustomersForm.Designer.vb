<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomers
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdGetChecked = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.cboCountryFilter = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ProcessColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdGetChecked)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdFilter)
        Me.Panel1.Controls.Add(Me.cboCountryFilter)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 229)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 100)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(163, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdGetChecked
        '
        Me.cmdGetChecked.Location = New System.Drawing.Point(296, 25)
        Me.cmdGetChecked.Name = "cmdGetChecked"
        Me.cmdGetChecked.Size = New System.Drawing.Size(118, 53)
        Me.cmdGetChecked.TabIndex = 2
        Me.cmdGetChecked.Text = "Checked"
        Me.cmdGetChecked.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(22, 65)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(75, 23)
        Me.cmdFilter.TabIndex = 3
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'cboCountryFilter
        '
        Me.cboCountryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountryFilter.FormattingEnabled = True
        Me.cboCountryFilter.Location = New System.Drawing.Point(22, 24)
        Me.cboCountryFilter.Name = "cboCountryFilter"
        Me.cboCountryFilter.Size = New System.Drawing.Size(184, 24)
        Me.cboCountryFilter.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProcessColumn, Me.CompanyNameColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(445, 229)
        Me.DataGridView1.TabIndex = 0
        '
        'ProcessColumn
        '
        Me.ProcessColumn.DataPropertyName = "Process"
        Me.ProcessColumn.HeaderText = "Process"
        Me.ProcessColumn.Name = "ProcessColumn"
        '
        'CompanyNameColumn
        '
        Me.CompanyNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CompanyNameColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameColumn.HeaderText = "Name"
        Me.CompanyNameColumn.Name = "CompanyNameColumn"
        Me.CompanyNameColumn.ReadOnly = True
        Me.CompanyNameColumn.Width = 70
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 329)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data from database"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents cboCountryFilter As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CompanyNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGetChecked As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class

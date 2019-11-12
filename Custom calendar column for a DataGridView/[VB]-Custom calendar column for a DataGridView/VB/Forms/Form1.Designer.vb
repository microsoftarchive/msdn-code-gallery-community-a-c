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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdNullifyHireDate = New System.Windows.Forms.Button()
        Me.chkCalendarOneClick = New System.Windows.Forms.CheckBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New CalendarInGrid.CalendarColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New CalendarInGrid.CalendarColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdNullifyHireDate)
        Me.Panel1.Controls.Add(Me.chkCalendarOneClick)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 237)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(387, 125)
        Me.Panel1.TabIndex = 1
        '
        'cmdNullifyHireDate
        '
        Me.cmdNullifyHireDate.Location = New System.Drawing.Point(13, 44)
        Me.cmdNullifyHireDate.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNullifyHireDate.Name = "cmdNullifyHireDate"
        Me.cmdNullifyHireDate.Size = New System.Drawing.Size(355, 28)
        Me.cmdNullifyHireDate.TabIndex = 2
        Me.cmdNullifyHireDate.Text = "Set current hire date to nothing"
        Me.cmdNullifyHireDate.UseVisualStyleBackColor = True
        '
        'chkCalendarOneClick
        '
        Me.chkCalendarOneClick.AutoSize = True
        Me.chkCalendarOneClick.Location = New System.Drawing.Point(13, 6)
        Me.chkCalendarOneClick.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCalendarOneClick.Name = "chkCalendarOneClick"
        Me.chkCalendarOneClick.Size = New System.Drawing.Size(175, 21)
        Me.chkCalendarOneClick.TabIndex = 0
        Me.chkCalendarOneClick.Text = "Less Click for Calendar"
        Me.chkCalendarOneClick.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(270, 6)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(100, 28)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(387, 237)
        Me.DataGridView1.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "PeopleNames"
        Me.Column2.HeaderText = "Names"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 150
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "HiredDate"
        Me.Column1.DateFormat = "MM/dd/yyyy H:mm"
        DataGridViewCellStyle1.Format = "MM/dd/yyyy H:mm"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Hired Date"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PeopleNames"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Names"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "HiredDate"
        Me.CalendarColumn1.DateFormat = "MM/dd/yy H:mm"
        DataGridViewCellStyle2.Format = "MM/dd/yy H:mm"
        Me.CalendarColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CalendarColumn1.HeaderText = "Hired Date"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Width = 150
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 362)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calendar Column For DataGridView"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cmdClose As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents chkCalendarOneClick As System.Windows.Forms.CheckBox
    Friend WithEvents cmdNullifyHireDate As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As CalendarInGrid.CalendarColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As CalendarInGrid.CalendarColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class

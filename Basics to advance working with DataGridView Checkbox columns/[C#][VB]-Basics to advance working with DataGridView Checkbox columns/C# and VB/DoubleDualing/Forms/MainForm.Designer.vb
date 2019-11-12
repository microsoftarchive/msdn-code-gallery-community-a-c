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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdResults = New System.Windows.Forms.Button()
        Me.cmdCloseForm = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.QuestionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YesResponse = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NoResponse = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 199)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(516, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdResults)
        Me.Panel1.Controls.Add(Me.cmdCloseForm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 151)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 48)
        Me.Panel1.TabIndex = 1
        '
        'cmdResults
        '
        Me.cmdResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdResults.Location = New System.Drawing.Point(13, 16)
        Me.cmdResults.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdResults.Name = "cmdResults"
        Me.cmdResults.Size = New System.Drawing.Size(100, 28)
        Me.cmdResults.TabIndex = 0
        Me.cmdResults.Text = "Results"
        Me.cmdResults.UseVisualStyleBackColor = True
        '
        'cmdCloseForm
        '
        Me.cmdCloseForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseForm.Location = New System.Drawing.Point(400, 16)
        Me.cmdCloseForm.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCloseForm.Name = "cmdCloseForm"
        Me.cmdCloseForm.Size = New System.Drawing.Size(100, 28)
        Me.cmdCloseForm.TabIndex = 1
        Me.cmdCloseForm.Text = "E&xit"
        Me.cmdCloseForm.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QuestionColumn, Me.YesResponse, Me.NoResponse})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(516, 151)
        Me.DataGridView1.TabIndex = 0
        '
        'QuestionColumn
        '
        Me.QuestionColumn.DataPropertyName = "Question"
        Me.QuestionColumn.HeaderText = "Question"
        Me.QuestionColumn.Name = "QuestionColumn"
        '
        'YesResponse
        '
        Me.YesResponse.DataPropertyName = "YesResponse"
        Me.YesResponse.HeaderText = "Yes"
        Me.YesResponse.Name = "YesResponse"
        Me.YesResponse.Width = 50
        '
        'NoResponse
        '
        Me.NoResponse.DataPropertyName = "NoResponse"
        Me.NoResponse.HeaderText = "No"
        Me.NoResponse.Name = "NoResponse"
        Me.NoResponse.Width = 50
        '
        'frmMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 221)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Questions"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdCloseForm As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdResults As System.Windows.Forms.Button
    Friend WithEvents QuestionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YesResponse As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NoResponse As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class

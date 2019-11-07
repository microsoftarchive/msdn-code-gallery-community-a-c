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
      Me.components = New System.ComponentModel.Container
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.cmdProcessCheckedRows = New System.Windows.Forms.Button
      Me.cmdCloseForm = New System.Windows.Forms.Button
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.DataGridView2 = New System.Windows.Forms.DataGridView
      Me.ProcessedGroupBox = New System.Windows.Forms.GroupBox
      Me.cmdClearBottomDataGridView = New System.Windows.Forms.Button
      Me.cmdCheckedRows = New System.Windows.Forms.Button
      Me.Panel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ProcessedGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 341)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(652, 22)
      Me.StatusStrip1.TabIndex = 0
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.cmdCheckedRows)
      Me.Panel1.Controls.Add(Me.cmdProcessCheckedRows)
      Me.Panel1.Controls.Add(Me.cmdCloseForm)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel1.Location = New System.Drawing.Point(0, 302)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(652, 39)
      Me.Panel1.TabIndex = 1
      '
      'cmdProcessCheckedRows
      '
      Me.cmdProcessCheckedRows.Location = New System.Drawing.Point(12, 9)
      Me.cmdProcessCheckedRows.Name = "cmdProcessCheckedRows"
      Me.cmdProcessCheckedRows.Size = New System.Drawing.Size(75, 23)
      Me.cmdProcessCheckedRows.TabIndex = 1
      Me.cmdProcessCheckedRows.Text = "&Process"
      Me.cmdProcessCheckedRows.UseVisualStyleBackColor = True
      '
      'cmdCloseForm
      '
      Me.cmdCloseForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCloseForm.Location = New System.Drawing.Point(566, 9)
      Me.cmdCloseForm.Name = "cmdCloseForm"
      Me.cmdCloseForm.Size = New System.Drawing.Size(75, 23)
      Me.cmdCloseForm.TabIndex = 0
      Me.cmdCloseForm.Text = "E&xit"
      Me.ToolTip1.SetToolTip(Me.cmdCloseForm, "Leave demo")
      Me.cmdCloseForm.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.Size = New System.Drawing.Size(652, 175)
      Me.DataGridView1.TabIndex = 2
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.AllowUserToDeleteRows = False
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.Location = New System.Drawing.Point(13, 18)
      Me.DataGridView2.MultiSelect = False
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.RowHeadersVisible = False
      Me.DataGridView2.Size = New System.Drawing.Size(461, 69)
      Me.DataGridView2.TabIndex = 3
      '
      'ProcessedGroupBox
      '
      Me.ProcessedGroupBox.Controls.Add(Me.cmdClearBottomDataGridView)
      Me.ProcessedGroupBox.Controls.Add(Me.DataGridView2)
      Me.ProcessedGroupBox.Location = New System.Drawing.Point(12, 185)
      Me.ProcessedGroupBox.Name = "ProcessedGroupBox"
      Me.ProcessedGroupBox.Size = New System.Drawing.Size(628, 111)
      Me.ProcessedGroupBox.TabIndex = 4
      Me.ProcessedGroupBox.TabStop = False
      '
      'cmdClearBottomDataGridView
      '
      Me.cmdClearBottomDataGridView.Location = New System.Drawing.Point(480, 19)
      Me.cmdClearBottomDataGridView.Name = "cmdClearBottomDataGridView"
      Me.cmdClearBottomDataGridView.Size = New System.Drawing.Size(75, 23)
      Me.cmdClearBottomDataGridView.TabIndex = 4
      Me.cmdClearBottomDataGridView.Text = "Clear"
      Me.cmdClearBottomDataGridView.UseVisualStyleBackColor = True
      '
      'cmdCheckedRows
      '
      Me.cmdCheckedRows.Location = New System.Drawing.Point(109, 9)
      Me.cmdCheckedRows.Name = "cmdCheckedRows"
      Me.cmdCheckedRows.Size = New System.Drawing.Size(75, 23)
      Me.cmdCheckedRows.TabIndex = 5
      Me.cmdCheckedRows.Text = "Checked"
      Me.cmdCheckedRows.UseVisualStyleBackColor = True
      '
      'frmMainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(652, 363)
      Me.Controls.Add(Me.ProcessedGroupBox)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmMainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Process CheckBox Column in DataGridView"
      Me.Panel1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ProcessedGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cmdCloseForm As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents cmdProcessCheckedRows As System.Windows.Forms.Button
   Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
   Friend WithEvents ProcessedGroupBox As System.Windows.Forms.GroupBox
   Friend WithEvents cmdClearBottomDataGridView As System.Windows.Forms.Button
   Friend WithEvents cmdCheckedRows As System.Windows.Forms.Button

End Class

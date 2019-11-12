<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckListBoxFormDemo
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
        Me.clbCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.chkSaveOnFormClose = New System.Windows.Forms.CheckBox()
        Me.lblCurrentCheckedState = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'clbCheckedListBox
        '
        Me.clbCheckedListBox.FormattingEnabled = True
        Me.clbCheckedListBox.Location = New System.Drawing.Point(37, 41)
        Me.clbCheckedListBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.clbCheckedListBox.Name = "clbCheckedListBox"
        Me.clbCheckedListBox.Size = New System.Drawing.Size(303, 123)
        Me.clbCheckedListBox.TabIndex = 1
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(241, 254)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(100, 28)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chkSaveOnFormClose
        '
        Me.chkSaveOnFormClose.AutoSize = True
        Me.chkSaveOnFormClose.Checked = Global.CheckListBoxFromMS_Access.My.MySettings.Default.SaveItemsOnFormClose
        Me.chkSaveOnFormClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveOnFormClose.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CheckListBoxFromMS_Access.My.MySettings.Default, "SaveItemsOnFormClose", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkSaveOnFormClose.Location = New System.Drawing.Point(37, 12)
        Me.chkSaveOnFormClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSaveOnFormClose.Name = "chkSaveOnFormClose"
        Me.chkSaveOnFormClose.Size = New System.Drawing.Size(107, 21)
        Me.chkSaveOnFormClose.TabIndex = 0
        Me.chkSaveOnFormClose.Text = "Save on exit"
        Me.chkSaveOnFormClose.UseVisualStyleBackColor = True
        '
        'lblCurrentCheckedState
        '
        Me.lblCurrentCheckedState.AutoSize = True
        Me.lblCurrentCheckedState.Location = New System.Drawing.Point(33, 192)
        Me.lblCurrentCheckedState.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentCheckedState.Name = "lblCurrentCheckedState"
        Me.lblCurrentCheckedState.Size = New System.Drawing.Size(264, 17)
        Me.lblCurrentCheckedState.TabIndex = 2
        Me.lblCurrentCheckedState.Text = "At runtime shows the current check state"
        '
        'frmCheckListBoxFormDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 309)
        Me.Controls.Add(Me.lblCurrentCheckedState)
        Me.Controls.Add(Me.chkSaveOnFormClose)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.clbCheckedListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCheckListBoxFormDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CheckListBox Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clbCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chkSaveOnFormClose As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrentCheckedState As System.Windows.Forms.Label
End Class

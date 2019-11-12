<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataTable
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
        Me.cmdGetChecked = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.cmdDemo = New System.Windows.Forms.Button()
        Me.txtDemoExt = New System.Windows.Forms.TextBox()
        Me.chkState = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'clbCheckedListBox
        '
        Me.clbCheckedListBox.FormattingEnabled = True
        Me.clbCheckedListBox.Location = New System.Drawing.Point(33, 30)
        Me.clbCheckedListBox.Margin = New System.Windows.Forms.Padding(4)
        Me.clbCheckedListBox.Name = "clbCheckedListBox"
        Me.clbCheckedListBox.Size = New System.Drawing.Size(303, 157)
        Me.clbCheckedListBox.TabIndex = 2
        '
        'cmdGetChecked
        '
        Me.cmdGetChecked.Location = New System.Drawing.Point(33, 194)
        Me.cmdGetChecked.Name = "cmdGetChecked"
        Me.cmdGetChecked.Size = New System.Drawing.Size(92, 34)
        Me.cmdGetChecked.TabIndex = 4
        Me.cmdGetChecked.Text = "Get"
        Me.cmdGetChecked.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(131, 194)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 34)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "For Question"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(33, 246)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(92, 22)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "One"
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(131, 240)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(205, 34)
        Me.cmdSearch.TabIndex = 10
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(396, 30)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(303, 157)
        Me.CheckedListBox1.TabIndex = 3
        '
        'cmdDemo
        '
        Me.cmdDemo.Location = New System.Drawing.Point(396, 194)
        Me.cmdDemo.Name = "cmdDemo"
        Me.cmdDemo.Size = New System.Drawing.Size(92, 34)
        Me.cmdDemo.TabIndex = 6
        Me.cmdDemo.Text = "Run"
        Me.cmdDemo.UseVisualStyleBackColor = True
        '
        'txtDemoExt
        '
        Me.txtDemoExt.Location = New System.Drawing.Point(503, 200)
        Me.txtDemoExt.Name = "txtDemoExt"
        Me.txtDemoExt.Size = New System.Drawing.Size(100, 22)
        Me.txtDemoExt.TabIndex = 7
        Me.txtDemoExt.Text = "Paul"
        '
        'chkState
        '
        Me.chkState.AutoSize = True
        Me.chkState.Location = New System.Drawing.Point(618, 201)
        Me.chkState.Name = "chkState"
        Me.chkState.Size = New System.Drawing.Size(63, 21)
        Me.chkState.TabIndex = 8
        Me.chkState.Text = "State"
        Me.chkState.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Using DataTable"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Using Strings"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdClose.Location = New System.Drawing.Point(607, 275)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(92, 34)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmDataTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 321)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkState)
        Me.Controls.Add(Me.txtDemoExt)
        Me.Controls.Add(Me.cmdDemo)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdGetChecked)
        Me.Controls.Add(Me.clbCheckedListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDataTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DataTableForm1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clbCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdGetChecked As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdDemo As System.Windows.Forms.Button
    Friend WithEvents txtDemoExt As System.Windows.Forms.TextBox
    Friend WithEvents chkState As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class

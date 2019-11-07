<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetLastColumnRowAndInsertForm
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
        Me.cboDateColumn = New System.Windows.Forms.ComboBox()
        Me.executeButton = New System.Windows.Forms.Button()
        Me.chkOpenExcel = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTimeColumn = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboDateColumn
        '
        Me.cboDateColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateColumn.FormattingEnabled = True
        Me.cboDateColumn.Location = New System.Drawing.Point(85, 11)
        Me.cboDateColumn.Name = "cboDateColumn"
        Me.cboDateColumn.Size = New System.Drawing.Size(92, 21)
        Me.cboDateColumn.TabIndex = 0
        '
        'executeButton
        '
        Me.executeButton.Location = New System.Drawing.Point(231, 48)
        Me.executeButton.Name = "executeButton"
        Me.executeButton.Size = New System.Drawing.Size(75, 23)
        Me.executeButton.TabIndex = 1
        Me.executeButton.Text = "Execute"
        Me.executeButton.UseVisualStyleBackColor = True
        '
        'chkOpenExcel
        '
        Me.chkOpenExcel.AutoSize = True
        Me.chkOpenExcel.Location = New System.Drawing.Point(231, 10)
        Me.chkOpenExcel.Name = "chkOpenExcel"
        Me.chkOpenExcel.Size = New System.Drawing.Size(52, 17)
        Me.chkOpenExcel.TabIndex = 2
        Me.chkOpenExcel.Text = "Open"
        Me.chkOpenExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date column"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Time column"
        '
        'cboTimeColumn
        '
        Me.cboTimeColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeColumn.FormattingEnabled = True
        Me.cboTimeColumn.Location = New System.Drawing.Point(85, 50)
        Me.cboTimeColumn.Name = "cboTimeColumn"
        Me.cboTimeColumn.Size = New System.Drawing.Size(92, 21)
        Me.cboTimeColumn.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(314, 91)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Although you can select any columns to write data to for this sample, it has been" &
    " setup for success as delivered yet feel free to change the columns to what ever" &
    " you want and all will still work"
        '
        'GetLastColumnRowAndInsertForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 204)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTimeColumn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkOpenExcel)
        Me.Controls.Add(Me.executeButton)
        Me.Controls.Add(Me.cboDateColumn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GetLastColumnRowAndInsertForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Last Column Row And Insert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboDateColumn As ComboBox
    Friend WithEvents executeButton As Button
    Friend WithEvents chkOpenExcel As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboTimeColumn As ComboBox
    Friend WithEvents Label3 As Label
End Class

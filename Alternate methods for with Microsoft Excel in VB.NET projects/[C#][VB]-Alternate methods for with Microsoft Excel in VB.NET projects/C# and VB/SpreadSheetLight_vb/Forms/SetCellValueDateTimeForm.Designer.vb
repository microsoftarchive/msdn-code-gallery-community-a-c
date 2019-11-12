<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetCellValueDateTimeForm
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
        Me.openExcelFile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSheetNames = New System.Windows.Forms.ComboBox()
        Me.cellAddressTextBox = New System.Windows.Forms.TextBox()
        Me.SetValueButton = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'openExcelFile
        '
        Me.openExcelFile.Location = New System.Drawing.Point(295, 123)
        Me.openExcelFile.Name = "openExcelFile"
        Me.openExcelFile.Size = New System.Drawing.Size(90, 39)
        Me.openExcelFile.TabIndex = 7
        Me.openExcelFile.Text = "Open"
        Me.openExcelFile.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cell value"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cell address (e.g. A1)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sheet name"
        '
        'cboSheetNames
        '
        Me.cboSheetNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetNames.FormattingEnabled = True
        Me.cboSheetNames.Location = New System.Drawing.Point(131, 30)
        Me.cboSheetNames.Name = "cboSheetNames"
        Me.cboSheetNames.Size = New System.Drawing.Size(147, 21)
        Me.cboSheetNames.TabIndex = 1
        '
        'cellAddressTextBox
        '
        Me.cellAddressTextBox.Location = New System.Drawing.Point(131, 75)
        Me.cellAddressTextBox.Name = "cellAddressTextBox"
        Me.cellAddressTextBox.Size = New System.Drawing.Size(147, 20)
        Me.cellAddressTextBox.TabIndex = 3
        Me.cellAddressTextBox.Text = "A1"
        '
        'SetValueButton
        '
        Me.SetValueButton.Location = New System.Drawing.Point(295, 78)
        Me.SetValueButton.Name = "SetValueButton"
        Me.SetValueButton.Size = New System.Drawing.Size(90, 39)
        Me.SetValueButton.TabIndex = 5
        Me.SetValueButton.Text = "Set cell"
        Me.SetValueButton.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(131, 101)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(147, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'SetCellValueDateTimeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 192)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.openExcelFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSheetNames)
        Me.Controls.Add(Me.cellAddressTextBox)
        Me.Controls.Add(Me.SetValueButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SetCellValueDateTimeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Cell Value DateTime"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents openExcelFile As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSheetNames As ComboBox
    Friend WithEvents cellAddressTextBox As TextBox
    Friend WithEvents SetValueButton As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class

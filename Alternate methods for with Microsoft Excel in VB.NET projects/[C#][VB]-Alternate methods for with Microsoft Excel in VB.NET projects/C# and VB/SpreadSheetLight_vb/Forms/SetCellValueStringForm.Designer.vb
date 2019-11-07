<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetCellValueStringForm
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
        Me.SetValueButton = New System.Windows.Forms.Button()
        Me.cellAddressTextBox = New System.Windows.Forms.TextBox()
        Me.cboSheetNames = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cellValueTextBox = New System.Windows.Forms.TextBox()
        Me.openExcelFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SetValueButton
        '
        Me.SetValueButton.Location = New System.Drawing.Point(291, 65)
        Me.SetValueButton.Name = "SetValueButton"
        Me.SetValueButton.Size = New System.Drawing.Size(90, 39)
        Me.SetValueButton.TabIndex = 5
        Me.SetValueButton.Text = "Set cell"
        Me.SetValueButton.UseVisualStyleBackColor = True
        '
        'cellAddressTextBox
        '
        Me.cellAddressTextBox.Location = New System.Drawing.Point(127, 62)
        Me.cellAddressTextBox.Name = "cellAddressTextBox"
        Me.cellAddressTextBox.Size = New System.Drawing.Size(147, 20)
        Me.cellAddressTextBox.TabIndex = 3
        Me.cellAddressTextBox.Text = "A1"
        '
        'cboSheetNames
        '
        Me.cboSheetNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetNames.FormattingEnabled = True
        Me.cboSheetNames.Location = New System.Drawing.Point(127, 17)
        Me.cboSheetNames.Name = "cboSheetNames"
        Me.cboSheetNames.Size = New System.Drawing.Size(147, 21)
        Me.cboSheetNames.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sheet name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cell address (e.g. A1)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cell value"
        '
        'cellValueTextBox
        '
        Me.cellValueTextBox.Location = New System.Drawing.Point(127, 88)
        Me.cellValueTextBox.Name = "cellValueTextBox"
        Me.cellValueTextBox.Size = New System.Drawing.Size(147, 20)
        Me.cellValueTextBox.TabIndex = 6
        Me.cellValueTextBox.Text = "Set from vb.net"
        '
        'openExcelFile
        '
        Me.openExcelFile.Location = New System.Drawing.Point(291, 110)
        Me.openExcelFile.Name = "openExcelFile"
        Me.openExcelFile.Size = New System.Drawing.Size(90, 39)
        Me.openExcelFile.TabIndex = 7
        Me.openExcelFile.Text = "Open"
        Me.openExcelFile.UseVisualStyleBackColor = True
        '
        'SetCellValueStringForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 196)
        Me.Controls.Add(Me.openExcelFile)
        Me.Controls.Add(Me.cellValueTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSheetNames)
        Me.Controls.Add(Me.cellAddressTextBox)
        Me.Controls.Add(Me.SetValueButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SetCellValueStringForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Cell Value String"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SetValueButton As Button
    Friend WithEvents cellAddressTextBox As TextBox
    Friend WithEvents cboSheetNames As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cellValueTextBox As TextBox
    Friend WithEvents openExcelFile As Button
End Class

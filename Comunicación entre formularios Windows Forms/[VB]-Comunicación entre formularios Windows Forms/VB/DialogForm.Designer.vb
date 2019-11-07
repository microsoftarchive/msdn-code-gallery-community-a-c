<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogForm
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(228, 190)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(82, 190)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "&Aceptar"
        Me.btnOk.UseVisualStyleBackColor = true
        '
        'chkActive
        '
        Me.chkActive.AutoSize = true
        Me.chkActive.Location = New System.Drawing.Point(33, 127)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 11
        Me.chkActive.Text = "Activo"
        Me.chkActive.UseVisualStyleBackColor = true
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(105, 76)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(255, 20)
        Me.txtSurname.TabIndex = 10
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Location = New System.Drawing.Point(30, 79)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(44, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Apellido"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(105, 33)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(255, 20)
        Me.txtName.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(30, 36)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Nombre"
        '
        'DialogForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(390, 247)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DialogForm"
        Me.Text = "Datos"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Private WithEvents btnCancel As Button
    Private WithEvents btnOk As Button
    Private WithEvents chkActive As CheckBox
    Private WithEvents txtSurname As TextBox
    Private WithEvents label2 As Label
    Private WithEvents txtName As TextBox
    Private WithEvents label1 As Label
End Class

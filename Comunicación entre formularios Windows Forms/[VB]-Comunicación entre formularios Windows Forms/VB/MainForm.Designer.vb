<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SurnameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EditColumn = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(444, 333)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "&Añadir"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = false
        Me.dataGridView1.AllowUserToDeleteRows = false
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameColumn, Me.SurnameColumn, Me.ActiveColumn, Me.EditColumn})
        Me.dataGridView1.Location = New System.Drawing.Point(66, 58)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = true
        Me.dataGridView1.Size = New System.Drawing.Size(453, 248)
        Me.dataGridView1.TabIndex = 2
        '
        'NameColumn
        '
        Me.NameColumn.HeaderText = "Nombre"
        Me.NameColumn.Name = "NameColumn"
        Me.NameColumn.ReadOnly = true
        '
        'SurnameColumn
        '
        Me.SurnameColumn.HeaderText = "Apellido"
        Me.SurnameColumn.Name = "SurnameColumn"
        Me.SurnameColumn.ReadOnly = true
        '
        'ActiveColumn
        '
        Me.ActiveColumn.HeaderText = "Activo"
        Me.ActiveColumn.Name = "ActiveColumn"
        Me.ActiveColumn.ReadOnly = true
        '
        'EditColumn
        '
        Me.EditColumn.HeaderText = ""
        Me.EditColumn.Name = "EditColumn"
        Me.EditColumn.ReadOnly = true
        Me.EditColumn.Text = "Editar"
        Me.EditColumn.UseColumnTextForButtonValue = true
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 415)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "MainForm"
        Me.Text = "Formulario Principal"
        CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Private WithEvents btnAdd As Button
    Private WithEvents dataGridView1 As DataGridView
    Private WithEvents NameColumn As DataGridViewTextBoxColumn
    Private WithEvents SurnameColumn As DataGridViewTextBoxColumn
    Private WithEvents ActiveColumn As DataGridViewCheckBoxColumn
    Private WithEvents EditColumn As DataGridViewButtonColumn
End Class

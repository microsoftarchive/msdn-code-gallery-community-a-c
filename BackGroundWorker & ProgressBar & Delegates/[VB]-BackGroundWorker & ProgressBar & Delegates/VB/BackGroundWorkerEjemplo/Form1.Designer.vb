<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.btnIniciar = New System.Windows.Forms.Button
        Me.txtProgreso = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblProgreso = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.lblNumeroIteraciones = New System.Windows.Forms.Label
        Me.lblEstado = New System.Windows.Forms.Label
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciar.Location = New System.Drawing.Point(25, 24)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(102, 23)
        Me.btnIniciar.TabIndex = 0
        Me.btnIniciar.Text = "Iniciar Thread"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'txtProgreso
        '
        Me.txtProgreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgreso.Location = New System.Drawing.Point(25, 82)
        Me.txtProgreso.Multiline = True
        Me.txtProgreso.Name = "txtProgreso"
        Me.txtProgreso.Size = New System.Drawing.Size(343, 110)
        Me.txtProgreso.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(25, 208)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(343, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'lblProgreso
        '
        Me.lblProgreso.AutoSize = True
        Me.lblProgreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgreso.Location = New System.Drawing.Point(22, 61)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(106, 13)
        Me.lblProgreso.TabIndex = 3
        Me.lblProgreso.Text = "Progreso del hilo:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(304, 27)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown1.TabIndex = 4
        Me.NumericUpDown1.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblNumeroIteraciones
        '
        Me.lblNumeroIteraciones.AutoSize = True
        Me.lblNumeroIteraciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroIteraciones.Location = New System.Drawing.Point(160, 29)
        Me.lblNumeroIteraciones.Name = "lblNumeroIteraciones"
        Me.lblNumeroIteraciones.Size = New System.Drawing.Size(138, 13)
        Me.lblNumeroIteraciones.TabIndex = 5
        Me.lblNumeroIteraciones.Text = "Número de iteraciones:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(22, 244)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 13)
        Me.lblEstado.TabIndex = 6
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 266)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblNumeroIteraciones)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.lblProgreso)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtProgreso)
        Me.Controls.Add(Me.btnIniciar)
        Me.Name = "frmPrincipal"
        Me.Text = "Ejemplo BackgroundWorker - lopezatienza.es"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents txtProgreso As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNumeroIteraciones As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label

End Class

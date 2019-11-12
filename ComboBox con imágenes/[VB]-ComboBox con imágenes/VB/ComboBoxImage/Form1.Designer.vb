<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.cmbImages = New System.Windows.Forms.ComboBox()
        Me.listImages = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picImage
        '
        Me.picImage.Location = New System.Drawing.Point(36, 22)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(125, 125)
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'cmbImages
        '
        Me.cmbImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbImages.FormattingEnabled = True
        Me.cmbImages.Location = New System.Drawing.Point(192, 22)
        Me.cmbImages.Name = "cmbImages"
        Me.cmbImages.Size = New System.Drawing.Size(290, 41)
        Me.cmbImages.TabIndex = 1
        '
        'listImages
        '
        Me.listImages.ImageStream = CType(resources.GetObject("listImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.listImages.TransparentColor = System.Drawing.Color.Transparent
        Me.listImages.Images.SetKeyName(0, "minion1.png")
        Me.listImages.Images.SetKeyName(1, "minion2.png")
        Me.listImages.Images.SetKeyName(2, "minion3.png")
        Me.listImages.Images.SetKeyName(3, "minion4.png")
        Me.listImages.Images.SetKeyName(4, "minion5.png")
        Me.listImages.Images.SetKeyName(5, "minion6.png")
        Me.listImages.Images.SetKeyName(6, "minion7.png")
        Me.listImages.Images.SetKeyName(7, "minion8.png")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 398)
        Me.Controls.Add(Me.cmbImages)
        Me.Controls.Add(Me.picImage)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents cmbImages As System.Windows.Forms.ComboBox
    Friend WithEvents listImages As System.Windows.Forms.ImageList

End Class

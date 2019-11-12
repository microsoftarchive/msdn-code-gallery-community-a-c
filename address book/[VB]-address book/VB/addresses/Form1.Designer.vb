<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnDelete = New System.Windows.Forms.Button
        Me.cboLN = New System.Windows.Forms.ComboBox
        Me.cboFN = New System.Windows.Forms.ComboBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboTitle = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtPostcode = New System.Windows.Forms.TextBox
        Me.txtCounty = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddr2 = New System.Windows.Forms.TextBox
        Me.txtAddr1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(199, 257)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 80
        Me.btnDelete.Text = "delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cboLN
        '
        Me.cboLN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboLN.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cboLN.FormattingEnabled = True
        Me.cboLN.Location = New System.Drawing.Point(127, 45)
        Me.cboLN.Name = "cboLN"
        Me.cboLN.Size = New System.Drawing.Size(309, 21)
        Me.cboLN.TabIndex = 61
        '
        'cboFN
        '
        Me.cboFN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboFN.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cboFN.FormattingEnabled = True
        Me.cboFN.Location = New System.Drawing.Point(127, 21)
        Me.cboFN.Name = "cboFN"
        Me.cboFN.Size = New System.Drawing.Size(309, 21)
        Me.cboFN.TabIndex = 60
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(361, 257)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 70
        Me.btnNew.Text = "new"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(280, 257)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 69
        Me.btnAdd.Text = "add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(300, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 16)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "title"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.UseCompatibleTextRendering = True
        '
        'cboTitle
        '
        Me.cboTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cboTitle.FormattingEnabled = True
        Me.cboTitle.Items.AddRange(New Object() {"Mr", "Mrs", "Ms", "Miss", "Dr"})
        Me.cboTitle.Location = New System.Drawing.Point(349, 74)
        Me.cboTitle.Name = "cboTitle"
        Me.cboTitle.Size = New System.Drawing.Size(87, 21)
        Me.cboTitle.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(2, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 19)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "country"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.UseCompatibleTextRendering = True
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCountry.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCountry.Location = New System.Drawing.Point(127, 186)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(309, 19)
        Me.txtCountry.TabIndex = 67
        '
        'txtPostcode
        '
        Me.txtPostcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPostcode.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtPostcode.Location = New System.Drawing.Point(127, 207)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(100, 19)
        Me.txtPostcode.TabIndex = 68
        '
        'txtCounty
        '
        Me.txtCounty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCounty.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounty.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCounty.Location = New System.Drawing.Point(127, 166)
        Me.txtCounty.Name = "txtCounty"
        Me.txtCounty.Size = New System.Drawing.Size(309, 19)
        Me.txtCounty.TabIndex = 66
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCity.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCity.Location = New System.Drawing.Point(127, 146)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(309, 19)
        Me.txtCity.TabIndex = 65
        '
        'txtAddr2
        '
        Me.txtAddr2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddr2.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddr2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtAddr2.Location = New System.Drawing.Point(127, 126)
        Me.txtAddr2.Name = "txtAddr2"
        Me.txtAddr2.Size = New System.Drawing.Size(309, 19)
        Me.txtAddr2.TabIndex = 64
        '
        'txtAddr1
        '
        Me.txtAddr1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddr1.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddr1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtAddr1.Location = New System.Drawing.Point(127, 106)
        Me.txtAddr1.Name = "txtAddr1"
        Me.txtAddr1.Size = New System.Drawing.Size(309, 19)
        Me.txtAddr1.TabIndex = 63
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(1, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 19)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "postcode"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.UseCompatibleTextRendering = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(-1, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 19)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "county"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.UseCompatibleTextRendering = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(1, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 19)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "city"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.UseCompatibleTextRendering = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(-1, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 19)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "address line2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.UseCompatibleTextRendering = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(-1, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 19)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "address line1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.UseCompatibleTextRendering = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(-1, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 19)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "last name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(-1, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 19)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "first name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.UseCompatibleTextRendering = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(458, 298)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.cboLN)
        Me.Controls.Add(Me.cboFN)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboTitle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.txtPostcode)
        Me.Controls.Add(Me.txtCounty)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtAddr2)
        Me.Controls.Add(Me.txtAddr1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "addresses"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cboLN As System.Windows.Forms.ComboBox
    Friend WithEvents cboFN As System.Windows.Forms.ComboBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtCounty As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

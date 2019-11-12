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
        Me.components = New System.ComponentModel.Container()
        Me.btnSendData = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstCOMPorts = New System.Windows.Forms.ComboBox()
        Me.txtDataReceived = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtDataReceivedd = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button24 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSendData
        '
        Me.btnSendData.Location = New System.Drawing.Point(144, 70)
        Me.btnSendData.Name = "btnSendData"
        Me.btnSendData.Size = New System.Drawing.Size(75, 23)
        Me.btnSendData.TabIndex = 0
        Me.btnSendData.Text = "Send Data"
        Me.btnSendData.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(12, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 1
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.Location = New System.Drawing.Point(220, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lstCOMPorts
        '
        Me.lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstCOMPorts.FormattingEnabled = True
        Me.lstCOMPorts.Location = New System.Drawing.Point(93, 14)
        Me.lstCOMPorts.Name = "lstCOMPorts"
        Me.lstCOMPorts.Size = New System.Drawing.Size(121, 21)
        Me.lstCOMPorts.TabIndex = 3
        '
        'txtDataReceived
        '
        Me.txtDataReceived.Location = New System.Drawing.Point(12, 70)
        Me.txtDataReceived.Multiline = True
        Me.txtDataReceived.Name = "txtDataReceived"
        Me.txtDataReceived.Size = New System.Drawing.Size(121, 21)
        Me.txtDataReceived.TabIndex = 4
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(93, 44)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(389, 20)
        Me.txtData.TabIndex = 5
        Me.txtData.Visible = False
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 15000
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'txtDataReceivedd
        '
        Me.txtDataReceivedd.Location = New System.Drawing.Point(225, 70)
        Me.txtDataReceivedd.Multiline = True
        Me.txtDataReceivedd.Name = "txtDataReceivedd"
        Me.txtDataReceivedd.Size = New System.Drawing.Size(232, 57)
        Me.txtDataReceivedd.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(773, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 37)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(788, 91)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 58)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(791, 187)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 55)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(906, 92)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(61, 56)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(187, 147)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(146, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.UseWaitCursor = True
        Me.TextBox1.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(484, 70)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(79, 48)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Phone Application"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(797, 273)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 57)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(484, 133)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(63, 47)
        Me.Button8.TabIndex = 15
        Me.Button8.Text = "Send"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(339, 133)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(118, 47)
        Me.Button9.TabIndex = 16
        Me.Button9.Text = "Retrieve Phone  Number from SIM card"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(7, 99)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(207, 82)
        Me.ListBox1.TabIndex = 17
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(254, 220)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(40, 35)
        Me.Button10.TabIndex = 18
        Me.Button10.Text = "1"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(300, 220)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(40, 35)
        Me.Button11.TabIndex = 19
        Me.Button11.Text = "2"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(346, 220)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(40, 35)
        Me.Button12.TabIndex = 20
        Me.Button12.Text = "3"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(255, 261)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(40, 35)
        Me.Button13.TabIndex = 21
        Me.Button13.Text = "4"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(301, 261)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(40, 35)
        Me.Button14.TabIndex = 22
        Me.Button14.Text = "5"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(347, 261)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(40, 35)
        Me.Button15.TabIndex = 23
        Me.Button15.Text = "6"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(254, 302)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(40, 35)
        Me.Button16.TabIndex = 24
        Me.Button16.Text = "7"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(301, 302)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(40, 35)
        Me.Button17.TabIndex = 25
        Me.Button17.Text = "8"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(347, 302)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(40, 35)
        Me.Button18.TabIndex = 26
        Me.Button18.Text = "9"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(301, 343)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(40, 35)
        Me.Button19.TabIndex = 27
        Me.Button19.Text = "0"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(444, 220)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(102, 20)
        Me.TextBox2.TabIndex = 28
        Me.TextBox2.Visible = False
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(254, 343)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(40, 35)
        Me.Button20.TabIndex = 29
        Me.Button20.Text = "*"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(347, 343)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(40, 35)
        Me.Button21.TabIndex = 30
        Me.Button21.Text = "#"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(12, 44)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(131, 20)
        Me.TextBox3.TabIndex = 31
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(458, 257)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(87, 59)
        Me.Button22.TabIndex = 32
        Me.Button22.Text = "Instant Call"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(444, 191)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(102, 20)
        Me.TextBox4.TabIndex = 33
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(458, 334)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(88, 40)
        Me.Button23.TabIndex = 34
        Me.Button23.Text = "New Number"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(328, 15)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(57, 19)
        Me.Button24.TabIndex = 35
        Me.Button24.Text = "Clear"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(7, 220)
        Me.TextBox5.MaxLength = 3
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(126, 20)
        Me.TextBox5.TabIndex = 3
        '
        'Button25
        '
        Me.Button25.Location = New System.Drawing.Point(393, 322)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(59, 65)
        Me.Button25.TabIndex = 36
        Me.Button25.Text = "Close Skype"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(393, 219)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(45, 97)
        Me.Button26.TabIndex = 37
        Me.Button26.Text = "Login Skype"
        Me.Button26.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(7, 257)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(155, 20)
        Me.TextBox6.TabIndex = 38
        '
        'Button27
        '
        Me.Button27.Location = New System.Drawing.Point(254, 191)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(131, 19)
        Me.Button27.TabIndex = 39
        Me.Button27.Text = "Answer Call"
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 396)
        Me.Controls.Add(Me.Button27)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Button26)
        Me.Controls.Add(Me.Button25)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Button24)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.txtDataReceivedd)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDataReceived)
        Me.Controls.Add(Me.lstCOMPorts)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnSendData)
        Me.Controls.Add(Me.txtData)
        Me.Name = "Form1"
        Me.Text = "VB.net COM port example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSendData As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstCOMPorts As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataReceived As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtDataReceivedd As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button27 As System.Windows.Forms.Button

End Class

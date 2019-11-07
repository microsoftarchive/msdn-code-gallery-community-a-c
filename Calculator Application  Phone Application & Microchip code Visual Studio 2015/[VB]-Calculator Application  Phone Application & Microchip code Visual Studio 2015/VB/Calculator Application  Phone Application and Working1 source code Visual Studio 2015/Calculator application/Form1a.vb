Public Class Form1a

    Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ProcID As Integer
        Dim ProcID1 As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        ' On Error GoTo errorhandler
        'GoTo Pause
        ''Form2.Show()
        ProcID = Shell("C:\Program Files\Skype\Phone\Skype.exe", AppWinStyle.NormalFocus)
        ProcID1 = Shell("C:\Windows\System32\SoundRecorder.exe", AppWinStyle.NormalFocus)

        'MsgBox(ProcID)
        Skype.Show()
        Skype.TopMost = True
        TextBox3.Text = ListBox1.SelectedItem
        If Skype.TextBox1.Text = TextBox1.Text Then
            Skype.Show()
        End If

        ' c = "0"
        'TextBox2.Text = "0"
        Me.TopMost = True
        ' ProcID = Form1.TextBox2.Text
        TextBox1.Text = ProcID
        'TextBox1.Text = Form1.TextBox1.Text
        ' MsgBox(ProcID)
        MsgBox(ProcID)
        AppActivate(ProcID)

        TextBox2.Text = ProcID1
        'TextBox1.Text = Form1.TextBox1.Text
        MsgBox(ProcID1)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcID = 'Form1.TextBox1.Text
        'TextBox1.Text = ProcID
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        ' TextBox2.Text = Form1.TextBox3.Text()
        ' MsgBox(ProcID1)
        'AppActivate(ProcID1)
        'MsgBox(ProcID)
        ' MsgBox(ProcID)
        ' AppActivate(ProcID)

        My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006583642487", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys("006591737839", True)
        My.Computer.Keyboard.SendKeys("~", True)
        'Else

        '  End If
        'GoTo Pause
        ''Form2.TopMost() = True
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)


errorhandler:
        Exit Sub
    End Sub

    Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'TextBox1.Text = Form1.txtDataReceived.Text
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox3.Text = ListBox1.SelectedItem
        TextBox3.Text = Form1.txtDataReceived.Text
        TextBox3.Text = Form1.TextBox3.Text
        TextBox1.Text=Skype.TextBox1.text   

        'TextBox1.Text = Form1.txtDataReceived.Text
    End Sub

    Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a111 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        Dim d1 As String
        Dim e1b As Integer
        ' Start the Calculator application, and store the process id.
        ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        'InputBox(a)
        AppActivate(ProcID)
        c = TextBox1.Text
        d1 = TextBox2.Text
        e1b = TextBox3.Text
        a111 = "+="

        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys(a111, True)
        My.Computer.Keyboard.SendKeys(e1b, True)
        My.Computer.Keyboard.SendKeys("=", True)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim a1 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        ' Dim d1 As String
        Dim e1 As Integer
        ' Start the Calculator application, and store the process id.
        ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        'InputBox(a)
        AppActivate(ProcID)
        c = TextBox1.Text
        ' d1 = TextBox2.Text
        e1 = TextBox3.Text
        'a1 = "+"

        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys("*", True)
        My.Computer.Keyboard.SendKeys(e1, True)
        My.Computer.Keyboard.SendKeys("=", True)
    End Sub

    Private Sub TextBox3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox3.MouseClick
        ListBox1.Items.Add(TextBox3.Text)
        Refresh()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        ListBox1.Items.Add(TextBox3.Text)
        'TextBox3.Text = ListBox1.SelectedItem
    End Sub
    Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        On Error GoTo errorhandler
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)
        'ProcID = Shell("C:\Program Files\Skype\Phone\Skype.EXE", AppWinStyle.NormalFocus)
        ProcID = Shell("WFS.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
start:
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        TextBox2.Text = TextBox1.Text
        TextBox2.Text = InputBox(a, , TextBox2.Text, , )

        AppActivate(ProcID)
        'c = TextBox1.Text
        ' d1 = TextBox2.text
        ' e1a = TextBox3.Text

        '22 SendALT-NALT-F123456789= the keystrokes to the Calculator application.

        My.Computer.Keyboard.SendKeys("%fnf", True)
        ''My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%f", True)
        My.Computer.Keyboard.SendKeys("%s", True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        '' My.Computer.Keyboard.SendKeys("+", True)
        '' My.Computer.Keyboard.SendKeys("123456789", True)
        ''  My.Computer.Keyboard.SendKeys("Call", True)
        ' The result is 22 * 44 = 968.
        My.Computer.Keyboard.SendKeys("%{f4}", True)
        GoTo start

errorhandler:
        Exit Sub
    End Sub

    Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        On Error GoTo errorhandler
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)
        'ProcID = Shell("C:\Program Files\Skype\Phone\Skype.EXE", AppWinStyle.NormalFocus)
        'ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ProcID = Shell("EXPLORER.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
start:
        TextBox1.Text = ProcID
        ' ProcID = TextBox1.Text
        a = ProcID
        'TextBox2.Text = InputBox(a)
        AppActivate(ProcID)
        'c = TextBox1.Text
        ' d1 = TextBox2.text
        ' e1a = TextBox3.Text

        '22 SendALT-NALT-F123456789= the keystrokes to the Calculator application.

        ''My.Computer.Keyboard.SendKeys("%fnf", True)
        ' My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox1.Text, True)
        My.Computer.Keyboard.SendKeys("+=", True)
        My.Computer.Keyboard.SendKeys(TextBox3.Text, True)
        My.Computer.Keyboard.SendKeys("=", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        ''My.Computer.Keyboard.SendKeys("%f", True)
        ''My.Computer.Keyboard.SendKeys("%s", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        '' My.Computer.Keyboard.SendKeys("+", True)
        '' My.Computer.Keyboard.SendKeys("123456789", True)
        ''  My.Computer.Keyboard.SendKeys("Call", True)
        ' The result is 22 * 44 = 968.
        'GoTo start
        'TextBox2.Text = InputBox(a)
errorhandler:
        Exit Sub
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Dim a1 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        ' Dim d1 As String
        Dim e1 As Integer
        ' Start the Calculator application, and store the process id.
        ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        'InputBox(a)
        AppActivate(ProcID)
        c = TextBox1.Text
        ' d1 = TextBox2.Text
        e1 = TextBox3.Text
        'a1 = "+"

        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys("-", True)
        My.Computer.Keyboard.SendKeys(e1, True)
        My.Computer.Keyboard.SendKeys("=", True)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Dim a1 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        ' Dim d1 As String
        Dim e1 As Integer
        ' Start the Calculator application, and store the process id.
        'ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ProcID = Shell("CALC.EXE", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        'InputBox(a)
        AppActivate(ProcID)
        c = TextBox1.Text
        ' d1 = TextBox2.Text
        e1 = TextBox3.Text
        'a1 = "+"

        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys("/", True)
        My.Computer.Keyboard.SendKeys(e1, True)
        My.Computer.Keyboard.SendKeys("=", True)
    End Sub

    Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Dim a1 As String
        Dim a111 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        Dim d1 As String
        Dim e1b As Integer
        On Error GoTo errorhandler
        'Dim ProcID As Integer
        'Dim a As Integer
        'Dim c As Integer
        ' Dim d1 As String
        Dim e1 As Integer
        ' Start the Calculator application, and store the process id.
        ProcID = Shell("C:\Program Files\Microsoft Office\Office14\Excel.exe", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        'AppActivate(ProcID)
        'start:

        'TextBox1.Text = "0"
        'GoTo Pause
        'Pause1:
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcID = TextBox1.Text
        a = ProcID
        'ListBox1.Text = TextBox1.Text
        ' TextBox2.Text = MsgBox(TextBox2.Text)
        'TextBox2.Text = InputBox(a, , TextBox2.Text, , )

        'InputBox(a)
        AppActivate(ProcID)
        'TextBox1.Text = InputBox(a, , TextBox1.Text, Top, Top)
        TextBox1.Text = ProcID
        c = TextBox1.Text
        'd1 = TextBox2.Text
        ' e1b = TextBox3.Text
        ' a111 = "+="
        c = ProcID

        TextBox2.Text = c
        Form4.Show()
        ' My.Computer.Keyboard.SendKeys(c, True)
        ' My.Computer.Keyboard.SendKeys(a111, True)
        'My.Computer.Keyboard.SendKeys(e1b, True)
        'My.Computer.Keyboard.SendKeys("=", True)
        'c = TextBox1.Text() '= InputBox(a, , , TopMost, TopMost)
        ' If c = "0" Then
        'Form2.Show()
        'Form2.TopMost = True
        '  Else
        ' End If
        'Form2.Show()
        'MsgBox(c)
        ' InputBox(c, , TextBox1.Text, TopMost, TopMost)
        'TextBox1.Refresh()
        'InputBox(a)
Pause1:
        My.Computer.Keyboard.SendKeys(TextBox1.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        ' c = TextBox1.Text
        ' d1 = TextBox2.Text1000

        '0e1 = TextBox3.Text
        'a1 = "+"

        'My.Computer.Keyboard.SendKeys(c, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("/", True)
        'My.Computer.Keyboard.SendKeys(e1, True)
        'My.Computer.Keyboard.SendKeys("=", True)
        ' GoTo start
Pause:
        'Button1.Show()
        'TextBox1.Show()
        ' My.Computer.Keyboard.SendKeys("~", True)
        If TextBox1.Text = c Then
            'SelectNextControl(My.Forms.Form1.ControlBox, 0, 1, 1, 1)
            ' Form2.Show()
            'Stop
            c = ProcID

            TextBox2.Text = c
            Form4.Show()
        Else
            Resume

        End If
        Form4.Show()
errorhandler:
        'My.Computer.Keyboard.SendKeys("=SUM", True)
        Exit Sub
        'GoTo start

    End Sub

    Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim text1 As String
        Dim a111 As String
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        Dim d1 As String
        Dim e1b As Integer
        On Error GoTo errorhandler
        'Dim ProcID As Integer
        'Dim a As Integer
        'Dim c As Integer
        ' Dim d1 As String
        Dim e1 As Integer
        ' Start the Calculator application, and store the process id.
        'ProcID = Shell("C:\Program Files\Microsoft Office\Office14\Excel.exe", AppWinStyle.NormalFocus)
        ' Activate the Calculator application.
        'AppActivate(ProcID)
        'start:

        'TextBox1.Text = "0"
        'GoTo Pause
        'Pause1:
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcID = TextBox1.Text
        'a = ProcID
        'ListBox1.Text = TextBox1.Text
        ' TextBox2.Text = MsgBox(TextBox2.Text)
        'TextBox2.Text = InputBox(a, , TextBox2.Text, , )

        'InputBox(a)
        'AppActivate(ProcID)
        'TextBox1.Text = InputBox(a, , TextBox1.Text, Top, Top)
        ProcID = TextBox1.Text
        TextBox1.Text = ProcID
        c = TextBox1.Text
        'd1 = TextBox2.Text
        ' e1b = TextBox3.Text
        ' a111 = "+="
        c = ProcID
        AppActivate(ProcID)

        TextBox2.Text = c
        Form4.Show()
        ' My.Computer.Keyboard.SendKeys(c, True)
        ' My.Computer.Keyboard.SendKeys(a111, True)
        'My.Computer.Keyboard.SendKeys(e1b, True)
        'My.Computer.Keyboard.SendKeys("=", True)
        'c = TextBox1.Text() '= InputBox(a, , , TopMost, TopMost)
        ' If c = "0" Then
        'Form2.Show()
        'Form2.TopMost = True
        '  Else
        ' End If
        'Form2.Show()
        'MsgBox(c)
        ' InputBox(c, , TextBox1.Text, TopMost, TopMost)
        'TextBox1.Refresh()
        'InputBox(a)
Pause1:
        'GoTo start
        text1 = "=" + "SUM"
        My.Computer.Keyboard.SendKeys(text1, True)
        ' c = TextBox1.Text
        ' d1 = TextBox2.Text1000

        '0e1 = TextBox3.Text
        'a1 = "+"

        'My.Computer.Keyboard.SendKeys(c, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("/", True)
        'My.Computer.Keyboard.SendKeys(e1, True)
        'My.Computer.Keyboard.SendKeys("=", True)
        ' GoTo start
Pause:
        'Button1.Show()
        'TextBox1.Show()
        ' My.Computer.Keyboard.SendKeys("~", True)
        If TextBox1.Text = c Then
            'SelectNextControl(My.Forms.Form1.ControlBox, 0, 1, 1, 1)
            ' Form2.Show()
            'Stop
            c = ProcID

            TextBox2.Text = c
            Form4.Show()
        Else
            Resume

        End If
        Form4.Show()
errorhandler:
        'My.Computer.Keyboard.SendKeys("=SUM", True)
        Exit Sub

    End Sub

    Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        ''My.Computer.Keyboard.SendKeys("%fnf", True)
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        On Error GoTo errorhandler
        'GoTo Pause
        ''Form2.Show()

        Skype.Show()
        Skype.TopMost = True
        ProcID = TextBox1.Text
        AppActivate(ProcID)

        'TextBox1.Text = ListBox1.SelectedItem
        'If Skype.TextBox1.Text = TextBox1.Text Then
        'Skype.Show()
        'Else

        'End If
        My.Computer.Keyboard.SendKeys("%SS", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        ''My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        'GoTo Pause
        ''Form2.TopMost() = True
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)


errorhandler:
        Exit Sub

    End Sub

    Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Form3.Show()
    End Sub
    Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'ListBox1.Items(1) = "006591737839"
        'ListBox1.Items(2) = "006583642487"
        'ListBox1.Items(3) = "0060126220509"
        'ListBox1.Items(4) = "0060380239203"
        'ListBox1.Text = ListBox1.Items(1)
        'ListBox1.Text = ListBox1.Items(2)
        'ListBox1.Text = ListBox1.Items(3)
        'ListBox1.Text = ListBox1.Items(4)
        'TextBox3.Text = Me.ListBox1.Items(index)
        'TextBox3.Text = Me.ListBox1.Items(index + 1)
        ' TextBox3.Text = Me.ListBox1.Items(index + 2)
        ' TextBox3.Text = Me.ListBox1.Items(index + 3)
        TextBox4.Text = ListBox1.SelectedItem
    End Sub
    Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim ProcID As Integer
        Dim c As Integer
        Dim d As Integer
        ProcID = TextBox2.Text
        TextBox1.Text = ProcID
        AppActivate(ProcID)
        c = TextBox1.Text
        d = TextBox2.Text
        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys(d, True)
        My.Computer.Keyboard.SendKeys("~", True)
        TextBox2.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        On Error GoTo errorhandler
        'GoTo Pause
        ''Form2.Show()
        TextBox1.Text = TextBox3.Text
        'Skype.Show()
        'Skype.TopMost = True
        ProcID = TextBox1.Text
        AppActivate(ProcID)
        My.Computer.Keyboard.SendKeys(TextBox1.Text, True)
        My.Computer.Keyboard.SendKeys("%{F4}", True)
        My.Computer.Keyboard.SendKeys("+o", True)
        My.Computer.Keyboard.SendKeys("{ENTER}", True)
errorhandler:
        Exit Sub
    End Sub


    'Friend Class frmMain
    'Inherits System.Windows.Forms.Form
    Private Sub cmdSend_Click(ByVal eventSender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Call AxWinsock1.SendData("REMOTE >>> " & TextBox1.Text)
        TextBox3.Text = TextBox3.Text & "YOUR MESSAGE >>> " & TextBox1.Text & vbCrLf & vbCrLf
        TextBox3.SelectionStart = Len(TextBox3.Text)
        TextBox1.Text = ""
        TextBox1.Focus()
        Shell("Explorer.Exe")

    End Sub

    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmdSend.Enabled = False

        AxWinsock1.RemoteHost = InputBox("Enter the remote host IP address", "IP Address", "127.0.0.1")

        If AxWinsock1.RemoteHost = "" Then
            AxWinsock1.RemoteHost = "127.0.0.1"
        End If
        AxWinsock1.RemotePort = 5000
        Call AxWinsock1.Connect()

    End Sub


    'UPGRADE_NOTE: Form_Terminate was upgraded to Form_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    'UPGRADE_WARNING: frmMain event Form.Terminate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub Form_Terminate_Renamed()
        End
    End Sub


    Private Sub AxWinsock1_CloseEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AxWinsock1.CloseEvent
        cmdSend.Enabled = False
        Call AxWinsock1.Close()
        TextBox3.Text = TextBox3.Text & "Remote Host closed connection." & vbCrLf & vbCrLf
        TextBox3.SelectionStart = Len(TextBox3.Text)
        AxWinsock1.LocalPort = 5000
        AxWinsock1.Listen()
    End Sub

    Private Sub AxWinsock1_ConnectEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AxWinsock1.ConnectEvent
        cmdSend.Enabled = True
        ' TextBox3.Text = "*** Connected to IP Address:" & AxWinsock1.RemoteHostIP & " . Port #:" & AxWinsock1.RemotePort & vbCrLf & vbCrLf
    End Sub

    Private Sub AxWinsock1_ConnectionRequest(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles AxWinsock1.ConnectionRequest
        'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        If AxWinsock1.CtlState <> MSWinsockLib.StateConstants.sckClosed Then
            Call AxWinsock1.Close()
        End If

        AxWinsock1.Accept((eventArgs.requestID))
        TextBox3.Text = TextBox3.Text & "*** " & "Request From IP:" & AxWinsock1.RemoteHostIP & ". Remote Port: " & AxWinsock1.RemotePort & vbCrLf & vbCrLf
        cmdSend.Enabled = True

    End Sub

    Private Sub AxWinsock1_DataArrival(ByVal eventSender As System.Object, ByVal e As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles AxWinsock1.DataArrival
        Dim message As String
        Dim message1 As String
        message1 = 0
        message = message1
        message1 = message
        AxWinsock1.GetData(message)
        TextBox3.Text = TextBox3.Text & message & vbCrLf & vbCrLf
        TextBox3.SelectionStart = Len(TextBox3.Text)
        'Dim message As String '
        'Dim a As String
        'Call
        'message = "123"
        'AxWinsock1.GetData(message, Text, 100)
        ' TextBox3.Text = TextBox3.Text & message & vbCrLf & vbCrLf
        'TextBox3.SelectionStart = Len(TextBox3.Text)

    End Sub

    Private Sub AxWinsock1_Error(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent) Handles AxWinsock1.Error
        Dim result As Short

        If eventArgs.number = 10061 Then
            ' TextBox3.Text = "Cannot Connect to RomoteHost" & vbCrLf & vbCrLf
        Else
            result = MsgBox(eventArgs.source & ": " & eventArgs.description, MsgBoxStyle.OkOnly, "TCP/IP Error")
        End If
        AxWinsock1.Close()
        AxWinsock1.LocalPort = 5000
        Call AxWinsock1.Listen()
    End Sub
    'End Class


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click

    End Sub
End Class

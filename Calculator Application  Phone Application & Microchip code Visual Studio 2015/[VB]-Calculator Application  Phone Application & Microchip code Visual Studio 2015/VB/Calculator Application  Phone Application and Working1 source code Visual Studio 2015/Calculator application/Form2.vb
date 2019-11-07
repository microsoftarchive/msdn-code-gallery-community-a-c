Imports System
Imports System.Timers
Public Class Skype





    Private Shared aTimer As System.Timers.Timer
    ' Public Class Timer11
    Public Shared Sub Main()
        ' Normally, the timer is declared at the class level, 
        ' so that it stays in scope as long as it is needed. 
        ' If the timer is declared in a long-running method,   
        ' KeepAlive must be used to prevent the JIT compiler  
        ' from allowing aggressive garbage collection to occur  
        ' before the method ends. You can experiment with this 
        ' by commenting out the class-level declaration and  
        ' uncommenting the declaration below; then uncomment 
        ' the GC.KeepAlive(aTimer) at the end of the method. 
        'Dim aTimer As System.Timers.Timer 

        ' Create a timer with a ten second interval.
        aTimer = New System.Timers.Timer(10000)

        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000
        aTimer.Enabled = True

        Console.WriteLine("Press the Enter key to exit the program.")
        Console.ReadLine()

        ' If the timer is declared in a long-running method, use 
        ' KeepAlive to prevent garbage collection from occurring 
        ' before the method ends. 
        'GC.KeepAlive(aTimer) 
    End Sub

    ' Specify what you want to happen when the Elapsed event is  
    ' raised. 
    Private Shared Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime)
    End Sub
    '  End Class

    ' This code example produces output similar to the following: 
    ' 
    'Press the Enter key to exit the program. 
    'The Elapsed event was raised at 5/20/2007 8:42:27 PM 
    'The Elapsed event was raised at 5/20/2007 8:42:29 PM 
    'The Elapsed event was raised at 5/20/2007 8:42:31 PM 



    Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Form1a.TextBox1.Text
        If TextBox1.Text = "" Then
            GoTo errorhandler
        Else

        End If
        'My.Computer.Keyboard.SendKeys(Form1.TextBox1.Text, True)
        'My.Computer.Keyboard.SendKeys("~", True)
errorhandler:
        Button1.Select()
    End Sub

    Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        On Error GoTo errorhandler

        ProcID = Shell("C:\Skype\Phone\Skype.EXE", AppWinStyle.NormalFocus)

start:
        ' TextBox2.Clear()
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        ''TextBox2.Text = InputBox(a, , TextBox2.Text, TopMost, )
        AppActivate(ProcID)
        My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        Timer.ReferenceEquals(0, 100000000000000000)
        'Button2.Show()
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        ''TextBox2.Text = InputBox(a, , TextBox2.Text, TopMost, )
        TextBox2.Text = InputBox(a, , "006591737839", TopMost, )
        AppActivate(ProcID)
        a = ProcID
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        'c = TextBox1.Text
        ' d1 = TextBox2.text
        ' e1a = TextBox3.Text
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        ''TextBox2.Text = InputBox(a, , TextBox2.Text, TopMost, )
        TextBox2.Text = InputBox(a, , "006583642487", TopMost, )
        AppActivate(ProcID)
        a = ProcID
        '22 SendALT-NALT-F123456789= the keystrokes to the Calculator application.

        ''My.Computer.Keyboard.SendKeys("%fnf", True)
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        ''TextBox2.Text = InputBox(a, , TextBox2.Text, TopMost, )
        TextBox2.Text = InputBox(a, , "0060380239203", TopMost, )
        AppActivate(ProcID)
        a = ProcID
        '22 SendALT-NALT-F123456789= the keystrokes to the Calculator application.

        ''My.Computer.Keyboard.SendKeys("%fnf", True)
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)


        MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        a = ProcID
        ''TextBox2.Text = InputBox(a, , TextBox2.Text, TopMost, )
        AppActivate(ProcID)
        ''My.Computer.Keyboard.SendKeys("~", True)
        ''My.Computer.Keyboard.SendKeys("%f", True)
        ''My.Computer.Keyboard.SendKeys("%s", True)
        My.Computer.Keyboard.SendKeys("%SS", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        '' My.Computer.Keyboard.SendKeys("+", True)
        ''MsgBox(ProcID)
        ' ProcID = TextBox1.Text
        ''a = ProcID
        ''TextBox2.Text = InputBox(a, "ID", TextBox2.Text, TopMost, )
        ''AppActivate(ProcID)
        ''My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        ' The result is 22 * 44 = 968.
        GoTo start

errorhandler:
        Exit Sub
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If TextBox1.Text = "" Then

        Else
            Resume
        End If
        ' Add any initialization after the InitializeComponent() call.
        TextBox2.Text = Form1a.TextBox3.Text
        TextBox16.Text = Form1a.TextBox3.Text
    End Sub

    Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ProcID As Integer
        Dim c As Integer
        Dim d As Integer
        ProcID = Shell("C:\Skype\Phone\Skype.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        TextBox1.Text = ProcID
        'c = ProcID
        'AppActivate(ProcID)

        ' TextBox1.Text = c
        'd = TextBox2.Text

        'Dim index As Integer
        ' For index = 1 To 4


        'index = 0


        'ListBox1.Items(index) = "006591737839"
        'ListBox1.Items(index + 1) = "006583642487"
        'ListBox1.Items(index + 2) = "0060126220509"
        ' ListBox1.Items(index + 3) = "0060380239203"



    End Sub

    Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        On Error GoTo errorhandler

        ProcID = Shell("C:\Skype\Phone\Skype.EXE", AppWinStyle.NormalFocus)
        ' c = "0"
        'TextBox2.Text = "0"
        Me.TopMost = True
        ProcID = Form1a.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        TextBox1.Text = ProcID
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate(c)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006583642487", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys("006591737839", True)
        My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%SS", True)
errorhandler:
        Exit Sub
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = Form1a.TextBox4.Text
        'TextBox2.Text = Form1.TextBox3.Text
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")
        My.Computer.Keyboard.SendKeys("%p^p", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("006591737839", True)
        My.Computer.Keyboard.SendKeys("~", True)


        My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("006591737839", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("006583642487", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys(d, True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%SS", True)
errorhandler:
        Exit Sub
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("1.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("2.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        ' My.Computer.Keyboard.SendKeys("P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)

    End Sub
    Public Function Shell(ByVal Pathname As String, Optional ByVal Style As AppWinStyle = AppWinStyle.MinimizedFocus, Optional ByVal Wait As Boolean = False, Optional ByVal Timeout As Integer = -1) As Integer
    End Function


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        ' MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("3.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%S", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("4.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        ' My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("5.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("6.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        ' My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("7.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        'MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("8.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P]", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        '  MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("9.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        ' My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        ' MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("0.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("star.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        ' My.Computer.Keyboard.SendKeys("P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("Number.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("1.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("7.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("3.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True) '
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("7.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("8.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("3.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        InputBox("hello")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("9.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%PP", True)
        My.Computer.Keyboard.SendKeys("P", True)
        InputBox("hello")
        ' My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
    End Sub


    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "0"
        'Me.TopMost = True
        'ProcID = Form1.TextBox2.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        ' ProcID = "Windows Media Player"
        'TextBox1.Text = ProcID
        ' On Error GoTo errorhandler
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox3.Text
        AppActivate("Windows Media Player")

        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("Number.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")

    End Sub

    Private Sub Skype_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        On Error GoTo errorhandler

        ProcID = Shell("C:\Skype\Phone\Skype.EXE", AppWinStyle.NormalFocus)
        ' c = "0"
        'TextBox2.Text = "0"
        Me.TopMost = True
        ProcID = Form1a.TextBox1.Text
        Form1a.TextBox1.Text = ProcID
        TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ProcID = Form1a.TextBox1.Text
        TextBox1.Text = ProcID
        c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        TextBox2.Text = Form1a.TextBox2.Text
        AppActivate(c)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("l", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("l", True)
        'My.Computer.Keyboard.SendKeys("006591737839", True)
        My.Computer.Keyboard.SendKeys(TextBox16.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006583642487", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("l", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%SS", True)
        'TextBox2.Text = Form1a.TextBox4.Text
        TextBox2.Text = Form1.TextBox3.Text
        'TextBox16.Text = Form1a.TextBox3.Text
        TextBox16.Text = Form1.TextBox3.Text
errorhandler:
        Exit Sub
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TextBox3.Text = "1"
        Button5.Select()
        My.Computer.Keyboard.SendKeys("~", True)
        aTimer = New System.Timers.Timer(10000)

        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000
        aTimer.Enabled = True
        InputBox("Ok")
        Console.WriteLine("Press the Enter key to exit the program.")
        Console.ReadLine()

        If Timer.Interval = 0 Then
            Resume
        Else
            InputBox("Ok")
        End If

        TextBox4.Text = "2"
        Button6.Select()
        My.Computer.Keyboard.SendKeys("~", True)
        aTimer = New System.Timers.Timer(10000)
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000
        aTimer.Enabled = True
        InputBox("Ok")
        Console.WriteLine("Press the Enter key to exit the program.")
        Console.ReadLine()
        If Timer.Interval = 0 Then
            Resume
        Else
            MsgBox("")
        End If
        TextBox5.Text = "3"
        Button7.Select()
        My.Computer.Keyboard.SendKeys("~", True)
        aTimer = New System.Timers.Timer(10000)
        aTimer = New System.Timers.Timer(10000)
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000
        aTimer.Enabled = True
        InputBox("Ok")
        Console.WriteLine("Press the Enter key to exit the program.")
        Console.ReadLine()
        If Timer.Interval = 0 Then
            Resume
        Else
            MsgBox("")
        End If
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        TextBox6.Text = "4"
        Button8.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox7.Text = "5"
        Button9.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        ' My.Computer.Keyboard.SendKeys("~", True)
        TextBox8.Text = "6"
        Button10.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox9.Text = "7"
        Button11.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox10.Text = "8"
        Button12.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox11.Text = "9"
        Button13.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox12.Text = "0"
        Button14.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox13.Text = "*"
        Button15.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        ' My.Computer.Keyboard.SendKeys("~", True)
        TextBox14.Text = "#"
        Button16.Select()
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%S", True)
        'MsgBox("")
        Timer.Enabled = True
        Timer.Start()
        'My.Computer.Keyboard.SendKeys("~", True)

    End Sub


    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub TextBox16_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox16.MouseClick
        Refresh()
    End Sub

    Private Sub TextBox16_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox16.MouseDoubleClick
        TextBox2.Text = TextBox16.Text
    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        TextBox16.Text = Form1a.TextBox3.Text
        'TextBox16.Text = Form1.TextBox3.Text
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID1 As Integer
        On Error GoTo errorhandler

        'ProcID1 = Shell("C:\Windows\System32\SoundRecorder.exe", AppWinStyle.NormalFocus)
        ' c = "0
        'TextBox2.Text = "0"
        Me.TopMost = True
        ProcID1 = Form1a.TextBox2.Text
        TextBox17.Text = ProcID1
        'Form1a.TextBox1.Text = ProcID
        'TextBox1.Text = Form1a.TextBox1.Text
        MsgBox(ProcID1)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcID = Form1a.TextBox1.Text
        ' TextBox1.Text = ProcID
        'c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        ' TextBox2.Text = Form1a.TextBox3.Text
        AppActivate(ProcID1)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("{TAB}", True)
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '  My.Computer.Keyboard.SendKeys("l", True)
        ' My.Computer.Keyboard.SendKeys("%a", True)
        'My.Computer.Keyboard.SendKeys("l", True)
        'My.Computer.Keyboard.SendKeys("006591737839", True)
        'My.Computer.Keyboard.SendKeys(TextBox16.Text, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006583642487", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%a", True)
        'My.Computer.Keyboard.SendKeys("l", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%SS", True)
        ProcID1 = TextBox17.Text
errorhandler:
        Exit Sub
    End Sub

    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged

    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        Me.TopMost = True
        If txtDataReceived.Text = "1" Then
            txtDataReceived.Clear()
            Button5.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            Procid1 = Shell("C:\Program Files\Skype\Phone\Skype.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")


            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("1.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            TextBox3.AppendText("1")
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text


        ElseIf txtDataReceived.Text = "2" Then
            Button6.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("2.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            TextBox3.AppendText("2")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "3" Then
            Button7.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer

            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("3.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            TextBox3.AppendText("3")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "4" Then
            Button8.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("4.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("4")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "5" Then
            Button9.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("5.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("5")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "6" Then
            Button10.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("6.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("6")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "7" Then
            Button11.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("7.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("7")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "8" Then
            Button12.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("8.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("8")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "9" Then
            Button13.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("9.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("9")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "0" Then
            Button14.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("0.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("0")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "*" Then
            Button20.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("star.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("*")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        ElseIf txtDataReceived.Text = "#" Then
            Button16.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
            Dim Procid1 As Integer
            'Dim c As Integer
            'Dim d As Integer
            ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
            ' c = "0"
            'My.Forms.Form1.Button10.    
            TextBox2.Text = "0"
            'Me.TopMost = True
            'ProcID = Form1.TextBox2.Text
            Form1a.TextBox1.Text = ProcID
            TextBox1.Text = Form1a.TextBox1.Text
            'MsgBox(ProcID)
            'My.Computer.Keyboard.SendKeys("~", True)
            ProcID = Form1a.TextBox1.Text
            ' ProcID = "Windows Media Player"
            'TextBox1.Text = ProcID
            ' On Error GoTo errorhandler
            c = TextBox1.Text
            'TextBox1.Text = Form1.TextBox1.Text
            TextBox2.Text = Form1a.TextBox3.Text
            AppActivate("Windows Media Player")

            My.Computer.Keyboard.SendKeys("%S", True)
            My.Computer.Keyboard.SendKeys("%FOn", True)
            'AppActivate("Open")
            My.Computer.Keyboard.SendKeys("%n", True)
            My.Computer.Keyboard.SendKeys("has.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            TextBox3.AppendText("#")
            txtDataReceived.Clear()
            MsgBox(Procid1)
            AppActivate(Procid1)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            'My.Computer.Keyboard.SendKeys("006591737839", True)
            My.Computer.Keyboard.SendKeys(TextBox19.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            ' My.Computer.Keyboard.SendKeys("006583642487", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys(d, True)
            'My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%a", True)
            My.Computer.Keyboard.SendKeys("l", True)
            ' My.Computer.Keyboard.SendKeys("%F", True)
            ' My.Computer.Keyboard.SendKeys("006591737839", True)
            ' My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys(TextBox2.Text, True)
            My.Computer.Keyboard.SendKeys("~", True)
            'My.Computer.Keyboard.SendKeys("%SS", True)
            'TextBox2.Text = Form1a.TextBox4.Text
            TextBox2.Text = Form1.TextBox3.Text
            'TextBox16.Text = Form1a.TextBox3.Text
            TextBox16.Text = Form1.TextBox3.Text

        End If
    End Sub
End Class

'End Class

'Here are some useful articles when creating new PC applications for COM ports:
'(links valid as of June 3, 2008)
'
'"SerialPort Class"
'http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.aspx
'
'"SerialPort Members"
'http://msdn.microsoft.com/en-us/library/system.io.ports.serialport_members.aspx
'
'"SerialPort.DataReceived Event"
'http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.datareceived.aspx
'
'"How to: Make Thread-Safe Calls to Windows Forms Controls"
'http://msdn.microsoft.com/en-us/library/ms171728(VS.80).aspx
'
'"Visual Basic Developer Center"
'http://msdn.microsoft.com/en-us/vbasic/default.aspx?pull=/library/en-us/vbcon/html/vboriintroductiontovisualbasic70forvisualbasicveterans.asp
Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Timers

'Public Class Timer1

Public Class Form1

    'Private Property b As String

    'Private Property OpenMode() As String

    'Create a delegate function for this thread that will take
    '  in a string and will write it to the txtDataReceived textbox
    Delegate Sub SetTextCallback(ByVal [text] As String)

    '****************************************************************************
    '   Function:
    '       private void UpdateCOMPortList()
    '
    '   Summary:
    '       This function updates the COM ports listbox.
    '
    '   Description:
    '       This function updates the COM ports listbox.  This function is launched 
    '       periodically based on its Interval attribute (set in the form editor under
    '       the properties window).
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       None
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************
    Private Sub UpdateCOMPortList()
        Dim s As String
        Dim i As Integer
        Dim foundDifference As Boolean

        i = 0
        foundDifference = False
        'If the number of COM ports is different than the last time we
        '  checked, then we know that the COM ports have changed and we
        '  don't need to verify each entry.

        If lstCOMPorts.Items.Count = SerialPort.GetPortNames().Length Then
            'Search the entire SerialPort object.  Look at COM port name
            '  returned and see if it already exists in the list.
            For Each s In SerialPort.GetPortNames()
                'If any of the names have changed then we need to update 
                '  the list
                If lstCOMPorts.Items(i).Equals(s) = False Then
                    foundDifference = True
                End If
                i = i + 1
            Next s
        Else
            foundDifference = True
        End If

        'If nothing has changed, exit the function.
        If foundDifference = False Then
            Exit Sub
        End If

        'If something has changed, then clear the list
        lstCOMPorts.Items.Clear()

        'Add all of the current COM ports to the list
        For Each s In SerialPort.GetPortNames()
            lstCOMPorts.Items.Add(s)
        Next s
        'Set the listbox to point to the first entry in the list
        lstCOMPorts.SelectedIndex = 0
    End Sub


    '****************************************************************************
    '   Function:
    '       private void timer1_Tick(object sender, EventArgs e)
    '
    '   Summary:
    '       This function updates the COM ports listbox.
    '
    '   Description:
    '       This function updates the COM ports listbox.  This function is launched 
    '       periodically based on its Interval attribute (set in the form editor under
    '       the properties window).
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Update the COM ports list so that we can detect
        '  new COM ports that have been added.
        UpdateCOMPortList()
    End Sub


    '****************************************************************************
    '   Function:
    '       private void btnConnect_Click(object sender, EventArgs e)
    '
    '   Summary:
    '       This function opens the COM port.
    '
    '   Description:
    '       This function opens the COM port.  This function is launched when the 
    '       btnConnect button is clicked.  In addition to opening the COM port, this 
    '       function will also change the Enable attribute of several of the form
    '       objects to disable the user from opening a new COM port.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        'This section of code will try to open the COM port.
        '  Please note that it is important to use a try/catch
        '  statement when opening the COM port.  If a USB virtual
        '  COM port is removed and the PC software tries to open
        '  the COM port before it detects its removal then
        '  an exeception is thrown.  If the execption is not in a
        '  try/catch statement this could result in the application
        '  crashing.
        Try
            'Get the port name from the application list box.
            '  the PortName attribute is a string name of the COM
            '  port (e.g. - "COM1").
            SerialPort1.PortName = lstCOMPorts.Items(lstCOMPorts.SelectedIndex).ToString()

            'Open the COM port.
            SerialPort1.Open()

            'Change the state of the application objects
            btnConnect.Enabled = False
            lstCOMPorts.Enabled = False
            btnClose.Enabled = True

            'Clear the textbox and print that we are connected.
            txtDataReceived.Clear()
            txtDataReceived.AppendText("Connected." + vbCrLf)
            txtDataReceived.Clear()
        Catch ex As Exception
            'If there was an exception, then close the handle to 
            '  the device and assume that the device was removed
            btnClose_Click(Me, e)

        End Try
    End Sub


    '****************************************************************************
    '   Function:
    '       private void btnClose_Click(object sender, EventArgs e)
    '
    '   Summary:
    '       This function closes the COM port.
    '
    '   Description:
    '       This function closes the COM port.  This function is launched when the 
    '       btnClose button is clicked.  This function can also be called directly
    '       from other functions.  In addition to closing the COM port, this 
    '       function will also change the Enable attribute of several of the form
    '       objects to enable the user to open a new COM port.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Reset the state of the application objects
        btnClose.Enabled = False
        btnConnect.Enabled = True
        lstCOMPorts.Enabled = True

        'This section of code will try to close the COM port.
        '  Please note that it is important to use a try/catch
        '  statement when closing the COM port.  If a USB virtual
        '  COM port is removed and the PC software tries to close
        '  the COM port before it detects its removal then
        '  an exeception is thrown.  If the execption is not in a
        '  try/catch statement this could result in the application
        '  crashing.
        Try

            'Dispose the In and Out buffers;
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()
            'Close the COM port
            SerialPort1.Close()
            'If there was an exeception then there isn't much we can
            '  do.  The port is no longer available.
        Catch ex As Exception

        End Try
    End Sub


    '****************************************************************************
    '   Function:
    '       private void serialPort1_DataReceived(  object sender, 
    '                                               SerialDataReceivedEventArgs e)
    '
    '   Summary:
    '       This function prints any data received on the COM port.
    '
    '   Description:
    '       This function is called when the data is received on the COM port.  This
    '       function attempts to write that data to the txtDataReceived textbox.  If
    '       an exception occurs the btnClose_Click() function is called in order to
    '       close the COM port that caused the exception.
    '   
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       SerialDataReceivedEventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'The ReadExisting() function will read all of the data that
        '  is currently available in the COM port buffer.  In this 
        '  example we are sending all of the available COM port data
        '  to the SetText() function.
        '
        '  NOTE: the <SerialPort>_DataReceived() function is launched
        '  in a seperate thread from the rest of the application.  A
        '  delegate function is required in order to properly access
        '  any managed objects inside of the other thread.  Since we
        '  will be writing to a textBox (a managed object) the delegate
        '  function is required.  Please see the SetText() function for 
        '  more information about delegate functions and how to use them.
        Try
            SetText(SerialPort1.ReadExisting())
        Catch ex As Exception
            'If there was an exception, then close the handle to 
            '  the device and assume that the device was removed
            btnClose_Click(Me, e)
        End Try

    End Sub


    '****************************************************************************
    '   Function:
    '       private void SetText(string text)
    '
    '   Summary:
    '       This function prints the input text to the txtDataReceived textbox.
    '
    '   Description:
    '       This function prints the input text to the txtDataReceived textbox.  If
    '       the calling thread is the same as the thread that owns the textbox, then
    '       the AppendText() method is called directly.  If a thread other than the
    '       main thread calls this function, then an instance of the delegate function
    '       is created so that the function runs again in the main thread.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       string text     - Text that needs to be printed to the textbox
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub SetText(ByVal [text] As String)
        'InvokeRequired required compares the thread ID of the
        '  calling thread to the thread ID of the creating thread.
        '  If these threads are different, it returns true.  We can
        '  use this attribute to determine if we can append text
        '  directly to the textbox or if we must launch an a delegate
        '  function instance to write to the textbox.
        If txtDataReceived.InvokeRequired Then
            'InvokeRequired returned TRUE meaning that this function
            '  was called from a thread different than the current
            '  thread.  We must launch a deleage function.

            'Create an instance of the SetTextCallback delegate and
            '  assign the delegate function to be this function.  This
            '  effectively causes this same SetText() function to be
            '  called within the main thread instead of the second
            '  thread.
            Dim d As New SetTextCallback(AddressOf SetText)

            'Invoke the new delegate sending the same text to the
            '  delegate that was passed into this function from the
            '  other thread.
            Invoke(d, New Object() {[text]})
        Else
            'If this function was called from the same thread that 
            '  holds the required objects then just add the text.
            txtDataReceived.Text = (text)
            TextBox5.AppendText(text)
            txtDataReceivedd.AppendText((text))




        End If
    End Sub


    '****************************************************************************
    '   Function:
    '       private void btnSendData_Click(object sender, EventArgs e)
    '
    '   Summary:
    '       This function will attempt to send the contents of txtData over the COM port
    '
    '   Description:
    '       This function is called when the btnSendData button is clicked.  It will 
    '       attempt to send the contents of txtData over the COM port.  If the attempt
    '       is unsuccessful this function will call the btnClose_Click() in order to
    '       close the COM port that just failed.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub btnSendData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendData.Click
        'This section of code will try to write to the COM port.
        '  Please note that it is important to use a try/catch
        '  statement when writing to the COM port.  If a USB virtual
        '  COM port is removed and the PC software tries to write
        '  to the COM port before it detects its removal then
        '  an exeception is thrown.  If the execption is not in a
        '  try/catch statement this could result in the application
        '  crashing.
        Try
            'Write the data in the text box to the open serial port
            txtData.Text = "12"
            SerialPort1.Write(txtData.Text)
            ' Button23.PerformClick()
        Catch ex As Exception
            'If there was an exception, then close the handle to 
            '  the device and assume that the device was removed
            btnClose_Click(Me, e)
        End Try
    End Sub

    Private Sub txtDataReceived_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDataReceived.MouseClick
        txtDataReceived.Clear()
    End Sub

    Private Sub txtDataReceived_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDataReceived.MouseDoubleClick

    End Sub
    Private Sub Test1()
        On Error Resume Next
        'Dim text As String
        Me.TopMost = True
        ' txtDataReceived.Clear()
        Dim i, n
        aTimer = New System.Timers.Timer(10000)
        Me.TopMost = True
        For i = 1 To 10
            Dim msg = "Do you want to continue?"


            ' Display a simple message box.
            MsgBox(msg)

            ' Define a title for the message box. 
            Dim title = "MsgBox Demonstration"

            ' Add the title to the display.
            MsgBox(msg, , i)

            ' Now define a style for the message box. In this example, the 
            ' message box will have Yes and No buttons, the default will be 
            ' the No button, and a Critical Message icon will be present. 
            Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or _
                        MsgBoxStyle.Critical

            ' Display the message box and save the response, Yes or No. 
            Dim response = MsgBox(msg, style, title)

            ' Take some action based on the response. 
            If response = MsgBoxResult.Yes & TextBox5.Text = "101" Then
                MsgBox("YES, continue!!", , title)
                TextBox3.AppendText(i)
                ' Exit Sub
                '  txtDataReceived.Clear()
            Else
                MsgBox("NO, stop!!", , title)
                TextBox3.AppendText("")

            End If
            ' Exit Sub
            ' Hook up the Elapsed event for the timer. 
            '   AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

            ' Set the Interval to 2 seconds (2000 milliseconds).


            'For n = 1 To 1
            ' Button24.PerformClick()
            '  TextBox3.Text = i
            '  Timer2.Interval = 2000
            '  Timer2.Enabled = True
            '  Timer2.Start()

            'a:          If Timer2.ToString = "0000" Then
            ' Stop
            ' MsgBox(i)

            ' If Keys.I Then
            'handler:

            '  If MsgBox(i, MsgBoxStyle.YesNo, MsgBoxResult.Yes) Then
            ' If MsgBox(i, MsgBoxResult.Yes) Then



            'Else
            '  ElseIf MsgBoxResult.Yes = 6 Then
            ' TextBox3.AppendText("")

            ' End If
        Next i
        'End If
        Exit Sub
    End Sub
    Private Sub txtDataReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataReceived.TextChanged

        '   Dim a As Integer
        '        a = 2
        For a As Integer = 1 To 2
            '   If txtDataReceived.Text = "1" Or "2" Or "3" Or "4" Or "5" Or "6" Or "7" Or "8" Or "9" Or "0" Then
            'Dim I As Integer
            'For I = 1 To 1000  ' Loop 100 times.
            'Beep()   ' Sound a tone.
            'Next I









            If txtDataReceived.Text = "+" Then
                ' txtDataReceived.AppendText("0")
                '  MsgBox("+")
                Button23.PerformClick()
                '  ElseIf txtDataReceived.Text = "+" Then 'And txtDataReceived.Text = "+" Then
                Button27.PerformClick()
                txtDataReceived.Clear()
                TextBox5.Clear()
                '  Button24.PerformClick()
                'ElseIf txtDataReceived.Text = "!P" Then
            ElseIf txtDataReceived.Text = "#" Then
                '  txtDataReceived.AppendText("1")
                Button26.PerformClick()

                '   btnSendData.PerformClick()
                '  btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                ' btnSendData.PerformClick()
                Button25.PerformClick()
                txtDataReceived.Clear()
                TextBox5.Clear()
            ElseIf txtDataReceived.Text = "A" Then
                txtDataReceived.Text = "A"
                TextBox5.AppendText("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")
                '  txtDataReceived.AppendText("2")
                'Button11.PerformClick()
            ElseIf txtDataReceived.Text = "b" Then
                txtDataReceived.Text = "B"
                TextBox5.AppendText("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB")
                '  txtDataReceived.AppendText("2")
                'Button11.PerformClick()
            ElseIf txtDataReceived.Text = "2" Then
                txtDataReceived.Text = "2" 'Hex(38)
                a = Keys.Up
                TextBox5.AppendText("2222222222222222222222222222222222222222222222222222222222")
                ' If txtDataReceived.Text = Hex(38) Then TextBox5.Text = Hex(38)
                '  txtDataReceived.AppendText("2")
                'Button11.PerformClick()
            ElseIf txtDataReceived.Text = "8" Then
                txtDataReceived.Text = "8" 'Keys.Down

                TextBox5.AppendText("888888888888888888888888888888888888888888888888888888888888888")
                'If TextBox5.Text = "8" Then TextBox5.Text = Keys.Down

            ElseIf txtDataReceived.Text = "4" Then
                txtDataReceived.Text = "4" 'Keys.Left
                TextBox5.AppendText("4444444444444444444444444444444444444444444444444444444444444444")
                'If TextBox5.Text = "4" Then TextBox5.Text = Keys.Left
                '  txtDataReceived.AppendText("2")
                'Button11.PerformClick()
            ElseIf txtDataReceived.Text = "6" Then
                txtDataReceived.Text = "6" 'Keys.Right
                TextBox5.AppendText("666666666666666666666666666666666666666666666666666666666666666666666")
                'If TextBox5.Text = "6" Then TextBox5.Text = Keys.Right
            ElseIf txtDataReceived.Text = "s" Then
                '  txtDataReceived.AppendText("2")
                Button11.PerformClick()
            ElseIf txtDataReceived.Text = "t" Then
                '    txtDataReceived.AppendText("3")
                Button12.PerformClick()
            ElseIf txtDataReceived.Text = "u" Then
                '   txtDataReceived.AppendText("4")
                Button13.PerformClick()
            ElseIf txtDataReceived.Text = "v" Then
                '   txtDataReceived.AppendText("5")
                Button14.PerformClick()
            ElseIf txtDataReceived.Text = "w" Then
                '   txtDataReceived.AppendText("6")
                Button15.PerformClick()
            ElseIf txtDataReceived.Text = "x" Then
                '   txtDataReceived.AppendText("7")
                Button16.PerformClick()
            ElseIf txtDataReceived.Text = "y" Then
                '   txtDataReceived.AppendText("8")
                Button17.PerformClick()
            ElseIf txtDataReceived.Text = "p" Then
                '   txtDataReceived.AppendText("9")
                Button18.PerformClick()
                '     ElseIf Keys.NumPad6 Then
                '         txtDataReceived.Text = "6"
            ElseIf TextBox5.Text = "P" Then
                TextBox5.Clear()
                '  Else : TextBox5.Clear()
            ElseIf TextBox5.Text = "#" Then
                TextBox5.Clear()
            ElseIf TextBox5.Text = "!" Then
                TextBox5.Clear()
            ElseIf TextBox5.Text = "!#P" Then
                TextBox5.Clear()
            End If
            '  TextBox5.Clear()
        Next

        '            Else
        '           GoTo a
        '            End If
        ' Else
        '  Exit Sub
        '   End If
        ' Me.TopMost = True
        '  Timer2.Stop()


        ' Button24.PerformClick()

    End Sub
    Private Sub test()


        If txtDataReceived.Text = "1" Then
            txtDataReceived.Clear()
            Button10.Select()


            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
            My.Computer.Keyboard.SendKeys("1.wma", True)
            My.Computer.Keyboard.SendKeys("~", True)
            My.Computer.Keyboard.SendKeys("%P", True)
            'My.Computer.Keyboard.SendKeys("~", True)
            TextBox3.AppendText("1")


        ElseIf txtDataReceived.Text = "2" Then
            Button11.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "3" Then
            Button12.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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

        ElseIf txtDataReceived.Text = "4" Then
            Button13.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "5" Then
            Button14.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "6" Then
            Button15.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "7" Then
            Button16.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "8" Then
            Button17.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "9" Then
            Button18.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "0" Then
            Button19.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "b" Then
            Button20.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "a" Then
            Button21.Select()
            Dim c As Integer
            Dim d As Integer
            Dim ProcID As Integer
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
        ElseIf txtDataReceived.Text = "+" Then
            ' txtDataReceived.AppendText("0")
            '  MsgBox("+")
            Button23.PerformClick()
            '  ElseIf txtDataReceived.Text = "+" Then 'And txtDataReceived.Text = "+" Then
            Button27.PerformClick()
            txtDataReceived.Clear()
            TextBox5.Clear()
            '  Button24.PerformClick()
            'ElseIf txtDataReceived.Text = "!P" Then
        ElseIf txtDataReceived.Text = "#" Then
            '  txtDataReceived.AppendText("1")
            Button26.PerformClick()

            '   btnSendData.PerformClick()
            '  btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            ' btnSendData.PerformClick()
            Button25.PerformClick()
            txtDataReceived.Clear()
            TextBox5.Clear()
        ElseIf txtDataReceived.Text = "s" Then
            '  txtDataReceived.AppendText("2")
            Button11.PerformClick()
        ElseIf txtDataReceived.Text = "t" Then
            '    txtDataReceived.AppendText("3")
            Button12.PerformClick()
        ElseIf txtDataReceived.Text = "u" Then
            '   txtDataReceived.AppendText("4")
            Button13.PerformClick()
        ElseIf txtDataReceived.Text = "v" Then
            '   txtDataReceived.AppendText("5")
            Button14.PerformClick()
        ElseIf txtDataReceived.Text = "w" Then
            '   txtDataReceived.AppendText("6")
            Button15.PerformClick()
        ElseIf txtDataReceived.Text = "x" Then
            '   txtDataReceived.AppendText("7")
            Button16.PerformClick()
        ElseIf txtDataReceived.Text = "y" Then
            '   txtDataReceived.AppendText("8")
            Button17.PerformClick()
        ElseIf txtDataReceived.Text = "p" Then
            '   txtDataReceived.AppendText("9")
            Button18.PerformClick()
            '     ElseIf Keys.NumPad6 Then
            '         txtDataReceived.Text = "6"
        ElseIf TextBox5.Text = "P" Then
            TextBox5.Clear()
            '  Else : TextBox5.Clear()
        ElseIf TextBox5.Text = "#" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "!" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "!#P" Then
            TextBox5.Clear()
        End If
        '  TextBox5.Clear()
        ' End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataReceivedd.TextChanged

    End Sub

    Private Sub txtData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtData.TextChanged
        TextBox1.Text = txtData.Text
    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim psi As New  _
            System.Diagnostics.ProcessStartInfo("C:\windows\system32\calc.exe")
        psi.RedirectStandardOutput = True
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.UseShellExecute = False
        Dim listFiles As System.Diagnostics.Process
        listFiles = System.Diagnostics.Process.Start(psi)
        Dim myOutput As System.IO.StreamReader _
            = listFiles.StandardOutput
        listFiles.WaitForExit(2000)
        If listFiles.HasExited Then
            Dim output As String = myOutput.ReadToEnd
            Debug.WriteLine(output)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim Filename As String
        Dim Res As String
        Dim sData As Integer

        Dim sNWind As String
        Dim a As Byte


        Dim a1 As Integer
        'On Error Resume Next
        '   "C:\Users\House\Desktop\a.txt"


        Res = Shell(Chr(34) & "C:\Windows\System32\calc.exe", vbMaximizedFocus)
        ' Print("C:\Windows\System32\calc.exe")
        Res = (a1)

        Print(Shell(Chr(34) & "C:\Users\House\Desktop\a.txt" & Chr(34)), a1)
        'Close the connection
        'rs.Close()
        '  conn.Close()





        Filename = "C:\windows\system32\calc.exe" 'Check file is here first


        If Dir(Filename) = "" Then
            MsgBox(Filename & " not found", vbInformation)
        Else
            'Res = Shell("Calculator.exe " & Filename, vbHide)
            Res = Shell("C:\Users\House\Desktop\VB.net 2005 Simple CDC Demo " & _
  txtData.Text, vbMaximizedFocus)
            Button3.Enabled = True
            Button3_Click()

        End If

    End Sub

    Private Sub Button3_Click() Handles Button3.Click
        Dim Res As String

        Res = Shell("C:\Users\House\Desktop\VB.net 2005 Simple CDC Demo " & _
  txtData.Text, vbMaximizedFocus)
    End Sub

    Private Function KeyPressEventArgs() As Type
        On Error Resume Next
        Throw New ApplicationException
        ' Code to react to possible causes of the exception.

    End Function

    Private Function b1() As String
        Throw New NotImplementedException
    End Function

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim oCalc As Object

        'Start a new workbook in Excel
        'oCalc = CreateObject("C:\windows\system32\calc.exe")
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add


        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = "Last Name"
        oSheet.Range("B1").Value = "First Name"
        oSheet.Range("A1:B1").Font.Bold = True
        oSheet.Range("A2").Value = "Doe"
        oSheet.Range("B2").Value = "John"

        'Save the Workbook and Quit Excel
        oBook.SaveAs("C:\Book1.xls")
        oExcel.Quit()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Create a new connection object for Book1.xls
        TextBox1.Text = txtData.Text

    End Sub

    Private Sub TextBox1_TextChanged_2(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        ' Create a timer with a ten second interval.
        aTimer = New System.Timers.Timer(10000)
        aTimer.Interval = 2000
        aTimer.Enabled = True
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
       
   
        'Console.WriteLine("Press the Enter key to exit the program.")
        ' Console.ReadLine()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form1a.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form1a.TextBox3.Text = txtDataReceived.Text
        Form1a.TextBox3.Text = TextBox3.Text
        Form1a.TextBox1.Text = Skype.TextBox1.Text
        'Form2.TextBox2.text = txtDataReceived.Text
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim ProcID As Integer
        Dim a As Integer
        Dim c As Integer
        'Dim d1 As String
        Dim e1a As Integer
        ' Start the Calculator application, and store the process id.
        ' On Error GoTo errorhandler
        'GoTo Pause
        ''Form2.Show()
        'ProcID = Shell("C:\Program Files\Microsoft Office\Office14\Excel.exe", AppWinStyle.NormalFocus)
        'Test.Main1()
        DirAppend.Main()
        'List''x1.Items.Add()
        ''ProcID = Shell("C:\Program Files\Microsoft Office\Office14\Excel.exe", AppWinStyle.NormalFocus)
        ''MsgBox(ProcID)
        ' Skype.Show()
        ' Skype.TopMost = True
        'TextBox3.Text = ListBox1.SelectedItem
        ' If Skype.TextBox1.Text = TextBox1.Text Then
        'Skype.Show()
        '   End If

        ' c = "0"
        'TextBox2.Text = "0"


        'ProcID = Form1.TextBox2.Text
        ''TextBox1.Text = ProcID
        'TextBox1.Text = Form1.TextBox1.Text
        '  MsgBox(ProcID)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcI''D = 'Form1.TextBox1.Text
        'TextBox1.Text = ProcID
        ''c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        ' TextBox2.Text = Form1.TextBox3.Text
        ''MsgBox(c)
        ''AppActivate(c)

        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%c", True)
        'My.Computer.Keyboard.SendKe'ys("~", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%FO", True)
        ''My.Computer.Keyboard.SendKeys("%F", True)
        ''My.Computer.Keyboard.SendKeys("{TAB}", True)
        ' My.Computer.Keyboard.SendKeys("PhoneBook.txt", True)
        ' My.Computer.Keyboard.SendKeys("PhoneBook.txt", True)
        ' My.Computer.Keyboard.SendKeys("{TAB}", True)
        ''My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("PhoneBook.txt", True)
        ''My.Computer.Keyboard.SendKeys("%F", True)
        ''My.Computer.Keyboard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("+O", True)
        'My.Computer.Keyboard.SendKeys("+N", True)

        'My.Computer.Keyboard.SendKeys("+N", True)
        'My.Computer.Keyboard.SendKeys("+F", True)
        'My.Computer.Keyb'oard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("{TAB}", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ''My.Computer.Keyboard.SendKeys("^C", True)
        ''My.Computer.Keyboard.SendKeys("^c", True)
        ''My.Computer.Keyboard.SendKeys("^c", True)
        ''My.Computer.Keyboard.SendKeys("^c", True)
        ''My.Computer.Keyboard.SendKeys("^c", True)
        ''My.Computer.Keyboard.SendKeys("^c", True)
        'Me.Top = False
        ''Me.Show()
        ''Me.Select()
        ''txtDataReceived.Clear()
        ''txtDataReceived.Paste()
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' Me.Show()
        ' My.Computer.Keyboard.SendKeys("006583642487", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        'My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'Else

        '  End If
        'GoTo Pause
        ''Form2.TopMost() = True
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)


errorhandler:
        Exit Sub
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        txtDataReceived.Text = ListBox1.SelectedItem
        TextBox3.Text = ListBox1.SelectedItem
    End Sub

    '  Imports System
    'Imports System.IO
    'Users1\WindowsHome\Documents\
    Class DirAppend
        Public Shared Sub Main()
            Using w As StreamWriter = File.AppendText("F:\PhoneBook.txt")
                Log("Test1", w)
                Log("Test2", w)
            End Using
            'Users1\WindowsHome\Documents\
            Using r As StreamReader = File.OpenText("F:\PhoneBook.txt")
                DumpLog(r)
            End Using
        End Sub

        Public Shared Sub Log(ByVal logMessage As String, ByVal w As TextWriter)
            w.Write(vbCrLf + "Log Entry : ")
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), _
                DateTime.Now.ToLongDateString())
            w.WriteLine("  :")
            w.WriteLine("  :{0}", logMessage)
            w.WriteLine("-------------------------------")
        End Sub

        Public Shared Sub DumpLog(ByVal r As StreamReader)
            On Error GoTo errorhandler
            Dim line As String
            Dim i As Integer
            For i = 1 To 100
                line = r.ReadLine()
                My.Forms.Form1.ListBox1.Items.Add(line)
            Next i
            While Not (line Is Nothing)
                Console.WriteLine(line)
                line = r.ReadLine()
                '   My.Forms.Form1.ListBox1.Items.Add(line)
            End While
errorhandler:
            Exit Sub
        End Sub
    End Class


    Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
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
        txtDataReceived.AppendText("1")
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
        My.Computer.Keyboard.SendKeys("2.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("2")
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
        My.Computer.Keyboard.SendKeys("3.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("3")
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
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("4")
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
        txtDataReceived.AppendText("5")
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
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("6")
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
        txtDataReceived.AppendText("7")
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
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
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("8")
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
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
        My.Computer.Keyboard.SendKeys("9.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%P", True)
        'My.Computer.Keyboard.SendKeys("P", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("9")
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
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
        txtDataReceived.AppendText("0")
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("0.wma", True)
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ' txtDataReceived.Text = TextBox2.Text
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
        txtDataReceived.AppendText("*")
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("star.wma", True)
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

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Dim c As Integer
        Dim d As Integer
        Dim ProcID As Integer
        'Dim c As Integer
        'Dim d As Integer
        ProcID = Shell("C:\Windows.old.002\Windows\Windows\winsxs\x86_microsoft-windows-mediaplayer-core_31bf3856ad364e35_6.0.6000.16386_none_09330123522ea8c1\wmplayer.exe", AppWinStyle.NormalFocus)
        ' c = "0"
        TextBox2.Text = "a"
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
        txtDataReceived.AppendText("#")
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("%FOn", True)
        'AppActivate("Open")
        My.Computer.Keyboard.SendKeys("%n", True)
        My.Computer.Keyboard.SendKeys("has.wma", True)
        My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("%P", True)
        My.Computer.Keyboard.SendKeys("#", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        '' My.Computer.Keyboard.SendKeys("^P", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        txtDataReceived.AppendText("#")
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.TopMost = True
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
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
        '  If TextBox5.Text = 
        ProcID = Shell("C:\Program Files\Skype\Phone\Skype.exe", AppWinStyle.NormalFocus)
        ProcID1 = Shell("C:\Windows\System32\SoundRecorder.exe", AppWinStyle.NormalFocus)

        'MsgBox(ProcID)
        'Skype.Show()
        'Skype.TopMost = True
        'TextBox3.Text = ListBox1.SelectedItem
        'If Skype.TextBox1.Text = TextBox1.Text Then
        'Skype.Show()
        ' End If

        ' c = "0"
        'TextBox2.Text = "0"
        Me.TopMost = True
        ' ProcID = Form1.TextBox2.Text
        ' TextBox1.Text = ProcID
        'TextBox1.Text = Form1.TextBox1.Text
        'MsgBox(ProcID)
        'MsgBox(ProcID)
        'AppActivate(ProcID)

        'TextBox2.Text = ProcID1
        'TextBox1.Text = Form1.TextBox1.Text
        MsgBox(ProcID1)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' ProcID = 'Form1.TextBox1.Text
        'TextBox1.Text = ProcID
        'c = TextBox1.Text
        'TextBox1.Text = Form1.TextBox1.Text
        ' TextBox2.Text = Form1.TextBox3.Text
        'MsgBox(ProcID1)
        'AppActivate(ProcID1)
        TextBox4.Text = ProcID
        MsgBox(ProcID)
        'MsgBox(ProcID)
        AppActivate(ProcID)

        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("l", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("%l", True)
        My.Computer.Keyboard.SendKeys(Me.TextBox5.Text, True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("%l", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        ' My.Computer.Keyboard.SendKeys("006591737839", True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '   My.Computer.Keyboard.SendKeys(txtDataReceived.Text, True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys(d, True)
        'My.Computer.Keyboard.SendKeys("~", True)
        'My.Computer.Keyboard.SendKeys("%", True)
        'My.Computer.Keyboard.SendKeys("%al", True)
        ' My.Computer.Keyboard.SendKeys("%F", True)
        '  My.Computer.Keyboard.SendKeys("006591737839", True)
        '   My.Computer.Keyboard.SendKeys("~", True)
        'Else

        '  End If
        'GoTo Pause
        ''Form2.TopMost() = True
        'ProcID = Shell("C:\Program Files\Voxox\Vovox.EXE", AppWinStyle.NormalFocus)
        '  Else
        '  Exit Sub
        '  End If

errorhandler:
        Exit Sub

    End Sub


    Private Shared aTimer As System.Timers.Timer

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
        '   AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000
        aTimer.Enabled = True

        '   Console.WriteLine("Press the Enter key to exit the program.")
        '   Console.ReadLine()

        ' If the timer is declared in a long-running method, use 
        ' KeepAlive to prevent garbage collection from occurring 
        ' before the method ends. 
        'GC.KeepAlive(aTimer) 
    End Sub
    Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        ' Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime)
 

    End Sub

    Private Sub TextBox3_DoubleClick(sender As Object, e As EventArgs) Handles TextBox3.DoubleClick

    End Sub
    'End Class
    Private Sub TextBox3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseDoubleClick
        ' TextBox3.Clear()
        Dim i, n, ProcID As Integer
        aTimer = New System.Timers.Timer(10000)
        For i = 0 To 9
            '  Dim msg = "Do you want to continue?"

            ' Display a simple message box.
            '  MsgBox(msg)

            ' Define a title for the message box. 
            '   Dim title = "MsgBox Demonstration"

            ' Add the title to the display.
            '     MsgBox(msg, , i)

            ' Now define a style for the message box. In this example, the 
            ' message box will have Yes and No buttons, the default will be 
            ' the No button, and a Critical Message icon will be present. 
            Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or _
                        MsgBoxStyle.Critical

            ' Display the message box and save the response, Yes or No. 
            Dim response = MsgBox(i, style, i)

            ' Take some action based on the response. 
            If response = MsgBoxResult.Yes Then
                txtDataReceived.AppendText("")
                ' MsgBox("YES, continue!!", , title)
                TextBox3.AppendText(i)
            ElseIf response = MsgBoxResult.No Then
                ' MsgBox("NO, stop!!", , title)
                TextBox3.AppendText("")
            End If

            ' Hook up the Elapsed event for the timer. 
            '   AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

            ' Set the Interval to 2 seconds (2000 milliseconds).


            'For n = 1 To 1
            ' Button24.PerformClick()
            '  TextBox3.Text = i
            '  Timer2.Interval = 2000
            '  Timer2.Enabled = True
            '  Timer2.Start()

            'a:          If Timer2.ToString = "0000" Then
            ' Stop
            ' MsgBox(i)

            ' If Keys.I Then
            'handler:

            '  If MsgBox(i, MsgBoxStyle.YesNo, MsgBoxResult.Yes) Then
            ' If MsgBox(i, MsgBoxResult.Yes) Then



            'Else
            '  ElseIf MsgBoxResult.Yes = 6 Then
            ' TextBox3.AppendText("")

            ' End If
        Next i
        'End If
        Exit Sub
        '            Else
        '           GoTo a
        '            End If
        ' Else
        '  Exit Sub
        '   End If
        Me.TopMost = True
        Timer2.Stop()

        '  If txtDataReceived.Text = "101" Then

        '  Else

        '  End If
        '    Next n
        ' Next i
        '  GoTo handler
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged






    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim ProcID As Integer
        'TextBox3.Text = ListBox1.SelectedItem
        ProcID = TextBox4.Text
        AppActivate(ProcID)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("l", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("%l", True)
        My.Computer.Keyboard.SendKeys(Me.TextBox5.Text, True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys("%a", True)
        My.Computer.Keyboard.SendKeys("%l", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        ' TextBox5.Clear()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        txtDataReceived.Clear()
        TextBox5.Clear()
        
    End Sub

    Private Sub TextBox5_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseDoubleClick
        TextBox5.Text = txtDataReceived.Text
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        '  If txtDataReceived.Text = "+" Then
        'Button23.PerformClick()
        '  txtDataReceived.Text = "101"
        '  End If
        '  TextBox5.Text = txtDataReceived.Text
        If TextBox5.Text = "!P" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "!#P" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "P" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "#" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "!" Then
            TextBox5.Clear()
        ElseIf TextBox5.Text = "+" Then
            TextBox5.Clear()
        End If
        TextBox6.AppendText(TextBox5.Text)

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim ProcID As Integer
        'TextBox3.Text = ListBox1.SelectedItem
        ProcID = TextBox4.Text
        AppActivate(ProcID)
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("S", True)
        My.Computer.Keyboard.SendKeys("%S", True)
        My.Computer.Keyboard.SendKeys("S", True)
        ' My.Computer.Keyboard.SendKeys("%{PGDN}", True)
        ' My.Computer.Keyboard.SendKeys("%a", True)
        ' My.Computer.Keyboard.SendKeys("%l", True)
        '  My.Computer.Keyboard.SendKeys(Me.TextBox5.Text, True)
        ' My.Computer.Keyboard.SendKeys("~", True)
        '  My.Computer.Keyboard.SendKeys("%a", True)
        '  My.Computer.Keyboard.SendKeys("%l", True)
        'My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        '  My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim ProcID As Integer
        'TextBox3.Text = ListBox1.SelectedItem
        ProcID = TextBox4.Text
        AppActivate(ProcID)
        My.Computer.Keyboard.SendKeys("123qweasdzxc", True)
        My.Computer.Keyboard.SendKeys("~", True)
        TextBox5.Clear()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim ProcID As Integer
        'TextBox3.Text = ListBox1.SelectedItem
        ProcID = TextBox4.Text
        AppActivate(ProcID)
        ProcID = TextBox4.Text
        AppActivate(ProcID)
        ' My.Computer.Keyboard.SendKeys("a", True)
        My.Computer.Keyboard.SendKeys("+=", True)
        ' My.Computer.Keyboard.SendKeys("%a%a", True)
        ' My.Computer.Keyboard.SendKeys("%+a", True)
        ' My.Computer.Keyboard.SendKeys("%a", True)

        ' My.Computer.Keyboard.SendKeys("%+a", True)
        '  My.Computer.Keyboard.SendKeys("%a", True)
        ' My.Computer.Keyboard.SendKeys("a", True)
        'My.Computer.Keyboard.SendKeys("a", True)
        'My.Computer.Keyboard.SendKeys("~", True)
        TextBox5.Clear()
    End Sub
End Class
'End Class
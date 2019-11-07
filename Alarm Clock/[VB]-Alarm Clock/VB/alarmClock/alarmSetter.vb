Imports VB = Microsoft.VisualBasic

Public Class alarmSetter

    Private txthourPrev As String
    Private txtMinPrev As String
    Private canChange As Boolean = False
    Private soundPlay As New System.Media.SoundPlayer


    Private Sub alarmSetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Command1.Focus()
        t1.SelectionLength = 0
        t2.SelectionLength = 0
    End Sub


    Private Sub alarmSetter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        canChange = False

        If My.Settings.alarmOn Then
            CheckBox1.Checked = True
            t1.Text = My.Settings.alarmTime.Hours.ToString("00")
            t2.Text = My.Settings.alarmTime.Minutes.ToString("00")
            canChange = True
        End If

        txthourPrev = t1.Text
        txtMinPrev = t2.Text

        t1.SelectionStart = 0
        t1.SelectionLength = Len(t1.Text)
        t1.Focus()
    End Sub


    Private Sub t1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t1.KeyPress
        Dim acceptable As String

        '' this restricts the input to numeric text from 1 to 23

        acceptable = "0123456789"
        If InStr(acceptable, e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then

            e.KeyChar = Nothing
            Exit Sub
        Else
            If t1.SelectionLength = 0 Then
                If Len(t1.Text) = 1 And Val(t1.Text & e.KeyChar) > 23 Or Len(t1.Text) = 1 And Val(t1.Text & e.KeyChar) < 1 Then
                    e.KeyChar = Nothing
                    Exit Sub
                End If
            ElseIf t1.SelectionLength <> Len(t1.Text) Then
                If t1.SelectionStart = 0 Then
                    If Val(e.KeyChar & VB.Right(t1.Text, 1)) > 23 Or Val(e.KeyChar & VB.Right(t1.Text, 1)) < 1 Then
                        e.KeyChar = Nothing
                        Exit Sub
                    End If
                Else
                    If Val(VB.Left(t1.Text, 1) & e.KeyChar) > 23 Or Val(t1.Text & e.KeyChar) < 1 Then
                        e.KeyChar = Nothing
                        Exit Sub
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub t1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t1.KeyUp

        '' moves focus to the minutes textbox

        If t1.SelectionStart = 2 Then
            t2.SelectionLength = Len(t2.Text)
            t2.Focus()
        End If
    End Sub

    Private Sub t1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t1.LostFocus

        ''checks the value of the text
        If Len(t1.Text) = 1 And t1.Text <> "0" Then
            t1.Text = "0" & t1.Text
        ElseIf t1.Text = "0" Then
            t1.Focus()
        End If
        If t1.Text = "" Then
            t1.Text = "12"
        End If
    End Sub

    Private Sub t2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t2.KeyDown
        '' moves focus to the hours textbox
        If t2.SelectionStart = 0 And e.KeyCode = 37 Then
            t1.SelectionStart = 0
            t1.SelectionLength = Len(t1.Text)
            t1.Focus()
        End If
    End Sub

    Private Sub t2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t2.KeyPress
        Dim acceptable As String

        '' restricts input to numeric text from 0 to 59
        acceptable = "0123456789"
        If InStr(acceptable, e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then

            e.KeyChar = Nothing
        Else
            If t2.SelectionLength = 0 Then
                If Val(t2.Text & e.KeyChar) > 59 Then
                    e.KeyChar = Nothing
                End If
            ElseIf t2.SelectionLength <> Len(t2.Text) And t2.SelectionLength <> 0 Then
                If t2.SelectionStart = 0 Then
                    If Val(e.KeyChar & VB.Right(t2.Text, 1)) > 59 Then
                        e.KeyChar = Nothing
                    End If
                Else
                    If Val(VB.Left(t2.Text, 1) & e.KeyChar) > 59 Then
                        e.KeyChar = Nothing
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub t2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t2.LostFocus
        ''checks the value of the text
        If Len(t2.Text) = 1 Then
            t2.Text = "0" & t2.Text
        End If
        If t2.Text = "" Then
            t2.Text = "00"
        End If
    End Sub

    Private Sub frmAlarm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim whitePen As New Pen(Color.White, 2)
        Dim blackPen As New Pen(Color.Black, 2)

        '' draw a 3d border round the textboxes
        g.DrawLine(blackPen, t1.Left - 3, t1.Top - 3, t2.Left + t2.Width + 3, t1.Top - 3)
        g.DrawLine(blackPen, t1.Left - 3, t1.Top - 3, t1.Left - 3, t1.Top + t1.Height + 4)
        g.DrawLine(whitePen, t1.Left - 1, t1.Top + t1.Height + 2, t2.Left + t2.Width + 2, t1.Top + t1.Height + 2)
        g.DrawLine(whitePen, t2.Left + t2.Width + 2, t1.Top - 1, t2.Left + t2.Width + 2, t1.Top + t1.Height + 3)

    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        If Command1.Text = "Test Alarm" Then
            Command1.Text = "Stop"
            soundPlay.SoundLocation = Application.StartupPath & "\alarm.wav"
            soundPlay.PlayLooping()
        Else
            Command1.Text = "Test Alarm"
            soundPlay.Stop()
        End If
    End Sub

    Private Sub t1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t1.TextChanged
        '' restricts CTRL+V pasting
        If IsNumeric(t1.Text) = False And t1.Text <> "" Then
            t1.Text = txthourPrev
        Else
            If canChange Then
                Dim ts As TimeSpan
                If TimeSpan.TryParse(t1.Text & ":" & t2.Text & ":00", ts) Then
                    My.Settings.alarmTime = ts
                    My.Settings.Save()
                End If
            End If
        End If
        txthourPrev = t1.Text

    End Sub

    Private Sub t2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles t2.TextChanged
        '' restricts CTRL+V pasting
        If IsNumeric(t2.Text) = False And t2.Text <> "" Then
            t2.Text = txtMinPrev
        Else
            If canChange Then
                Dim ts As TimeSpan
                If TimeSpan.TryParse(t1.Text & ":" & t2.Text & ":00", ts) Then
                    My.Settings.alarmTime = ts
                    My.Settings.Save()
                End If
            End If
        End If

        txtMinPrev = t2.Text

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.alarmOn = CheckBox1.Checked
        My.Settings.Save()
    End Sub
End Class

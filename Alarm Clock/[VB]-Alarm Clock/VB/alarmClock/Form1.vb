Imports System.Drawing.Drawing2D

Public Class Form1

#Region "     form level variables"

    Private minuteHandPic As Bitmap = New Bitmap(Application.StartupPath + "\minute1.bmp")
    Private secondHandPic As Bitmap = New Bitmap(Application.StartupPath + "\second1.bmp")
    Private hourHandPic As Bitmap = New Bitmap(Application.StartupPath + "\hour1.bmp")
    Private centrePic As Bitmap = New Bitmap(Application.StartupPath + "\centre.bmp")

    Private img1 As Bitmap = New Bitmap(310, 330)
    Private img2 As Bitmap
    Private Graph1 As Graphics = Graphics.FromImage(img1)

    Private WithEvents analogTmr As New Timer
    Private WithEvents digitalTmr As New Timer

    Private alarmSounded As Boolean = False

#End Region

#Region "     draw clock"

    Private Sub drawClockFace()

        Graph1.SmoothingMode = SmoothingMode.HighQuality

        Graph1.FillRectangle(New SolidBrush(SystemColors.Control), New Rectangle(0, 0, img1.Width, img1.Height))

        Graph1.DrawEllipse(New Pen(Color.Black, 1), New Rectangle(29, 54, 256, 256))

        For x As Integer = 1 To 60

            Dim angleDegSecond As Integer = x * 6
            'Turn degrees to radians (because of the sin and cos operations)
            Dim angleRadSecond As Single = CSng(Math.PI * angleDegSecond / 180)

            If x Mod 5 = 0 Then
                'Calculate X2 and Y2
                Dim lineX1 As Single = CSng(157 + Math.Sin(angleRadSecond) * 113)
                Dim lineY1 As Single = CSng(182 - Math.Cos(angleRadSecond) * 113)
                Graph1.DrawLine(New Pen(Color.Black, 2), 157, 182, lineX1, lineY1)
            Else
                'Calculate X1 and Y1
                Dim lineX1 As Integer = CInt(155 + Math.Cos(x * 2 * Math.PI / 60 - (0.5 * Math.PI)) * 110)
                Dim lineY1 As Integer = CInt(180 - Math.Sin(x * 2 * Math.PI / 60 - (0.5 * Math.PI)) * 110)
                Graph1.FillEllipse(New SolidBrush(Color.Black), New Rectangle(lineX1, lineY1, 3, 3))
            End If

        Next

        Graph1.FillEllipse(New SolidBrush(SystemColors.Control), New Rectangle(54, 79, 206, 206))

        Dim tLeft As Integer = CInt(Math.Floor(156 - (Graph1.MeasureString("longtime", Me.Font).Width) / 2))
        Graph1.DrawString("longtime", Me.Font, Brushes.Black, tLeft, 240)

        Me.BackgroundImageLayout = ImageLayout.None
        Me.BackgroundImage = img1

    End Sub

    Private Sub drawHands()
        img2 = DirectCast(img1.Clone, Bitmap)
        Dim Graph2 As Graphics = Graphics.FromImage(img2)

        Graph2.SmoothingMode = SmoothingMode.HighQuality

        If My.Settings.alarmOn Then
            '' draw the alarm hand
            Dim redPen1 As New Pen(Color.Red, 1)
            Dim redPen3 As New Pen(Color.Red, 3)
            Dim redPen5 As New Pen(Color.Red, 5)

            Graph2.TranslateTransform(157, 182)
            Graph2.RotateTransform(CSng((My.Settings.alarmTime.Hours * 30) + (My.Settings.alarmTime.Minutes * 0.5)))

            Graph2.DrawLine(redPen5, 0, 0, 0, -90)
            Graph2.DrawLine(redPen3, 0, 0, 0, -93)
            Graph2.DrawLine(redPen1, 0, 0, 0, -95)

            Graph2.ResetTransform()
        End If


        '' draw the minute hand
        Graph2.TranslateTransform(157, 182)

        Graph2.RotateTransform(CSng(-90 + (((Math.Floor(Now.Minute) * 6) + (Now.Second * 0.1)))))

        minuteHandPic.MakeTransparent(Color.White)
        Graph2.DrawImage(minuteHandPic, -1, -1)
        Graph2.ResetTransform()

        '' draw the hour hand
        Graph2.TranslateTransform(157, 182)

        Graph2.RotateTransform(CSng(-90 + (((Math.Floor(Now.Hour) * 30) + (Now.Minute * 0.5)))))

        hourHandPic.MakeTransparent(Color.White)
        Graph2.DrawImage(hourHandPic, -1, -1)
        Graph2.ResetTransform()

        '' draw the second hand
        Graph2.TranslateTransform(157, 182)
        Graph2.RotateTransform(-90 + (Now.Second * 6))

        secondHandPic.MakeTransparent(Color.White)
        Graph2.DrawImage(secondHandPic, -1, -1)
        Graph2.ResetTransform()

        centrePic.MakeTransparent(Color.White)
        Graph2.DrawImage(centrePic, 151, 176)

        Me.BackgroundImage = img2

    End Sub

#End Region

    Private Sub analogTmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles analogTmr.Tick
        drawHands()
        checkAlarm()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If digitalTmr.Enabled Then
            e.Graphics.DrawString(Now.ToString("HH:mm:ss"), New Font("Lucida Console", 36), Brushes.Black, 12, 12 + MenuStrip1.Height)
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        AnalogToolStripMenuItem.PerformClick()
        MenuStrip1.Refresh()
    End Sub

    Private Sub DigitalToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DigitalToolStripMenuItem.Click, AnalogToolStripMenuItem.Click
        Dim items() As ToolStripMenuItem = {AnalogToolStripMenuItem, DigitalToolStripMenuItem}
        items.First(Function(t) t IsNot sender).Checked = False
        Dim selected As ToolStripMenuItem = items.First(Function(t) t Is sender)
        selected.Checked = True

        If selected Is AnalogToolStripMenuItem Then
            drawClockFace()
            drawHands()
            digitalTmr.Enabled = False
            analogTmr.Interval = 1000
            analogTmr.Enabled = True
            Me.SetClientSizeCore(310, 330)
        Else
            analogTmr.Enabled = False
            Me.BackgroundImage = Nothing
            digitalTmr.Interval = 1000
            digitalTmr.Enabled = True
            Me.SetClientSizeCore(279, 78 + MenuStrip1.Height)
        End If

    End Sub

    Private Sub AlarmToolStripMenuItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlarmToolStripMenuItem.DropDownOpened
        If TimeToolStripMenuItem.DropDownItems.Count = 0 Then
            Dim setter As New alarmSetter()
            TimeToolStripMenuItem.DropDownItems.Add(New ToolStripControlHost(setter))
        End If
    End Sub

    Private Sub digitalTmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles digitalTmr.Tick
        Me.Invalidate()
        checkAlarm()
    End Sub

    Private Sub checkAlarm()
        If My.Settings.alarmOn Then
            If Now.TimeOfDay > My.Settings.alarmTime And Now.TimeOfDay < My.Settings.alarmTime.Add(New TimeSpan(0, 0, 1)) Then
                If alarmSounded = False Then
                    alarmSounded = True
                    Dim alarm As New aFrm1
                    alarm.Label1.Text = "It is " & String.Format("{0:00}:{1:00}:{2:00}", My.Settings.alarmTime.Hours, My.Settings.alarmTime.Minutes, My.Settings.alarmTime.Seconds)
                    alarm.ShowDialog()
                End If
            Else
                alarmSounded = False
            End If
        End If
    End Sub

End Class

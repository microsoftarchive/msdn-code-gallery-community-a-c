# Analogue Clock
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic Express 2010
## Topics
- Trigonometry and Graphing
## Updated
- 11/01/2013
## Description

<h1><img id="100559" src="100559-analogue%20clock2.jpg" alt="" width="576" height="423"></h1>
<h1>
<div class="endscriptcode">&nbsp;</div>
Introduction</h1>
<p>This version on an Analog (Analogue) Clock was written in VB Express 2010. It is simply a running clock displaying the time of day.It now includes user selectable Chimes and Alarm.&nbsp;The display is both digital (24 hour format), and analogue. I wrote
 it as an exercise in trigonometry and graphics. It was first presented in the Visual Basic Forum with a lot of incorrect programming techniques. I was fortunate enough to have many critics willing to show me the error of my ways and advise me as to how I could
 correct my mistakes. So, in a lot of ways, the credit for this sample must go to other members of the Visual Basic Forum.</p>
<p><span>Building the Sample</span></p>
<p>There are no<strong> </strong>special requirements in building the sample, simply download the code, or copy the code to a new app and run it.</p>
<p>If you copy the code from here you will need to download the WAV files to include in the Resources folder.</p>
<p>The WAV files can be downloaded from here:&nbsp;<a href="http://sdrv.ms/1aY1QUy">Analogue Clock WAV Files</a>&nbsp;but it would be best to download the sce code from this site.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Analogue Clock&nbsp; is a graphical representation showing the Hour, Minute and Second hands. It also incorporates a Digital clock at the centre of the face.</p>
<p>It is a stand-alone application requiring no input from the user. The clock will start running as soon as the application is run.</p>
<p>The application employs Trigonometric Polar to Cartesian co-ordinates conversion to calculate the X,Y co-ordinates of the end of the hand from the angle of the hands which, of course is dependent on the time.</p>
<p>Both the Hour and &nbsp;minute hand are sweeping hands. The second hands changes with each tick.</p>
<p>The app now has a practical purpose as it now has an alrm function that can be set and turnes on off at the user discretio. The principals involved in presenting moving graphics which are dependent on the current time of the computer clock, although it can
 be kept minimized on the Taskbar and restored when it needs to be shown.</p>
<p>EDIT: I've edited the program since it was first posted. It now includes routines for chiming on the hour and half hour and for setting the alarm. Because of the limitations in playing sounds in VB if the alarm is set either on the hour or half hour the
 chime sound and alarm sound will clash and the chimes usually win. To get the best result from the chimes and alarm it is best to set the alarm say, 1 minute after the hour or half hour.</p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="preview"></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class Form1
    Const Convert As Double = Math.PI / 180
    Const alarmRadius = 190
    Const SecRadius As Double = 185
    Const MinRadius As Double = 180
    Const HrRadius As Double = 155
    Dim AlarmAngle As Double
    Dim SecAngle As Double
    Dim MinAngle As Double
    Dim HrAngle As Double
    Dim AlarmX As Single = 220
    Dim AlarmY As Single = 20
    Dim SecX As Single = 220
    Dim SecY As Single = 20
    Dim MinX As Single = 220
    Dim MinY As Single = 20
    Dim HrX As Single = 220
    Dim HrY As Single = 20
    Dim ChimesCount As Integer
    Dim hrs, min, value As Integer
    Dim TimeString As String
    Dim ChimesFlag As Boolean
    Dim AlarmFlag As Boolean
    Dim WithEvents tmrClock As New Timer
    Dim WithEvents tmrChimes As New Timer
    Dim WithEvents TBAlarm As New TrackBar
    Dim WithEvents btnAlarm As New Button
    Dim WithEvents btnChimes As New Button
    Dim WithEvents lblPanel As New Label
    Dim lblTB As New Label
    Dim pnlExtras As New Panel
    Dim tTip As New ToolTip
    Dim StartPoint(60) As PointF
    Dim EndPoint(60) As PointF
    Dim NumberPoint() As PointF = {New PointF(285, 50), New PointF(350, 115), New PointF(376, 203),
                                   New PointF(350, 290), New PointF(285, 350), New PointF(205, 366),
                                   New PointF(125, 350), New PointF(60, 290), New PointF(38, 203),
                                   New PointF(55, 120), New PointF(112, 59), New PointF(196, 36)}
    'Create the Pens
    Dim RedPen As Pen = New Pen(Color.Red, 6)
    Dim BluePen As Pen = New Pen(Color.Blue, 4)
    Dim OrangePen As Pen = New Pen(Color.DarkOrange, 5)
    Dim BlackPen As Pen = New Pen(Color.Black, 6)
    Dim myPen As New Pen(Color.DarkBlue, 8)
    Dim AlarmPen As New Pen(Color.Red, 4)
    'Create the Fonts
    Dim NumberFont As New Font(&quot;Arial&quot;, 25, FontStyle.Bold)
    Dim ClockFont As New Font(&quot;Arial&quot;, 18, FontStyle.Bold)
    Dim NameFont As New Font(&quot;Brush Script MT&quot;, 25, FontStyle.Italic)
    'Create the Bitmap to draw the clock face
    Dim ClockFace As New Bitmap(445, 445)
    Dim gr As Graphics = Graphics.FromImage(ClockFace)
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Add a ToolTip to the form
        tTip.SetToolTip(Me, &quot;Double Click Clock Face To Close&quot;)
        tTip.Active = True
        BluePen.SetLineCap(LineCap.Round, LineCap.ArrowAnchor, DashCap.Flat)
        OrangePen.SetLineCap(LineCap.Round, LineCap.ArrowAnchor, DashCap.Flat)
        BlackPen.SetLineCap(LineCap.Round, LineCap.ArrowAnchor, DashCap.Flat)
        DoubleBuffered = True
        Me.Size = New Size(570, 470)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.TransparencyKey = SystemColors.Control
        Me.CenterToScreen()
        CreatePanel()
        CalculateIncrements()
        DrawClockFace()
        tmrClock.Interval = 990
        tmrClock.Start()
    End Sub
    Private Sub Form1_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
        Me.Close()
    End Sub
    Sub btnChimesClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChimes.Click
        ChimesFlag = Not ChimesFlag
        If ChimesFlag = True Then
            btnChimes.Text = &quot;Chimes Are On&quot;
        Else
            btnChimes.Text = &quot;Chimes Are Off&quot;
        End If
    End Sub
    Sub btnAlarmClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlarm.Click
        AlarmFlag = Not AlarmFlag
        If AlarmFlag = True Then
            btnAlarm.Text = &quot;Alarm Is On&quot;
        Else
            btnAlarm.Text = &quot;Alarm Is Off&quot;
            My.Computer.Audio.Stop()
        End If
    End Sub
    Private Sub TBAlarm_Scroll(sender As System.Object, e As System.EventArgs) Handles TBAlarm.Scroll
        value = CInt(TBAlarm.Value)
        hrs = CInt(Fix(value / 60))
        min = CInt(TBAlarm.Value - (hrs * 60))
        If hrs = 24 Then hrs = 0
        lblTB.Text = Format(hrs, &quot;00&quot;) &amp; &quot;:&quot; &amp; Format(min, &quot;00&quot;)
        AlarmAngle = (hrs &#43; min / 60) * 30
        AlarmX = CInt(alarmRadius * Math.Cos((90 - AlarmAngle) * Convert)) &#43; 220
        AlarmY = 220 - CInt(alarmRadius * Math.Sin((90 - AlarmAngle) * Convert))
    End Sub
    Sub lblPanelClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPanel.Click
        If pnlExtras.Visible = True Then
            pnlExtras.Hide()
            lblPanel.Location = New Point(424, 210)
            lblPanel.Text = &quot;&gt;&quot;
        Else
            pnlExtras.Show()
            lblPanel.Location = New Point(520, 210)
            lblPanel.Text = &quot;&lt;&quot;
        End If
    End Sub
    Sub CreatePanel() 'with extras for chimes and alarm
        Me.Controls.Add(pnlExtras)
        With pnlExtras
            .Size = New Size(100, 165)
            .Location = New Point(423, 140)
            .BackColor = Color.Coral
            .BorderStyle = BorderStyle.Fixed3D
            .Hide()
        End With
        Me.Controls.Add(lblPanel)
        With lblPanel
            .Size = New Size(20, 20)
            .Location = New Point(424, 210)
            .BackColor = Color.Coral
            .Font = New Font(&quot;Arial&quot;, 14, FontStyle.Bold)
            .Text = &quot;&gt;&quot;
        End With
        tTip.SetToolTip(lblPanel, &quot;Click To Show and Hide&quot;)
        pnlExtras.Controls.Add(btnChimes)
        With btnChimes
            .Size = New Size(60, 40)
            .Location = New Point(20, 10)
            .BackColor = Color.LightBlue
            .Text = &quot;Chimes Are Off&quot;
        End With
        pnlExtras.Controls.Add(btnAlarm)
        With btnAlarm
            .Size = New Size(60, 40)
            .Location = New Point(20, 115)
            .BackColor = Color.LightBlue
            .Text = &quot;Alarm Is Off&quot;
        End With
        pnlExtras.Controls.Add(TBAlarm)
        With TBAlarm
            .Value = 0
            .Maximum = 1439
            .Minimum = 0
            .SmallChange = 1
            .LargeChange = 1
            .Location = New Point(10, 60)
            .Size = New Size(80, 20)
            .BackColor = Color.Beige
        End With
        pnlExtras.Controls.Add(lblTB)
        With lblTB
            .Font = New Font(&quot;Arial&quot;, 14, FontStyle.Bold)
            .Text = &quot;00:00&quot;
            .Size = New Size(65, 20)
            .Location = New Point(18, 80)
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.Fixed3D
            .BringToFront()
        End With
        tmrChimes.Interval = 1200
    End Sub
    Sub DrawClockFace()
        gr.SmoothingMode = SmoothingMode.HighQuality
        'Draw Clock Background
        gr.FillEllipse(Brushes.Beige, 20, 20, 400, 400)
        gr.DrawEllipse(RedPen, 20, 20, 400, 400)
        gr.DrawEllipse(Pens.Red, 120, 120, 200, 200)
        'Draw Increments around cicumferance
        For I As Integer = 1 To 60
            gr.DrawLine(RedPen, StartPoint(I), EndPoint(I))
        Next
        'Draw Numbers
        For I As Integer = 1 To 12
            gr.DrawString(I.ToString, NumberFont, Brushes.Black, NumberPoint(I - 1))
        Next
        'Draw Name
        gr.DrawString(&quot;Ronex&quot;, NameFont, Brushes.Black, 180, 85)
        'Draw Digital Clock Background
        gr.FillRectangle(Brushes.DarkBlue, 170, 260, 100, 30)
        myPen.LineJoin = LineJoin.Round
        gr.DrawRectangle(myPen, 170, 260, 100, 30)
    End Sub
    Sub CalculateIncrements() 'around clock perimeter
        Dim X, Y As Integer
        Dim radius As Integer
        For I As Integer = 1 To 60
            If I Mod 5 = 0 Then
                radius = 182
            Else
                radius = 190
            End If
            'Calculate Start Point
            X = CInt(radius * Math.Cos((90 - I * 6) * Convert)) &#43; 220
            Y = 220 - CInt(radius * Math.Sin((90 - I * 6) * Convert))
            StartPoint(I) = New PointF(X, Y)
            'Calculate End Point
            X = CInt(200 * Math.Cos((90 - I * 6) * Convert)) &#43; 220
            Y = 220 - CInt(200 * Math.Sin((90 - I * 6) * Convert))
            EndPoint(I) = New PointF(X, Y)
        Next
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'Draw Clock Background
        e.Graphics.DrawImage(ClockFace, Point.Empty)
        'Draw Digital Time
        e.Graphics.DrawString(TimeString, ClockFont, Brushes.White, 170, 260)
        'Draw Hands
        e.Graphics.DrawLine(AlarmPen, 220, 220, AlarmX, AlarmY)
        e.Graphics.DrawLine(BlackPen, 220, 220, HrX, HrY)
        e.Graphics.FillEllipse(Brushes.Black, 210, 210, 20, 20)
        e.Graphics.DrawLine(OrangePen, 220, 220, MinX, MinY)
        e.Graphics.FillEllipse(Brushes.DarkOrange, 212, 212, 16, 16)
        e.Graphics.DrawLine(BluePen, 220, 220, SecX, SecY)
        e.Graphics.FillEllipse(Brushes.Blue, 215, 215, 10, 10)
    End Sub
    Private Sub tmrClock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrClock.Tick
        TimeString = Now.ToString(&quot;HH:mm:ss&quot;)
        'Set The Angle of the Second, Minute and Hour hand according to the time
        SecAngle = (Now.Second * 6)
        MinAngle = (Now.Minute &#43; Now.Second / 60) * 6
        HrAngle = (Now.Hour &#43; Now.Minute / 60) * 30
        'Get the X,Y co-ordinates of the end point of each hand
        SecX = CInt(SecRadius * Math.Cos((90 - SecAngle) * Convert)) &#43; 220
        SecY = 220 - CInt(SecRadius * Math.Sin((90 - SecAngle) * Convert))
        MinX = CInt(MinRadius * Math.Cos((90 - MinAngle) * Convert)) &#43; 220
        MinY = 220 - CInt(MinRadius * Math.Sin((90 - MinAngle) * Convert))
        HrX = CInt(HrRadius * Math.Cos((90 - HrAngle) * Convert)) &#43; 220
        HrY = 220 - CInt(HrRadius * Math.Sin((90 - HrAngle) * Convert))
        Refresh()
        'Play chimes if selected
        If ChimesFlag = True Then
            If Now.Minute = 0 And Now.Second = 0 Then
                ChimesCount = Now.Hour
                If ChimesCount &gt; 12 Then ChimesCount -= 12
                If ChimesCount = 0 Then ChimesCount = 12
                tmrChimes.Start()
                My.Computer.Audio.Play(My.Resources.Chime, AudioPlayMode.Background)
            ElseIf Now.Minute = 30 And Now.Second = 0 Then
                My.Computer.Audio.Play(My.Resources.Chime, AudioPlayMode.Background)
            End If
        End If
        'Set off Alarm if selected
        If AlarmFlag = True Then
            If Now.Hour = hrs And Now.Minute = min And Now.Second = 0 Then
                My.Computer.Audio.Play(My.Resources.Alarm, AudioPlayMode.BackgroundLoop)
            End If
        End If
    End Sub
    Private Sub tmrChimes_Tick(sender As System.Object, e As System.EventArgs) Handles tmrChimes.Tick
        Static count As Integer = 0
        count &#43;= 1
        If count &lt; ChimesCount Then
            My.Computer.Audio.Play(My.Resources.Chime, AudioPlayMode.Background)
        Else
            count = 0
            tmrChimes.Stop()
        End If
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;Convert&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;Math.PI&nbsp;/&nbsp;<span class="visualBasic__number">180</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;alarmRadius&nbsp;=&nbsp;<span class="visualBasic__number">190</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;SecRadius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__number">185</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;MinRadius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__number">180</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;HrRadius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__number">155</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AlarmAngle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SecAngle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;MinAngle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;HrAngle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AlarmX&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AlarmY&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SecX&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;SecY&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;MinX&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;MinY&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;HrX&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;HrY&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ChimesCount&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hrs,&nbsp;min,&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;TimeString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ChimesFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AlarmFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;tmrClock&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Timer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;tmrChimes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Timer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;TBAlarm&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TrackBar&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;btnAlarm&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Button&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;btnChimes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Button&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;lblPanel&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Label&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;lblTB&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Label&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;pnlExtras&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Panel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tTip&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ToolTip&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;StartPoint(<span class="visualBasic__number">60</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PointF&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;EndPoint(<span class="visualBasic__number">60</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PointF&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;NumberPoint()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PointF&nbsp;=&nbsp;{<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">285</span>,&nbsp;<span class="visualBasic__number">50</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">350</span>,&nbsp;<span class="visualBasic__number">115</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">376</span>,&nbsp;<span class="visualBasic__number">203</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">350</span>,&nbsp;<span class="visualBasic__number">290</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">285</span>,&nbsp;<span class="visualBasic__number">350</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">205</span>,&nbsp;<span class="visualBasic__number">366</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">125</span>,&nbsp;<span class="visualBasic__number">350</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">60</span>,&nbsp;<span class="visualBasic__number">290</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">38</span>,&nbsp;<span class="visualBasic__number">203</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">55</span>,&nbsp;<span class="visualBasic__number">120</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">112</span>,&nbsp;<span class="visualBasic__number">59</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(<span class="visualBasic__number">196</span>,&nbsp;<span class="visualBasic__number">36</span>)}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;Pens</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;RedPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Red,&nbsp;<span class="visualBasic__number">6</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;BluePen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Blue,&nbsp;<span class="visualBasic__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;OrangePen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.DarkOrange,&nbsp;<span class="visualBasic__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;BlackPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black,&nbsp;<span class="visualBasic__number">6</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.DarkBlue,&nbsp;<span class="visualBasic__number">8</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AlarmPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Red,&nbsp;<span class="visualBasic__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;Fonts</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;NumberFont&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Arial&quot;</span>,&nbsp;<span class="visualBasic__number">25</span>,&nbsp;FontStyle.Bold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ClockFont&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Arial&quot;</span>,&nbsp;<span class="visualBasic__number">18</span>,&nbsp;FontStyle.Bold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;NameFont&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Brush&nbsp;Script&nbsp;MT&quot;</span>,&nbsp;<span class="visualBasic__number">25</span>,&nbsp;FontStyle.Italic)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;Bitmap&nbsp;to&nbsp;draw&nbsp;the&nbsp;clock&nbsp;face</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ClockFace&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(<span class="visualBasic__number">445</span>,&nbsp;<span class="visualBasic__number">445</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;gr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics&nbsp;=&nbsp;Graphics.FromImage(ClockFace)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Add&nbsp;a&nbsp;ToolTip&nbsp;to&nbsp;the&nbsp;form</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tTip.SetToolTip(<span class="visualBasic__keyword">Me</span>,&nbsp;<span class="visualBasic__string">&quot;Double&nbsp;Click&nbsp;Clock&nbsp;Face&nbsp;To&nbsp;Close&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tTip.Active&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BluePen.SetLineCap(LineCap.Round,&nbsp;LineCap.ArrowAnchor,&nbsp;DashCap.Flat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrangePen.SetLineCap(LineCap.Round,&nbsp;LineCap.ArrowAnchor,&nbsp;DashCap.Flat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BlackPen.SetLineCap(LineCap.Round,&nbsp;LineCap.ArrowAnchor,&nbsp;DashCap.Flat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleBuffered&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">570</span>,&nbsp;<span class="visualBasic__number">470</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.FormBorderStyle&nbsp;=&nbsp;Windows.Forms.FormBorderStyle.None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TransparencyKey&nbsp;=&nbsp;SystemColors.Control&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CenterToScreen()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreatePanel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CalculateIncrements()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawClockFace()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tmrClock.Interval&nbsp;=&nbsp;<span class="visualBasic__number">990</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tmrClock.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_DoubleClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.DoubleClick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnChimesClick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnChimes.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ChimesFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;ChimesFlag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ChimesFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnChimes.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Chimes&nbsp;Are&nbsp;On&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnChimes.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Chimes&nbsp;Are&nbsp;Off&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnAlarmClick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAlarm.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlarmFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;AlarmFlag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;AlarmFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnAlarm.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Alarm&nbsp;Is&nbsp;On&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnAlarm.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Alarm&nbsp;Is&nbsp;Off&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.Audio.<span class="visualBasic__keyword">Stop</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;TBAlarm_Scroll(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;TBAlarm.Scroll&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(TBAlarm.Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hrs&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Fix(value&nbsp;/&nbsp;<span class="visualBasic__number">60</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;min&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(TBAlarm.Value&nbsp;-&nbsp;(hrs&nbsp;*&nbsp;<span class="visualBasic__number">60</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;hrs&nbsp;=&nbsp;<span class="visualBasic__number">24</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;hrs&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblTB.Text&nbsp;=&nbsp;Format(hrs,&nbsp;<span class="visualBasic__string">&quot;00&quot;</span>)&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>&nbsp;&amp;&nbsp;Format(min,&nbsp;<span class="visualBasic__string">&quot;00&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlarmAngle&nbsp;=&nbsp;(hrs&nbsp;&#43;&nbsp;min&nbsp;/&nbsp;<span class="visualBasic__number">60</span>)&nbsp;*&nbsp;<span class="visualBasic__number">30</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlarmX&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(alarmRadius&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;AlarmAngle)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlarmY&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(alarmRadius&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;AlarmAngle)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;lblPanelClick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;lblPanel.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;pnlExtras.Visible&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Hide()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblPanel.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">424</span>,&nbsp;<span class="visualBasic__number">210</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblPanel.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Show()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblPanel.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">520</span>,&nbsp;<span class="visualBasic__number">210</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblPanel.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&lt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CreatePanel()&nbsp;<span class="visualBasic__com">'with&nbsp;extras&nbsp;for&nbsp;chimes&nbsp;and&nbsp;alarm</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Controls.Add(pnlExtras)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;pnlExtras&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">165</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">423</span>,&nbsp;<span class="visualBasic__number">140</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.Coral&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BorderStyle&nbsp;=&nbsp;BorderStyle.Fixed3D&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Hide()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Controls.Add(lblPanel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;lblPanel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">20</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">424</span>,&nbsp;<span class="visualBasic__number">210</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.Coral&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Font&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Arial&quot;</span>,&nbsp;<span class="visualBasic__number">14</span>,&nbsp;FontStyle.Bold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tTip.SetToolTip(lblPanel,&nbsp;<span class="visualBasic__string">&quot;Click&nbsp;To&nbsp;Show&nbsp;and&nbsp;Hide&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Controls.Add(btnChimes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;btnChimes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">60</span>,&nbsp;<span class="visualBasic__number">40</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.LightBlue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Chimes&nbsp;Are&nbsp;Off&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Controls.Add(btnAlarm)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;btnAlarm&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">60</span>,&nbsp;<span class="visualBasic__number">40</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">115</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.LightBlue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Alarm&nbsp;Is&nbsp;Off&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Controls.Add(TBAlarm)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;TBAlarm&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Value&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Maximum&nbsp;=&nbsp;<span class="visualBasic__number">1439</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Minimum&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SmallChange&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.LargeChange&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">10</span>,&nbsp;<span class="visualBasic__number">60</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">80</span>,&nbsp;<span class="visualBasic__number">20</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.Beige&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlExtras.Controls.Add(lblTB)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;lblTB&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Font&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Arial&quot;</span>,&nbsp;<span class="visualBasic__number">14</span>,&nbsp;FontStyle.Bold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;00:00&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">65</span>,&nbsp;<span class="visualBasic__number">20</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(<span class="visualBasic__number">18</span>,&nbsp;<span class="visualBasic__number">80</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;Color.Beige&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BorderStyle&nbsp;=&nbsp;BorderStyle.Fixed3D&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BringToFront()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tmrChimes.Interval&nbsp;=&nbsp;<span class="visualBasic__number">1200</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DrawClockFace()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.SmoothingMode&nbsp;=&nbsp;SmoothingMode.HighQuality&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Clock&nbsp;Background</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.FillEllipse(Brushes.Beige,&nbsp;<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">400</span>,&nbsp;<span class="visualBasic__number">400</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawEllipse(RedPen,&nbsp;<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">400</span>,&nbsp;<span class="visualBasic__number">400</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawEllipse(Pens.Red,&nbsp;<span class="visualBasic__number">120</span>,&nbsp;<span class="visualBasic__number">120</span>,&nbsp;<span class="visualBasic__number">200</span>,&nbsp;<span class="visualBasic__number">200</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Increments&nbsp;around&nbsp;cicumferance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;I&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">60</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawLine(RedPen,&nbsp;StartPoint(I),&nbsp;EndPoint(I))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Numbers</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;I&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">12</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawString(I.ToString,&nbsp;NumberFont,&nbsp;Brushes.Black,&nbsp;NumberPoint(I&nbsp;-&nbsp;<span class="visualBasic__number">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawString(<span class="visualBasic__string">&quot;Ronex&quot;</span>,&nbsp;NameFont,&nbsp;Brushes.Black,&nbsp;<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">85</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Digital&nbsp;Clock&nbsp;Background</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.FillRectangle(Brushes.DarkBlue,&nbsp;<span class="visualBasic__number">170</span>,&nbsp;<span class="visualBasic__number">260</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">30</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myPen.LineJoin&nbsp;=&nbsp;LineJoin.Round&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.DrawRectangle(myPen,&nbsp;<span class="visualBasic__number">170</span>,&nbsp;<span class="visualBasic__number">260</span>,&nbsp;<span class="visualBasic__number">100</span>,&nbsp;<span class="visualBasic__number">30</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CalculateIncrements()&nbsp;<span class="visualBasic__com">'around&nbsp;clock&nbsp;perimeter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;X,&nbsp;Y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;radius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;I&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">60</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;I&nbsp;<span class="visualBasic__keyword">Mod</span>&nbsp;<span class="visualBasic__number">5</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;radius&nbsp;=&nbsp;<span class="visualBasic__number">182</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;radius&nbsp;=&nbsp;<span class="visualBasic__number">190</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Calculate&nbsp;Start&nbsp;Point</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(radius&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;I&nbsp;*&nbsp;<span class="visualBasic__number">6</span>)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Y&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(radius&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;I&nbsp;*&nbsp;<span class="visualBasic__number">6</span>)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StartPoint(I)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(X,&nbsp;Y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Calculate&nbsp;End&nbsp;Point</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__number">200</span>&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;I&nbsp;*&nbsp;<span class="visualBasic__number">6</span>)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Y&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__number">200</span>&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;I&nbsp;*&nbsp;<span class="visualBasic__number">6</span>)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPoint(I)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(X,&nbsp;Y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Forms.PaintEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.SmoothingMode&nbsp;=&nbsp;SmoothingMode.HighQuality&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Clock&nbsp;Background</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(ClockFace,&nbsp;Point.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Digital&nbsp;Time</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(TimeString,&nbsp;ClockFont,&nbsp;Brushes.White,&nbsp;<span class="visualBasic__number">170</span>,&nbsp;<span class="visualBasic__number">260</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;Hands</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(AlarmPen,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;AlarmX,&nbsp;AlarmY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(BlackPen,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;HrX,&nbsp;HrY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillEllipse(Brushes.Black,&nbsp;<span class="visualBasic__number">210</span>,&nbsp;<span class="visualBasic__number">210</span>,&nbsp;<span class="visualBasic__number">20</span>,&nbsp;<span class="visualBasic__number">20</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(OrangePen,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;MinX,&nbsp;MinY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillEllipse(Brushes.DarkOrange,&nbsp;<span class="visualBasic__number">212</span>,&nbsp;<span class="visualBasic__number">212</span>,&nbsp;<span class="visualBasic__number">16</span>,&nbsp;<span class="visualBasic__number">16</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(BluePen,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;<span class="visualBasic__number">220</span>,&nbsp;SecX,&nbsp;SecY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillEllipse(Brushes.Blue,&nbsp;<span class="visualBasic__number">215</span>,&nbsp;<span class="visualBasic__number">215</span>,&nbsp;<span class="visualBasic__number">10</span>,&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;tmrClock_Tick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;tmrClock.Tick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TimeString&nbsp;=&nbsp;Now.ToString(<span class="visualBasic__string">&quot;HH:mm:ss&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Set&nbsp;The&nbsp;Angle&nbsp;of&nbsp;the&nbsp;Second,&nbsp;Minute&nbsp;and&nbsp;Hour&nbsp;hand&nbsp;according&nbsp;to&nbsp;the&nbsp;time</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecAngle&nbsp;=&nbsp;(Now.Second&nbsp;*&nbsp;<span class="visualBasic__number">6</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinAngle&nbsp;=&nbsp;(Now.Minute&nbsp;&#43;&nbsp;Now.Second&nbsp;/&nbsp;<span class="visualBasic__number">60</span>)&nbsp;*&nbsp;<span class="visualBasic__number">6</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HrAngle&nbsp;=&nbsp;(Now.Hour&nbsp;&#43;&nbsp;Now.Minute&nbsp;/&nbsp;<span class="visualBasic__number">60</span>)&nbsp;*&nbsp;<span class="visualBasic__number">30</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Get&nbsp;the&nbsp;X,Y&nbsp;co-ordinates&nbsp;of&nbsp;the&nbsp;end&nbsp;point&nbsp;of&nbsp;each&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecX&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(SecRadius&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;SecAngle)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecY&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(SecRadius&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;SecAngle)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinX&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(MinRadius&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;MinAngle)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinY&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(MinRadius&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;MinAngle)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HrX&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(HrRadius&nbsp;*&nbsp;Math.Cos((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;HrAngle)&nbsp;*&nbsp;Convert))&nbsp;&#43;&nbsp;<span class="visualBasic__number">220</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HrY&nbsp;=&nbsp;<span class="visualBasic__number">220</span>&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(HrRadius&nbsp;*&nbsp;Math.Sin((<span class="visualBasic__number">90</span>&nbsp;-&nbsp;HrAngle)&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Play&nbsp;chimes&nbsp;if&nbsp;selected</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ChimesFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Now.Minute&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Now.Second&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ChimesCount&nbsp;=&nbsp;Now.Hour&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ChimesCount&nbsp;&gt;&nbsp;<span class="visualBasic__number">12</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;ChimesCount&nbsp;-=&nbsp;<span class="visualBasic__number">12</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ChimesCount&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;ChimesCount&nbsp;=&nbsp;<span class="visualBasic__number">12</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tmrChimes.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.Audio.Play(My.Resources.Chime,&nbsp;AudioPlayMode.Background)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;Now.Minute&nbsp;=&nbsp;<span class="visualBasic__number">30</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Now.Second&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.Audio.Play(My.Resources.Chime,&nbsp;AudioPlayMode.Background)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Set&nbsp;off&nbsp;Alarm&nbsp;if&nbsp;selected</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;AlarmFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Now.Hour&nbsp;=&nbsp;hrs&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Now.Minute&nbsp;=&nbsp;min&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Now.Second&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.Audio.Play(My.Resources.Alarm,&nbsp;AudioPlayMode.BackgroundLoop)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;tmrChimes_Tick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;tmrChimes.Tick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Static</span>&nbsp;count&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;count&nbsp;&lt;&nbsp;ChimesCount&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.Audio.Play(My.Resources.Chime,&nbsp;AudioPlayMode.Background)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tmrChimes.<span class="visualBasic__keyword">Stop</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>sour
<div class="endscriptcode">&nbsp;</div>
ce code file name #2 - summary for this source code file.</em></em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>

Imports System.Drawing 
Imports System.Windows.Forms 
 
Namespace ClockControl 
    Public Partial Class ClockControl 
        Inherits Control 
        #Region "Construct the clock" 
 
        Public Sub New() 
            InitializeComponent() 
 
            'Set the double buffered to true to reduce flickering of the graphics 
            DoubleBuffered = True 
 
            'Create the timer and start it 
            AddHandler ClockTimer.Tick, AddressOf ClockTimer_Tick 
            ClockTimer.Enabled = True 
            ClockTimer.Interval = 1 
            ClockTimer.Start() 
        End Sub 
 
        #End Region 
 
        #Region "Update the clock" 
 
        ''' <summary> 
        ''' The tick event for the timer 
        ''' </summary> 
        ''' <param name="sender">The object that sends the trigger</param> 
        ''' <param name="e">The event arguments for the event</param> 
        Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) 
            Refresh() 
        End Sub 
 
        ''' <summary> 
        ''' The timer to update the hands 
        ''' </summary> 
        Private ClockTimer As New Timer() 
 
        #End Region 
 
        #Region "On paint" 
 
        ''' <summary> 
        ''' Called when the control needs to draw itself 
        ''' </summary> 
        ''' <param name="pe">The paint event arguments for the control</param> 
        Protected Overrides Sub OnPaint(pe As PaintEventArgs) 
            MyBase.OnPaint(pe) 
 
            'Clear the graphics to the back color of the control 
            pe.Graphics.Clear(BackColor) 
 
            'Draw the border of the clock 
            pe.Graphics.DrawEllipse(Pens.Black, 0, 0, Size.Width - 1, Size.Height - 1) 
 
            'Find the radius of the control by dividing the width by 2 
            Dim radius As Single = (Size.Width \ 2) 
 
            'Find the origin of the circle by dividing the width and height of the control 
            Dim origin As New PointF(Size.Width \ 2, Size.Height \ 2) 
 
            'Draw only if ShowMajorSegments is true; 
            If ShowMajorSegments Then 
                'Draw the Major segments for the clock 
                Dim i As Single = 0F 
                While i <> 390F 
                    pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius - 1, i, origin), PointOnCircle(radius - 21, i, origin)) 
                    i += 30F 
                End While 
            End If 
 
            'Draw only if ShowMinorSegments is true 
            If ShowMinorSegments Then 
                'Draw the minor segments for the control 
                Dim i As Single = 0F 
                While i <> 366F 
                    pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius, i, origin), PointOnCircle(radius - 10, i, origin)) 
                    i += 6F 
                End While 
            End If 
 
            'Draw only if ShowSecondHand is true 
            If ShowSecondhand Then 
                'Draw the second hand 
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius, DateTime.Now.Second * 6F, origin)) 
            End If 
 
            'Draw only if ShowMinuteHand is true 
            If ShowMinuteHand Then 
                'Draw the minute hand 
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius * 0.75F, DateTime.Now.Minute * 6F, origin)) 
            End If 
 
            'Draw only if ShowHourHand is true 
            If ShowHourHand Then 
                'Draw the hour hand 
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius * 0.5F, DateTime.Now.Hour * 30F, origin)) 
            End If 
 
        End Sub 
 
        #End Region 
 
        #Region "On size changed" 
 
        ''' <summary> 
        ''' Triggered when the size of the control changes 
        ''' </summary> 
        ''' <param name="e">The event arguments for the event</param> 
        Protected Overrides Sub OnSizeChanged(e As EventArgs) 
            MyBase.OnSizeChanged(e) 
 
            'Make sure the control is square 
            If Size.Height <> Size.Width Then 
                Size = New Size(Size.Width, Size.Width) 
            End If 
 
            'Redraw the control 
            Refresh() 
        End Sub 
 
        #End Region 
 
        #Region "Point on circle" 
 
        ''' <summary> 
        ''' Find the point on the circumference of a circle 
        ''' </summary> 
        ''' <param name="radius">The radius of the circle</param> 
        ''' <param name="angleInDegrees">The angle of the point to origin</param> 
        ''' <param name="origin">The origin of the circle</param> 
        ''' <returns>Return the point</returns> 
        Private Function PointOnCircle(radius As Single, angleInDegrees As Single, origin As PointF) As PointF 
            'Find the x and y using the parametric equation for a circle 
            Dim x As Single = CSng(radius * Math.Cos((angleInDegrees - 90F) * Math.PI / 180F)) + origin.X 
            Dim y As Single = CSng(radius * Math.Sin((angleInDegrees - 90F) * Math.PI / 180F)) + origin.Y 
 
            'Note : The "- 90f" is only for the proper rotation of the clock. 
'             * It is not part of the parament equation for a circle 
 
 
            'Return the point 
            Return New PointF(x, y) 
        End Function 
 
        #End Region 
 
        #Region "Show Minor Segments" 
 
        ''' <summary> 
        ''' Indicates if the minor segements are shown 
        ''' </summary> 
        Private m_showMinorSegments As Boolean = True 
 
        ''' <summary> 
        ''' Indicates if the minor segements are shown 
        ''' </summary> 
        Public Property ShowMinorSegments() As Boolean 
            Get 
                Return m_showMinorSegments 
            End Get 
            Set 
                m_showMinorSegments = value 
                Refresh() 
            End Set 
        End Property 
 
        #End Region 
 
        #Region "Show Major Segments" 
 
        ''' <summary> 
        ''' Indicates if the major segements are shown 
        ''' </summary> 
        Private m_showMajorSegments As Boolean = True 
 
        ''' <summary> 
        ''' Indicates if the major segements are shown 
        ''' </summary> 
        Public Property ShowMajorSegments() As Boolean 
            Get 
                Return m_showMajorSegments 
            End Get 
            Set 
                m_showMajorSegments = value 
                Refresh() 
            End Set 
        End Property 
 
        #End Region 
 
        #Region "Show Second Hand" 
 
        ''' <summary> 
        ''' Indicates if the second hand is shown 
        ''' </summary> 
        Private m_showSecondHand As Boolean = True 
 
        ''' <summary> 
        ''' Indicates if the second hand is shown 
        ''' </summary> 
        Public Property ShowSecondhand() As Boolean 
            Get 
                Return m_showSecondHand 
            End Get 
            Set 
                m_showSecondHand = value 
                Refresh() 
            End Set 
        End Property 
 
        #End Region 
 
        #Region "Show Minute Hand" 
 
        ''' <summary> 
        ''' Indicates if the minute hand is shown 
        ''' </summary> 
        Private m_showMinuteHand As Boolean = True 
 
        ''' <summary> 
        ''' Indicates if the minute hand is shown 
        ''' </summary> 
        Public Property ShowMinuteHand() As Boolean 
            Get 
                Return m_showMinuteHand 
            End Get 
            Set 
                m_showMinuteHand = value 
                Refresh() 
            End Set 
        End Property 
 
        #End Region 
 
        #Region "Show Hour Hand" 
 
        ''' <summary> 
        ''' Indicates if the hour hand is shown 
        ''' </summary> 
        Private m_showHourHand As Boolean = True 
 
        ''' <summary> 
        ''' Indicates if the hour hand is shown 
        ''' </summary> 
        Public Property ShowHourHand() As Boolean 
            Get 
                Return m_showHourHand 
            End Get 
            Set 
                m_showHourHand = value 
                Refresh() 
            End Set 
        End Property 
 
        #End Region 
 
    End Class 
End Namespace 

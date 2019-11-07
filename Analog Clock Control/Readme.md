# Analog Clock Control
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Class Library
- VB.Net
- C# Language
- VB.NET Language Features
- Graphics Functions
- Windows Desktop App Development
## Topics
- Graphics
- C#
- Windows Forms
- 2d graphics
- VB.Net
- Generic C# resuable code
- C# Language Features
- Graphics Functions
## Updated
- 08/02/2016
## Description

<h1>Introduction</h1>
<p><em>What problem does the sample solve?</em></p>
<p><em>The sample solves the need for an analog clock control</em>&nbsp;.</p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>No there aren't any special requirements except the latest .net framework.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This code helps you to create an analog clock control for windows forms. Keep in mind this is just the starting, the graphics quality is low and can be extended further for better quality. The analog clock control draws the second, minute, and hour hands.
 The analog clock control also draws the major and minor segments for the clock. The major and minor segments can be hidden using properties &quot;ShowMajorSegments&quot; and &quot;ShowMinorSegments&quot;. Also, the second, minute, and hour hand can be hidden from the user as
 well.</p>
<p>This is how the control looks.</p>
<p><img id="92393" src="92393-capture.png" alt="" width="239" height="225"></p>
<p>1. Create a new solution called ClockControl.</p>
<p>2. Add a custom control class named ClockControl.</p>
<p>2. Delete everything in ClockControl and add the following code in ClockControl.</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
vbcsharp<span class="hidden">&nbsp;</span>
<pre class="hidden">Imports System.Drawing
Imports System.Windows.Forms

Namespace ClockControl
	Public Partial Class ClockControl
		Inherits Control
		#Region &quot;Construct the clock&quot;

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

		#Region &quot;Update the clock&quot;

		''' &lt;summary&gt;
		''' The tick event for the timer
		''' &lt;/summary&gt;
		''' &lt;param name=&quot;sender&quot;&gt;The object that sends the trigger&lt;/param&gt;
		''' &lt;param name=&quot;e&quot;&gt;The event arguments for the event&lt;/param&gt;
		Private Sub ClockTimer_Tick(sender As Object, e As EventArgs)
			Refresh()
		End Sub

		''' &lt;summary&gt;
		''' The timer to update the hands
		''' &lt;/summary&gt;
		Private ClockTimer As New Timer()

		#End Region

		#Region &quot;On paint&quot;

		''' &lt;summary&gt;
		''' Called when the control needs to draw itself
		''' &lt;/summary&gt;
		''' &lt;param name=&quot;pe&quot;&gt;The paint event arguments for the control&lt;/param&gt;
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
				While i &lt;&gt; 390F
					pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius - 1, i, origin), PointOnCircle(radius - 21, i, origin))
					i &#43;= 30F
				End While
			End If

			'Draw only if ShowMinorSegments is true
			If ShowMinorSegments Then
				'Draw the minor segments for the control
				Dim i As Single = 0F
				While i &lt;&gt; 366F
					pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius, i, origin), PointOnCircle(radius - 10, i, origin))
					i &#43;= 6F
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

		#Region &quot;On size changed&quot;

		''' &lt;summary&gt;
		''' Triggered when the size of the control changes
		''' &lt;/summary&gt;
		''' &lt;param name=&quot;e&quot;&gt;The event arguments for the event&lt;/param&gt;
		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			MyBase.OnSizeChanged(e)

			'Make sure the control is square
			If Size.Height &lt;&gt; Size.Width Then
				Size = New Size(Size.Width, Size.Width)
			End If

			'Redraw the control
			Refresh()
		End Sub

		#End Region

		#Region &quot;Point on circle&quot;

		''' &lt;summary&gt;
		''' Find the point on the circumference of a circle
		''' &lt;/summary&gt;
		''' &lt;param name=&quot;radius&quot;&gt;The radius of the circle&lt;/param&gt;
		''' &lt;param name=&quot;angleInDegrees&quot;&gt;The angle of the point to origin&lt;/param&gt;
		''' &lt;param name=&quot;origin&quot;&gt;The origin of the circle&lt;/param&gt;
		''' &lt;returns&gt;Return the point&lt;/returns&gt;
		Private Function PointOnCircle(radius As Single, angleInDegrees As Single, origin As PointF) As PointF
			'Find the x and y using the parametric equation for a circle
			Dim x As Single = CSng(radius * Math.Cos((angleInDegrees - 90F) * Math.PI / 180F)) &#43; origin.X
			Dim y As Single = CSng(radius * Math.Sin((angleInDegrees - 90F) * Math.PI / 180F)) &#43; origin.Y

			'Note : The &quot;- 90f&quot; is only for the proper rotation of the clock.
'             * It is not part of the parament equation for a circle


			'Return the point
			Return New PointF(x, y)
		End Function

		#End Region

		#Region &quot;Show Minor Segments&quot;

		''' &lt;summary&gt;
		''' Indicates if the minor segements are shown
		''' &lt;/summary&gt;
		Private m_showMinorSegments As Boolean = True

		''' &lt;summary&gt;
		''' Indicates if the minor segements are shown
		''' &lt;/summary&gt;
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

		#Region &quot;Show Major Segments&quot;

		''' &lt;summary&gt;
		''' Indicates if the major segements are shown
		''' &lt;/summary&gt;
		Private m_showMajorSegments As Boolean = True

		''' &lt;summary&gt;
		''' Indicates if the major segements are shown
		''' &lt;/summary&gt;
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

		#Region &quot;Show Second Hand&quot;

		''' &lt;summary&gt;
		''' Indicates if the second hand is shown
		''' &lt;/summary&gt;
		Private m_showSecondHand As Boolean = True

		''' &lt;summary&gt;
		''' Indicates if the second hand is shown
		''' &lt;/summary&gt;
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

		#Region &quot;Show Minute Hand&quot;

		''' &lt;summary&gt;
		''' Indicates if the minute hand is shown
		''' &lt;/summary&gt;
		Private m_showMinuteHand As Boolean = True

		''' &lt;summary&gt;
		''' Indicates if the minute hand is shown
		''' &lt;/summary&gt;
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

		#Region &quot;Show Hour Hand&quot;

		''' &lt;summary&gt;
		''' Indicates if the hour hand is shown
		''' &lt;/summary&gt;
		Private m_showHourHand As Boolean = True

		''' &lt;summary&gt;
		''' Indicates if the hour hand is shown
		''' &lt;/summary&gt;
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
</pre>
<pre class="hidden">using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClockControl
{
    public partial class ClockControl : Control
    {
        #region Construct the clock

        public ClockControl()
        {
            InitializeComponent();

            //Set the double buffered to true to reduce flickering of the graphics
            DoubleBuffered = true;

            //Create the timer and start it
            ClockTimer.Tick &#43;= ClockTimer_Tick;
            ClockTimer.Enabled = true;
            ClockTimer.Interval = 1;
            ClockTimer.Start();
        }

        #endregion

        #region Update the clock

        /// &lt;summary&gt;
        /// The tick event for the timer
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;The object that sends the trigger&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;The event arguments for the event&lt;/param&gt;
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        /// &lt;summary&gt;
        /// The timer to update the hands
        /// &lt;/summary&gt;
        private Timer ClockTimer = new Timer();

        #endregion

        #region On paint

        /// &lt;summary&gt;
        /// Called when the control needs to draw itself
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;pe&quot;&gt;The paint event arguments for the control&lt;/param&gt;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //Clear the graphics to the back color of the control
            pe.Graphics.Clear(BackColor);

            //Draw the border of the clock
            pe.Graphics.DrawEllipse(Pens.Black, 0, 0, Size.Width - 1, Size.Height - 1);

            //Find the radius of the control by dividing the width by 2
            float radius = (Size.Width / 2);

            //Find the origin of the circle by dividing the width and height of the control
            PointF origin = new PointF(Size.Width / 2, Size.Height / 2);

            //Draw only if ShowMajorSegments is true;
            if (ShowMajorSegments)
            {
                //Draw the Major segments for the clock
                for (float i = 0f; i != 390f; i &#43;= 30f)
                {
                    pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius - 1, i, origin), PointOnCircle(radius - 21, i, origin));
                }
            }

            //Draw only if ShowMinorSegments is true
            if (ShowMinorSegments)
            {
                //Draw the minor segments for the control
                for (float i = 0f; i != 366f; i &#43;= 6f)
                {
                    pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius, i, origin), PointOnCircle(radius - 10, i, origin));
                }
            }

            //Draw only if ShowSecondHand is true
            if (ShowSecondhand)
            //Draw the second hand
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius, DateTime.Now.Second * 6f, origin));

            //Draw only if ShowMinuteHand is true
            if (ShowMinuteHand)
            //Draw the minute hand
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius * 0.75f, DateTime.Now.Minute * 6f, origin));

            //Draw only if ShowHourHand is true
            if (ShowHourHand)
            //Draw the hour hand
                pe.Graphics.DrawLine(Pens.Black, origin, PointOnCircle(radius * 0.50f, DateTime.Now.Hour * 30f, origin));

        }

        #endregion

        #region On size changed

        /// &lt;summary&gt;
        /// Triggered when the size of the control changes
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;e&quot;&gt;The event arguments for the event&lt;/param&gt;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //Make sure the control is square
            if (Size.Height != Size.Width)
                Size = new Size(Size.Width, Size.Width);

            //Redraw the control
            Refresh();
        }

        #endregion

        #region Point on circle

        /// &lt;summary&gt;
        /// Find the point on the circumference of a circle
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;radius&quot;&gt;The radius of the circle&lt;/param&gt;
        /// &lt;param name=&quot;angleInDegrees&quot;&gt;The angle of the point to origin&lt;/param&gt;
        /// &lt;param name=&quot;origin&quot;&gt;The origin of the circle&lt;/param&gt;
        /// &lt;returns&gt;Return the point&lt;/returns&gt;
        private PointF PointOnCircle(float radius, float angleInDegrees, PointF origin)
        {
            //Find the x and y using the parametric equation for a circle
            float x = (float)(radius * Math.Cos((angleInDegrees - 90f) * Math.PI / 180F)) &#43; origin.X;
            float y = (float)(radius * Math.Sin((angleInDegrees - 90f) * Math.PI / 180F)) &#43; origin.Y;

            /*Note : The &quot;- 90f&quot; is only for the proper rotation of the clock.
             * It is not part of the parament equation for a circle*/

            //Return the point
            return new PointF(x, y);
        }

        #endregion

        #region Show Minor Segments

        /// &lt;summary&gt;
        /// Indicates if the minor segements are shown
        /// &lt;/summary&gt;
        private bool showMinorSegments = true;

        /// &lt;summary&gt;
        /// Indicates if the minor segements are shown
        /// &lt;/summary&gt;
        public bool ShowMinorSegments 
        {
            get
            {
                return showMinorSegments;
            }
            set
            {
                showMinorSegments = value;
                Refresh();
            }
        }

        #endregion

        #region Show Major Segments

        /// &lt;summary&gt;
        /// Indicates if the major segements are shown
        /// &lt;/summary&gt;
        private bool showMajorSegments = true;

        /// &lt;summary&gt;
        /// Indicates if the major segements are shown
        /// &lt;/summary&gt;
        public bool ShowMajorSegments
        {
            get
            {
                return showMajorSegments;
            }
            set
            {
                showMajorSegments = value;
                Refresh();
            }
        }

        #endregion

        #region Show Second Hand

        /// &lt;summary&gt;
        /// Indicates if the second hand is shown
        /// &lt;/summary&gt;
        private bool showSecondHand = true;

        /// &lt;summary&gt;
        /// Indicates if the second hand is shown
        /// &lt;/summary&gt;
        public bool ShowSecondhand
        {
            get
            {
                return showSecondHand;
            }
            set
            {
                showSecondHand = value;
                Refresh();
            }
        }

        #endregion

        #region Show Minute Hand

        /// &lt;summary&gt;
        /// Indicates if the minute hand is shown
        /// &lt;/summary&gt;
        private bool showMinuteHand = true;

        /// &lt;summary&gt;
        /// Indicates if the minute hand is shown
        /// &lt;/summary&gt;
        public bool ShowMinuteHand
        {
            get
            {
                return showMinuteHand;
            }
            set
            {
                showMinuteHand = value;
                Refresh();
            }
        }

        #endregion

        #region Show Hour Hand

        /// &lt;summary&gt;
        /// Indicates if the hour hand is shown
        /// &lt;/summary&gt;
        private bool showHourHand = true;

        /// &lt;summary&gt;
        /// Indicates if the hour hand is shown
        /// &lt;/summary&gt;
        public bool ShowHourHand
        {
            get
            {
                return showHourHand;
            }
            set
            {
                showHourHand = value;
                Refresh();
            }
        }

        #endregion

    }
}
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Forms&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;ClockControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Partial</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;ClockControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Control<span class="visualBasic__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Construct&nbsp;the&nbsp;clock</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Set&nbsp;the&nbsp;double&nbsp;buffered&nbsp;to&nbsp;true&nbsp;to&nbsp;reduce&nbsp;flickering&nbsp;of&nbsp;the&nbsp;graphics</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleBuffered&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;the&nbsp;timer&nbsp;and&nbsp;start&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;ClockTimer.Tick,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;ClockTimer_Tick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClockTimer.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClockTimer.Interval&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClockTimer.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Update&nbsp;the&nbsp;clock</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;tick&nbsp;event&nbsp;for&nbsp;the&nbsp;timer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;The&nbsp;object&nbsp;that&nbsp;sends&nbsp;the&nbsp;trigger&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;The&nbsp;event&nbsp;arguments&nbsp;for&nbsp;the&nbsp;event&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ClockTimer_Tick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;timer&nbsp;to&nbsp;update&nbsp;the&nbsp;hands</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;ClockTimer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Timer()<span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;On&nbsp;paint</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Called&nbsp;when&nbsp;the&nbsp;control&nbsp;needs&nbsp;to&nbsp;draw&nbsp;itself</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;pe&quot;&gt;The&nbsp;paint&nbsp;event&nbsp;arguments&nbsp;for&nbsp;the&nbsp;control&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(pe&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PaintEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnPaint(pe)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Clear&nbsp;the&nbsp;graphics&nbsp;to&nbsp;the&nbsp;back&nbsp;color&nbsp;of&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.Clear(BackColor)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;border&nbsp;of&nbsp;the&nbsp;clock</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawEllipse(Pens.Black,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;Size.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;Size.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Find&nbsp;the&nbsp;radius&nbsp;of&nbsp;the&nbsp;control&nbsp;by&nbsp;dividing&nbsp;the&nbsp;width&nbsp;by&nbsp;2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;radius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;(Size.Width&nbsp;\&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Find&nbsp;the&nbsp;origin&nbsp;of&nbsp;the&nbsp;circle&nbsp;by&nbsp;dividing&nbsp;the&nbsp;width&nbsp;and&nbsp;height&nbsp;of&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;origin&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(Size.Width&nbsp;\&nbsp;<span class="visualBasic__number">2</span>,&nbsp;Size.Height&nbsp;\&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;only&nbsp;if&nbsp;ShowMajorSegments&nbsp;is&nbsp;true;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ShowMajorSegments&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;Major&nbsp;segments&nbsp;for&nbsp;the&nbsp;clock</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;0F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;i&nbsp;&lt;&gt;&nbsp;390F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawLine(Pens.Black,&nbsp;PointOnCircle(radius&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;i,&nbsp;origin),&nbsp;PointOnCircle(radius&nbsp;-&nbsp;<span class="visualBasic__number">21</span>,&nbsp;i,&nbsp;origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;&#43;=&nbsp;30F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;only&nbsp;if&nbsp;ShowMinorSegments&nbsp;is&nbsp;true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ShowMinorSegments&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;minor&nbsp;segments&nbsp;for&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;0F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;i&nbsp;&lt;&gt;&nbsp;366F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawLine(Pens.Black,&nbsp;PointOnCircle(radius,&nbsp;i,&nbsp;origin),&nbsp;PointOnCircle(radius&nbsp;-&nbsp;<span class="visualBasic__number">10</span>,&nbsp;i,&nbsp;origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;&#43;=&nbsp;6F&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;only&nbsp;if&nbsp;ShowSecondHand&nbsp;is&nbsp;true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ShowSecondhand&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;second&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawLine(Pens.Black,&nbsp;origin,&nbsp;PointOnCircle(radius,&nbsp;DateTime.Now.Second&nbsp;*&nbsp;6F,&nbsp;origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;only&nbsp;if&nbsp;ShowMinuteHand&nbsp;is&nbsp;true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ShowMinuteHand&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;minute&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawLine(Pens.Black,&nbsp;origin,&nbsp;PointOnCircle(radius&nbsp;*&nbsp;<span class="visualBasic__number">0</span>.75F,&nbsp;DateTime.Now.Minute&nbsp;*&nbsp;6F,&nbsp;origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;only&nbsp;if&nbsp;ShowHourHand&nbsp;is&nbsp;true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ShowHourHand&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;hour&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Graphics.DrawLine(Pens.Black,&nbsp;origin,&nbsp;PointOnCircle(radius&nbsp;*&nbsp;<span class="visualBasic__number">0</span>.5F,&nbsp;DateTime.Now.Hour&nbsp;*&nbsp;30F,&nbsp;origin))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;On&nbsp;size&nbsp;changed</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Triggered&nbsp;when&nbsp;the&nbsp;size&nbsp;of&nbsp;the&nbsp;control&nbsp;changes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;The&nbsp;event&nbsp;arguments&nbsp;for&nbsp;the&nbsp;event&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnSizeChanged(e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnSizeChanged(e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Make&nbsp;sure&nbsp;the&nbsp;control&nbsp;is&nbsp;square</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Size.Height&nbsp;&lt;&gt;&nbsp;Size.Width&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(Size.Width,&nbsp;Size.Width)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Redraw&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Point&nbsp;on&nbsp;circle</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Find&nbsp;the&nbsp;point&nbsp;on&nbsp;the&nbsp;circumference&nbsp;of&nbsp;a&nbsp;circle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;radius&quot;&gt;The&nbsp;radius&nbsp;of&nbsp;the&nbsp;circle&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;angleInDegrees&quot;&gt;The&nbsp;angle&nbsp;of&nbsp;the&nbsp;point&nbsp;to&nbsp;origin&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;origin&quot;&gt;The&nbsp;origin&nbsp;of&nbsp;the&nbsp;circle&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;Return&nbsp;the&nbsp;point&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;PointOnCircle(radius&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>,&nbsp;angleInDegrees&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>,&nbsp;origin&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PointF)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PointF&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Find&nbsp;the&nbsp;x&nbsp;and&nbsp;y&nbsp;using&nbsp;the&nbsp;parametric&nbsp;equation&nbsp;for&nbsp;a&nbsp;circle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CSng</span>(radius&nbsp;*&nbsp;Math.Cos((angleInDegrees&nbsp;-&nbsp;90F)&nbsp;*&nbsp;Math.PI&nbsp;/&nbsp;180F))&nbsp;&#43;&nbsp;origin.X&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Single</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CSng</span>(radius&nbsp;*&nbsp;Math.Sin((angleInDegrees&nbsp;-&nbsp;90F)&nbsp;*&nbsp;Math.PI&nbsp;/&nbsp;180F))&nbsp;&#43;&nbsp;origin.Y&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Note&nbsp;:&nbsp;The&nbsp;&quot;-&nbsp;90f&quot;&nbsp;is&nbsp;only&nbsp;for&nbsp;the&nbsp;proper&nbsp;rotation&nbsp;of&nbsp;the&nbsp;clock.</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;It&nbsp;is&nbsp;not&nbsp;part&nbsp;of&nbsp;the&nbsp;parament&nbsp;equation&nbsp;for&nbsp;a&nbsp;circle</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Return&nbsp;the&nbsp;point</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PointF(x,&nbsp;y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Show&nbsp;Minor&nbsp;Segments</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;minor&nbsp;segements&nbsp;are&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_showMinorSegments&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;minor&nbsp;segements&nbsp;are&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowMinorSegments()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_showMinorSegments&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_showMinorSegments&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Show&nbsp;Major&nbsp;Segments</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;major&nbsp;segements&nbsp;are&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_showMajorSegments&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;major&nbsp;segements&nbsp;are&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowMajorSegments()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_showMajorSegments&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_showMajorSegments&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Show&nbsp;Second&nbsp;Hand</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;second&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_showSecondHand&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;second&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowSecondhand()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_showSecondHand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_showSecondHand&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Show&nbsp;Minute&nbsp;Hand</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;minute&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_showMinuteHand&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;minute&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowMinuteHand()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_showMinuteHand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_showMinuteHand&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Show&nbsp;Hour&nbsp;Hand</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;hour&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_showHourHand&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicates&nbsp;if&nbsp;the&nbsp;hour&nbsp;hand&nbsp;is&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowHourHand()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_showHourHand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_showHourHand&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span>&nbsp;
</pre>
</div>
</div>
</div>
<p><span>4. Then in ClockControl.designer delete everything and add the following code</span></p>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Namespace ClockControl
	Partial Class ClockControl
		#Region &quot;IContainer&quot;

		''' &lt;summary&gt;
		''' Required designer variable.
		''' &lt;/summary&gt;
		Private components As System.ComponentModel.IContainer = Nothing

		#End Region

		#Region &quot;Dispose&quot;

		''' &lt;summary&gt;
		''' Clean up any resources being used.
		''' &lt;/summary&gt;
		''' &lt;param name=&quot;disposing&quot;&gt;true if managed resources should be disposed; otherwise, false.&lt;/param&gt;
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		#Region &quot;Component Designer generated code&quot;

		#Region &quot;Initialize Component&quot;

		''' &lt;summary&gt;
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' &lt;/summary&gt;
		Private Sub InitializeComponent()
			components = New System.ComponentModel.Container()
		End Sub

		#End Region

		#End Region
	End Class
End Namespace
</pre>
<pre class="hidden">namespace ClockControl
{
    partial class ClockControl
    {
        #region IContainer

        /// &lt;summary&gt;
        /// Required designer variable.
        /// &lt;/summary&gt;
        private System.ComponentModel.IContainer components = null;

        #endregion

        #region Dispose

        /// &lt;summary&gt;
        /// Clean up any resources being used.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;disposing&quot;&gt;true if managed resources should be disposed; otherwise, false.&lt;/param&gt;
        protected override void Dispose(bool disposing)
        {
            if (disposing &amp;&amp; (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Component Designer generated code

        #region Initialize Component

        /// &lt;summary&gt;
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// &lt;/summary&gt;
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #endregion
    }
}
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Namespace</span>&nbsp;ClockControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Partial</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;ClockControl<span class="visualBasic__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;IContainer</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Required&nbsp;designer&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;components&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.ComponentModel.IContainer&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Dispose</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Clean&nbsp;up&nbsp;any&nbsp;resources&nbsp;being&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;disposing&quot;&gt;true&nbsp;if&nbsp;managed&nbsp;resources&nbsp;should&nbsp;be&nbsp;disposed;&nbsp;otherwise,&nbsp;false.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Dispose(disposing&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;disposing&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;(components&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;components.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Dispose(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Component&nbsp;Designer&nbsp;generated&nbsp;code</span>&quot;<span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#Region&nbsp;&quot;Initialize&nbsp;Component</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Required&nbsp;method&nbsp;for&nbsp;Designer&nbsp;support&nbsp;-&nbsp;do&nbsp;not&nbsp;modify&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;the&nbsp;contents&nbsp;of&nbsp;this&nbsp;method&nbsp;with&nbsp;the&nbsp;code&nbsp;editor.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;InitializeComponent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;components&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;System.ComponentModel.Container()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#End&nbsp;Region</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</span><span>Source Code Files</span></h1>
<ul>
<li><em>ClockControl.cs - the code to draw the grphics for the clock</em> </li><li><em>ClockControl.designer.cs - the designer code</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information email me on <a href="mailto:genie.jinesh@outlook.com">
genie.jinesh@outlook.com</a>.</em></p>

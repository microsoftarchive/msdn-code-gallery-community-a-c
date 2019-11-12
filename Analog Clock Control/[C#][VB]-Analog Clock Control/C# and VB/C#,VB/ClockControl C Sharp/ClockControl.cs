using System;
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
            ClockTimer.Tick += ClockTimer_Tick;
            ClockTimer.Enabled = true;
            ClockTimer.Interval = 1;
            ClockTimer.Start();
        }

        #endregion

        #region Update the clock

        /// <summary>
        /// The tick event for the timer
        /// </summary>
        /// <param name="sender">The object that sends the trigger</param>
        /// <param name="e">The event arguments for the event</param>
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// The timer to update the hands
        /// </summary>
        private Timer ClockTimer = new Timer();

        #endregion

        #region On paint

        /// <summary>
        /// Called when the control needs to draw itself
        /// </summary>
        /// <param name="pe">The paint event arguments for the control</param>
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
                for (float i = 0f; i != 390f; i += 30f)
                {
                    pe.Graphics.DrawLine(Pens.Black, PointOnCircle(radius - 1, i, origin), PointOnCircle(radius - 21, i, origin));
                }
            }

            //Draw only if ShowMinorSegments is true
            if (ShowMinorSegments)
            {
                //Draw the minor segments for the control
                for (float i = 0f; i != 366f; i += 6f)
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

        /// <summary>
        /// Triggered when the size of the control changes
        /// </summary>
        /// <param name="e">The event arguments for the event</param>
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

        /// <summary>
        /// Find the point on the circumference of a circle
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="angleInDegrees">The angle of the point to origin</param>
        /// <param name="origin">The origin of the circle</param>
        /// <returns>Return the point</returns>
        private PointF PointOnCircle(float radius, float angleInDegrees, PointF origin)
        {
            //Find the x and y using the parametric equation for a circle
            float x = (float)(radius * Math.Cos((angleInDegrees - 90f) * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin((angleInDegrees - 90f) * Math.PI / 180F)) + origin.Y;

            /*Note : The "- 90f" is only for the proper rotation of the clock.
             * It is not part of the parament equation for a circle*/

            //Return the point
            return new PointF(x, y);
        }

        #endregion

        #region Show Minor Segments

        /// <summary>
        /// Indicates if the minor segements are shown
        /// </summary>
        private bool showMinorSegments = true;

        /// <summary>
        /// Indicates if the minor segements are shown
        /// </summary>
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

        /// <summary>
        /// Indicates if the major segements are shown
        /// </summary>
        private bool showMajorSegments = true;

        /// <summary>
        /// Indicates if the major segements are shown
        /// </summary>
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

        /// <summary>
        /// Indicates if the second hand is shown
        /// </summary>
        private bool showSecondHand = true;

        /// <summary>
        /// Indicates if the second hand is shown
        /// </summary>
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

        /// <summary>
        /// Indicates if the minute hand is shown
        /// </summary>
        private bool showMinuteHand = true;

        /// <summary>
        /// Indicates if the minute hand is shown
        /// </summary>
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

        /// <summary>
        /// Indicates if the hour hand is shown
        /// </summary>
        private bool showHourHand = true;

        /// <summary>
        /// Indicates if the hour hand is shown
        /// </summary>
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

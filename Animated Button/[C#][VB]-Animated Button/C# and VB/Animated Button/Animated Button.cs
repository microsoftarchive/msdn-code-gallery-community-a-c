using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animate
{
    public partial class AnimatedButton : Button
    {
        #region Frame

        private class Frame
        {
            public Frame(int FrameCount, int CurrentFrame, Size FrameSize, Image ImageStrip)
            {
                this.FrameCount = FrameCount;
                this.CurrentFrame = CurrentFrame;
                this.FrameSize = FrameSize;
                this.ImageStrip = ImageStrip;
            }

            public Image ImageStrip
            {
                get;
                set;
            }
            public int FrameCount
            {
                get;
                set;
            }
            public int CurrentFrame
            {
                get;
                set;
            }
            public Size FrameSize
            {
                get;
                set;
            }
        }

        #endregion

        #region MouseOver

        private bool _IsMouseOver = false;
        private Frame MouseOverFrame
        {
            get;
            set;
        }
        private bool IsMouseOver
        {
            get
            {
                return _IsMouseOver;
            }
            set
            {
                _IsMouseOver = value;

                Refresh();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            IsMouseOver = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            IsMouseOver = false;
        }

        #endregion

        #region MouseClick

        private bool _IsMouseDown = false;
        private bool IsMouseDown
        {
            get
            {
                return _IsMouseDown;
            }
            set
            {
                _IsMouseDown = value;

                Refresh();
            }
        }
        private Frame MouseClickFrame
        {
            get;
            set;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            IsMouseDown = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            IsMouseDown = false;
        }

        #endregion

        public AnimatedButton()
        {
            InitializeComponent();

            DoubleBuffered = true;

            MouseOverFrame = new Frame(25, 0, new Size(100, 30), Properties.Resources.ButtonMouseOver);
            MouseClickFrame = new Frame(25, 0, new Size(100, 30), Properties.Resources.ButtonMouseDown);

            this.Size = MouseOverFrame.FrameSize;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.Clear(BackColor); 

            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            if (!IsMouseOver && !IsMouseDown && MouseOverFrame.CurrentFrame == 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver && !IsMouseDown && MouseOverFrame.CurrentFrame != MouseOverFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, MouseOverFrame.CurrentFrame++ * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver && !IsMouseDown && MouseOverFrame.CurrentFrame == MouseOverFrame.FrameCount && MouseClickFrame.CurrentFrame == 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, (MouseOverFrame.CurrentFrame - 1) * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver && IsMouseDown && MouseClickFrame.CurrentFrame != MouseClickFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, MouseClickFrame.CurrentFrame++ * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver && IsMouseDown && MouseClickFrame.CurrentFrame == MouseClickFrame.FrameCount)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip,
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, (MouseClickFrame.CurrentFrame - 1) * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (IsMouseOver && !IsMouseDown && MouseClickFrame.CurrentFrame != 0)
            {
                pe.Graphics.DrawImage(MouseClickFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    new Rectangle(0, --MouseClickFrame.CurrentFrame * MouseClickFrame.FrameSize.Height, MouseClickFrame.FrameSize.Width, MouseClickFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }
            else if (!IsMouseOver && !IsMouseDown && MouseOverFrame.CurrentFrame != 0)
            {
                pe.Graphics.DrawImage(MouseOverFrame.ImageStrip, 
                    new Rectangle(0, 0, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    new Rectangle(0, --MouseOverFrame.CurrentFrame * MouseOverFrame.FrameSize.Height, MouseOverFrame.FrameSize.Width, MouseOverFrame.FrameSize.Height), 
                    GraphicsUnit.Pixel);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), pe.ClipRectangle, sf);
            }
        }

        private void _FPS_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}

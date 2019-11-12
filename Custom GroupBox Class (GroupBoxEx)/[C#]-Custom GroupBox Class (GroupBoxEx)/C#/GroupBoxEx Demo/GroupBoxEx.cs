using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
//If you are building a Class Library project then you will need to add reference to System.Windows.Forms and
//System.Drawing. You can do that after you create the new Class Library by going to the VB menu and clicking
//(Project) and then selecting (Add Reference...). Then on the (.Net) tab you can find and select (System.Drawing)
//and (System.Windows.Forms) to add the references.
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GroupBoxEx_Demo
{
    //Inherit the Properties, Methods, and Events from the GroupBox class
    public class GroupBoxEx : GroupBox
    {
        //Create the property backing fields
        private SolidBrush _BackColorBrush;
        private SolidBrush _PanelBrush;
        private PanelType _PanelShape = PanelType.Rounded;
        private Pen _BorderPen;
        private bool _DrawBorder = true;
        private SolidBrush _TextBrush;
        private SolidBrush _TextBackBrush;
        private Pen _TextBorderPen;
        private Image _BackgroundPanelImage;

        //Create an Enum used for the PanelShape property
        public enum PanelType : int
        {
            Squared = 0,
            Rounded = 1
        }

        //Set the Styles, pens, brushes, and properties used for the defaults when a new instance is created
        public GroupBoxEx()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Size = new Size(180, 100);
            _BackColorBrush = new SolidBrush(Color.Transparent);
            _BorderPen = new Pen(Color.Black);
            _PanelBrush = new SolidBrush(base.BackColor);
            _TextBrush = new SolidBrush(base.ForeColor);
            _TextBackBrush = new SolidBrush(Color.White);
            _TextBorderPen = new Pen(Color.Black);
            base.BackColor = Color.Transparent;
        }

        //Create the properties for the control

        [Category("Appearance"), Description("Gets or sets the Background image.")]
        [Browsable(true)]
        public Image BackgroundPanelImage
        {
            get { return _BackgroundPanelImage; }
            set
            {
                _BackgroundPanelImage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the text.")]
        [Browsable(true)]
        public override System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                _TextBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("Gets or sets the Background color.")]
        [Browsable(true)]
        public Color GroupPanelColor
        {
            get { return _PanelBrush.Color; }
            set
            {
                _PanelBrush.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the shape of the control.")]
        [Browsable(true)]
        public PanelType GroupPanelShape
        {
            get { return _PanelShape; }
            set
            {
                _PanelShape = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets if a border is drawn around the control.")]
        [Browsable(true)]
        public bool DrawGroupBorder
        {
            get { return _DrawBorder; }
            set
            {
                _DrawBorder = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the border.")]
        [Browsable(true)]
        public Color GroupBorderColor
        {
            get { return _BorderPen.Color; }
            set
            {
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the Background color of the text.")]
        [Browsable(true)]
        public Color TextBackColor
        {
            get { return _TextBackBrush.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _TextBackBrush.Color;
                    throw new Exception("Color Transparent is not supported");
                }
                _TextBackBrush.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Gets or sets the color of the border around the text.")]
        [Browsable(true)]
        public Color TextBorderColor
        {
            get { return _TextBorderPen.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _TextBorderPen.Color;
                    throw new Exception("Color Transparent is not supported");
                }
                _TextBorderPen.Color = value;
                this.Refresh();
            }
        }

        //Used to paint the control according to how the properties are set
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var _with1 = e.Graphics;
            _with1.FillRectangle(_BackColorBrush, 0, 0, this.Width, this.Height);
            _with1.SmoothingMode = SmoothingMode.AntiAlias;
            int tw = Convert.ToInt32(_with1.MeasureString(this.Text, this.Font).Width);
            int th = Convert.ToInt32(_with1.MeasureString(this.Text, this.Font).Height);
            Rectangle rec = new Rectangle(0, Convert.ToInt32(th / 2), this.Width - 1, this.Height - 1 - Convert.ToInt32(th / 2));
            using (GraphicsPath gp = new GraphicsPath())
            {
                if (this.GroupPanelShape == PanelType.Rounded)
                {
                    int rad = 14;
                    gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                    gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                    gp.CloseFigure();
                }
                else
                {
                    gp.AddRectangle(rec);
                }

                _with1.FillPath(_PanelBrush, gp);
                if (this.BackgroundPanelImage != null)
                {
                    DrawBackImage(e.Graphics, gp, Convert.ToInt32(th / 2));
                }
                if (this.DrawGroupBorder)
                    _with1.DrawPath(_BorderPen, gp);
            }
            if (tw > 0 & th > 0)
            {
                Rectangle trec = new Rectangle(7, 0, this.Width - 15, th + 2);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    int rad = 6;
                    gp.AddArc(trec.Right - (rad), trec.Y, rad, rad, 270, 90);
                    gp.AddArc(trec.Right - (rad), trec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(trec.X, trec.Bottom - (rad), rad, rad, 90, 90);
                    gp.AddArc(trec.X, trec.Y, rad, rad, 180, 90);
                    gp.CloseFigure();
                    _with1.FillPath(_TextBackBrush, gp);
                    _with1.DrawPath(_TextBorderPen, gp);
                }
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                {
                    _with1.DrawString(this.Text, this.Font, _TextBrush, trec, sf);
                }
            }
        }

        //A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout
        private void DrawBackImage(Graphics g, GraphicsPath grxpath, int topoffset)
        {
            using (Bitmap bm = new Bitmap(this.Width, this.Height - topoffset))
            {
                using (Graphics grx = Graphics.FromImage(bm))
                {
                    if (this.BackgroundImageLayout == ImageLayout.None)
                    {
                        grx.DrawImage(this.BackgroundPanelImage, 0, 0, this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Tile)
                    {
                        int tc = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bm.Width / this.BackgroundPanelImage.Width)));
                        int tr = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bm.Height / this.BackgroundPanelImage.Height)));
                        for (int y = 0; y <= tr; y++)
                        {
                            for (int x = 0; x <= tc; x++)
                            {
                                grx.DrawImage(this.BackgroundPanelImage, (x * this.BackgroundPanelImage.Width), (y * this.BackgroundPanelImage.Height), this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                            }
                        }
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Center)
                    {
                        int xx = Convert.ToInt32((this.Width / 2) - (this.BackgroundPanelImage.Width / 2));
                        int yy = Convert.ToInt32(((this.Height - topoffset) / 2) - (this.BackgroundPanelImage.Height / 2));
                        grx.DrawImage(this.BackgroundPanelImage, xx, yy, this.BackgroundPanelImage.Width, this.BackgroundPanelImage.Height);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                    {
                        grx.DrawImage(this.BackgroundPanelImage, 0, 0, this.Width, this.Height - topoffset);
                    }
                    else if (this.BackgroundImageLayout == ImageLayout.Zoom)
                    {
                        double meratio = this.Width / (this.Height - topoffset);
                        double imgratio = this.BackgroundPanelImage.Width / this.BackgroundPanelImage.Height;
                        Rectangle imgrect = new Rectangle(0, 0, this.Width, this.Height - topoffset);
                        if (imgratio > meratio)
                        {
                            imgrect.Width = this.Width;
                            imgrect.Height = Convert.ToInt32(this.Width / imgratio);
                        }
                        else if (imgratio < meratio)
                        {
                            imgrect.Height = this.Height - topoffset;
                            imgrect.Width = Convert.ToInt32((this.Height - topoffset) * imgratio);
                        }
                        imgrect.X = Convert.ToInt32((this.Width / 2) - (imgrect.Width / 2));
                        imgrect.Y = Convert.ToInt32(((this.Height - topoffset) / 2) - (imgrect.Height / 2));
                        grx.DrawImage(this.BackgroundPanelImage, imgrect);
                    }
                }
                using (TextureBrush tb = new TextureBrush(bm))
                {
                    if (this.BackgroundImageLayout != ImageLayout.Tile)
                        tb.WrapMode = WrapMode.Clamp;
                    tb.TranslateTransform(0, topoffset);
                    g.FillPath(tb, grxpath);
                }
            }
        }

        //Used to force the control to repaint itself when the text is changed
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        //Override the BackColor property and hide it from the user
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("The BackColor property is not implemented.", true)]
        public new System.Drawing.Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                throw new Exception("The BackColor property is not implemented.");
            }
        }

        //Override the BackgroundImage property and hide it from the user
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("The BackgroundImage property is not implemented.", true)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                throw new Exception("The BackgroundImage property is not implemented.");
            }
        }

        //Dispose of all brushes and pens used for the property backing fields
        protected override void Dispose(bool disposing)
        {
            _BackColorBrush.Dispose();
            _BorderPen.Dispose();
            _PanelBrush.Dispose();
            _TextBrush.Dispose();
            _TextBackBrush.Dispose();
            _TextBorderPen.Dispose();
            base.Dispose(disposing);
        }
    }
}

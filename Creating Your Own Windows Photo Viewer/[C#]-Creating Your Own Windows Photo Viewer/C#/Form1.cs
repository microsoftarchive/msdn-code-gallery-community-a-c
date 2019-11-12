using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Picture_Labs
{
    public partial class Form1 : Form
    {
        //Open And Save Dialog
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        //Zoom Level
        double zoomFactor = 1.0;
        
        //Image Processing Handler
        ImageProcessing.ImageHandler imageHandler = new ImageProcessing.ImageHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageHandler = new ImageProcessing.ImageHandler();
        }

        private void cOpen_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Title = "Open Picture";
            ofd.Filter = "Picture File |*.bmp;*.jpg;*.png;*.gif";
            ofd.ShowDialog();
            if (ofd.FileName.ToString() != "")
            {
                //Send Image To Handle
                imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(ofd.FileName);
                imageHandler.BitmapPath = ofd.FileName;

                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                this.Invalidate();

                ofd.Dispose();
            }

        }

        // Detect any Change From Handle and Then Display It To Current Form
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Scale Image To Center Screen
            Graphics g = e.Graphics;
            int FormSizeX = (this.Size.Width / 2) - ( imageHandler.CurrentBitmap.Width / 2);
            int FormSizeY = (this.Size.Height / 2) - (imageHandler.CurrentBitmap.Height / 2);
            g.DrawImage(imageHandler.CurrentBitmap, new Rectangle(FormSizeX, FormSizeY, Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor)));
        }

        // Save The File
        private void cSave_Click(object sender, EventArgs e)
        {
            sfd = new SaveFileDialog();
            sfd.Title = "Save Pictre";
            sfd.Filter = "Windows Bitmap (*.bmp) |*.bmp";
            sfd.ShowDialog();
            if (sfd.FileName.ToString() != "")
            {
                imageHandler.SaveBitmap(sfd.FileName);
            }
        }

        // Change Zoom Level
        private void cbScale_Change(object sender, EventArgs e)
        {
            switch (cbScale.Text)
            {
                case "50%":
                    zoomFactor = 0.5;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "100%":
                    zoomFactor = 1.0;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "150%":
                    zoomFactor = 1.5;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "200%":
                    zoomFactor = 2.0;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "250%":
                    zoomFactor = 2.5;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "300%":
                    zoomFactor = 3.0;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "350%":
                    zoomFactor = 3.5;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "400%":
                    zoomFactor = 4.0;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                default:
                    break;
            }
        }

        // Rotate And Flip Image
        private void cbRotateFlip_Change(object sender, EventArgs e)
        {
            switch (cbRotateFlip.Text)
            {
                case "Rotate 90":
                    imageHandler.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "Rotate 180":
                    imageHandler.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "Rotate 270":
                    imageHandler.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "Flip Horizontal":
                    imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                case "Flip Vertical":
                    imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                    this.Invalidate();
                    break;
                default:
                    break;
            }
        }

        private void cbMask_Change(object sender, EventArgs e)
        {
            switch (cbMask.Text)
            {
                case "Red":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    imageHandler.SetColorFilter(ImageProcessing.ImageHandler.ColorFilterTypes.Red);
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Green":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    imageHandler.SetColorFilter(ImageProcessing.ImageHandler.ColorFilterTypes.Green);
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Blue":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    imageHandler.SetColorFilter(ImageProcessing.ImageHandler.ColorFilterTypes.Blue);
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                default:
                    break;
            }
        }

        private void cbFilter_Change(object sender, EventArgs e)
        {
            switch (cbFilter.Text)
            {
                    //"Gamma",
                    //"Contrast",
                    //"Brightness"});
                case "Grayscake":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    imageHandler.SetGrayscale();
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Invert":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    imageHandler.SetInvert();
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Gamma":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    //You Can Change This Value
                    imageHandler.SetGamma( 2.1, 2.1, 2.0);   //Is Enough?
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Contrast":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    //You Can Change This Value
                    imageHandler.SetContrast(2.5);          //Is Enough?
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                case "Brightness":
                    this.Cursor = Cursors.WaitCursor;
                    imageHandler.RestorePrevious();
                    //You Can Change This Value
                    imageHandler.SetBrightness(15);         //Is Enough?
                    this.Invalidate();
                    this.Cursor = Cursors.Default;
                    break;
                default:
                    break;
            }
        }

    }
}

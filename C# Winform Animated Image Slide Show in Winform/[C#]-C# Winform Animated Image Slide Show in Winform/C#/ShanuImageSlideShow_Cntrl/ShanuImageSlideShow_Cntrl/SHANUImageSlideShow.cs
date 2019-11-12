using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;
using System.Drawing.Drawing2D;

using System.Windows.Forms;
//Author  : Syed Shanu
//Date    : 2014-08-01
//Description : Shanu Pareto Chart

namespace ShanuImageSlideShow_Cntrl
{
    public partial class SHANUImageSlideShow : UserControl
    {  
        #region Members
        public string[] AllImageFielsNames = null;
        private int CurrentIndex = 0;
        private int StartIndex = 0;
        private int LastIndex = 0;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        int locX = 40;
        int locY = 10;
        int sizeWidth = 130;
        int sizeHeight = 130;
        int TotalimageFiles = 0;
        PictureBox[] ctrl;
        Boolean imageselected = false;
        Random rnd = new Random();
        int SlideType = 1;
        int xval = 0;
        int yval = 0;
        private double ZOOMFACTOR = 1.25;	// = 25% smaller or larger
        private int MINMAX = 2;				// 5 times bigger or smaller than the ctrl
        int opacity = 0;
        int opacity_new = 100;
        int xval_Right = 0;
        int yval_Right = 0;
        Pen B1pen = new Pen(Color.Black, 1);


        int recBlockXval = 0;
        int recBlockYval = 0;
        int barwidth = 0;
        int barheight = 0;
        Boolean playSound = false;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        #endregion
       
        #region Initialize
        public SHANUImageSlideShow()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void SHANUImageSlideShow_Load(object sender, EventArgs e)
        {
            wplayer.URL = "Music.wav";
            wplayer.controls.stop();
            Start_Stop_Timer_1(false);
            Start_Stop_Timer_2(false);
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            imageselected = false;
        }
        #endregion

        #region Events
        private void picLoadImage_Click(object sender, EventArgs e)
        {
           
                this.picPlay.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.play;
                playSound = false;
                Play_Stop_Audio();
            Start_Stop_Timer_1(false);
            Start_Stop_Timer_2(false);
            CurrentIndex = 0;
            StartIndex = 0;
            LastIndex = 0;
            TotalimageFiles = 0;
            LoadImages();
        }

        private void picPrevious_Click(object sender, EventArgs e)
        {
            prevImage();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            if (imageselected == false)
            {

                return;
            }
            if (timer1.Enabled == false)
            {
                this.picPlay.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.stop;
                Start_Stop_Timer_1(true);

                playSound = true;
                Play_Stop_Audio();
             
            }
            else
            {

                playSound = false;
                Play_Stop_Audio();
                this.picPlay.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.play;
                Start_Stop_Timer_1(false);
                Start_Stop_Timer_2(false);
            }
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            nextImage();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imageselected == false)
            {

                return;
            }
            nextImage();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            

            drawAnimation();
        }

        private void pic_PlaySound_Click(object sender, EventArgs e)
        {
            if (playSound == false)
            {
                playSound = true;
            }
            else
            {
                playSound = false;
            }
            Play_Stop_Audio();
        }

        #endregion
       
        #region Methods


        #region Play and Stoop Audio
        //To Play and Stoop Audio
        public void Play_Stop_Audio()
        {
            if (playSound == true)
            {
                this.pic_PlaySound.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.soundON;
                wplayer.settings.setMode("loop", true);
                wplayer.controls.play();
            }
            else
            {
                this.pic_PlaySound.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.soundOFF;
                //wplayer.settings.setMode("loop", true);
                wplayer.controls.stop();
            }
        }
        #endregion

        #region LoadImage
        public void LoadImages()
        {
            DirectoryInfo Folder;
            DialogResult result = this.folderBrowserDlg.ShowDialog();
            imageselected = false;
            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);


                var imageFiles = Folder.GetFiles("*.jpg")
                      .Concat(Folder.GetFiles("*.gif"))
                      .Concat(Folder.GetFiles("*.png"))
                      .Concat(Folder.GetFiles("*.jpeg"))
                      .Concat(Folder.GetFiles("*.bmp")).ToArray(); // Here we filter all image files 
                pnlThumb.Controls.Clear();
                if (imageFiles.Length > 0)
                {
                    imageselected = true;
                    TotalimageFiles = imageFiles.Length;
                }
                else
                {
                    return;
                }
                int locnewX = locX;
                int locnewY = locY;

                ctrl = new PictureBox[TotalimageFiles];
                AllImageFielsNames = new String[TotalimageFiles];
                int imageindexs = 0;
                foreach (FileInfo img in imageFiles)
                {
                    AllImageFielsNames[imageindexs] = img.FullName;
                    loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY, imageindexs);
                    locnewX = locnewX + sizeWidth + 10;
                    imageindexs = imageindexs + 1;

                }
                CurrentIndex = 0;
                StartIndex = 0;
                LastIndex = 0;

                DrawImageSlideShows();
            }
        }



        private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY, int imageindexs)
        {
            ctrl[imageindexs] = new PictureBox();
            ctrl[imageindexs].Image = Image.FromFile(ImageFullName);
            ctrl[imageindexs].BackColor = Color.Black;
            ctrl[imageindexs].Location = new Point(newLocX, newLocY);
            ctrl[imageindexs].Size = new System.Drawing.Size(sizeWidth - 30, sizeHeight - 60);
            ctrl[imageindexs].BorderStyle = BorderStyle.None;
            ctrl[imageindexs].SizeMode = PictureBoxSizeMode.StretchImage;
            //  ctrl[imageindexs].MouseClick += new MouseEventHandler(control_MouseMove);
            pnlThumb.Controls.Add(ctrl[imageindexs]);


        }
        #endregion
        
        //To Start and Stop the Timer
        #region Start and Stop Timer
        //To Start and Stop the Timer1
        public void Start_Stop_Timer_1(Boolean StartStatus)
        {
            if (StartStatus)
            {
                timer1.Enabled = true;
                timer1.Start();
                
            }
            else               
            {
                timer1.Enabled = false;
                timer1.Stop();

            }
        }
        //To Start and Stop the Timer2
        public void Start_Stop_Timer_2(Boolean StartStatus)
        {
            if (StartStatus)
            {
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                timer2.Enabled = false;
                timer2.Stop();
            }
        }
        #endregion

        #region Highlight The Current Slected image
        public void HighlightCurrentImage()
        {
            for (int i = 0; i <= ctrl.Length - 1; i++)
            {
                if (i == CurrentIndex)
                {
                    ctrl[i].Left = ctrl[i].Left - 20;
                    ctrl[i].Size = new System.Drawing.Size(sizeWidth + 10, sizeHeight);
                    ctrl[i].BorderStyle = BorderStyle.FixedSingle;

                }
                else
                {
                    // ctrl[i].Location = new Point(newLocX, newLocY);
                    ctrl[i].Size = new System.Drawing.Size(sizeWidth - 20, sizeHeight - 40);
                    ctrl[i].BorderStyle = BorderStyle.None;
                }
            }
        }
        #endregion
        #region Prev/next image load Metods
        private void prevImage()
        {
            if (imageselected == false)
            {

                return;
            }
            if (CurrentIndex == 0)
            {
                CurrentIndex = ctrl.Length - 1;
                DrawImageSlideShows();
            }
            else
            {
                CurrentIndex = CurrentIndex - 1;
                DrawImageSlideShows();
            }
        }

        private void nextImage()
        {
            if (imageselected == false)
            {

                return;
            }
            picImageSlide.Location = new Point(0, 0);
            if (CurrentIndex == ctrl.Length - 1)
            {
                CurrentIndex = 0;
                DrawImageSlideShows();
            }
            else
            {
                CurrentIndex = CurrentIndex + 1;
                DrawImageSlideShows();
            }
        }
        #endregion
        #region load the Selected Image
        public void DrawImageSlideShows()
        {
            if (imageselected == false)
            {

                return;
            }
            picImageSlide.Image = Image.FromFile(AllImageFielsNames[CurrentIndex]);// ctrl[CurrentIndex].Image;
            HighlightCurrentImage();


            if (timer1.Enabled == false)
            {

                return;
            }

            Start_Stop_Timer_1(false);
            Start_Stop_Timer_2(true);
         


            xval = -pnlImg.Width;
            xval_Right = pnlImg.Width;
            yval = -pnlImg.Height;
            yval_Right = pnlImg.Height;
            int barwidth_adjust = 54;
            int barheight_adjust = 98;
            SlideType = rnd.Next(0, 11);

            opacity = 0;
            opacity_new = 100;

            barwidth = picImageSlide.Image.Width / barwidth_adjust;
            barheight = picImageSlide.Image.Height / barheight_adjust;


            if (SlideType == 0)
            {
                picImageSlide.Width = 100;
                picImageSlide.Height = 100;
                picImageSlide.Left = pnlImg.Width / 2;
                picImageSlide.Top = pnlImg.Height / barheight_adjust;
            }
            else
            {
                picImageSlide.Width = pnlImg.Width;
                picImageSlide.Height = pnlImg.Height;
            }
            if (SlideType == 6)
            {
                barwidth = picImageSlide.Image.Width / barwidth_adjust;
                barheight = picImageSlide.Image.Height / barheight_adjust;
                recBlockXval = 0;
                recBlockYval = picImageSlide.Image.Height / barheight_adjust;
            }
            else if (SlideType == 8)
            {
                barwidth = picImageSlide.Image.Height / barheight_adjust;
                barheight = picImageSlide.Image.Width / barwidth_adjust;
                recBlockXval = 0;
                recBlockYval = 0;
            }

            picImageSlide.Image = Image.FromFile(AllImageFielsNames[CurrentIndex]);// ctrl[CurrentIndex].Image;
        }
       
        #endregion

       
       
        #region Draw Animation on seleced Image

        // Small to Big Size Image
        private void SmalltoBigImage_Animation()
        {
            int leftConstant_adjust = 40;
            int topconstant_adjust = 30;
            if ((picImageSlide.Width < (MINMAX * pnlImg.Width)) &&
             (picImageSlide.Height < (MINMAX * pnlImg.Height)))
            {
                picImageSlide.Width = Convert.ToInt32(picImageSlide.Width * ZOOMFACTOR);
                picImageSlide.Height = Convert.ToInt32(picImageSlide.Height * ZOOMFACTOR);
                picImageSlide.Left = Convert.ToInt32(picImageSlide.Left - leftConstant_adjust);
                if (picImageSlide.Top <= 0)
                {
                    picImageSlide.Left = 0;
                    picImageSlide.Top = 0;
                }
                picImageSlide.Top = Convert.ToInt32(picImageSlide.Top - topconstant_adjust);
                picImageSlide.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else //In else part i check for the animation completed if its completed stop the timer 2 and start the timer 1 to load the next image .
            {
                picImageSlide.Width = pnlImg.Width;
                picImageSlide.Height = pnlImg.Height;
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
               
            }
        }

        //Left to Right Animation
        private void LefttoRight_Animation()
        {
            picImageSlide.Invalidate();
            if (picImageSlide.Location.X >= 10)
            {
                picImageSlide.Left = 0;

                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
            }
            else
            {

                picImageSlide.Left = xval;
                xval = xval + 100;
            }
            picImageSlide.Width = pnlImg.Width;
            picImageSlide.Height = pnlImg.Height;
        }

        //Left to Right Animation
        private void Transparent_Bar_Animation()
        {
            //   picImageSlide.Invalidate();

            if (opacity >= 90)
            {
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.

                opacity = 100;
            }
            //   picImageSlide.Refresh();   
            Graphics g = Graphics.FromImage(picImageSlide.Image);
            g.FillRectangle(new SolidBrush(Color.FromArgb(58, Color.White)), 0, 0, picImageSlide.Image.Width, picImageSlide.Image.Height);
            opacity = opacity + 10;
            picImageSlide.Image = PictuerBoxFadeIn(picImageSlide.Image, opacity);  //calling ChangeOpacity Function 
        }
        // Right to Left Animation
        private void RighttoLeft_Animation()
        {
            picImageSlide.Invalidate();
            if (xval_Right <= 100)
            {
                picImageSlide.Left = 0;
                xval_Right = 0;
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
            }
            else
            {

                picImageSlide.Left = xval_Right;
                xval_Right = xval_Right - 100;
            }
            picImageSlide.Width = pnlImg.Width;
            picImageSlide.Height = pnlImg.Height;
        }

     

        // Top to Bottom Slide Animation
        private void ToptoBottom_Animation()
        {
            picImageSlide.Invalidate();
            if (yval + 60 >= 30)
            {
                picImageSlide.Top = 0;

                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
            }
            else
            {

                picImageSlide.Top = yval;
                yval = yval + 100;
            }
            picImageSlide.Width = pnlImg.Width;
            picImageSlide.Height = pnlImg.Height;
        }

        // Bottom to Top Slide Animation
        private void BottomTop_Animation()
        {
            picImageSlide.Invalidate();
            if (yval_Right <= 0)
            {
                picImageSlide.Left = 0;
                xval_Right = 0;

                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
            }
            else
            {

                picImageSlide.Top = yval_Right;
                yval_Right = yval_Right - 100;
            }
            picImageSlide.Width = pnlImg.Width;
            picImageSlide.Height = pnlImg.Height;

        }

           // vertical transparent Bar Animation
        private void Vertical_Bar_Animation()
        {
            if (opacity_new <= 0)
            {
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                opacity_new = 100;
            }
            // picImageSlide.Refresh();
            Graphics g2 = Graphics.FromImage(picImageSlide.Image);


            recBlockYval = 0;
            barheight = barheight + 100;

            g2.DrawRectangle(Pens.Black, recBlockXval, recBlockYval, barwidth, barheight);
            g2.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), recBlockXval, recBlockYval, barwidth - 1, barheight - 1);
            opacity_new = opacity_new - 10;
            recBlockXval = recBlockXval + barwidth + 4;
        
            picImageSlide.Refresh();
        }

         // Random bar and Circle transparent  Animation
        private void Random_Bar_Animation()
        {

            if (opacity_new <= 0)
            {
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                opacity_new = 100;
            }
            // picImageSlide.Refresh();
            Graphics g3 = Graphics.FromImage(picImageSlide.Image);


            recBlockXval = 0;
            barwidth = barwidth + 100;

            // g3.DrawRectangle(Pens.Black, rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(100, 600), rnd.Next(60, 400));
            g3.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), rnd.Next(10, 600), rnd.Next(10, 600), rnd.Next(100, 600), rnd.Next(60, 400));
            opacity_new = opacity_new - 5;
            recBlockYval = recBlockYval + barheight + 4;
            //recBlockYval = recBlockYval + 100;
            //barheight = barheight + 100;
            picImageSlide.Refresh();
        }
        //Horizontal transparent Bar Animation
        private void Horizontal_Bar_Animation()
        {
            if (opacity_new <= 0)
            {
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                opacity_new = 100;
            }
            recBlockXval = 0;
            barwidth = barwidth + 100;
            Graphics g4 = Graphics.FromImage(picImageSlide.Image);
            g4.DrawRectangle(Pens.Black, recBlockXval, recBlockYval, barwidth, barheight);
            g4.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), recBlockXval, recBlockYval, barwidth - 1, barheight - 1);
            opacity_new = opacity_new - 10;
            recBlockYval = recBlockYval + barheight + 4;
            picImageSlide.Refresh();
        }

        // transparent text Animation
        private void  Transparent_Text_Animation()
        {
                            if (opacity_new <= 0)
                        {
                            Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                            Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                            opacity_new = 100;
                        }
                        // picImageSlide.Refresh();
                        Graphics g5 = Graphics.FromImage(picImageSlide.Image);

                        g5.DrawString("Shanu Slide Show", new Font("Arial", 86),
                  new SolidBrush(Color.FromArgb(opacity_new, Color.FromArgb(this.rnd.Next(256), this.rnd.Next(256), this.rnd.Next(256)))),
                  rnd.Next(600), rnd.Next(400));

                        opacity_new = opacity_new - 5;

                        picImageSlide.Refresh();
        }

        // Random Circle Animation
        private void Random_Circle_Animation()
        {
            if (opacity_new <= 0)
            {
                Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                opacity_new = 100;
            }
            // picImageSlide.Refresh();
            Graphics g6 = Graphics.FromImage(picImageSlide.Image);

            recBlockXval = 0;
            barwidth = barwidth + 100;

            // g3.DrawRectangle(Pens.Black, rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(100, 600), rnd.Next(60, 400));
            g6.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), rnd.Next(10, 600), rnd.Next(10, 600), rnd.Next(400, 800), rnd.Next(60, 400));
            g6.FillPie(new SolidBrush(Color.FromArgb(opacity_new, Color.FromArgb(this.rnd.Next(256), this.rnd.Next(256), this.rnd.Next(256)))), rnd.Next(600), rnd.Next(400), rnd.Next(400, 800), rnd.Next(400), 0, 360);
            opacity_new = opacity_new - 5;
            recBlockYval = recBlockYval + barheight + 4;
            //recBlockYval = recBlockYval + 100;
            //barheight = barheight + 100;
            picImageSlide.Refresh();
        }


        public void drawAnimation()
        {
            try
            {

                switch (SlideType)
                {
                    case 0:// Small to big
                        SmalltoBigImage_Animation();
                        break;

                    case 1:// left to right
                        LefttoRight_Animation();
                        break;

                    case 2:// Rectangle Transparent
                        Transparent_Bar_Animation();
                        break;

                    case 3:// Right to Left
                        RighttoLeft_Animation();        
                        break;

                    case 4:// Top to Bottom
                        ToptoBottom_Animation();    
                        break;

                    case 5:// Bottom to Top
                        BottomTop_Animation();
                        break;

                    case 6:// Rectangle Vertical Block Transparent
                        Vertical_Bar_Animation();
                        break;

                    case 7:// Random Block Transparent
                        Random_Bar_Animation();
                        break;

                    case 8:// Rectangle Horizontal Block Transparent
                       Horizontal_Bar_Animation();                      
                        break;

                    case 9:// Text Transparent
                        Transparent_Text_Animation();                         
                        break;

                    case 10:// Random Circle and Bar Transparent
                        Random_Circle_Animation();
                        break;


                    default: // In Default there is no animation but load next image in time intervals.
                        picImageSlide.Width = pnlImg.Width;
                        picImageSlide.Height = pnlImg.Height;

                        timer1.Enabled = true;
                        timer1.Start();

                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
        //for the Image Transparent
        public static Bitmap PictuerBoxFadeIn(Image img, int opacity)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            Graphics g = Graphics.FromImage(bmp);
            ColorMatrix colmat = new ColorMatrix();
            colmat.Matrix33 = opacity;
            ImageAttributes imgAttr = new ImageAttributes();
            imgAttr.SetColorMatrix(colmat, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttr);
            g.Dispose();
            // return the new fade in Image          
            return bmp;
        }
        #endregion

      
        #endregion
    }
}

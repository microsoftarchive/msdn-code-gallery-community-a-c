namespace ShanuImageSlideShow_Cntrl
{
    partial class SHANUImageSlideShow
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHANUImageSlideShow));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlThumb = new System.Windows.Forms.Panel();
            this.pnlImg = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.picImageSlide = new System.Windows.Forms.PictureBox();
            this.pic_PlaySound = new System.Windows.Forms.PictureBox();
            this.picNext = new System.Windows.Forms.PictureBox();
            this.picPlay = new System.Windows.Forms.PictureBox();
            this.picPrevious = new System.Windows.Forms.PictureBox();
            this.picLoadImage = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.pnlImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImageSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlaySound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).BeginInit();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.Beige;
            this.pnlControls.Controls.Add(this.pic_PlaySound);
            this.pnlControls.Controls.Add(this.picNext);
            this.pnlControls.Controls.Add(this.picPlay);
            this.pnlControls.Controls.Add(this.picPrevious);
            this.pnlControls.Controls.Add(this.picLoadImage);
            this.pnlControls.Controls.Add(this.pnlThumb);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 570);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1000, 230);
            this.pnlControls.TabIndex = 132;
            // 
            // pnlThumb
            // 
            this.pnlThumb.AutoScroll = true;
            this.pnlThumb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlThumb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThumb.Location = new System.Drawing.Point(0, 0);
            this.pnlThumb.Name = "pnlThumb";
            this.pnlThumb.Size = new System.Drawing.Size(1000, 168);
            this.pnlThumb.TabIndex = 5;
            // 
            // pnlImg
            // 
            this.pnlImg.BackColor = System.Drawing.Color.White;
            this.pnlImg.Controls.Add(this.picImageSlide);
            this.pnlImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImg.Location = new System.Drawing.Point(0, 29);
            this.pnlImg.Name = "pnlImg";
            this.pnlImg.Size = new System.Drawing.Size(1000, 541);
            this.pnlImg.TabIndex = 133;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // picImageSlide
            // 
            this.picImageSlide.BackColor = System.Drawing.Color.White;
            this.picImageSlide.Location = new System.Drawing.Point(0, 0);
            this.picImageSlide.Name = "picImageSlide";
            this.picImageSlide.Size = new System.Drawing.Size(992, 536);
            this.picImageSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImageSlide.TabIndex = 3;
            this.picImageSlide.TabStop = false;
            // 
            // pic_PlaySound
            // 
            this.pic_PlaySound.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.soundOFF;
            this.pic_PlaySound.Location = new System.Drawing.Point(760, 176);
            this.pic_PlaySound.Name = "pic_PlaySound";
            this.pic_PlaySound.Size = new System.Drawing.Size(36, 36);
            this.pic_PlaySound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PlaySound.TabIndex = 18;
            this.pic_PlaySound.TabStop = false;
            this.pic_PlaySound.Click += new System.EventHandler(this.pic_PlaySound_Click);
            // 
            // picNext
            // 
            this.picNext.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.Next;
            this.picNext.Location = new System.Drawing.Point(581, 173);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(48, 50);
            this.picNext.TabIndex = 17;
            this.picNext.TabStop = false;
            this.picNext.Click += new System.EventHandler(this.picNext_Click);
            // 
            // picPlay
            // 
            this.picPlay.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.play;
            this.picPlay.Location = new System.Drawing.Point(517, 173);
            this.picPlay.Name = "picPlay";
            this.picPlay.Size = new System.Drawing.Size(48, 50);
            this.picPlay.TabIndex = 16;
            this.picPlay.TabStop = false;
            this.picPlay.Click += new System.EventHandler(this.picPlay_Click);
            // 
            // picPrevious
            // 
            this.picPrevious.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.Previous;
            this.picPrevious.Location = new System.Drawing.Point(453, 175);
            this.picPrevious.Name = "picPrevious";
            this.picPrevious.Size = new System.Drawing.Size(48, 50);
            this.picPrevious.TabIndex = 15;
            this.picPrevious.TabStop = false;
            this.picPrevious.Click += new System.EventHandler(this.picPrevious_Click);
            // 
            // picLoadImage
            // 
            this.picLoadImage.Image = global::ShanuImageSlideShow_Cntrl.Properties.Resources.folder_image;
            this.picLoadImage.Location = new System.Drawing.Point(372, 169);
            this.picLoadImage.Name = "picLoadImage";
            this.picLoadImage.Size = new System.Drawing.Size(60, 60);
            this.picLoadImage.TabIndex = 14;
            this.picLoadImage.TabStop = false;
            this.picLoadImage.Click += new System.EventHandler(this.picLoadImage_Click);
            // 
            // Panel4
            // 
            this.Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel4.BackgroundImage")));
            this.Panel4.Controls.Add(this.Label1);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1000, 29);
            this.Panel4.TabIndex = 131;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Yellow;
            this.Label1.Location = new System.Drawing.Point(360, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(277, 24);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "SHANU Image Slider Control";
            // 
            // SHANUImageSlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlImg);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.Panel4);
            this.Name = "SHANUImageSlideShow";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.SHANUImageSlideShow_Load);
            this.pnlControls.ResumeLayout(false);
            this.pnlImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImageSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlaySound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadImage)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.PictureBox picNext;
        private System.Windows.Forms.PictureBox picPlay;
        private System.Windows.Forms.PictureBox picPrevious;
        private System.Windows.Forms.PictureBox picLoadImage;
        private System.Windows.Forms.Panel pnlThumb;
        private System.Windows.Forms.Panel pnlImg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox picImageSlide;
        private System.Windows.Forms.PictureBox pic_PlaySound;
    }
}

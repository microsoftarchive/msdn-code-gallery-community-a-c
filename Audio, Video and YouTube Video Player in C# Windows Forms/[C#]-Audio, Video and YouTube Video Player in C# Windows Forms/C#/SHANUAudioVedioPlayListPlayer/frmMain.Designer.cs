namespace SHANUAudioVedioPlayListPlayer
{
    partial class frmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAudioPlayer = new System.Windows.Forms.PictureBox();
            this.btnYouTubePlayer = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAudioPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYouTubePlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.btnYouTubePlayer);
            this.panel1.Controls.Add(this.btnAudioPlayer);
            this.panel1.Controls.Add(this.Panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 104);
            this.panel1.TabIndex = 2;
            // 
            // Panel4
            // 
            this.Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel4.BackgroundImage")));
            this.Panel4.Controls.Add(this.Label1);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1020, 29);
            this.Panel4.TabIndex = 132;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Yellow;
            this.Label1.Location = new System.Drawing.Point(296, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(412, 24);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "SHANU Audio / Video and YouTube Player";
            // 
            // btnAudioPlayer
            // 
            this.btnAudioPlayer.Image = global::SHANUAudioVedioPlayListPlayer.Properties.Resources.Windows_Media_Player_10;
            this.btnAudioPlayer.Location = new System.Drawing.Point(432, 32);
            this.btnAudioPlayer.Name = "btnAudioPlayer";
            this.btnAudioPlayer.Size = new System.Drawing.Size(64, 64);
            this.btnAudioPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAudioPlayer.TabIndex = 133;
            this.btnAudioPlayer.TabStop = false;
            this.btnAudioPlayer.Click += new System.EventHandler(this.btnfirst_Click);
            // 
            // btnYouTubePlayer
            // 
            this.btnYouTubePlayer.Image = global::SHANUAudioVedioPlayListPlayer.Properties.Resources.youtube64;
            this.btnYouTubePlayer.Location = new System.Drawing.Point(512, 32);
            this.btnYouTubePlayer.Name = "btnYouTubePlayer";
            this.btnYouTubePlayer.Size = new System.Drawing.Size(64, 64);
            this.btnYouTubePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnYouTubePlayer.TabIndex = 134;
            this.btnYouTubePlayer.TabStop = false;
            this.btnYouTubePlayer.Click += new System.EventHandler(this.btnYouTubePlayer_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 104);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1020, 458);
            this.pnlMain.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1020, 562);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "S H A N U - Audio/video and YouTube Player";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAudioPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYouTubePlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.PictureBox btnYouTubePlayer;
        private System.Windows.Forms.PictureBox btnAudioPlayer;
        private System.Windows.Forms.Panel pnlMain;
    }
}


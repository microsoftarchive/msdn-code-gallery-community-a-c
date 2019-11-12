namespace SHANUAudioVedioPlayListPlayer.PlayerControls
{
    partial class YouTubeCntl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YouTubeCntl));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShockwaveFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUtube = new System.Windows.Forms.TextBox();
            this.btnYoutube = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShockwaveFlash)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnYoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ShockwaveFlash);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 520);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 4;
            // 
            // ShockwaveFlash
            // 
            this.ShockwaveFlash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShockwaveFlash.Enabled = true;
            this.ShockwaveFlash.Location = new System.Drawing.Point(0, 0);
            this.ShockwaveFlash.Name = "ShockwaveFlash";
            this.ShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ShockwaveFlash.OcxState")));
            this.ShockwaveFlash.Size = new System.Drawing.Size(800, 520);
            this.ShockwaveFlash.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUtube);
            this.groupBox1.Controls.Add(this.btnYoutube);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 74);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YouTube Vedio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(744, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Enter your Youtube Vedio Link * -> delete \"watch?\" before the \"v\" and after \"v\" r" +
    "eplace the \"=\" with  \"/\" from your youtube URL.";
            // 
            // txtUtube
            // 
            this.txtUtube.Location = new System.Drawing.Point(9, 20);
            this.txtUtube.Multiline = true;
            this.txtUtube.Name = "txtUtube";
            this.txtUtube.Size = new System.Drawing.Size(720, 29);
            this.txtUtube.TabIndex = 13;
            this.txtUtube.Text = "https://www.youtube.com/v/Ce_Ne5P02q0";
            // 
            // btnYoutube
            // 
            this.btnYoutube.Image = global::SHANUAudioVedioPlayListPlayer.Properties.Resources.youtube_32;
            this.btnYoutube.Location = new System.Drawing.Point(736, 19);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(34, 34);
            this.btnYoutube.TabIndex = 12;
            this.btnYoutube.TabStop = false;
            this.btnYoutube.Click += new System.EventHandler(this.btnYoutube_Click);
            // 
            // YouTubeCntl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "YouTubeCntl";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShockwaveFlash)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnYoutube)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private AxShockwaveFlashObjects.AxShockwaveFlash ShockwaveFlash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUtube;
        private System.Windows.Forms.PictureBox btnYoutube;
    }
}

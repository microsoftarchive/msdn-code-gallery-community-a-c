namespace 图片查看器
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picBoxView = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClockwiseRotate = new System.Windows.Forms.Button();
            this.btncounterclockwiseRotate = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxView)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxView
            // 
            this.picBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxView.Location = new System.Drawing.Point(-1, 0);
            this.picBoxView.Name = "picBoxView";
            this.picBoxView.Size = new System.Drawing.Size(684, 262);
            this.picBoxView.TabIndex = 0;
            this.picBoxView.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(25, 269);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "打开图片";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClockwiseRotate
            // 
            this.btnClockwiseRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClockwiseRotate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClockwiseRotate.BackgroundImage")));
            this.btnClockwiseRotate.Location = new System.Drawing.Point(300, 268);
            this.btnClockwiseRotate.Name = "btnClockwiseRotate";
            this.btnClockwiseRotate.Size = new System.Drawing.Size(26, 23);
            this.btnClockwiseRotate.TabIndex = 6;
            this.btnClockwiseRotate.UseVisualStyleBackColor = true;
            this.btnClockwiseRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btncounterclockwiseRotate
            // 
            this.btncounterclockwiseRotate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncounterclockwiseRotate.BackgroundImage")));
            this.btncounterclockwiseRotate.Location = new System.Drawing.Point(332, 268);
            this.btncounterclockwiseRotate.Name = "btncounterclockwiseRotate";
            this.btncounterclockwiseRotate.Size = new System.Drawing.Size(25, 23);
            this.btncounterclockwiseRotate.TabIndex = 7;
            this.btncounterclockwiseRotate.UseVisualStyleBackColor = true;
            this.btncounterclockwiseRotate.Click += new System.EventHandler(this.btncounterclockwiseRotate_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Location = new System.Drawing.Point(191, 267);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(50, 23);
            this.btnPre.TabIndex = 8;
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(247, 267);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(47, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 299);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btncounterclockwiseRotate);
            this.Controls.Add(this.btnClockwiseRotate);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.picBoxView);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxView;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClockwiseRotate;
        private System.Windows.Forms.Button btncounterclockwiseRotate;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
    }
}


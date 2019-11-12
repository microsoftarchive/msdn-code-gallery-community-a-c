namespace SHANUImageSlideShow_Demo
{
    partial class frmShanuSlideShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShanuSlideShow));
            this.shanuImageSlideShow = new ShanuImageSlideShow_Cntrl.SHANUImageSlideShow();
            this.SuspendLayout();
            // 
            // shanuImageSlideShow
            // 
            this.shanuImageSlideShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shanuImageSlideShow.Location = new System.Drawing.Point(0, 0);
            this.shanuImageSlideShow.Name = "shanuImageSlideShow";
            this.shanuImageSlideShow.Size = new System.Drawing.Size(992, 816);
            this.shanuImageSlideShow.TabIndex = 0;
            // 
            // frmShanuSlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(992, 816);
            this.Controls.Add(this.shanuImageSlideShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShanuSlideShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SHANU Animated Image Slide Show";
            this.Load += new System.EventHandler(this.frmShanuSlideShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ShanuImageSlideShow_Cntrl.SHANUImageSlideShow shanuImageSlideShow;




    }
}


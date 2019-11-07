namespace ImageToIcon
{
    partial class ImageToIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnSaveAsIcon = new System.Windows.Forms.Button();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImagePath
            // 
            this.txtImagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagePath.Location = new System.Drawing.Point(2, 2);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(165, 26);
            this.txtImagePath.TabIndex = 0;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(173, 2);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(84, 26);
            this.btnOpenImage.TabIndex = 1;
            this.btnOpenImage.Text = "Open Image";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(2, 35);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(255, 255);
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // btnSaveAsIcon
            // 
            this.btnSaveAsIcon.Location = new System.Drawing.Point(2, 297);
            this.btnSaveAsIcon.Name = "btnSaveAsIcon";
            this.btnSaveAsIcon.Size = new System.Drawing.Size(255, 29);
            this.btnSaveAsIcon.TabIndex = 3;
            this.btnSaveAsIcon.Text = "Save as Icon";
            this.btnSaveAsIcon.UseVisualStyleBackColor = true;
            this.btnSaveAsIcon.Click += new System.EventHandler(this.btnSaveAsIcon_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG";
            // 
            // sfdPicture
            // 
            this.sfdPicture.DefaultExt = "ico";
            this.sfdPicture.FileName = "Icon";
            this.sfdPicture.Filter = "Icon File (*.ico)|*.ico";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 328);
            this.Controls.Add(this.btnSaveAsIcon);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.txtImagePath);
            this.Name = "Form1";
            this.Text = "ImageToIconSample";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSaveAsIcon;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
    }
}


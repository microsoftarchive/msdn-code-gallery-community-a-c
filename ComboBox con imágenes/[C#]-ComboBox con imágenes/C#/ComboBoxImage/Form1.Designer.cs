namespace ComboBoxImage
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picImage = new System.Windows.Forms.PictureBox();
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.cmbImages = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(55, 36);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(125, 125);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "minion1.png");
            this.listImages.Images.SetKeyName(1, "minion2.png");
            this.listImages.Images.SetKeyName(2, "minion3.png");
            this.listImages.Images.SetKeyName(3, "minion4.png");
            this.listImages.Images.SetKeyName(4, "minion5.png");
            this.listImages.Images.SetKeyName(5, "minion6.png");
            this.listImages.Images.SetKeyName(6, "minion7.png");
            this.listImages.Images.SetKeyName(7, "minion8.png");
            // 
            // cmbImages
            // 
            this.cmbImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Location = new System.Drawing.Point(211, 36);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(318, 41);
            this.cmbImages.TabIndex = 1;
            this.cmbImages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbImages_DrawItem);
            this.cmbImages.SelectedIndexChanged += new System.EventHandler(this.cmbImages_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 411);
            this.Controls.Add(this.cmbImages);
            this.Controls.Add(this.picImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ImageList listImages;
        private System.Windows.Forms.ComboBox cmbImages;
    }
}


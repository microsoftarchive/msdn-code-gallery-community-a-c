namespace AutodiscoverChecker
{
    partial class DisplayText
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
            this.BodyText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BodyText
            // 
            this.BodyText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyText.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BodyText.Location = new System.Drawing.Point(0, 0);
            this.BodyText.Name = "BodyText";
            this.BodyText.Size = new System.Drawing.Size(829, 405);
            this.BodyText.TabIndex = 78;
            this.BodyText.Text = "";
            this.BodyText.TextChanged += new System.EventHandler(this.BodyText_TextChanged);
            // 
            // DisplayText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 405);
            this.Controls.Add(this.BodyText);
            this.Name = "DisplayText";
            this.Text = "Information";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox BodyText;

    }
}
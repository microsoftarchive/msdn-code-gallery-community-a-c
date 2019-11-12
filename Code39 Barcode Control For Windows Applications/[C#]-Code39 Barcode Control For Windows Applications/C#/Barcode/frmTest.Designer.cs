namespace Barcode
{
    partial class frmTest
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
            this.components = new System.ComponentModel.Container();
            this.code39Control1 = new Barcode.Code39Control();
            this.txtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // code39Control1
            // 
            this.code39Control1.BackColor = System.Drawing.Color.White;
            this.code39Control1.Location = new System.Drawing.Point(44, 22);
            this.code39Control1.Name = "code39Control1";
            this.code39Control1.Size = new System.Drawing.Size(362, 187);
            this.code39Control1.TabIndex = 0;
            this.code39Control1.Text = "TAMER";
            this.code39Control1.WideNarrowRatio = 2;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(44, 217);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(362, 20);
            this.txtText.TabIndex = 2;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 449);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.code39Control1);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Code39Control code39Control1;
        private System.Windows.Forms.TextBox txtText;


    }
}


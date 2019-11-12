namespace BitmapFilters
{
    partial class MainForm
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
            this.grbInput = new System.Windows.Forms.GroupBox();
            this.picSource = new System.Windows.Forms.Panel();
            this.grbOutput = new System.Windows.Forms.GroupBox();
            this.picOutput = new System.Windows.Forms.Panel();
            this.btnLoadSource = new System.Windows.Forms.Button();
            this.rdGrayscaleBits = new System.Windows.Forms.RadioButton();
            this.rdTransparencyBits = new System.Windows.Forms.RadioButton();
            this.rdSepiaBits = new System.Windows.Forms.RadioButton();
            this.rdNegativeBits = new System.Windows.Forms.RadioButton();
            this.rdGrayscaleDraw = new System.Windows.Forms.RadioButton();
            this.rdSepiaDraw = new System.Windows.Forms.RadioButton();
            this.rdTransparencyDraw = new System.Windows.Forms.RadioButton();
            this.rdNegativeDraw = new System.Windows.Forms.RadioButton();
            this.grbInput.SuspendLayout();
            this.grbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbInput
            // 
            this.grbInput.Controls.Add(this.picSource);
            this.grbInput.Location = new System.Drawing.Point(12, 12);
            this.grbInput.Name = "grbInput";
            this.grbInput.Size = new System.Drawing.Size(272, 280);
            this.grbInput.TabIndex = 0;
            this.grbInput.TabStop = false;
            this.grbInput.Text = "Input Source";
            // 
            // picSource
            // 
            this.picSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSource.Location = new System.Drawing.Point(11, 19);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(250, 250);
            this.picSource.TabIndex = 0;
            // 
            // grbOutput
            // 
            this.grbOutput.Controls.Add(this.picOutput);
            this.grbOutput.Location = new System.Drawing.Point(301, 12);
            this.grbOutput.Name = "grbOutput";
            this.grbOutput.Size = new System.Drawing.Size(272, 280);
            this.grbOutput.TabIndex = 1;
            this.grbOutput.TabStop = false;
            this.grbOutput.Text = "Filtered Output";
            // 
            // picOutput
            // 
            this.picOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOutput.Location = new System.Drawing.Point(11, 19);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(250, 250);
            this.picOutput.TabIndex = 0;
            // 
            // btnLoadSource
            // 
            this.btnLoadSource.Location = new System.Drawing.Point(12, 298);
            this.btnLoadSource.Name = "btnLoadSource";
            this.btnLoadSource.Size = new System.Drawing.Size(110, 23);
            this.btnLoadSource.TabIndex = 2;
            this.btnLoadSource.Text = "Load Source";
            this.btnLoadSource.UseVisualStyleBackColor = true;
            this.btnLoadSource.Click += new System.EventHandler(this.btnLoadSource_Click);
            // 
            // rdGrayscaleBits
            // 
            this.rdGrayscaleBits.AutoSize = true;
            this.rdGrayscaleBits.Checked = true;
            this.rdGrayscaleBits.Location = new System.Drawing.Point(223, 301);
            this.rdGrayscaleBits.Name = "rdGrayscaleBits";
            this.rdGrayscaleBits.Size = new System.Drawing.Size(98, 17);
            this.rdGrayscaleBits.TabIndex = 3;
            this.rdGrayscaleBits.Text = "Grayscale - Bits";
            this.rdGrayscaleBits.UseVisualStyleBackColor = true;
            this.rdGrayscaleBits.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdTransparencyBits
            // 
            this.rdTransparencyBits.AutoSize = true;
            this.rdTransparencyBits.Location = new System.Drawing.Point(353, 347);
            this.rdTransparencyBits.Name = "rdTransparencyBits";
            this.rdTransparencyBits.Size = new System.Drawing.Size(116, 17);
            this.rdTransparencyBits.TabIndex = 4;
            this.rdTransparencyBits.Text = "Transparency - Bits";
            this.rdTransparencyBits.UseVisualStyleBackColor = true;
            this.rdTransparencyBits.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdSepiaBits
            // 
            this.rdSepiaBits.AutoSize = true;
            this.rdSepiaBits.Location = new System.Drawing.Point(467, 301);
            this.rdSepiaBits.Name = "rdSepiaBits";
            this.rdSepiaBits.Size = new System.Drawing.Size(106, 17);
            this.rdSepiaBits.TabIndex = 6;
            this.rdSepiaBits.Text = "Sepia Tone - Bits";
            this.rdSepiaBits.UseVisualStyleBackColor = true;
            this.rdSepiaBits.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdNegativeBits
            // 
            this.rdNegativeBits.AutoSize = true;
            this.rdNegativeBits.Location = new System.Drawing.Point(353, 301);
            this.rdNegativeBits.Name = "rdNegativeBits";
            this.rdNegativeBits.Size = new System.Drawing.Size(94, 17);
            this.rdNegativeBits.TabIndex = 5;
            this.rdNegativeBits.Text = "Negative - Bits";
            this.rdNegativeBits.UseVisualStyleBackColor = true;
            this.rdNegativeBits.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdGrayscaleDraw
            // 
            this.rdGrayscaleDraw.AutoSize = true;
            this.rdGrayscaleDraw.Location = new System.Drawing.Point(223, 324);
            this.rdGrayscaleDraw.Name = "rdGrayscaleDraw";
            this.rdGrayscaleDraw.Size = new System.Drawing.Size(106, 17);
            this.rdGrayscaleDraw.TabIndex = 7;
            this.rdGrayscaleDraw.Text = "Grayscale - Draw";
            this.rdGrayscaleDraw.UseVisualStyleBackColor = true;
            this.rdGrayscaleDraw.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdSepiaDraw
            // 
            this.rdSepiaDraw.AutoSize = true;
            this.rdSepiaDraw.Location = new System.Drawing.Point(467, 324);
            this.rdSepiaDraw.Name = "rdSepiaDraw";
            this.rdSepiaDraw.Size = new System.Drawing.Size(114, 17);
            this.rdSepiaDraw.TabIndex = 8;
            this.rdSepiaDraw.Text = "Sepia Tone - Draw";
            this.rdSepiaDraw.UseVisualStyleBackColor = true;
            this.rdSepiaDraw.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdTransparencyDraw
            // 
            this.rdTransparencyDraw.AutoSize = true;
            this.rdTransparencyDraw.Location = new System.Drawing.Point(223, 347);
            this.rdTransparencyDraw.Name = "rdTransparencyDraw";
            this.rdTransparencyDraw.Size = new System.Drawing.Size(124, 17);
            this.rdTransparencyDraw.TabIndex = 9;
            this.rdTransparencyDraw.Text = "Transparency - Draw";
            this.rdTransparencyDraw.UseVisualStyleBackColor = true;
            this.rdTransparencyDraw.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // rdNegativeDraw
            // 
            this.rdNegativeDraw.AutoSize = true;
            this.rdNegativeDraw.Location = new System.Drawing.Point(353, 324);
            this.rdNegativeDraw.Name = "rdNegativeDraw";
            this.rdNegativeDraw.Size = new System.Drawing.Size(102, 17);
            this.rdNegativeDraw.TabIndex = 10;
            this.rdNegativeDraw.Text = "Negative - Draw";
            this.rdNegativeDraw.UseVisualStyleBackColor = true;
            this.rdNegativeDraw.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 371);
            this.Controls.Add(this.rdNegativeDraw);
            this.Controls.Add(this.rdTransparencyDraw);
            this.Controls.Add(this.rdSepiaDraw);
            this.Controls.Add(this.rdGrayscaleDraw);
            this.Controls.Add(this.rdSepiaBits);
            this.Controls.Add(this.rdNegativeBits);
            this.Controls.Add(this.rdTransparencyBits);
            this.Controls.Add(this.rdGrayscaleBits);
            this.Controls.Add(this.btnLoadSource);
            this.Controls.Add(this.grbOutput);
            this.Controls.Add(this.grbInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitmap Filters";
            this.grbInput.ResumeLayout(false);
            this.grbOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbInput;
        private System.Windows.Forms.Panel picSource;
        private System.Windows.Forms.GroupBox grbOutput;
        private System.Windows.Forms.Panel picOutput;
        private System.Windows.Forms.Button btnLoadSource;
        private System.Windows.Forms.RadioButton rdGrayscaleBits;
        private System.Windows.Forms.RadioButton rdTransparencyBits;
        private System.Windows.Forms.RadioButton rdSepiaBits;
        private System.Windows.Forms.RadioButton rdNegativeBits;
        private System.Windows.Forms.RadioButton rdGrayscaleDraw;
        private System.Windows.Forms.RadioButton rdSepiaDraw;
        private System.Windows.Forms.RadioButton rdTransparencyDraw;
        private System.Windows.Forms.RadioButton rdNegativeDraw;
    }
}


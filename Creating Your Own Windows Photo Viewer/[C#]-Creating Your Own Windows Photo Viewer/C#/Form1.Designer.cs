namespace Picture_Labs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TTS = new System.Windows.Forms.ToolStrip();
            this.cIO = new System.Windows.Forms.ToolStripLabel();
            this.cOpen = new System.Windows.Forms.ToolStripButton();
            this.cSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cScale = new System.Windows.Forms.ToolStripLabel();
            this.cbScale = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cRT = new System.Windows.Forms.ToolStripLabel();
            this.cbRotateFlip = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cMask = new System.Windows.Forms.ToolStripLabel();
            this.cbMask = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cFillter = new System.Windows.Forms.ToolStripLabel();
            this.cbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.TTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // TTS
            // 
            this.TTS.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTS.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cIO,
            this.cOpen,
            this.cSave,
            this.toolStripSeparator1,
            this.cScale,
            this.cbScale,
            this.toolStripSeparator2,
            this.cRT,
            this.cbRotateFlip,
            this.toolStripSeparator3,
            this.cMask,
            this.cbMask,
            this.toolStripSeparator4,
            this.cFillter,
            this.cbFilter});
            this.TTS.Location = new System.Drawing.Point(0, 0);
            this.TTS.Name = "TTS";
            this.TTS.Size = new System.Drawing.Size(883, 31);
            this.TTS.TabIndex = 0;
            this.TTS.Text = "Standard Toolbar";
            // 
            // cIO
            // 
            this.cIO.Name = "cIO";
            this.cIO.Size = new System.Drawing.Size(28, 28);
            this.cIO.Text = "I/O";
            // 
            // cOpen
            // 
            this.cOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cOpen.Image = ((System.Drawing.Image)(resources.GetObject("cOpen.Image")));
            this.cOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cOpen.Name = "cOpen";
            this.cOpen.Size = new System.Drawing.Size(28, 28);
            this.cOpen.Text = "Open";
            this.cOpen.ToolTipText = "Open Picture File";
            this.cOpen.Click += new System.EventHandler(this.cOpen_Click);
            // 
            // cSave
            // 
            this.cSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cSave.Image = ((System.Drawing.Image)(resources.GetObject("cSave.Image")));
            this.cSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cSave.Name = "cSave";
            this.cSave.Size = new System.Drawing.Size(28, 28);
            this.cSave.Text = "Save";
            this.cSave.ToolTipText = "Save Picture";
            this.cSave.Click += new System.EventHandler(this.cSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // cScale
            // 
            this.cScale.Name = "cScale";
            this.cScale.Size = new System.Drawing.Size(40, 28);
            this.cScale.Text = "Scale";
            // 
            // cbScale
            // 
            this.cbScale.Items.AddRange(new object[] {
            "- Select Scale -",
            "50%",
            "100%",
            "150%",
            "200%",
            "250%",
            "300%",
            "350%",
            "400%"});
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(121, 31);
            this.cbScale.Text = "- Select Scale -";
            this.cbScale.TextChanged += new System.EventHandler(this.cbScale_Change);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // cRT
            // 
            this.cRT.Name = "cRT";
            this.cRT.Size = new System.Drawing.Size(88, 28);
            this.cRT.Text = "Rotate && Flip";
            // 
            // cbRotateFlip
            // 
            this.cbRotateFlip.Items.AddRange(new object[] {
            "- Select -",
            "Rotate 90",
            "Rotate 180",
            "Rotate 270",
            "Flip Horizontal",
            "Flip Vertical"});
            this.cbRotateFlip.Name = "cbRotateFlip";
            this.cbRotateFlip.Size = new System.Drawing.Size(121, 31);
            this.cbRotateFlip.Text = "- Select -";
            this.cbRotateFlip.ToolTipText = "Select Rotate And Flip Methode";
            this.cbRotateFlip.TextChanged += new System.EventHandler(this.cbRotateFlip_Change);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // cMask
            // 
            this.cMask.Name = "cMask";
            this.cMask.Size = new System.Drawing.Size(41, 28);
            this.cMask.Text = "Mask";
            // 
            // cbMask
            // 
            this.cbMask.Items.AddRange(new object[] {
            "- Select -",
            "Red",
            "Green",
            "Blue"});
            this.cbMask.Name = "cbMask";
            this.cbMask.Size = new System.Drawing.Size(121, 31);
            this.cbMask.Text = "- Select -";
            this.cbMask.ToolTipText = "Select Masking";
            this.cbMask.TextChanged += new System.EventHandler(this.cbMask_Change);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // cFillter
            // 
            this.cFillter.Name = "cFillter";
            this.cFillter.Size = new System.Drawing.Size(38, 28);
            this.cFillter.Text = "Filter";
            // 
            // cbFilter
            // 
            this.cbFilter.Items.AddRange(new object[] {
            "- Select -",
            "Invert",
            "Grayscake",
            "Gamma",
            "Contrast",
            "Brightness"});
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 31);
            this.cbFilter.Text = "- Select -";
            this.cbFilter.ToolTipText = "Select Filter Methode";
            this.cbFilter.TextChanged += new System.EventHandler(this.cbFilter_Change);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(883, 413);
            this.Controls.Add(this.TTS);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Picture Labs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.TTS.ResumeLayout(false);
            this.TTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TTS;
        private System.Windows.Forms.ToolStripButton cOpen;
        private System.Windows.Forms.ToolStripButton cSave;
        private System.Windows.Forms.ToolStripLabel cIO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel cScale;
        private System.Windows.Forms.ToolStripComboBox cbScale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel cRT;
        private System.Windows.Forms.ToolStripComboBox cbRotateFlip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel cMask;
        private System.Windows.Forms.ToolStripComboBox cbMask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel cFillter;
        private System.Windows.Forms.ToolStripComboBox cbFilter;
    }
}


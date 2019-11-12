namespace AutodiscoverChecker
{
    partial class AutodiscoverCheckerMain
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
            this.btnManagedApiChecker = new System.Windows.Forms.Button();
            this.btnRawCodeChecker = new System.Windows.Forms.Button();
            this.btnRawScpChecker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagedApiChecker
            // 
            this.btnManagedApiChecker.Location = new System.Drawing.Point(71, 57);
            this.btnManagedApiChecker.Name = "btnManagedApiChecker";
            this.btnManagedApiChecker.Size = new System.Drawing.Size(263, 23);
            this.btnManagedApiChecker.TabIndex = 0;
            this.btnManagedApiChecker.Text = "Exchange Managed API Checker";
            this.btnManagedApiChecker.UseVisualStyleBackColor = true;
            this.btnManagedApiChecker.Click += new System.EventHandler(this.btnManagedApiChecker_Click);
            // 
            // btnRawCodeChecker
            // 
            this.btnRawCodeChecker.Location = new System.Drawing.Point(71, 117);
            this.btnRawCodeChecker.Name = "btnRawCodeChecker";
            this.btnRawCodeChecker.Size = new System.Drawing.Size(263, 23);
            this.btnRawCodeChecker.TabIndex = 1;
            this.btnRawCodeChecker.Text = "Raw Code Checker";
            this.btnRawCodeChecker.UseVisualStyleBackColor = true;
            this.btnRawCodeChecker.Click += new System.EventHandler(this.btnRawCodeChecker_Click);
            // 
            // btnRawScpChecker
            // 
            this.btnRawScpChecker.Location = new System.Drawing.Point(71, 175);
            this.btnRawScpChecker.Name = "btnRawScpChecker";
            this.btnRawScpChecker.Size = new System.Drawing.Size(263, 23);
            this.btnRawScpChecker.TabIndex = 2;
            this.btnRawScpChecker.Text = "SCP Checker";
            this.btnRawScpChecker.UseVisualStyleBackColor = true;
            this.btnRawScpChecker.Click += new System.EventHandler(this.btnRawScpChecker_Click);
            // 
            // AutodiscoverCheckerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(398, 262);
            this.Controls.Add(this.btnRawScpChecker);
            this.Controls.Add(this.btnRawCodeChecker);
            this.Controls.Add(this.btnManagedApiChecker);
            this.Name = "AutodiscoverCheckerMain";
            this.Text = "Autodiscover Checker";
            this.Load += new System.EventHandler(this.AutodiscoverChecker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagedApiChecker;
        private System.Windows.Forms.Button btnRawCodeChecker;
        private System.Windows.Forms.Button btnRawScpChecker;
    }
}
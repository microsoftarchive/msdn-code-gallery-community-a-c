namespace Conways_Game_of_Life_cs
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
            this.Button1 = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.exDGV1 = new Conways_Game_of_Life_cs.exDGV();
            ((System.ComponentModel.ISupportInitialize)(this.exDGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(441, 466);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Go";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "None",
            "Diamond",
            "Square",
            "Cross"});
            this.ComboBox1.Location = new System.Drawing.Point(12, 14);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(504, 21);
            this.ComboBox1.TabIndex = 3;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_1);
            // 
            // exDGV1
            // 
            this.exDGV1.AllowUserToAddRows = false;
            this.exDGV1.AllowUserToDeleteRows = false;
            this.exDGV1.AllowUserToResizeColumns = false;
            this.exDGV1.AllowUserToResizeRows = false;
            this.exDGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDGV1.ColumnHeadersVisible = false;
            this.exDGV1.Location = new System.Drawing.Point(12, 45);
            this.exDGV1.Name = "exDGV1";
            this.exDGV1.RowHeadersVisible = false;
            this.exDGV1.Size = new System.Drawing.Size(503, 403);
            this.exDGV1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 502);
            this.Controls.Add(this.exDGV1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ComboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conway\'s Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.exDGV1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        private exDGV exDGV1;
    }
}


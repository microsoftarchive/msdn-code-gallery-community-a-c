namespace WindowsFormsApplication1
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdAddRows = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(444, 152);
            this.DataGridView1.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdView);
            this.Panel1.Controls.Add(this.cmdAddRows);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 152);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(444, 67);
            this.Panel1.TabIndex = 1;
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(107, 18);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(78, 37);
            this.cmdView.TabIndex = 1;
            this.cmdView.Text = "Peek";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdAddRows
            // 
            this.cmdAddRows.Location = new System.Drawing.Point(23, 18);
            this.cmdAddRows.Name = "cmdAddRows";
            this.cmdAddRows.Size = new System.Drawing.Size(78, 37);
            this.cmdAddRows.TabIndex = 0;
            this.cmdAddRows.Text = "Demo";
            this.cmdAddRows.UseVisualStyleBackColor = true;
            this.cmdAddRows.Click += new System.EventHandler(this.cmdAddRows_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 219);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdView;
        internal System.Windows.Forms.Button cmdAddRows;
    }
}


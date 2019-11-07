namespace Example1
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
            this.cmdSimpleOpenToSheet = new System.Windows.Forms.Button();
            this.cmdGetSheets = new System.Windows.Forms.Button();
            this.lstSheetNames = new System.Windows.Forms.ListBox();
            this.cmdCollectCellData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSimpleOpenToSheet
            // 
            this.cmdSimpleOpenToSheet.Location = new System.Drawing.Point(12, 33);
            this.cmdSimpleOpenToSheet.Name = "cmdSimpleOpenToSheet";
            this.cmdSimpleOpenToSheet.Size = new System.Drawing.Size(104, 37);
            this.cmdSimpleOpenToSheet.TabIndex = 0;
            this.cmdSimpleOpenToSheet.Text = "Open 1";
            this.cmdSimpleOpenToSheet.UseVisualStyleBackColor = true;
            this.cmdSimpleOpenToSheet.Click += new System.EventHandler(this.cmdSimpleOpenToSheet_Click);
            // 
            // cmdGetSheets
            // 
            this.cmdGetSheets.Location = new System.Drawing.Point(42, 21);
            this.cmdGetSheets.Name = "cmdGetSheets";
            this.cmdGetSheets.Size = new System.Drawing.Size(104, 37);
            this.cmdGetSheets.TabIndex = 1;
            this.cmdGetSheets.Text = "Sheets";
            this.cmdGetSheets.UseVisualStyleBackColor = true;
            this.cmdGetSheets.Click += new System.EventHandler(this.cmdGetSheets_Click);
            // 
            // lstSheetNames
            // 
            this.lstSheetNames.FormattingEnabled = true;
            this.lstSheetNames.ItemHeight = 16;
            this.lstSheetNames.Location = new System.Drawing.Point(41, 64);
            this.lstSheetNames.Name = "lstSheetNames";
            this.lstSheetNames.Size = new System.Drawing.Size(120, 84);
            this.lstSheetNames.TabIndex = 2;
            // 
            // cmdCollectCellData
            // 
            this.cmdCollectCellData.Location = new System.Drawing.Point(153, 33);
            this.cmdCollectCellData.Name = "cmdCollectCellData";
            this.cmdCollectCellData.Size = new System.Drawing.Size(104, 37);
            this.cmdCollectCellData.TabIndex = 3;
            this.cmdCollectCellData.Text = "Collect";
            this.cmdCollectCellData.UseVisualStyleBackColor = true;
            this.cmdCollectCellData.Click += new System.EventHandler(this.cmdCollectCellData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstSheetNames);
            this.groupBox1.Controls.Add(this.cmdGetSheets);
            this.groupBox1.Location = new System.Drawing.Point(299, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 176);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 192);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCollectCellData);
            this.Controls.Add(this.cmdSimpleOpenToSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo 1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSimpleOpenToSheet;
        private System.Windows.Forms.Button cmdGetSheets;
        private System.Windows.Forms.ListBox lstSheetNames;
        private System.Windows.Forms.Button cmdCollectCellData;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


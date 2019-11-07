namespace CheckOneRow_C
{
    partial class frmMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerNightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomColumn,
            this.RoomTypeColumn,
            this.PricePerNightColumn,
            this.AvailableColumn});
            this.DataGridView1.Location = new System.Drawing.Point(13, 23);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(615, 127);
            this.DataGridView1.TabIndex = 1;
            // 
            // RoomColumn
            // 
            this.RoomColumn.DataPropertyName = "Room";
            this.RoomColumn.HeaderText = "Room";
            this.RoomColumn.Name = "RoomColumn";
            // 
            // RoomTypeColumn
            // 
            this.RoomTypeColumn.DataPropertyName = "RoomType";
            this.RoomTypeColumn.HeaderText = "Room Type";
            this.RoomTypeColumn.Name = "RoomTypeColumn";
            this.RoomTypeColumn.Width = 200;
            // 
            // PricePerNightColumn
            // 
            this.PricePerNightColumn.DataPropertyName = "Rate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.PricePerNightColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.PricePerNightColumn.HeaderText = "Price Per Night";
            this.PricePerNightColumn.Name = "PricePerNightColumn";
            this.PricePerNightColumn.Width = 150;
            // 
            // AvailableColumn
            // 
            this.AvailableColumn.DataPropertyName = "Available";
            this.AvailableColumn.HeaderText = "Available";
            this.AvailableColumn.Name = "AvailableColumn";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(527, 174);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 28);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 224);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.DataGridView1);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Only one row example";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RoomColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RoomTypeColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PricePerNightColumn;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn AvailableColumn;
        internal System.Windows.Forms.Button cmdClose;
    }
}


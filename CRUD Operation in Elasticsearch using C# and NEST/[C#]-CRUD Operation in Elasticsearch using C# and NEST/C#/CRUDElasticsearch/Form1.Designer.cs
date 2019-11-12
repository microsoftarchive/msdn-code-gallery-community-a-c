namespace CRUDElasticsearch
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
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxVoiceActor = new System.Windows.Forms.TextBox();
            this.tbxDebut = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblVoiceActor = new System.Windows.Forms.Label();
            this.lblDebut = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIndex = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvwDisneyCharacter = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGetAllData = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(237, 18);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(190, 20);
            this.tbxID.TabIndex = 0;
            this.tbxID.TextChanged += new System.EventHandler(this.tbxID_TextChanged);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(237, 50);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(190, 20);
            this.tbxName.TabIndex = 1;
            // 
            // tbxVoiceActor
            // 
            this.tbxVoiceActor.Location = new System.Drawing.Point(237, 78);
            this.tbxVoiceActor.Name = "tbxVoiceActor";
            this.tbxVoiceActor.Size = new System.Drawing.Size(190, 20);
            this.tbxVoiceActor.TabIndex = 2;
            // 
            // tbxDebut
            // 
            this.tbxDebut.Location = new System.Drawing.Point(237, 108);
            this.tbxDebut.Name = "tbxDebut";
            this.tbxDebut.Size = new System.Drawing.Size(190, 20);
            this.tbxDebut.TabIndex = 3;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(199, 21);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(182, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblVoiceActor
            // 
            this.lblVoiceActor.AutoSize = true;
            this.lblVoiceActor.Location = new System.Drawing.Point(117, 78);
            this.lblVoiceActor.Name = "lblVoiceActor";
            this.lblVoiceActor.Size = new System.Drawing.Size(103, 13);
            this.lblVoiceActor.TabIndex = 6;
            this.lblVoiceActor.Text = "Original Voice Actor:";
            // 
            // lblDebut
            // 
            this.lblDebut.AutoSize = true;
            this.lblDebut.Location = new System.Drawing.Point(137, 108);
            this.lblDebut.Name = "lblDebut";
            this.lblDebut.Size = new System.Drawing.Size(83, 13);
            this.lblDebut.TabIndex = 7;
            this.lblDebut.Text = "Animated Debut";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.tbxDebut);
            this.panel1.Controls.Add(this.lblDebut);
            this.panel1.Controls.Add(this.tbxVoiceActor);
            this.panel1.Controls.Add(this.tbxID);
            this.panel1.Controls.Add(this.lblVoiceActor);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 153);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetAllData);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnIndex);
            this.groupBox1.Location = new System.Drawing.Point(468, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 115);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRUD";
            // 
            // btnIndex
            // 
            this.btnIndex.Location = new System.Drawing.Point(44, 21);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(90, 35);
            this.btnIndex.TabIndex = 0;
            this.btnIndex.Text = "Index/ Insert";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(140, 21);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(44, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvwDisneyCharacter
            // 
            this.lvwDisneyCharacter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwDisneyCharacter.FullRowSelect = true;
            this.lvwDisneyCharacter.GridLines = true;
            this.lvwDisneyCharacter.Location = new System.Drawing.Point(12, 180);
            this.lvwDisneyCharacter.Name = "lvwDisneyCharacter";
            this.lvwDisneyCharacter.Size = new System.Drawing.Size(816, 155);
            this.lvwDisneyCharacter.TabIndex = 9;
            this.lvwDisneyCharacter.UseCompatibleStateImageBehavior = false;
            this.lvwDisneyCharacter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 205;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Original Voice Actor";
            this.columnHeader3.Width = 233;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Animated Debut";
            this.columnHeader4.Width = 265;
            // 
            // btnGetAllData
            // 
            this.btnGetAllData.Location = new System.Drawing.Point(188, 62);
            this.btnGetAllData.Name = "btnGetAllData";
            this.btnGetAllData.Size = new System.Drawing.Size(139, 35);
            this.btnGetAllData.TabIndex = 4;
            this.btnGetAllData.Text = "Get All Data";
            this.btnGetAllData.UseVisualStyleBackColor = true;
            this.btnGetAllData.Click += new System.EventHandler(this.btnGetAllData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 348);
            this.Controls.Add(this.lvwDisneyCharacter);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ES CRUD Operation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxVoiceActor;
        private System.Windows.Forms.TextBox tbxDebut;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVoiceActor;
        private System.Windows.Forms.Label lblDebut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.ListView lvwDisneyCharacter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnGetAllData;
    }
}


namespace CrudWithLinq
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
            this.components = new System.ComponentModel.Container();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.tblStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsDataSet = new CrudWithLinq.StudentsDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NationalCode = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tbl_StudentTableAdapter = new CrudWithLinq.StudentsDataSetTableAdapters.tbl_StudentTableAdapter();
            this.sIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNationalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Data
            // 
            this.dgv_Data.AutoGenerateColumns = false;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIDDataGridViewTextBoxColumn,
            this.sNameDataGridViewTextBoxColumn,
            this.sLastNameDataGridViewTextBoxColumn,
            this.sNationalCodeDataGridViewTextBoxColumn});
            this.dgv_Data.DataSource = this.tblStudentBindingSource;
            this.dgv_Data.Location = new System.Drawing.Point(12, 133);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.Size = new System.Drawing.Size(260, 189);
            this.dgv_Data.TabIndex = 6;
            this.dgv_Data.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Data_CellMouseClick);
            // 
            // tblStudentBindingSource
            // 
            this.tblStudentBindingSource.DataMember = "tbl_Student";
            this.tblStudentBindingSource.DataSource = this.studentsDataSet;
            // 
            // studentsDataSet
            // 
            this.studentsDataSet.DataSetName = "StudentsDataSet";
            this.studentsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 43);
            this.panel1.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 43);
            this.label1.TabIndex = 20;
            this.label1.Text = "Student Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name                 :";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Name.Location = new System.Drawing.Point(121, 49);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 22);
            this.txt_Name.TabIndex = 0;
            this.txt_Name.Enter += new System.EventHandler(this.txt_Name_Enter);
            this.txt_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Name_KeyDown);
            this.txt_Name.Leave += new System.EventHandler(this.txt_Name_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lastname          :";
            // 
            // txt_LastName
            // 
            this.txt_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_LastName.Location = new System.Drawing.Point(121, 77);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(151, 22);
            this.txt_LastName.TabIndex = 1;
            this.txt_LastName.Enter += new System.EventHandler(this.txt_LastName_Enter);
            this.txt_LastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_LastName_KeyDown);
            this.txt_LastName.Leave += new System.EventHandler(this.txt_LastName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "National Code :";
            // 
            // txt_NationalCode
            // 
            this.txt_NationalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_NationalCode.Location = new System.Drawing.Point(121, 105);
            this.txt_NationalCode.Name = "txt_NationalCode";
            this.txt_NationalCode.Size = new System.Drawing.Size(151, 22);
            this.txt_NationalCode.TabIndex = 2;
            this.txt_NationalCode.Enter += new System.EventHandler(this.txt_NationalCode_Enter);
            this.txt_NationalCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NationalCode_KeyDown);
            this.txt_NationalCode.Leave += new System.EventHandler(this.txt_NationalCode_Leave);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Exit.Image = global::CrudWithLinq.Properties.Resources.exit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Exit.Location = new System.Drawing.Point(204, 328);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(53, 74);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "&Exit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Delete.Image = global::CrudWithLinq.Properties.Resources.recycle;
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Delete.Location = new System.Drawing.Point(145, 328);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(53, 74);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Edit.Image = global::CrudWithLinq.Properties.Resources.pen2;
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Edit.Location = new System.Drawing.Point(86, 328);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(53, 74);
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Add.Image = global::CrudWithLinq.Properties.Resources.plus2;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Add.Location = new System.Drawing.Point(27, 328);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(53, 74);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "&Add";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tbl_StudentTableAdapter
            // 
            this.tbl_StudentTableAdapter.ClearBeforeFill = true;
            // 
            // sIDDataGridViewTextBoxColumn
            // 
            this.sIDDataGridViewTextBoxColumn.DataPropertyName = "S_ID";
            this.sIDDataGridViewTextBoxColumn.HeaderText = "S_ID";
            this.sIDDataGridViewTextBoxColumn.Name = "sIDDataGridViewTextBoxColumn";
            this.sIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sNameDataGridViewTextBoxColumn
            // 
            this.sNameDataGridViewTextBoxColumn.DataPropertyName = "S_Name";
            this.sNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.sNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.sNameDataGridViewTextBoxColumn.Name = "sNameDataGridViewTextBoxColumn";
            this.sNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sLastNameDataGridViewTextBoxColumn
            // 
            this.sLastNameDataGridViewTextBoxColumn.DataPropertyName = "S_LastName";
            this.sLastNameDataGridViewTextBoxColumn.HeaderText = "Lastname";
            this.sLastNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.sLastNameDataGridViewTextBoxColumn.Name = "sLastNameDataGridViewTextBoxColumn";
            this.sLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sNationalCodeDataGridViewTextBoxColumn
            // 
            this.sNationalCodeDataGridViewTextBoxColumn.DataPropertyName = "S_NationalCode";
            this.sNationalCodeDataGridViewTextBoxColumn.HeaderText = "National Code";
            this.sNationalCodeDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.sNationalCodeDataGridViewTextBoxColumn.Name = "sNationalCodeDataGridViewTextBoxColumn";
            this.sNationalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 409);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_NationalCode);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NationalCode;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Exit;
        private StudentsDataSet studentsDataSet;
        private System.Windows.Forms.BindingSource tblStudentBindingSource;
        private StudentsDataSetTableAdapters.tbl_StudentTableAdapter tbl_StudentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNationalCodeDataGridViewTextBoxColumn;
    }
}


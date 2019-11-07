namespace MainApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerForExcel = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolButtonOpenDebugFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.cmdSimpleOpenReadExample = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.cboCustomerSheetNames = new System.Windows.Forms.ComboBox();
            this.cmdUsedRowsColumns = new System.Windows.Forms.Button();
            this.txtUsedRowsColumns = new System.Windows.Forms.TextBox();
            this.cmdGetSheetNamesAutomation = new System.Windows.Forms.Button();
            this.cboSheetNamesAutomation = new System.Windows.Forms.ComboBox();
            this.cboGetSheetNamesXml = new System.Windows.Forms.ComboBox();
            this.cmdGetSheetNamesXml = new System.Windows.Forms.Button();
            this.cmdReadUsingWrapperLibOverOpenXml = new System.Windows.Forms.Button();
            this.cmdUsedRangeOpenXml = new System.Windows.Forms.Button();
            this.txtUsedRangeOpenXml = new System.Windows.Forms.TextBox();
            this.cmdCreateWithOpenXml = new System.Windows.Forms.Button();
            this.cmdCreateAndFillWithOpenXml = new System.Windows.Forms.Button();
            this.cmdGetSheetNamesOleDb = new System.Windows.Forms.Button();
            this.cboGetSheetNamesOleDb = new System.Windows.Forms.ComboBox();
            this.groupBoxVarious = new System.Windows.Forms.GroupBox();
            this.groupBoxAutomation = new System.Windows.Forms.GroupBox();
            this.cmdCrappyCreateAndPopulateAutomationButton = new System.Windows.Forms.Button();
            this.groupBoxOleDb = new System.Windows.Forms.GroupBox();
            this.cmdImportTextFileIntoWorkSheetOleDb = new System.Windows.Forms.Button();
            this.cmdCopyAndPopulateOleDb = new System.Windows.Forms.Button();
            this.cmdCreateExcelFileOleDb = new System.Windows.Forms.Button();
            this.cmdReadCustomersOleDb = new System.Windows.Forms.Button();
            this.cmdUsedRangeOleDb = new System.Windows.Forms.Button();
            this.groupBoxOpenXml = new System.Windows.Forms.GroupBox();
            this.cmdCreateAndPopulateWithVb = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdSimpleOleSearch = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxVarious.SuspendLayout();
            this.groupBoxAutomation.SuspendLayout();
            this.groupBoxOleDb.SuspendLayout();
            this.groupBoxOpenXml.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerForExcel
            // 
            this.timerForExcel.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolButtonOpenDebugFolder});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1123, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolButtonOpenDebugFolder
            // 
            this.toolButtonOpenDebugFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonOpenDebugFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonOpenDebugFolder.Image")));
            this.toolButtonOpenDebugFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonOpenDebugFolder.Name = "toolButtonOpenDebugFolder";
            this.toolButtonOpenDebugFolder.Size = new System.Drawing.Size(32, 20);
            this.toolButtonOpenDebugFolder.Text = "Open Debug folder";
            this.toolButtonOpenDebugFolder.ButtonClick += new System.EventHandler(this.toolButtonOpenDebugFolder_ButtonClick);
            // 
            // cmdSimpleOpenReadExample
            // 
            this.cmdSimpleOpenReadExample.Location = new System.Drawing.Point(6, 19);
            this.cmdSimpleOpenReadExample.Name = "cmdSimpleOpenReadExample";
            this.cmdSimpleOpenReadExample.Size = new System.Drawing.Size(133, 23);
            this.cmdSimpleOpenReadExample.TabIndex = 0;
            this.cmdSimpleOpenReadExample.Text = "Read cells simple";
            this.cmdSimpleOpenReadExample.UseVisualStyleBackColor = true;
            this.cmdSimpleOpenReadExample.Click += new System.EventHandler(this.cmdSimpleOpenReadExample_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtResults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 79);
            this.panel1.TabIndex = 2;
            // 
            // txtResults
            // 
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Location = new System.Drawing.Point(0, 0);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(1123, 79);
            this.txtResults.TabIndex = 0;
            // 
            // cboCustomerSheetNames
            // 
            this.cboCustomerSheetNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerSheetNames.FormattingEnabled = true;
            this.cboCustomerSheetNames.Location = new System.Drawing.Point(161, 19);
            this.cboCustomerSheetNames.Name = "cboCustomerSheetNames";
            this.cboCustomerSheetNames.Size = new System.Drawing.Size(215, 21);
            this.cboCustomerSheetNames.TabIndex = 1;
            // 
            // cmdUsedRowsColumns
            // 
            this.cmdUsedRowsColumns.Location = new System.Drawing.Point(6, 48);
            this.cmdUsedRowsColumns.Name = "cmdUsedRowsColumns";
            this.cmdUsedRowsColumns.Size = new System.Drawing.Size(133, 23);
            this.cmdUsedRowsColumns.TabIndex = 2;
            this.cmdUsedRowsColumns.Text = "Last row/column";
            this.cmdUsedRowsColumns.UseVisualStyleBackColor = true;
            this.cmdUsedRowsColumns.Click += new System.EventHandler(this.cmdUsedRowsColumns_Click);
            // 
            // txtUsedRowsColumns
            // 
            this.txtUsedRowsColumns.Location = new System.Drawing.Point(161, 50);
            this.txtUsedRowsColumns.Name = "txtUsedRowsColumns";
            this.txtUsedRowsColumns.Size = new System.Drawing.Size(212, 20);
            this.txtUsedRowsColumns.TabIndex = 3;
            // 
            // cmdGetSheetNamesAutomation
            // 
            this.cmdGetSheetNamesAutomation.Location = new System.Drawing.Point(24, 19);
            this.cmdGetSheetNamesAutomation.Name = "cmdGetSheetNamesAutomation";
            this.cmdGetSheetNamesAutomation.Size = new System.Drawing.Size(133, 23);
            this.cmdGetSheetNamesAutomation.TabIndex = 0;
            this.cmdGetSheetNamesAutomation.Text = "Automation";
            this.cmdGetSheetNamesAutomation.UseVisualStyleBackColor = true;
            this.cmdGetSheetNamesAutomation.Click += new System.EventHandler(this.cmdGetSheetNamesAutomation_Click);
            // 
            // cboSheetNamesAutomation
            // 
            this.cboSheetNamesAutomation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheetNamesAutomation.FormattingEnabled = true;
            this.cboSheetNamesAutomation.Location = new System.Drawing.Point(179, 21);
            this.cboSheetNamesAutomation.Name = "cboSheetNamesAutomation";
            this.cboSheetNamesAutomation.Size = new System.Drawing.Size(215, 21);
            this.cboSheetNamesAutomation.TabIndex = 1;
            // 
            // cboGetSheetNamesXml
            // 
            this.cboGetSheetNamesXml.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGetSheetNamesXml.FormattingEnabled = true;
            this.cboGetSheetNamesXml.Location = new System.Drawing.Point(179, 50);
            this.cboGetSheetNamesXml.Name = "cboGetSheetNamesXml";
            this.cboGetSheetNamesXml.Size = new System.Drawing.Size(215, 21);
            this.cboGetSheetNamesXml.TabIndex = 3;
            // 
            // cmdGetSheetNamesXml
            // 
            this.cmdGetSheetNamesXml.Location = new System.Drawing.Point(24, 48);
            this.cmdGetSheetNamesXml.Name = "cmdGetSheetNamesXml";
            this.cmdGetSheetNamesXml.Size = new System.Drawing.Size(133, 23);
            this.cmdGetSheetNamesXml.TabIndex = 2;
            this.cmdGetSheetNamesXml.Text = "Open XML";
            this.cmdGetSheetNamesXml.UseVisualStyleBackColor = true;
            this.cmdGetSheetNamesXml.Click += new System.EventHandler(this.cmdGetSheetNamesXml_Click);
            // 
            // cmdReadUsingWrapperLibOverOpenXml
            // 
            this.cmdReadUsingWrapperLibOverOpenXml.Location = new System.Drawing.Point(24, 50);
            this.cmdReadUsingWrapperLibOverOpenXml.Name = "cmdReadUsingWrapperLibOverOpenXml";
            this.cmdReadUsingWrapperLibOverOpenXml.Size = new System.Drawing.Size(133, 23);
            this.cmdReadUsingWrapperLibOverOpenXml.TabIndex = 2;
            this.cmdReadUsingWrapperLibOverOpenXml.Text = "Read Customers";
            this.cmdReadUsingWrapperLibOverOpenXml.UseVisualStyleBackColor = true;
            this.cmdReadUsingWrapperLibOverOpenXml.Click += new System.EventHandler(this.cmdReadUsingWrapperLibOverOpenXml_Click);
            // 
            // cmdUsedRangeOpenXml
            // 
            this.cmdUsedRangeOpenXml.Location = new System.Drawing.Point(24, 21);
            this.cmdUsedRangeOpenXml.Name = "cmdUsedRangeOpenXml";
            this.cmdUsedRangeOpenXml.Size = new System.Drawing.Size(133, 23);
            this.cmdUsedRangeOpenXml.TabIndex = 0;
            this.cmdUsedRangeOpenXml.Text = "Used Range";
            this.cmdUsedRangeOpenXml.UseVisualStyleBackColor = true;
            this.cmdUsedRangeOpenXml.Click += new System.EventHandler(this.cmdUsedRangeOpenXml_Click);
            // 
            // txtUsedRangeOpenXml
            // 
            this.txtUsedRangeOpenXml.Location = new System.Drawing.Point(179, 23);
            this.txtUsedRangeOpenXml.Name = "txtUsedRangeOpenXml";
            this.txtUsedRangeOpenXml.Size = new System.Drawing.Size(212, 20);
            this.txtUsedRangeOpenXml.TabIndex = 1;
            // 
            // cmdCreateWithOpenXml
            // 
            this.cmdCreateWithOpenXml.Location = new System.Drawing.Point(24, 108);
            this.cmdCreateWithOpenXml.Name = "cmdCreateWithOpenXml";
            this.cmdCreateWithOpenXml.Size = new System.Drawing.Size(133, 23);
            this.cmdCreateWithOpenXml.TabIndex = 4;
            this.cmdCreateWithOpenXml.Text = "Create new file";
            this.cmdCreateWithOpenXml.UseVisualStyleBackColor = true;
            this.cmdCreateWithOpenXml.Click += new System.EventHandler(this.cmdCreateWithOpenXml_Click);
            // 
            // cmdCreateAndFillWithOpenXml
            // 
            this.cmdCreateAndFillWithOpenXml.Location = new System.Drawing.Point(24, 137);
            this.cmdCreateAndFillWithOpenXml.Name = "cmdCreateAndFillWithOpenXml";
            this.cmdCreateAndFillWithOpenXml.Size = new System.Drawing.Size(133, 23);
            this.cmdCreateAndFillWithOpenXml.TabIndex = 5;
            this.cmdCreateAndFillWithOpenXml.Text = "Create and populate";
            this.cmdCreateAndFillWithOpenXml.UseVisualStyleBackColor = true;
            this.cmdCreateAndFillWithOpenXml.Click += new System.EventHandler(this.cmdCreateAndFillWithOpenXml_Click);
            // 
            // cmdGetSheetNamesOleDb
            // 
            this.cmdGetSheetNamesOleDb.Location = new System.Drawing.Point(24, 77);
            this.cmdGetSheetNamesOleDb.Name = "cmdGetSheetNamesOleDb";
            this.cmdGetSheetNamesOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdGetSheetNamesOleDb.TabIndex = 4;
            this.cmdGetSheetNamesOleDb.Text = "OleDb";
            this.cmdGetSheetNamesOleDb.UseVisualStyleBackColor = true;
            this.cmdGetSheetNamesOleDb.Click += new System.EventHandler(this.cmdGetSheetNamesOleDb_Click);
            // 
            // cboGetSheetNamesOleDb
            // 
            this.cboGetSheetNamesOleDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGetSheetNamesOleDb.FormattingEnabled = true;
            this.cboGetSheetNamesOleDb.Location = new System.Drawing.Point(179, 77);
            this.cboGetSheetNamesOleDb.Name = "cboGetSheetNamesOleDb";
            this.cboGetSheetNamesOleDb.Size = new System.Drawing.Size(215, 21);
            this.cboGetSheetNamesOleDb.TabIndex = 5;
            // 
            // groupBoxVarious
            // 
            this.groupBoxVarious.Controls.Add(this.cboGetSheetNamesOleDb);
            this.groupBoxVarious.Controls.Add(this.cmdGetSheetNamesOleDb);
            this.groupBoxVarious.Controls.Add(this.cboGetSheetNamesXml);
            this.groupBoxVarious.Controls.Add(this.cmdGetSheetNamesXml);
            this.groupBoxVarious.Controls.Add(this.cboSheetNamesAutomation);
            this.groupBoxVarious.Controls.Add(this.cmdGetSheetNamesAutomation);
            this.groupBoxVarious.Location = new System.Drawing.Point(12, 12);
            this.groupBoxVarious.Name = "groupBoxVarious";
            this.groupBoxVarious.Size = new System.Drawing.Size(413, 147);
            this.groupBoxVarious.TabIndex = 17;
            this.groupBoxVarious.TabStop = false;
            this.groupBoxVarious.Text = "Various methods to get sheet names";
            // 
            // groupBoxAutomation
            // 
            this.groupBoxAutomation.Controls.Add(this.cmdCrappyCreateAndPopulateAutomationButton);
            this.groupBoxAutomation.Controls.Add(this.cmdSimpleOpenReadExample);
            this.groupBoxAutomation.Controls.Add(this.cboCustomerSheetNames);
            this.groupBoxAutomation.Controls.Add(this.cmdUsedRowsColumns);
            this.groupBoxAutomation.Controls.Add(this.txtUsedRowsColumns);
            this.groupBoxAutomation.Location = new System.Drawing.Point(444, 12);
            this.groupBoxAutomation.Name = "groupBoxAutomation";
            this.groupBoxAutomation.Size = new System.Drawing.Size(406, 147);
            this.groupBoxAutomation.TabIndex = 18;
            this.groupBoxAutomation.TabStop = false;
            this.groupBoxAutomation.Text = "Working with Automation";
            // 
            // cmdCrappyCreateAndPopulateAutomationButton
            // 
            this.cmdCrappyCreateAndPopulateAutomationButton.Location = new System.Drawing.Point(6, 77);
            this.cmdCrappyCreateAndPopulateAutomationButton.Name = "cmdCrappyCreateAndPopulateAutomationButton";
            this.cmdCrappyCreateAndPopulateAutomationButton.Size = new System.Drawing.Size(133, 23);
            this.cmdCrappyCreateAndPopulateAutomationButton.TabIndex = 4;
            this.cmdCrappyCreateAndPopulateAutomationButton.Text = "Create and populate";
            this.cmdCrappyCreateAndPopulateAutomationButton.UseVisualStyleBackColor = true;
            this.cmdCrappyCreateAndPopulateAutomationButton.Click += new System.EventHandler(this.cmdCrappyCreateAndPopulateAutomationButton_ClickAsync);
            // 
            // groupBoxOleDb
            // 
            this.groupBoxOleDb.Controls.Add(this.cmdSimpleOleSearch);
            this.groupBoxOleDb.Controls.Add(this.cmdImportTextFileIntoWorkSheetOleDb);
            this.groupBoxOleDb.Controls.Add(this.cmdCopyAndPopulateOleDb);
            this.groupBoxOleDb.Controls.Add(this.cmdCreateExcelFileOleDb);
            this.groupBoxOleDb.Controls.Add(this.cmdReadCustomersOleDb);
            this.groupBoxOleDb.Controls.Add(this.cmdUsedRangeOleDb);
            this.groupBoxOleDb.Location = new System.Drawing.Point(444, 168);
            this.groupBoxOleDb.Name = "groupBoxOleDb";
            this.groupBoxOleDb.Size = new System.Drawing.Size(406, 182);
            this.groupBoxOleDb.TabIndex = 19;
            this.groupBoxOleDb.TabStop = false;
            this.groupBoxOleDb.Text = "Working with OleDb";
            // 
            // cmdImportTextFileIntoWorkSheetOleDb
            // 
            this.cmdImportTextFileIntoWorkSheetOleDb.Location = new System.Drawing.Point(6, 137);
            this.cmdImportTextFileIntoWorkSheetOleDb.Name = "cmdImportTextFileIntoWorkSheetOleDb";
            this.cmdImportTextFileIntoWorkSheetOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdImportTextFileIntoWorkSheetOleDb.TabIndex = 4;
            this.cmdImportTextFileIntoWorkSheetOleDb.Text = "Import from Text file";
            this.cmdImportTextFileIntoWorkSheetOleDb.UseVisualStyleBackColor = true;
            this.cmdImportTextFileIntoWorkSheetOleDb.Click += new System.EventHandler(this.cmdImportTextFileIntoWorkSheetOleDb_Click);
            // 
            // cmdCopyAndPopulateOleDb
            // 
            this.cmdCopyAndPopulateOleDb.Location = new System.Drawing.Point(6, 108);
            this.cmdCopyAndPopulateOleDb.Name = "cmdCopyAndPopulateOleDb";
            this.cmdCopyAndPopulateOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdCopyAndPopulateOleDb.TabIndex = 3;
            this.cmdCopyAndPopulateOleDb.Text = "Create and populate";
            this.cmdCopyAndPopulateOleDb.UseVisualStyleBackColor = true;
            this.cmdCopyAndPopulateOleDb.Click += new System.EventHandler(this.cmdCopyAndPopulateOleDb_Click);
            // 
            // cmdCreateExcelFileOleDb
            // 
            this.cmdCreateExcelFileOleDb.Location = new System.Drawing.Point(6, 79);
            this.cmdCreateExcelFileOleDb.Name = "cmdCreateExcelFileOleDb";
            this.cmdCreateExcelFileOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdCreateExcelFileOleDb.TabIndex = 2;
            this.cmdCreateExcelFileOleDb.Text = "Create new file";
            this.cmdCreateExcelFileOleDb.UseVisualStyleBackColor = true;
            this.cmdCreateExcelFileOleDb.Click += new System.EventHandler(this.cmdCreateExcelFileOleDb_Click);
            // 
            // cmdReadCustomersOleDb
            // 
            this.cmdReadCustomersOleDb.Location = new System.Drawing.Point(6, 50);
            this.cmdReadCustomersOleDb.Name = "cmdReadCustomersOleDb";
            this.cmdReadCustomersOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdReadCustomersOleDb.TabIndex = 1;
            this.cmdReadCustomersOleDb.Text = "Read Customers";
            this.cmdReadCustomersOleDb.UseVisualStyleBackColor = true;
            this.cmdReadCustomersOleDb.Click += new System.EventHandler(this.cmdReadCustomersOleDb_Click);
            // 
            // cmdUsedRangeOleDb
            // 
            this.cmdUsedRangeOleDb.Location = new System.Drawing.Point(6, 20);
            this.cmdUsedRangeOleDb.Name = "cmdUsedRangeOleDb";
            this.cmdUsedRangeOleDb.Size = new System.Drawing.Size(133, 23);
            this.cmdUsedRangeOleDb.TabIndex = 0;
            this.cmdUsedRangeOleDb.Text = "Used Range";
            this.cmdUsedRangeOleDb.UseVisualStyleBackColor = true;
            this.cmdUsedRangeOleDb.Click += new System.EventHandler(this.cmdUsedRangeOleDb_Click);
            // 
            // groupBoxOpenXml
            // 
            this.groupBoxOpenXml.Controls.Add(this.cmdCreateAndPopulateWithVb);
            this.groupBoxOpenXml.Controls.Add(this.cmdUsedRangeOpenXml);
            this.groupBoxOpenXml.Controls.Add(this.cmdReadUsingWrapperLibOverOpenXml);
            this.groupBoxOpenXml.Controls.Add(this.txtUsedRangeOpenXml);
            this.groupBoxOpenXml.Controls.Add(this.cmdCreateAndFillWithOpenXml);
            this.groupBoxOpenXml.Controls.Add(this.cmdCreateWithOpenXml);
            this.groupBoxOpenXml.Location = new System.Drawing.Point(12, 168);
            this.groupBoxOpenXml.Name = "groupBoxOpenXml";
            this.groupBoxOpenXml.Size = new System.Drawing.Size(423, 182);
            this.groupBoxOpenXml.TabIndex = 20;
            this.groupBoxOpenXml.TabStop = false;
            this.groupBoxOpenXml.Text = "Working with Open XML";
            // 
            // cmdCreateAndPopulateWithVb
            // 
            this.cmdCreateAndPopulateWithVb.Location = new System.Drawing.Point(24, 79);
            this.cmdCreateAndPopulateWithVb.Name = "cmdCreateAndPopulateWithVb";
            this.cmdCreateAndPopulateWithVb.Size = new System.Drawing.Size(133, 23);
            this.cmdCreateAndPopulateWithVb.TabIndex = 3;
            this.cmdCreateAndPopulateWithVb.Text = "Create/populate vb.net";
            this.cmdCreateAndPopulateWithVb.UseVisualStyleBackColor = true;
            this.cmdCreateAndPopulateWithVb.Click += new System.EventHandler(this.cmdCreateAndPopulateWithVb_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 319);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBox1);
            this.groupBox5.Location = new System.Drawing.Point(863, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(249, 338);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Progress";
            // 
            // cmdSimpleOleSearch
            // 
            this.cmdSimpleOleSearch.Location = new System.Drawing.Point(145, 21);
            this.cmdSimpleOleSearch.Name = "cmdSimpleOleSearch";
            this.cmdSimpleOleSearch.Size = new System.Drawing.Size(133, 23);
            this.cmdSimpleOleSearch.TabIndex = 5;
            this.cmdSimpleOleSearch.Text = "Simple search";
            this.cmdSimpleOleSearch.UseVisualStyleBackColor = true;
            this.cmdSimpleOleSearch.Click += new System.EventHandler(this.cmdSimpleOleSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 460);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBoxOpenXml);
            this.Controls.Add(this.groupBoxOleDb);
            this.Controls.Add(this.groupBoxAutomation);
            this.Controls.Add(this.groupBoxVarious);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Automation/OpenXML";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxVarious.ResumeLayout(false);
            this.groupBoxAutomation.ResumeLayout(false);
            this.groupBoxAutomation.PerformLayout();
            this.groupBoxOleDb.ResumeLayout(false);
            this.groupBoxOpenXml.ResumeLayout(false);
            this.groupBoxOpenXml.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerForExcel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button cmdSimpleOpenReadExample;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ComboBox cboCustomerSheetNames;
        private System.Windows.Forms.Button cmdUsedRowsColumns;
        private System.Windows.Forms.TextBox txtUsedRowsColumns;
        private System.Windows.Forms.Button cmdGetSheetNamesAutomation;
        private System.Windows.Forms.ComboBox cboSheetNamesAutomation;
        private System.Windows.Forms.ComboBox cboGetSheetNamesXml;
        private System.Windows.Forms.Button cmdGetSheetNamesXml;
        private System.Windows.Forms.Button cmdReadUsingWrapperLibOverOpenXml;
        private System.Windows.Forms.Button cmdUsedRangeOpenXml;
        private System.Windows.Forms.TextBox txtUsedRangeOpenXml;
        private System.Windows.Forms.Button cmdCreateWithOpenXml;
        private System.Windows.Forms.Button cmdCreateAndFillWithOpenXml;
        private System.Windows.Forms.ToolStripSplitButton toolButtonOpenDebugFolder;
        private System.Windows.Forms.Button cmdGetSheetNamesOleDb;
        private System.Windows.Forms.ComboBox cboGetSheetNamesOleDb;
        private System.Windows.Forms.GroupBox groupBoxVarious;
        private System.Windows.Forms.GroupBox groupBoxAutomation;
        private System.Windows.Forms.GroupBox groupBoxOleDb;
        private System.Windows.Forms.GroupBox groupBoxOpenXml;
        private System.Windows.Forms.Button cmdUsedRangeOleDb;
        private System.Windows.Forms.Button cmdReadCustomersOleDb;
        private System.Windows.Forms.Button cmdCreateExcelFileOleDb;
        private System.Windows.Forms.Button cmdCopyAndPopulateOleDb;
        private System.Windows.Forms.Button cmdCrappyCreateAndPopulateAutomationButton;
        private System.Windows.Forms.Button cmdCreateAndPopulateWithVb;
        private System.Windows.Forms.Button cmdImportTextFileIntoWorkSheetOleDb;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdSimpleOleSearch;
    }
}


namespace HTMLConverter
{
    partial class Form1
    {
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
            this.rdo_urlBtn = new System.Windows.Forms.RadioButton();
            this.rdo_htmlStringBtn = new System.Windows.Forms.RadioButton();
            this.url_TxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.baseURL_txtBox = new System.Windows.Forms.TextBox();
            this.htmlString_txtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.form_checkBox = new System.Windows.Forms.CheckBox();
            this.delay_txtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bookmark_checkBox = new System.Windows.Forms.CheckBox();
            this.toc_checkBox = new System.Windows.Forms.CheckBox();
            this.hyperlink_checkBox = new System.Windows.Forms.CheckBox();
            this.JavaScript_CheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rotation_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.footer_checkBox = new System.Windows.Forms.CheckBox();
            this.header_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.margin_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdo_landscapeBtn = new System.Windows.Forms.RadioButton();
            this.rdo_portraitBtn = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.convertBtn = new System.Windows.Forms.Button();
            this.rdo_MhtmlBtn = new System.Windows.Forms.RadioButton();
            this.rdo_ImageBtn = new System.Windows.Forms.RadioButton();
            this.rdo_SvgBtn = new System.Windows.Forms.RadioButton();
            this.rdo_PDFBtn = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_urlBtn
            // 
            this.rdo_urlBtn.AutoSize = true;
            this.rdo_urlBtn.Checked = true;
            this.rdo_urlBtn.Location = new System.Drawing.Point(15, 25);
            this.rdo_urlBtn.Name = "rdo_urlBtn";
            this.rdo_urlBtn.Size = new System.Drawing.Size(215, 24);
            this.rdo_urlBtn.TabIndex = 1;
            this.rdo_urlBtn.TabStop = true;
            this.rdo_urlBtn.Text = "Convert URL or HTML file";
            this.rdo_urlBtn.UseVisualStyleBackColor = true;
            this.rdo_urlBtn.CheckedChanged += new System.EventHandler(this.rdo_urlBtn_CheckedChanged);
            // 
            // rdo_htmlStringBtn
            // 
            this.rdo_htmlStringBtn.AutoSize = true;
            this.rdo_htmlStringBtn.Location = new System.Drawing.Point(348, 25);
            this.rdo_htmlStringBtn.Name = "rdo_htmlStringBtn";
            this.rdo_htmlStringBtn.Size = new System.Drawing.Size(182, 24);
            this.rdo_htmlStringBtn.TabIndex = 2;
            this.rdo_htmlStringBtn.Text = "Convert HTML String";
            this.rdo_htmlStringBtn.UseVisualStyleBackColor = true;
            this.rdo_htmlStringBtn.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // url_TxtBox
            // 
            this.url_TxtBox.Location = new System.Drawing.Point(173, 41);
            this.url_TxtBox.Name = "url_TxtBox";
            this.url_TxtBox.Size = new System.Drawing.Size(381, 26);
            this.url_TxtBox.TabIndex = 2;
            this.url_TxtBox.Text = "www.google.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL or HTML file";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_urlBtn);
            this.groupBox1.Controls.Add(this.rdo_htmlStringBtn);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.baseURL_txtBox);
            this.groupBox6.Controls.Add(this.htmlString_txtBox);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Location = new System.Drawing.Point(15, 59);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(864, 116);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "HTML String";
            this.groupBox6.Visible = false;
            // 
            // baseURL_txtBox
            // 
            this.baseURL_txtBox.Location = new System.Drawing.Point(122, 73);
            this.baseURL_txtBox.Name = "baseURL_txtBox";
            this.baseURL_txtBox.Size = new System.Drawing.Size(709, 26);
            this.baseURL_txtBox.TabIndex = 2;
            // 
            // htmlString_txtBox
            // 
            this.htmlString_txtBox.Location = new System.Drawing.Point(122, 30);
            this.htmlString_txtBox.Name = "htmlString_txtBox";
            this.htmlString_txtBox.Size = new System.Drawing.Size(709, 26);
            this.htmlString_txtBox.TabIndex = 1;
            this.htmlString_txtBox.Click += new System.EventHandler(this.htmlString_txtBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Base URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Text";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.url_TxtBox);
            this.groupBox7.Controls.Add(this.browse_btn);
            this.groupBox7.Location = new System.Drawing.Point(15, 63);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(868, 112);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Please enter URL or select HTML file";
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(581, 42);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(37, 31);
            this.browse_btn.TabIndex = 3;
            this.browse_btn.Text = "...";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.form_checkBox);
            this.groupBox2.Controls.Add(this.delay_txtBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bookmark_checkBox);
            this.groupBox2.Controls.Add(this.toc_checkBox);
            this.groupBox2.Controls.Add(this.hyperlink_checkBox);
            this.groupBox2.Controls.Add(this.JavaScript_CheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conversion Settings";
            // 
            // form_checkBox
            // 
            this.form_checkBox.AutoSize = true;
            this.form_checkBox.Location = new System.Drawing.Point(680, 38);
            this.form_checkBox.Name = "form_checkBox";
            this.form_checkBox.Size = new System.Drawing.Size(203, 24);
            this.form_checkBox.TabIndex = 8;
            this.form_checkBox.Text = "Create fillable PDF form";
            this.form_checkBox.UseVisualStyleBackColor = true;
            // 
            // delay_txtBox
            // 
            this.delay_txtBox.Location = new System.Drawing.Point(195, 94);
            this.delay_txtBox.Name = "delay_txtBox";
            this.delay_txtBox.Size = new System.Drawing.Size(100, 26);
            this.delay_txtBox.TabIndex = 9;
            this.delay_txtBox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Additional Delay (in sec)";
            // 
            // bookmark_checkBox
            // 
            this.bookmark_checkBox.AutoSize = true;
            this.bookmark_checkBox.Location = new System.Drawing.Point(493, 38);
            this.bookmark_checkBox.Name = "bookmark_checkBox";
            this.bookmark_checkBox.Size = new System.Drawing.Size(169, 24);
            this.bookmark_checkBox.TabIndex = 7;
            this.bookmark_checkBox.Text = "Enable Bookmarks";
            this.bookmark_checkBox.UseVisualStyleBackColor = true;
            // 
            // toc_checkBox
            // 
            this.toc_checkBox.AutoSize = true;
            this.toc_checkBox.Location = new System.Drawing.Point(358, 38);
            this.toc_checkBox.Name = "toc_checkBox";
            this.toc_checkBox.Size = new System.Drawing.Size(115, 24);
            this.toc_checkBox.TabIndex = 6;
            this.toc_checkBox.Text = "Enable Toc";
            this.toc_checkBox.UseVisualStyleBackColor = true;
            // 
            // hyperlink_checkBox
            // 
            this.hyperlink_checkBox.AutoSize = true;
            this.hyperlink_checkBox.Checked = true;
            this.hyperlink_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hyperlink_checkBox.Location = new System.Drawing.Point(189, 38);
            this.hyperlink_checkBox.Name = "hyperlink_checkBox";
            this.hyperlink_checkBox.Size = new System.Drawing.Size(154, 24);
            this.hyperlink_checkBox.TabIndex = 5;
            this.hyperlink_checkBox.Text = "Enable Hyperlink";
            this.hyperlink_checkBox.UseVisualStyleBackColor = true;
            // 
            // JavaScript_CheckBox
            // 
            this.JavaScript_CheckBox.AutoSize = true;
            this.JavaScript_CheckBox.Checked = true;
            this.JavaScript_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.JavaScript_CheckBox.Location = new System.Drawing.Point(15, 38);
            this.JavaScript_CheckBox.Name = "JavaScript_CheckBox";
            this.JavaScript_CheckBox.Size = new System.Drawing.Size(167, 24);
            this.JavaScript_CheckBox.TabIndex = 4;
            this.JavaScript_CheckBox.Text = "Enable JavaScript ";
            this.JavaScript_CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rotation_comboBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.footer_checkBox);
            this.groupBox3.Controls.Add(this.header_checkBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.margin_comboBox);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(898, 170);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Page Settings";
            // 
            // rotation_comboBox
            // 
            this.rotation_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotation_comboBox.FormattingEnabled = true;
            this.rotation_comboBox.Items.AddRange(new object[] {
            "RotateAngle0",
            "RotateAngle90",
            "RotateAngle180",
            "RotateAngle270"});
            this.rotation_comboBox.Location = new System.Drawing.Point(717, 36);
            this.rotation_comboBox.Name = "rotation_comboBox";
            this.rotation_comboBox.Size = new System.Drawing.Size(166, 28);
            this.rotation_comboBox.TabIndex = 5;
            this.rotation_comboBox.SelectedIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rotation";
            // 
            // footer_checkBox
            // 
            this.footer_checkBox.AutoSize = true;
            this.footer_checkBox.Location = new System.Drawing.Point(443, 40);
            this.footer_checkBox.Name = "footer_checkBox";
            this.footer_checkBox.Size = new System.Drawing.Size(126, 24);
            this.footer_checkBox.TabIndex = 3;
            this.footer_checkBox.Text = "Show Footer";
            this.footer_checkBox.UseVisualStyleBackColor = true;
            // 
            // header_checkBox
            // 
            this.header_checkBox.AutoSize = true;
            this.header_checkBox.Location = new System.Drawing.Point(255, 38);
            this.header_checkBox.Name = "header_checkBox";
            this.header_checkBox.Size = new System.Drawing.Size(132, 24);
            this.header_checkBox.TabIndex = 2;
            this.header_checkBox.Text = "Show Header";
            this.header_checkBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Page Margin";
            // 
            // margin_comboBox
            // 
            this.margin_comboBox.FormattingEnabled = true;
            this.margin_comboBox.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.margin_comboBox.Location = new System.Drawing.Point(120, 36);
            this.margin_comboBox.MaxLength = 50;
            this.margin_comboBox.Name = "margin_comboBox";
            this.margin_comboBox.Size = new System.Drawing.Size(77, 28);
            this.margin_comboBox.TabIndex = 1;
            this.margin_comboBox.SelectedIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdo_landscapeBtn);
            this.groupBox5.Controls.Add(this.rdo_portraitBtn);
            this.groupBox5.Location = new System.Drawing.Point(15, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 68);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Orientation";
            // 
            // rdo_landscapeBtn
            // 
            this.rdo_landscapeBtn.AutoSize = true;
            this.rdo_landscapeBtn.Location = new System.Drawing.Point(219, 27);
            this.rdo_landscapeBtn.Name = "rdo_landscapeBtn";
            this.rdo_landscapeBtn.Size = new System.Drawing.Size(113, 24);
            this.rdo_landscapeBtn.TabIndex = 0;
            this.rdo_landscapeBtn.Text = "Landscape";
            this.rdo_landscapeBtn.UseVisualStyleBackColor = true;
            // 
            // rdo_portraitBtn
            // 
            this.rdo_portraitBtn.AutoSize = true;
            this.rdo_portraitBtn.Checked = true;
            this.rdo_portraitBtn.Location = new System.Drawing.Point(17, 28);
            this.rdo_portraitBtn.Name = "rdo_portraitBtn";
            this.rdo_portraitBtn.Size = new System.Drawing.Size(85, 24);
            this.rdo_portraitBtn.TabIndex = 1;
            this.rdo_portraitBtn.TabStop = true;
            this.rdo_portraitBtn.Text = "Portrait";
            this.rdo_portraitBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.convertBtn);
            this.groupBox4.Controls.Add(this.rdo_MhtmlBtn);
            this.groupBox4.Controls.Add(this.rdo_ImageBtn);
            this.groupBox4.Controls.Add(this.rdo_SvgBtn);
            this.groupBox4.Controls.Add(this.rdo_PDFBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 552);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(898, 87);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save As";
            // 
            // convertBtn
            // 
            this.convertBtn.Location = new System.Drawing.Point(762, 32);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(121, 37);
            this.convertBtn.TabIndex = 20;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // rdo_MhtmlBtn
            // 
            this.rdo_MhtmlBtn.AutoSize = true;
            this.rdo_MhtmlBtn.Location = new System.Drawing.Point(493, 38);
            this.rdo_MhtmlBtn.Name = "rdo_MhtmlBtn";
            this.rdo_MhtmlBtn.Size = new System.Drawing.Size(90, 24);
            this.rdo_MhtmlBtn.TabIndex = 19;
            this.rdo_MhtmlBtn.Text = "MHTML";
            this.rdo_MhtmlBtn.UseVisualStyleBackColor = true;
            this.rdo_MhtmlBtn.CheckedChanged += new System.EventHandler(this.rdo_MhtmlBtn_CheckedChanged);
            // 
            // rdo_ImageBtn
            // 
            this.rdo_ImageBtn.AutoSize = true;
            this.rdo_ImageBtn.Location = new System.Drawing.Point(348, 38);
            this.rdo_ImageBtn.Name = "rdo_ImageBtn";
            this.rdo_ImageBtn.Size = new System.Drawing.Size(79, 24);
            this.rdo_ImageBtn.TabIndex = 18;
            this.rdo_ImageBtn.Text = "Image";
            this.rdo_ImageBtn.UseVisualStyleBackColor = true;
            this.rdo_ImageBtn.CheckedChanged += new System.EventHandler(this.rdo_ImageBtn_CheckedChanged);
            // 
            // rdo_SvgBtn
            // 
            this.rdo_SvgBtn.AutoSize = true;
            this.rdo_SvgBtn.Location = new System.Drawing.Point(189, 38);
            this.rdo_SvgBtn.Name = "rdo_SvgBtn";
            this.rdo_SvgBtn.Size = new System.Drawing.Size(69, 24);
            this.rdo_SvgBtn.TabIndex = 17;
            this.rdo_SvgBtn.Text = "SVG";
            this.rdo_SvgBtn.UseVisualStyleBackColor = true;
            this.rdo_SvgBtn.CheckedChanged += new System.EventHandler(this.rdo_SvgBtn_CheckedChanged);
            // 
            // rdo_PDFBtn
            // 
            this.rdo_PDFBtn.AutoSize = true;
            this.rdo_PDFBtn.Checked = true;
            this.rdo_PDFBtn.Location = new System.Drawing.Point(20, 38);
            this.rdo_PDFBtn.Name = "rdo_PDFBtn";
            this.rdo_PDFBtn.Size = new System.Drawing.Size(66, 24);
            this.rdo_PDFBtn.TabIndex = 16;
            this.rdo_PDFBtn.TabStop = true;
            this.rdo_PDFBtn.Text = "PDF";
            this.rdo_PDFBtn.UseVisualStyleBackColor = true;
            this.rdo_PDFBtn.CheckedChanged += new System.EventHandler(this.rdo_PDFBtn_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(921, 651);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTML Conversion";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Private members

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.RadioButton rdo_urlBtn;
        private System.Windows.Forms.RadioButton rdo_htmlStringBtn;
        private System.Windows.Forms.TextBox url_TxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox form_checkBox;
        private System.Windows.Forms.TextBox delay_txtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox bookmark_checkBox;
        private System.Windows.Forms.CheckBox toc_checkBox;
        private System.Windows.Forms.CheckBox hyperlink_checkBox;
        private System.Windows.Forms.CheckBox JavaScript_CheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox margin_comboBox;
        private System.Windows.Forms.ComboBox rotation_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox footer_checkBox;
        private System.Windows.Forms.CheckBox header_checkBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdo_MhtmlBtn;
        private System.Windows.Forms.RadioButton rdo_ImageBtn;
        private System.Windows.Forms.RadioButton rdo_SvgBtn;
        private System.Windows.Forms.RadioButton rdo_PDFBtn;
        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdo_landscapeBtn;
        private System.Windows.Forms.RadioButton rdo_portraitBtn;
        internal System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox baseURL_txtBox;
        internal System.Windows.Forms.TextBox htmlString_txtBox;
        internal System.Windows.Forms.GroupBox groupBox7;

        #endregion
    }
}


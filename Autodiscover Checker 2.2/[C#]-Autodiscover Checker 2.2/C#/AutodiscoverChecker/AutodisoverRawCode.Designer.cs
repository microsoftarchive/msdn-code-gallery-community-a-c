namespace AutodiscoverChecker
{
    partial class AutodisoverRawCode
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.chkDefaultWindowsCredentials = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.txtTargetMailboxText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTracing = new System.Windows.Forms.TextBox();
            this.btnInternalScpLookup = new System.Windows.Forms.Button();
            this.chkAllowSelfSignedCerts = new System.Windows.Forms.CheckBox();
            this.btnAutodiscoverSoap = new System.Windows.Forms.Button();
            this.btnAutodiscoverPOX = new System.Windows.Forms.Button();
            this.chkTraceCertificateInformation = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.chkDefaultWindowsCredentials);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 111);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.txtDomain.Location = new System.Drawing.Point(90, 83);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(152, 20);
            this.txtDomain.TabIndex = 48;
            // 
            // chkDefaultWindowsCredentials
            // 
            this.chkDefaultWindowsCredentials.AutoSize = true;
            this.chkDefaultWindowsCredentials.Location = new System.Drawing.Point(6, 13);
            this.chkDefaultWindowsCredentials.Name = "chkDefaultWindowsCredentials";
            this.chkDefaultWindowsCredentials.Size = new System.Drawing.Size(162, 17);
            this.chkDefaultWindowsCredentials.TabIndex = 42;
            this.chkDefaultWindowsCredentials.Text = "Default Windows Credentials";
            this.chkDefaultWindowsCredentials.UseVisualStyleBackColor = true;
            this.chkDefaultWindowsCredentials.CheckedChanged += new System.EventHandler(this.chkDefaultWindowsCredentials_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(90, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(152, 20);
            this.txtUser.TabIndex = 43;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(90, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Password:";
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(272, 25);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(120, 13);
            this.TargetMailboxLabel.TabIndex = 73;
            this.TargetMailboxLabel.Text = "Mailbox SMTP Address:";
            // 
            // txtTargetMailboxText
            // 
            this.txtTargetMailboxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetMailboxText.Location = new System.Drawing.Point(398, 23);
            this.txtTargetMailboxText.Name = "txtTargetMailboxText";
            this.txtTargetMailboxText.Size = new System.Drawing.Size(424, 20);
            this.txtTargetMailboxText.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Results:";
            // 
            // txtTracing
            // 
            this.txtTracing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTracing.BackColor = System.Drawing.Color.Cornsilk;
            this.txtTracing.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTracing.Location = new System.Drawing.Point(7, 169);
            this.txtTracing.Multiline = true;
            this.txtTracing.Name = "txtTracing";
            this.txtTracing.ReadOnly = true;
            this.txtTracing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTracing.Size = new System.Drawing.Size(815, 395);
            this.txtTracing.TabIndex = 79;
            this.txtTracing.DoubleClick += new System.EventHandler(this.txtTracing_DoubleClick);
            // 
            // btnInternalScpLookup
            // 
            this.btnInternalScpLookup.Location = new System.Drawing.Point(610, 64);
            this.btnInternalScpLookup.Name = "btnInternalScpLookup";
            this.btnInternalScpLookup.Size = new System.Drawing.Size(212, 23);
            this.btnInternalScpLookup.TabIndex = 84;
            this.btnInternalScpLookup.Text = "Internal SCP Lookup";
            this.btnInternalScpLookup.UseVisualStyleBackColor = true;
            this.btnInternalScpLookup.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // chkAllowSelfSignedCerts
            // 
            this.chkAllowSelfSignedCerts.AutoSize = true;
            this.chkAllowSelfSignedCerts.Checked = true;
            this.chkAllowSelfSignedCerts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowSelfSignedCerts.Location = new System.Drawing.Point(275, 59);
            this.chkAllowSelfSignedCerts.Name = "chkAllowSelfSignedCerts";
            this.chkAllowSelfSignedCerts.Size = new System.Drawing.Size(133, 17);
            this.chkAllowSelfSignedCerts.TabIndex = 74;
            this.chkAllowSelfSignedCerts.Text = "Allow Self-signed Certs";
            this.chkAllowSelfSignedCerts.UseVisualStyleBackColor = true;
            // 
            // btnAutodiscoverSoap
            // 
            this.btnAutodiscoverSoap.Location = new System.Drawing.Point(610, 122);
            this.btnAutodiscoverSoap.Name = "btnAutodiscoverSoap";
            this.btnAutodiscoverSoap.Size = new System.Drawing.Size(212, 23);
            this.btnAutodiscoverSoap.TabIndex = 86;
            this.btnAutodiscoverSoap.Text = "Autodiscover SOAP";
            this.btnAutodiscoverSoap.UseVisualStyleBackColor = true;
            this.btnAutodiscoverSoap.Click += new System.EventHandler(this.btnAutodiscoverBoth_Click);
            // 
            // btnAutodiscoverPOX
            // 
            this.btnAutodiscoverPOX.Location = new System.Drawing.Point(610, 93);
            this.btnAutodiscoverPOX.Name = "btnAutodiscoverPOX";
            this.btnAutodiscoverPOX.Size = new System.Drawing.Size(212, 23);
            this.btnAutodiscoverPOX.TabIndex = 87;
            this.btnAutodiscoverPOX.Text = "Autodiscover POX";
            this.btnAutodiscoverPOX.UseVisualStyleBackColor = true;
            this.btnAutodiscoverPOX.Click += new System.EventHandler(this.btnAutodiscoverExternal_Click);
            // 
            // chkTraceCertificateInformation
            // 
            this.chkTraceCertificateInformation.AutoSize = true;
            this.chkTraceCertificateInformation.Location = new System.Drawing.Point(275, 83);
            this.chkTraceCertificateInformation.Name = "chkTraceCertificateInformation";
            this.chkTraceCertificateInformation.Size = new System.Drawing.Size(159, 17);
            this.chkTraceCertificateInformation.TabIndex = 88;
            this.chkTraceCertificateInformation.Text = "Trace Certificate Information";
            this.chkTraceCertificateInformation.UseVisualStyleBackColor = true;
            this.chkTraceCertificateInformation.CheckedChanged += new System.EventHandler(this.chkTraceCertificateInformation_CheckedChanged);
            // 
            // AutodisoverRawCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(834, 576);
            this.Controls.Add(this.chkTraceCertificateInformation);
            this.Controls.Add(this.btnAutodiscoverPOX);
            this.Controls.Add(this.btnAutodiscoverSoap);
            this.Controls.Add(this.btnInternalScpLookup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTracing);
            this.Controls.Add(this.chkAllowSelfSignedCerts);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.txtTargetMailboxText);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutodisoverRawCode";
            this.Text = "Autodiscover Raw Code";
            this.Load += new System.EventHandler(this.AutodisoverRawCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.CheckBox chkDefaultWindowsCredentials;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox txtTargetMailboxText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTracing;
        private System.Windows.Forms.Button btnInternalScpLookup;
        private System.Windows.Forms.CheckBox chkAllowSelfSignedCerts;
        private System.Windows.Forms.Button btnAutodiscoverSoap;
        private System.Windows.Forms.Button btnAutodiscoverPOX;
        private System.Windows.Forms.CheckBox chkTraceCertificateInformation;
    }
}
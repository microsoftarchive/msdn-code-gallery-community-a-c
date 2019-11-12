namespace AutodiscoverChecker
{
    partial class AutodiscoverViewerForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.cmboExchangeVersion = new System.Windows.Forms.ComboBox();
            this.chkPreAuthenticate = new System.Windows.Forms.CheckBox();
            this.chkEnableScpLookup = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtTracing = new System.Windows.Forms.TextBox();
            this.txtCerts = new System.Windows.Forms.TextBox();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.txtTargetMailbox = new System.Windows.Forms.TextBox();
            this.btnAutoDiscoverServiceDirect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btnAutodiscoverOffOfServiceObject = new System.Windows.Forms.Button();
            this.chkWorkAroundAddressRedirectIssue = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 128);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.helpProvider1.SetHelpString(this.txtDomain, "Login Domain.  Leave blank for Exchange Online/Office 365.");
            this.txtDomain.Location = new System.Drawing.Point(86, 86);
            this.txtDomain.Name = "txtDomain";
            this.helpProvider1.SetShowHelp(this.txtDomain, true);
            this.txtDomain.Size = new System.Drawing.Size(152, 20);
            this.txtDomain.TabIndex = 48;
            // 
            // chkDefaultWindowsCredentials
            // 
            this.chkDefaultWindowsCredentials.AutoSize = true;
            this.chkDefaultWindowsCredentials.Checked = true;
            this.chkDefaultWindowsCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.helpProvider1.SetHelpString(this.txtUser, "User alias OR SMTP address. SMTP Address needed for Exchange Online/Office 365.");
            this.txtUser.Location = new System.Drawing.Point(86, 35);
            this.txtUser.Name = "txtUser";
            this.helpProvider1.SetShowHelp(this.txtUser, true);
            this.txtUser.Size = new System.Drawing.Size(152, 20);
            this.txtUser.TabIndex = 43;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(86, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 69;
            this.label7.Text = "Exchange Version:";
            // 
            // cmboExchangeVersion
            // 
            this.cmboExchangeVersion.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.cmboExchangeVersion, "Set this to the version of Exchange your going against or to the oldest version i" +
                    "f you don\'t know.");
            this.cmboExchangeVersion.Items.AddRange(new object[] {
            "Exchange2007_SP1",
            "Exchange2010",
            "Exchange2010_SP1",
            "Exchange2010_SP2",
            "Exchange2013"});
            this.cmboExchangeVersion.Location = new System.Drawing.Point(376, 31);
            this.cmboExchangeVersion.Name = "cmboExchangeVersion";
            this.helpProvider1.SetShowHelp(this.cmboExchangeVersion, true);
            this.cmboExchangeVersion.Size = new System.Drawing.Size(121, 21);
            this.cmboExchangeVersion.TabIndex = 68;
            this.cmboExchangeVersion.Text = "Exchange2013";
            this.cmboExchangeVersion.SelectedIndexChanged += new System.EventHandler(this.cmboExchangeVersion_SelectedIndexChanged);
            // 
            // chkPreAuthenticate
            // 
            this.chkPreAuthenticate.AutoSize = true;
            this.chkPreAuthenticate.Checked = true;
            this.chkPreAuthenticate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreAuthenticate.Location = new System.Drawing.Point(272, 90);
            this.chkPreAuthenticate.Name = "chkPreAuthenticate";
            this.chkPreAuthenticate.Size = new System.Drawing.Size(147, 17);
            this.chkPreAuthenticate.TabIndex = 67;
            this.chkPreAuthenticate.Text = "Pre-authenticate requests";
            this.chkPreAuthenticate.UseVisualStyleBackColor = true;
            // 
            // chkEnableScpLookup
            // 
            this.chkEnableScpLookup.AutoSize = true;
            this.chkEnableScpLookup.Checked = true;
            this.chkEnableScpLookup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.helpProvider1.SetHelpString(this.chkEnableScpLookup, "On premis CAS Servers are published in AD and are of the first hit by Autodiscove" +
                    "ry.  Disable the lookup to speed ");
            this.chkEnableScpLookup.Location = new System.Drawing.Point(272, 64);
            this.chkEnableScpLookup.Name = "chkEnableScpLookup";
            this.helpProvider1.SetShowHelp(this.chkEnableScpLookup, true);
            this.chkEnableScpLookup.Size = new System.Drawing.Size(388, 17);
            this.chkEnableScpLookup.TabIndex = 66;
            this.chkEnableScpLookup.Text = "Enable Scp Lookup (Disabling will prevent AD lookup of Autodiscover URLs)";
            this.chkEnableScpLookup.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Tracing:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Certificates:";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.BackColor = System.Drawing.Color.Cornsilk;
            this.txtResults.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.txtResults, "Provided the Autodiscovery Informaiton.  Results are provided on a property-by-pr" +
                    "operty basis rather than XML. ");
            this.txtResults.Location = new System.Drawing.Point(80, 479);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.helpProvider1.SetShowHelp(this.txtResults, true);
            this.txtResults.Size = new System.Drawing.Size(937, 172);
            this.txtResults.TabIndex = 62;
            this.txtResults.DoubleClick += new System.EventHandler(this.txtResults_DoubleClick);
            // 
            // txtTracing
            // 
            this.txtTracing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTracing.BackColor = System.Drawing.Color.Cornsilk;
            this.txtTracing.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.txtTracing, "Provides a trace of http requests and responses.");
            this.txtTracing.Location = new System.Drawing.Point(80, 252);
            this.txtTracing.Multiline = true;
            this.txtTracing.Name = "txtTracing";
            this.txtTracing.ReadOnly = true;
            this.txtTracing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.helpProvider1.SetShowHelp(this.txtTracing, true);
            this.txtTracing.Size = new System.Drawing.Size(937, 221);
            this.txtTracing.TabIndex = 61;
            this.txtTracing.TextChanged += new System.EventHandler(this.txtTracing_TextChanged);
            this.txtTracing.DoubleClick += new System.EventHandler(this.txtTracing_DoubleClick);
            // 
            // txtCerts
            // 
            this.txtCerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCerts.BackColor = System.Drawing.Color.Cornsilk;
            this.txtCerts.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.txtCerts, "Tells you abaout the certificates encountered while doing Autodisovery.");
            this.txtCerts.Location = new System.Drawing.Point(80, 138);
            this.txtCerts.Multiline = true;
            this.txtCerts.Name = "txtCerts";
            this.txtCerts.ReadOnly = true;
            this.txtCerts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.helpProvider1.SetShowHelp(this.txtCerts, true);
            this.txtCerts.Size = new System.Drawing.Size(937, 108);
            this.txtCerts.TabIndex = 60;
            this.txtCerts.TextChanged += new System.EventHandler(this.txtCerts_TextChanged);
            this.txtCerts.DoubleClick += new System.EventHandler(this.txtCerts_DoubleClick);
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(269, 8);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(176, 13);
            this.TargetMailboxLabel.TabIndex = 59;
            this.TargetMailboxLabel.Text = "Settings for Mailbox SMTP Address:";
            // 
            // txtTargetMailbox
            // 
            this.txtTargetMailbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.txtTargetMailbox, "The mailbox being accessed - enter its SMTP address.");
            this.txtTargetMailbox.Location = new System.Drawing.Point(451, 5);
            this.txtTargetMailbox.Name = "txtTargetMailbox";
            this.helpProvider1.SetShowHelp(this.txtTargetMailbox, true);
            this.txtTargetMailbox.Size = new System.Drawing.Size(544, 20);
            this.txtTargetMailbox.TabIndex = 58;
            // 
            // btnAutoDiscoverServiceDirect
            // 
            this.btnAutoDiscoverServiceDirect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.btnAutoDiscoverServiceDirect, "Do Autodiscovery.");
            this.btnAutoDiscoverServiceDirect.Location = new System.Drawing.Point(737, 81);
            this.btnAutoDiscoverServiceDirect.Name = "btnAutoDiscoverServiceDirect";
            this.helpProvider1.SetShowHelp(this.btnAutoDiscoverServiceDirect, true);
            this.btnAutoDiscoverServiceDirect.Size = new System.Drawing.Size(280, 23);
            this.btnAutoDiscoverServiceDirect.TabIndex = 57;
            this.btnAutoDiscoverServiceDirect.Text = "Autodiscover directly against Autodiscover Service";
            this.btnAutoDiscoverServiceDirect.UseVisualStyleBackColor = true;
            this.btnAutoDiscoverServiceDirect.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Results:";
            // 
            // btnAutodiscoverOffOfServiceObject
            // 
            this.btnAutodiscoverOffOfServiceObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.btnAutodiscoverOffOfServiceObject, "Do Autodiscovery.");
            this.btnAutodiscoverOffOfServiceObject.Location = new System.Drawing.Point(737, 107);
            this.btnAutodiscoverOffOfServiceObject.Name = "btnAutodiscoverOffOfServiceObject";
            this.helpProvider1.SetShowHelp(this.btnAutodiscoverOffOfServiceObject, true);
            this.btnAutodiscoverOffOfServiceObject.Size = new System.Drawing.Size(280, 23);
            this.btnAutodiscoverOffOfServiceObject.TabIndex = 73;
            this.btnAutodiscoverOffOfServiceObject.Text = "Autodiscover using Exchange Service Object";
            this.btnAutodiscoverOffOfServiceObject.UseVisualStyleBackColor = true;
            this.btnAutodiscoverOffOfServiceObject.Click += new System.EventHandler(this.btnAutodiscoverOffOfServiceObject_Click);
            // 
            // chkWorkAroundAddressRedirectIssue
            // 
            this.chkWorkAroundAddressRedirectIssue.AutoSize = true;
            this.chkWorkAroundAddressRedirectIssue.Checked = true;
            this.chkWorkAroundAddressRedirectIssue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWorkAroundAddressRedirectIssue.Location = new System.Drawing.Point(272, 113);
            this.chkWorkAroundAddressRedirectIssue.Name = "chkWorkAroundAddressRedirectIssue";
            this.chkWorkAroundAddressRedirectIssue.Size = new System.Drawing.Size(200, 17);
            this.chkWorkAroundAddressRedirectIssue.TabIndex = 74;
            this.chkWorkAroundAddressRedirectIssue.Text = "Work-around Address Redirect Issue";
            this.chkWorkAroundAddressRedirectIssue.UseVisualStyleBackColor = true;
            // 
            // AutodiscoverViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1029, 663);
            this.Controls.Add(this.chkWorkAroundAddressRedirectIssue);
            this.Controls.Add(this.btnAutodiscoverOffOfServiceObject);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmboExchangeVersion);
            this.Controls.Add(this.chkPreAuthenticate);
            this.Controls.Add(this.chkEnableScpLookup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.txtTracing);
            this.Controls.Add(this.txtCerts);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.txtTargetMailbox);
            this.Controls.Add(this.btnAutoDiscoverServiceDirect);
            this.Name = "AutodiscoverViewerForm";
            this.Text = "Exchange Managed API Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmboExchangeVersion;
        private System.Windows.Forms.CheckBox chkPreAuthenticate;
        private System.Windows.Forms.CheckBox chkEnableScpLookup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtTracing;
        private System.Windows.Forms.TextBox txtCerts;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox txtTargetMailbox;
        private System.Windows.Forms.Button btnAutoDiscoverServiceDirect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button btnAutodiscoverOffOfServiceObject;
        private System.Windows.Forms.CheckBox chkWorkAroundAddressRedirectIssue;

    }
}


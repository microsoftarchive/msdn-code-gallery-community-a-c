namespace AutodiscoverChecker
{
    partial class ScpChecker
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
            this.btnAdQueryOnly = new System.Windows.Forms.Button();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.txtTargetMailbox = new System.Windows.Forms.TextBox();
            this.txtAdQueryResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdQueryAndPosts = new System.Windows.Forms.Button();
            this.cmboTimeout = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // btnAdQueryOnly
            // 
            this.btnAdQueryOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.btnAdQueryOnly, "Does AD Query and then does a test  POST to every URL found.  ");
            this.btnAdQueryOnly.Location = new System.Drawing.Point(573, 36);
            this.btnAdQueryOnly.Name = "btnAdQueryOnly";
            this.helpProvider1.SetShowHelp(this.btnAdQueryOnly, true);
            this.btnAdQueryOnly.Size = new System.Drawing.Size(255, 23);
            this.btnAdQueryOnly.TabIndex = 0;
            this.btnAdQueryOnly.Text = "Do AD Query for SCP records Only";
            this.btnAdQueryOnly.UseVisualStyleBackColor = true;
            this.btnAdQueryOnly.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(12, 18);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(176, 13);
            this.TargetMailboxLabel.TabIndex = 75;
            this.TargetMailboxLabel.Text = "Settings for Mailbox SMTP Address:";
            // 
            // txtTargetMailbox
            // 
            this.txtTargetMailbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetMailbox.Location = new System.Drawing.Point(194, 12);
            this.txtTargetMailbox.Name = "txtTargetMailbox";
            this.txtTargetMailbox.Size = new System.Drawing.Size(634, 20);
            this.txtTargetMailbox.TabIndex = 74;
            // 
            // txtAdQueryResults
            // 
            this.txtAdQueryResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdQueryResults.BackColor = System.Drawing.Color.Cornsilk;
            this.txtAdQueryResults.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdQueryResults.Location = new System.Drawing.Point(4, 103);
            this.txtAdQueryResults.Multiline = true;
            this.txtAdQueryResults.Name = "txtAdQueryResults";
            this.txtAdQueryResults.ReadOnly = true;
            this.txtAdQueryResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdQueryResults.Size = new System.Drawing.Size(834, 323);
            this.txtAdQueryResults.TabIndex = 76;
            this.txtAdQueryResults.TextChanged += new System.EventHandler(this.txtAdQueryResults_TextChanged);
            this.txtAdQueryResults.DoubleClick += new System.EventHandler(this.txtAdQueryResults_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Results:";
            // 
            // btnAdQueryAndPosts
            // 
            this.btnAdQueryAndPosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.btnAdQueryAndPosts, "Does AD Query and then does a test  POST to every URL found.  This will take a wh" +
                    "ile to complete. ");
            this.btnAdQueryAndPosts.Location = new System.Drawing.Point(573, 62);
            this.btnAdQueryAndPosts.Name = "btnAdQueryAndPosts";
            this.helpProvider1.SetShowHelp(this.btnAdQueryAndPosts, true);
            this.btnAdQueryAndPosts.Size = new System.Drawing.Size(255, 23);
            this.btnAdQueryAndPosts.TabIndex = 78;
            this.btnAdQueryAndPosts.Text = "Do AD Query for SCP records and do tests POSTs";
            this.btnAdQueryAndPosts.UseVisualStyleBackColor = true;
            this.btnAdQueryAndPosts.Click += new System.EventHandler(this.btnAdQueryAndPosts_Click);
            // 
            // cmboTimeout
            // 
            this.cmboTimeout.FormattingEnabled = true;
            this.cmboTimeout.Location = new System.Drawing.Point(194, 38);
            this.cmboTimeout.Name = "cmboTimeout";
            this.cmboTimeout.Size = new System.Drawing.Size(70, 21);
            this.cmboTimeout.TabIndex = 79;
            this.cmboTimeout.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Post Timeout Seconds:";
            // 
            // ScpChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(840, 438);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboTimeout);
            this.Controls.Add(this.btnAdQueryAndPosts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdQueryResults);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.txtTargetMailbox);
            this.Controls.Add(this.btnAdQueryOnly);
            this.Name = "ScpChecker";
            this.Text = "SCP Checker";
            this.Load += new System.EventHandler(this.ScpChecker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdQueryOnly;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox txtTargetMailbox;
        private System.Windows.Forms.TextBox txtAdQueryResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdQueryAndPosts;
        private System.Windows.Forms.ComboBox cmboTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}
namespace CheckListBoxSimple_C_Sharp
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.txtDemoExt = new System.Windows.Forms.TextBox();
            this.cmdDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(31, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(318, 89);
            this.checkedListBox1.TabIndex = 0;
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Location = new System.Drawing.Point(253, 114);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(63, 21);
            this.chkState.TabIndex = 3;
            this.chkState.Text = "State";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // txtDemoExt
            // 
            this.txtDemoExt.Location = new System.Drawing.Point(138, 113);
            this.txtDemoExt.Name = "txtDemoExt";
            this.txtDemoExt.Size = new System.Drawing.Size(100, 22);
            this.txtDemoExt.TabIndex = 2;
            this.txtDemoExt.Text = "Paul";
            // 
            // cmdDemo
            // 
            this.cmdDemo.Location = new System.Drawing.Point(31, 107);
            this.cmdDemo.Name = "cmdDemo";
            this.cmdDemo.Size = new System.Drawing.Size(92, 34);
            this.cmdDemo.TabIndex = 1;
            this.cmdDemo.Text = "Run";
            this.cmdDemo.UseVisualStyleBackColor = true;
            this.cmdDemo.Click += new System.EventHandler(this.cmdDemo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 163);
            this.Controls.Add(this.chkState);
            this.Controls.Add(this.txtDemoExt);
            this.Controls.Add(this.cmdDemo);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo find in C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        internal System.Windows.Forms.CheckBox chkState;
        internal System.Windows.Forms.TextBox txtDemoExt;
        internal System.Windows.Forms.Button cmdDemo;
    }
}


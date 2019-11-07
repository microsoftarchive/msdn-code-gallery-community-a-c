namespace APIPro
{
    partial class frmAPIPro
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
            this.tmrCursorPos = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblXPos = new System.Windows.Forms.Label();
            this.lblYPos = new System.Windows.Forms.Label();
            this.lblWinText = new System.Windows.Forms.Label();
            this.lblHWnd = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.rtbClassName = new System.Windows.Forms.RichTextBox();
            this.rtbCaption = new System.Windows.Forms.RichTextBox();
            this.lblWinParentCls = new System.Windows.Forms.Label();
            this.rtbWinParent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tmrCursorPos
            // 
            this.tmrCursorPos.Interval = 5;
            this.tmrCursorPos.Tick += new System.EventHandler(this.tmrCursorPos_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(315, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(396, 7);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(16, 12);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(49, 13);
            this.lblXPos.TabIndex = 2;
            this.lblXPos.Text = "Mouse Y";
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(123, 12);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(49, 13);
            this.lblYPos.TabIndex = 3;
            this.lblYPos.Text = "Mouse Y";
            // 
            // lblWinText
            // 
            this.lblWinText.AutoSize = true;
            this.lblWinText.Location = new System.Drawing.Point(16, 74);
            this.lblWinText.Name = "lblWinText";
            this.lblWinText.Size = new System.Drawing.Size(85, 13);
            this.lblWinText.TabIndex = 4;
            this.lblWinText.Text = "Window Caption";
            // 
            // lblHWnd
            // 
            this.lblHWnd.AutoSize = true;
            this.lblHWnd.Location = new System.Drawing.Point(16, 42);
            this.lblHWnd.Name = "lblHWnd";
            this.lblHWnd.Size = new System.Drawing.Size(83, 13);
            this.lblHWnd.TabIndex = 5;
            this.lblHWnd.Text = "Window Handle";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(16, 134);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(105, 13);
            this.lblClassName.TabIndex = 6;
            this.lblClassName.Text = "Window Class Name";
            // 
            // rtbClassName
            // 
            this.rtbClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClassName.Location = new System.Drawing.Point(19, 150);
            this.rtbClassName.Name = "rtbClassName";
            this.rtbClassName.ReadOnly = true;
            this.rtbClassName.Size = new System.Drawing.Size(452, 41);
            this.rtbClassName.TabIndex = 7;
            this.rtbClassName.Text = "";
            // 
            // rtbCaption
            // 
            this.rtbCaption.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCaption.Location = new System.Drawing.Point(19, 90);
            this.rtbCaption.Name = "rtbCaption";
            this.rtbCaption.ReadOnly = true;
            this.rtbCaption.Size = new System.Drawing.Size(452, 41);
            this.rtbCaption.TabIndex = 8;
            this.rtbCaption.Text = "";
            // 
            // lblWinParentCls
            // 
            this.lblWinParentCls.AutoSize = true;
            this.lblWinParentCls.Location = new System.Drawing.Point(19, 198);
            this.lblWinParentCls.Name = "lblWinParentCls";
            this.lblWinParentCls.Size = new System.Drawing.Size(139, 13);
            this.lblWinParentCls.TabIndex = 9;
            this.lblWinParentCls.Text = "Window Parent Class Name";
            // 
            // rtbWinParent
            // 
            this.rtbWinParent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWinParent.Location = new System.Drawing.Point(19, 214);
            this.rtbWinParent.Name = "rtbWinParent";
            this.rtbWinParent.ReadOnly = true;
            this.rtbWinParent.Size = new System.Drawing.Size(452, 41);
            this.rtbWinParent.TabIndex = 10;
            this.rtbWinParent.Text = "";
            // 
            // frmAPIPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 272);
            this.Controls.Add(this.rtbWinParent);
            this.Controls.Add(this.lblWinParentCls);
            this.Controls.Add(this.rtbCaption);
            this.Controls.Add(this.rtbClassName);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.lblHWnd);
            this.Controls.Add(this.lblWinText);
            this.Controls.Add(this.lblYPos);
            this.Controls.Add(this.lblXPos);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "frmAPIPro";
            this.Text = "API Pro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAPIPro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrCursorPos;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.Label lblWinText;
        private System.Windows.Forms.Label lblHWnd;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.RichTextBox rtbClassName;
        private System.Windows.Forms.RichTextBox rtbCaption;
        private System.Windows.Forms.Label lblWinParentCls;
        private System.Windows.Forms.RichTextBox rtbWinParent;
    }
}


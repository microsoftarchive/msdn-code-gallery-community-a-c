namespace GroupBoxEx_Demo
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
            this.groupBoxEx2 = new GroupBoxEx_Demo.GroupBoxEx();
            this.groupBoxEx1 = new GroupBoxEx_Demo.GroupBoxEx();
            this.groupBoxEx3 = new GroupBoxEx_Demo.GroupBoxEx();
            this.groupBoxEx4 = new GroupBoxEx_Demo.GroupBoxEx();
            this.SuspendLayout();
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.BackgroundPanelImage = null;
            this.groupBoxEx2.DrawGroupBorder = true;
            this.groupBoxEx2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEx2.ForeColor = System.Drawing.Color.Lime;
            this.groupBoxEx2.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx2.GroupPanelColor = System.Drawing.Color.Transparent;
            this.groupBoxEx2.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Squared;
            this.groupBoxEx2.Location = new System.Drawing.Point(12, 118);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Size = new System.Drawing.Size(180, 100);
            this.groupBoxEx2.TabIndex = 1;
            this.groupBoxEx2.TabStop = false;
            this.groupBoxEx2.Text = "GroupBoxEx2";
            this.groupBoxEx2.TextBackColor = System.Drawing.Color.Black;
            this.groupBoxEx2.TextBorderColor = System.Drawing.Color.Lime;
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BackgroundPanelImage = null;
            this.groupBoxEx1.DrawGroupBorder = true;
            this.groupBoxEx1.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEx1.ForeColor = System.Drawing.Color.Red;
            this.groupBoxEx1.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx1.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.groupBoxEx1.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Squared;
            this.groupBoxEx1.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(180, 100);
            this.groupBoxEx1.TabIndex = 0;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "GroupBoxEx1";
            this.groupBoxEx1.TextBackColor = System.Drawing.Color.White;
            this.groupBoxEx1.TextBorderColor = System.Drawing.Color.Black;
            // 
            // groupBoxEx3
            // 
            this.groupBoxEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxEx3.BackgroundPanelImage = global::GroupBoxEx_Demo.Properties.Resources.Blue_n_White;
            this.groupBoxEx3.DrawGroupBorder = true;
            this.groupBoxEx3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEx3.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxEx3.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx3.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.groupBoxEx3.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Rounded;
            this.groupBoxEx3.Location = new System.Drawing.Point(208, 12);
            this.groupBoxEx3.Name = "groupBoxEx3";
            this.groupBoxEx3.Size = new System.Drawing.Size(180, 100);
            this.groupBoxEx3.TabIndex = 0;
            this.groupBoxEx3.TabStop = false;
            this.groupBoxEx3.Text = "GroupBoxEx3";
            this.groupBoxEx3.TextBackColor = System.Drawing.Color.White;
            this.groupBoxEx3.TextBorderColor = System.Drawing.Color.Black;
            // 
            // groupBoxEx4
            // 
            this.groupBoxEx4.BackgroundPanelImage = global::GroupBoxEx_Demo.Properties.Resources.RedCircle;
            this.groupBoxEx4.DrawGroupBorder = true;
            this.groupBoxEx4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEx4.ForeColor = System.Drawing.Color.Red;
            this.groupBoxEx4.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx4.GroupPanelColor = System.Drawing.Color.Transparent;
            this.groupBoxEx4.GroupPanelShape = GroupBoxEx_Demo.GroupBoxEx.PanelType.Rounded;
            this.groupBoxEx4.Location = new System.Drawing.Point(208, 118);
            this.groupBoxEx4.Name = "groupBoxEx4";
            this.groupBoxEx4.Size = new System.Drawing.Size(180, 100);
            this.groupBoxEx4.TabIndex = 2;
            this.groupBoxEx4.TabStop = false;
            this.groupBoxEx4.Text = "GroupBoxEx4";
            this.groupBoxEx4.TextBackColor = System.Drawing.Color.Yellow;
            this.groupBoxEx4.TextBorderColor = System.Drawing.Color.Black;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GroupBoxEx_Demo.Properties.Resources.BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 232);
            this.Controls.Add(this.groupBoxEx4);
            this.Controls.Add(this.groupBoxEx3);
            this.Controls.Add(this.groupBoxEx2);
            this.Controls.Add(this.groupBoxEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupBoxEx Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBoxEx groupBoxEx1;
        private GroupBoxEx groupBoxEx2;
        private GroupBoxEx groupBoxEx3;
        private GroupBoxEx groupBoxEx4;
    }
}


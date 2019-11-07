namespace ProgressBarEx_Demo
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
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarEx13 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx12 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx11 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx10 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx9 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx8 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx7 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx6 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx5 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx4 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx3 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx2 = new ProgressBarEx_Demo.ProgressBarEx();
            this.progressBarEx1 = new ProgressBarEx_Demo.ProgressBarEx();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(396, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarEx13
            // 
            this.progressBarEx13.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx13.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.progressBarEx13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx13.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Bottom;
            this.progressBarEx13.Image = null;
            this.progressBarEx13.Location = new System.Drawing.Point(173, 56);
            this.progressBarEx13.Margin = new System.Windows.Forms.Padding(0);
            this.progressBarEx13.Name = "progressBarEx13";
            this.progressBarEx13.ProgressColor = System.Drawing.Color.Goldenrod;
            this.progressBarEx13.ProgressDirection = ProgressBarEx_Demo.ProgressBarEx.ProgressDir.Vertical;
            this.progressBarEx13.RoundedCorners = false;
            this.progressBarEx13.Size = new System.Drawing.Size(23, 199);
            this.progressBarEx13.Text = "progressBarEx13";
            this.progressBarEx13.Value = 72;
            // 
            // progressBarEx12
            // 
            this.progressBarEx12.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx12.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.progressBarEx12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx12.Image = null;
            this.progressBarEx12.Location = new System.Drawing.Point(196, 56);
            this.progressBarEx12.Margin = new System.Windows.Forms.Padding(0);
            this.progressBarEx12.Name = "progressBarEx12";
            this.progressBarEx12.ProgressColor = System.Drawing.Color.Goldenrod;
            this.progressBarEx12.ProgressDirection = ProgressBarEx_Demo.ProgressBarEx.ProgressDir.Vertical;
            this.progressBarEx12.RoundedCorners = false;
            this.progressBarEx12.Size = new System.Drawing.Size(23, 199);
            this.progressBarEx12.Text = "progressBarEx12";
            this.progressBarEx12.Value = 60;
            // 
            // progressBarEx11
            // 
            this.progressBarEx11.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx11.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBarEx11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx11.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx11.Image = global::ProgressBarEx_Demo.Properties.Resources.SavetoFolder2;
            this.progressBarEx11.ImageLayout = ProgressBarEx_Demo.ProgressBarEx.ImageLayoutType.Center;
            this.progressBarEx11.Location = new System.Drawing.Point(108, 88);
            this.progressBarEx11.Name = "progressBarEx11";
            this.progressBarEx11.ProgressColor = System.Drawing.Color.Black;
            this.progressBarEx11.ProgressDirection = ProgressBarEx_Demo.ProgressBarEx.ProgressDir.Vertical;
            this.progressBarEx11.Size = new System.Drawing.Size(48, 167);
            this.progressBarEx11.Text = "progressBarEx11";
            this.progressBarEx11.Value = 78;
            // 
            // progressBarEx10
            // 
            this.progressBarEx10.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx10.Border = false;
            this.progressBarEx10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx10.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx10.Image = null;
            this.progressBarEx10.Location = new System.Drawing.Point(54, 88);
            this.progressBarEx10.Name = "progressBarEx10";
            this.progressBarEx10.ProgressDirection = ProgressBarEx_Demo.ProgressBarEx.ProgressDir.Vertical;
            this.progressBarEx10.ShowPercentage = true;
            this.progressBarEx10.Size = new System.Drawing.Size(36, 167);
            this.progressBarEx10.Text = "progressBarEx10";
            this.progressBarEx10.Value = 75;
            // 
            // progressBarEx9
            // 
            this.progressBarEx9.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx9.Border = false;
            this.progressBarEx9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx9.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx9.Image = null;
            this.progressBarEx9.Location = new System.Drawing.Point(12, 88);
            this.progressBarEx9.Name = "progressBarEx9";
            this.progressBarEx9.ProgressColor = System.Drawing.Color.Red;
            this.progressBarEx9.ProgressDirection = ProgressBarEx_Demo.ProgressBarEx.ProgressDir.Vertical;
            this.progressBarEx9.ShowPercentage = true;
            this.progressBarEx9.Size = new System.Drawing.Size(36, 167);
            this.progressBarEx9.Text = "progressBarEx9";
            this.progressBarEx9.Value = 50;
            // 
            // progressBarEx8
            // 
            this.progressBarEx8.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx8.BackgroundColor = System.Drawing.Color.Black;
            this.progressBarEx8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx8.ForeColor = System.Drawing.Color.White;
            this.progressBarEx8.GradiantColor = System.Drawing.Color.Cyan;
            this.progressBarEx8.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx8.Image = null;
            this.progressBarEx8.Location = new System.Drawing.Point(241, 232);
            this.progressBarEx8.Name = "progressBarEx8";
            this.progressBarEx8.ProgressColor = System.Drawing.Color.Blue;
            this.progressBarEx8.Size = new System.Drawing.Size(149, 23);
            this.progressBarEx8.Text = "progressBarEx8";
            // 
            // progressBarEx7
            // 
            this.progressBarEx7.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx7.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx7.Image = global::ProgressBarEx_Demo.Properties.Resources.SavetoFolder2;
            this.progressBarEx7.ImageLayout = ProgressBarEx_Demo.ProgressBarEx.ImageLayoutType.Center;
            this.progressBarEx7.Location = new System.Drawing.Point(241, 175);
            this.progressBarEx7.Name = "progressBarEx7";
            this.progressBarEx7.ProgressColor = System.Drawing.Color.Blue;
            this.progressBarEx7.Size = new System.Drawing.Size(200, 35);
            this.progressBarEx7.Text = "progressBarEx7";
            this.progressBarEx7.Value = 76;
            // 
            // progressBarEx6
            // 
            this.progressBarEx6.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx6.BackgroundColor = System.Drawing.Color.Plum;
            this.progressBarEx6.Border = false;
            this.progressBarEx6.Image = null;
            this.progressBarEx6.Location = new System.Drawing.Point(241, 131);
            this.progressBarEx6.Name = "progressBarEx6";
            this.progressBarEx6.ProgressColor = System.Drawing.Color.DarkViolet;
            this.progressBarEx6.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx6.Text = "progressBarEx6";
            this.progressBarEx6.Value = 42;
            // 
            // progressBarEx5
            // 
            this.progressBarEx5.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx5.BackgroundColor = System.Drawing.Color.White;
            this.progressBarEx5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx5.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.None;
            this.progressBarEx5.Image = null;
            this.progressBarEx5.Location = new System.Drawing.Point(242, 88);
            this.progressBarEx5.Name = "progressBarEx5";
            this.progressBarEx5.ProgressColor = System.Drawing.Color.Aqua;
            this.progressBarEx5.ShowText = true;
            this.progressBarEx5.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx5.Text = "Loading...";
            this.progressBarEx5.Value = 44;
            // 
            // progressBarEx4
            // 
            this.progressBarEx4.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx4.BackgroundColor = System.Drawing.Color.Tan;
            this.progressBarEx4.BorderColor = System.Drawing.Color.Red;
            this.progressBarEx4.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Center;
            this.progressBarEx4.Image = null;
            this.progressBarEx4.Location = new System.Drawing.Point(241, 50);
            this.progressBarEx4.Name = "progressBarEx4";
            this.progressBarEx4.ProgressColor = System.Drawing.Color.Red;
            this.progressBarEx4.Size = new System.Drawing.Size(200, 23);
            this.progressBarEx4.Text = "progressBarEx4";
            this.progressBarEx4.Value = 18;
            // 
            // progressBarEx3
            // 
            this.progressBarEx3.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx3.ForeColor = System.Drawing.Color.Blue;
            this.progressBarEx3.GradiantColor = System.Drawing.Color.LemonChiffon;
            this.progressBarEx3.GradiantPosition = ProgressBarEx_Demo.ProgressBarEx.GradiantArea.Bottom;
            this.progressBarEx3.Image = null;
            this.progressBarEx3.Location = new System.Drawing.Point(12, 12);
            this.progressBarEx3.Name = "progressBarEx3";
            this.progressBarEx3.ProgressColor = System.Drawing.Color.Yellow;
            this.progressBarEx3.RoundedCorners = false;
            this.progressBarEx3.ShowPercentage = true;
            this.progressBarEx3.Size = new System.Drawing.Size(134, 33);
            this.progressBarEx3.Text = "progressBarEx3";
            this.progressBarEx3.Value = 28;
            // 
            // progressBarEx2
            // 
            this.progressBarEx2.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx2.Image = null;
            this.progressBarEx2.Location = new System.Drawing.Point(12, 52);
            this.progressBarEx2.Name = "progressBarEx2";
            this.progressBarEx2.ProgressColor = System.Drawing.Color.Orange;
            this.progressBarEx2.ShowPercentage = true;
            this.progressBarEx2.Size = new System.Drawing.Size(134, 17);
            this.progressBarEx2.Text = "progressBarEx2";
            this.progressBarEx2.Value = 33;
            // 
            // progressBarEx1
            // 
            this.progressBarEx1.BackColor = System.Drawing.Color.Transparent;
            this.progressBarEx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarEx1.Image = null;
            this.progressBarEx1.Location = new System.Drawing.Point(166, 12);
            this.progressBarEx1.Name = "progressBarEx1";
            this.progressBarEx1.ShowPercentage = true;
            this.progressBarEx1.ShowText = true;
            this.progressBarEx1.Size = new System.Drawing.Size(276, 23);
            this.progressBarEx1.Text = "Progress - ";
            this.progressBarEx1.Value = 64;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 268);
            this.Controls.Add(this.progressBarEx13);
            this.Controls.Add(this.progressBarEx12);
            this.Controls.Add(this.progressBarEx11);
            this.Controls.Add(this.progressBarEx10);
            this.Controls.Add(this.progressBarEx9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBarEx8);
            this.Controls.Add(this.progressBarEx7);
            this.Controls.Add(this.progressBarEx6);
            this.Controls.Add(this.progressBarEx5);
            this.Controls.Add(this.progressBarEx4);
            this.Controls.Add(this.progressBarEx3);
            this.Controls.Add(this.progressBarEx2);
            this.Controls.Add(this.progressBarEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ProgressBarEx Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBarEx progressBarEx1;
        private ProgressBarEx progressBarEx2;
        private ProgressBarEx progressBarEx3;
        private ProgressBarEx progressBarEx4;
        private ProgressBarEx progressBarEx5;
        private ProgressBarEx progressBarEx6;
        private ProgressBarEx progressBarEx7;
        private ProgressBarEx progressBarEx8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private ProgressBarEx progressBarEx9;
        private ProgressBarEx progressBarEx10;
        private ProgressBarEx progressBarEx11;
        private ProgressBarEx progressBarEx12;
        private ProgressBarEx progressBarEx13;
    }
}


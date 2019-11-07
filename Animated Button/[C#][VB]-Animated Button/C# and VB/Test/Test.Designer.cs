namespace Test
{
    partial class Test
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
            this.animatedButton1 = new Animate.AnimatedButton();
            this.animatedButton2 = new Animated_Button_VB.AnimatedButton();
            this.SuspendLayout();
            // 
            // animatedButton1
            // 
            this.animatedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.animatedButton1.ForeColor = System.Drawing.Color.White;
            this.animatedButton1.Location = new System.Drawing.Point(12, 12);
            this.animatedButton1.Name = "animatedButton1";
            this.animatedButton1.Size = new System.Drawing.Size(100, 30);
            this.animatedButton1.TabIndex = 0;
            this.animatedButton1.Text = "C#";
            this.animatedButton1.UseVisualStyleBackColor = true;
            // 
            // animatedButton2
            // 
            this.animatedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.animatedButton2.ForeColor = System.Drawing.Color.White;
            this.animatedButton2.Location = new System.Drawing.Point(12, 48);
            this.animatedButton2.Name = "animatedButton2";
            this.animatedButton2.Size = new System.Drawing.Size(100, 30);
            this.animatedButton2.TabIndex = 1;
            this.animatedButton2.Text = "VB";
            this.animatedButton2.UseVisualStyleBackColor = true;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 90);
            this.Controls.Add(this.animatedButton2);
            this.Controls.Add(this.animatedButton1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Animate.AnimatedButton animatedButton1;
        private Animated_Button_VB.AnimatedButton animatedButton2;

    }
}
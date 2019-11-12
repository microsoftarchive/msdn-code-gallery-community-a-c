using System.Globalization;
using CloseApplicationAfterLastFormClosed.Properties;

namespace CloseApplicationAfterLastFormClosed
{
    partial class ExampleForm
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
            this.OpenNewWindowsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenNewWindowsButton
            // 
            this.OpenNewWindowsButton.Location = new System.Drawing.Point(13, 13);
            this.OpenNewWindowsButton.Name = "OpenNewWindowsButton";
            this.OpenNewWindowsButton.Size = new System.Drawing.Size(169, 23);
            this.OpenNewWindowsButton.TabIndex = 0;
            this.OpenNewWindowsButton.Text = Resources.NewWindowButtonText;
            this.OpenNewWindowsButton.UseVisualStyleBackColor = true;
            this.OpenNewWindowsButton.Click += new System.EventHandler(this.OnOpenNewWindowButtonClick);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 48);
            this.Controls.Add(this.OpenNewWindowsButton);
            this.Name = "ExampleForm";
            this.Text = string.Format(CultureInfo.CurrentCulture, Resources.FormTitle, 0);
            this.Load += new System.EventHandler(this.OnExampleFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenNewWindowsButton;
    }
}


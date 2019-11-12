namespace AirportStatus.Demo.Solution.Client
{
    partial class AirportStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirportStatusForm));
            this.comboBoxAirports = new System.Windows.Forms.ComboBox();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.groupBoxStatusAirport = new System.Windows.Forms.GroupBox();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.labelStateText = new System.Windows.Forms.Label();
            this.labelCityText = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.groupBoxWeather = new System.Windows.Forms.GroupBox();
            this.labelWind = new System.Windows.Forms.Label();
            this.labelTemprature = new System.Windows.Forms.Label();
            this.labelVisibility = new System.Windows.Forms.Label();
            this.pictureBoxWeather = new System.Windows.Forms.PictureBox();
            this.pictureBoxAirport = new System.Windows.Forms.PictureBox();
            this.labelVisibilityText = new System.Windows.Forms.Label();
            this.labelTempratureText = new System.Windows.Forms.Label();
            this.labelWindText = new System.Windows.Forms.Label();
            this.groupBoxStatusAirport.SuspendLayout();
            this.groupBoxWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeather)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAirport)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxAirports
            // 
            this.comboBoxAirports.FormattingEnabled = true;
            this.comboBoxAirports.Location = new System.Drawing.Point(42, 26);
            this.comboBoxAirports.Name = "comboBoxAirports";
            this.comboBoxAirports.Size = new System.Drawing.Size(270, 21);
            this.comboBoxAirports.TabIndex = 0;
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(332, 26);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonStatus.TabIndex = 1;
            this.buttonStatus.Text = "&Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // groupBoxStatusAirport
            // 
            this.groupBoxStatusAirport.Controls.Add(this.pictureBoxAirport);
            this.groupBoxStatusAirport.Controls.Add(this.labelStatusText);
            this.groupBoxStatusAirport.Controls.Add(this.labelStateText);
            this.groupBoxStatusAirport.Controls.Add(this.labelCityText);
            this.groupBoxStatusAirport.Controls.Add(this.labelCity);
            this.groupBoxStatusAirport.Controls.Add(this.labelStatus);
            this.groupBoxStatusAirport.Controls.Add(this.labelState);
            this.groupBoxStatusAirport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStatusAirport.Location = new System.Drawing.Point(42, 80);
            this.groupBoxStatusAirport.Name = "groupBoxStatusAirport";
            this.groupBoxStatusAirport.Size = new System.Drawing.Size(365, 100);
            this.groupBoxStatusAirport.TabIndex = 6;
            this.groupBoxStatusAirport.TabStop = false;
            this.groupBoxStatusAirport.Text = "Status Airport";
            // 
            // labelStatusText
            // 
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusText.Location = new System.Drawing.Point(136, 71);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(10, 13);
            this.labelStatusText.TabIndex = 11;
            this.labelStatusText.Text = "-";
            // 
            // labelStateText
            // 
            this.labelStateText.AutoSize = true;
            this.labelStateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStateText.Location = new System.Drawing.Point(137, 43);
            this.labelStateText.Name = "labelStateText";
            this.labelStateText.Size = new System.Drawing.Size(10, 13);
            this.labelStateText.TabIndex = 10;
            this.labelStateText.Text = "-";
            // 
            // labelCityText
            // 
            this.labelCityText.AutoSize = true;
            this.labelCityText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCityText.Location = new System.Drawing.Point(137, 19);
            this.labelCityText.Name = "labelCityText";
            this.labelCityText.Size = new System.Drawing.Size(10, 13);
            this.labelCityText.TabIndex = 9;
            this.labelCityText.Text = "-";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCity.Location = new System.Drawing.Point(94, 19);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(36, 13);
            this.labelCity.TabIndex = 8;
            this.labelCity.Text = "City :";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(79, 71);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(51, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status :";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.Location = new System.Drawing.Point(86, 43);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(45, 13);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "State :";
            // 
            // groupBoxWeather
            // 
            this.groupBoxWeather.Controls.Add(this.labelVisibilityText);
            this.groupBoxWeather.Controls.Add(this.labelTempratureText);
            this.groupBoxWeather.Controls.Add(this.labelWindText);
            this.groupBoxWeather.Controls.Add(this.pictureBoxWeather);
            this.groupBoxWeather.Controls.Add(this.labelVisibility);
            this.groupBoxWeather.Controls.Add(this.labelTemprature);
            this.groupBoxWeather.Controls.Add(this.labelWind);
            this.groupBoxWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxWeather.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxWeather.Location = new System.Drawing.Point(42, 201);
            this.groupBoxWeather.Name = "groupBoxWeather";
            this.groupBoxWeather.Size = new System.Drawing.Size(365, 111);
            this.groupBoxWeather.TabIndex = 7;
            this.groupBoxWeather.TabStop = false;
            this.groupBoxWeather.Text = "Weather";
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.Location = new System.Drawing.Point(104, 28);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(44, 13);
            this.labelWind.TabIndex = 0;
            this.labelWind.Text = "Wind :";
            // 
            // labelTemprature
            // 
            this.labelTemprature.AutoSize = true;
            this.labelTemprature.Location = new System.Drawing.Point(69, 54);
            this.labelTemprature.Name = "labelTemprature";
            this.labelTemprature.Size = new System.Drawing.Size(79, 13);
            this.labelTemprature.TabIndex = 1;
            this.labelTemprature.Text = "Temprature :";
            // 
            // labelVisibility
            // 
            this.labelVisibility.AutoSize = true;
            this.labelVisibility.Location = new System.Drawing.Point(86, 79);
            this.labelVisibility.Name = "labelVisibility";
            this.labelVisibility.Size = new System.Drawing.Size(61, 13);
            this.labelVisibility.TabIndex = 2;
            this.labelVisibility.Text = "Visibility :";
            // 
            // pictureBoxWeather
            // 
            this.pictureBoxWeather.ErrorImage = null;
            this.pictureBoxWeather.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWeather.Image")));
            this.pictureBoxWeather.Location = new System.Drawing.Point(12, 31);
            this.pictureBoxWeather.Name = "pictureBoxWeather";
            this.pictureBoxWeather.Size = new System.Drawing.Size(51, 51);
            this.pictureBoxWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxWeather.TabIndex = 3;
            this.pictureBoxWeather.TabStop = false;
            // 
            // pictureBoxAirport
            // 
            this.pictureBoxAirport.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAirport.Image")));
            this.pictureBoxAirport.Location = new System.Drawing.Point(12, 20);
            this.pictureBoxAirport.Name = "pictureBoxAirport";
            this.pictureBoxAirport.Size = new System.Drawing.Size(51, 50);
            this.pictureBoxAirport.TabIndex = 12;
            this.pictureBoxAirport.TabStop = false;
            // 
            // labelVisibilityText
            // 
            this.labelVisibilityText.AutoSize = true;
            this.labelVisibilityText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisibilityText.Location = new System.Drawing.Point(155, 80);
            this.labelVisibilityText.Name = "labelVisibilityText";
            this.labelVisibilityText.Size = new System.Drawing.Size(10, 13);
            this.labelVisibilityText.TabIndex = 14;
            this.labelVisibilityText.Text = "-";
            // 
            // labelTempratureText
            // 
            this.labelTempratureText.AutoSize = true;
            this.labelTempratureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempratureText.Location = new System.Drawing.Point(154, 55);
            this.labelTempratureText.Name = "labelTempratureText";
            this.labelTempratureText.Size = new System.Drawing.Size(10, 13);
            this.labelTempratureText.TabIndex = 13;
            this.labelTempratureText.Text = "-";
            // 
            // labelWindText
            // 
            this.labelWindText.AutoSize = true;
            this.labelWindText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWindText.Location = new System.Drawing.Point(155, 28);
            this.labelWindText.Name = "labelWindText";
            this.labelWindText.Size = new System.Drawing.Size(10, 13);
            this.labelWindText.TabIndex = 12;
            this.labelWindText.Text = "-";
            // 
            // AirportStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 324);
            this.Controls.Add(this.groupBoxWeather);
            this.Controls.Add(this.groupBoxStatusAirport);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.comboBoxAirports);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AirportStatusForm";
            this.Text = "Airport";
            this.groupBoxStatusAirport.ResumeLayout(false);
            this.groupBoxStatusAirport.PerformLayout();
            this.groupBoxWeather.ResumeLayout(false);
            this.groupBoxWeather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeather)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAirport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAirports;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.GroupBox groupBoxStatusAirport;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Label labelStateText;
        private System.Windows.Forms.Label labelCityText;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.GroupBox groupBoxWeather;
        private System.Windows.Forms.Label labelVisibility;
        private System.Windows.Forms.Label labelTemprature;
        private System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.PictureBox pictureBoxWeather;
        private System.Windows.Forms.PictureBox pictureBoxAirport;
        private System.Windows.Forms.Label labelVisibilityText;
        private System.Windows.Forms.Label labelTempratureText;
        private System.Windows.Forms.Label labelWindText;

    }
}


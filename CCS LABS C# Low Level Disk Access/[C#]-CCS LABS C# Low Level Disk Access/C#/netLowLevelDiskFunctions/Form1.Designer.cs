namespace netLowLevelDiskFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.lbDriveList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBytesPerSector = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSectors = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHash = new System.Windows.Forms.Label();
            this.timerSeconds = new System.Windows.Forms.Timer(this.components);
            this.lblSectorsPerSecond = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTracks = new System.Windows.Forms.CheckBox();
            this.lblTracksPerSecond = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTrack = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalTracks = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBytesPerTrack = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.tbTrackBufferSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.progressPie = new Nexus.Windows.Forms.PieChart();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(499, 203);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbDriveList
            // 
            this.lbDriveList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDriveList.FormattingEnabled = true;
            this.lbDriveList.Location = new System.Drawing.Point(12, 209);
            this.lbDriveList.Name = "lbDriveList";
            this.lbDriveList.Size = new System.Drawing.Size(120, 17);
            this.lbDriveList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bytes Per Sector:";
            // 
            // lblBytesPerSector
            // 
            this.lblBytesPerSector.AutoSize = true;
            this.lblBytesPerSector.Location = new System.Drawing.Point(121, 22);
            this.lblBytesPerSector.Name = "lblBytesPerSector";
            this.lblBytesPerSector.Size = new System.Drawing.Size(13, 13);
            this.lblBytesPerSector.TabIndex = 5;
            this.lblBytesPerSector.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Sectors:";
            // 
            // lblTotalSectors
            // 
            this.lblTotalSectors.AutoSize = true;
            this.lblTotalSectors.Location = new System.Drawing.Point(121, 35);
            this.lblTotalSectors.Name = "lblTotalSectors";
            this.lblTotalSectors.Size = new System.Drawing.Size(13, 13);
            this.lblTotalSectors.TabIndex = 7;
            this.lblTotalSectors.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sector:";
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Location = new System.Drawing.Point(121, 48);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(13, 13);
            this.lblSector.TabIndex = 9;
            this.lblSector.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sector Hash:";
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHash.Location = new System.Drawing.Point(121, 9);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(12, 12);
            this.lblHash.TabIndex = 11;
            this.lblHash.Text = "0";
            // 
            // timerSeconds
            // 
            this.timerSeconds.Interval = 1000;
            this.timerSeconds.Tick += new System.EventHandler(this.timerSeconds_Tick);
            // 
            // lblSectorsPerSecond
            // 
            this.lblSectorsPerSecond.AutoSize = true;
            this.lblSectorsPerSecond.Location = new System.Drawing.Point(121, 61);
            this.lblSectorsPerSecond.Name = "lblSectorsPerSecond";
            this.lblSectorsPerSecond.Size = new System.Drawing.Size(13, 13);
            this.lblSectorsPerSecond.TabIndex = 13;
            this.lblSectorsPerSecond.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sectors per Second:";
            // 
            // cbTracks
            // 
            this.cbTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTracks.AutoSize = true;
            this.cbTracks.Location = new System.Drawing.Point(12, 186);
            this.cbTracks.Name = "cbTracks";
            this.cbTracks.Size = new System.Drawing.Size(59, 17);
            this.cbTracks.TabIndex = 14;
            this.cbTracks.Text = "Tracks";
            this.cbTracks.UseVisualStyleBackColor = true;
            // 
            // lblTracksPerSecond
            // 
            this.lblTracksPerSecond.AutoSize = true;
            this.lblTracksPerSecond.Location = new System.Drawing.Point(322, 61);
            this.lblTracksPerSecond.Name = "lblTracksPerSecond";
            this.lblTracksPerSecond.Size = new System.Drawing.Size(13, 13);
            this.lblTracksPerSecond.TabIndex = 22;
            this.lblTracksPerSecond.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tracks per Second:";
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(322, 48);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(13, 13);
            this.lblTrack.TabIndex = 20;
            this.lblTrack.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Track:";
            // 
            // lblTotalTracks
            // 
            this.lblTotalTracks.AutoSize = true;
            this.lblTotalTracks.Location = new System.Drawing.Point(322, 35);
            this.lblTotalTracks.Name = "lblTotalTracks";
            this.lblTotalTracks.Size = new System.Drawing.Size(13, 13);
            this.lblTotalTracks.TabIndex = 18;
            this.lblTotalTracks.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Total Tracks:";
            // 
            // lblBytesPerTrack
            // 
            this.lblBytesPerTrack.AutoSize = true;
            this.lblBytesPerTrack.Location = new System.Drawing.Point(322, 22);
            this.lblBytesPerTrack.Name = "lblBytesPerTrack";
            this.lblBytesPerTrack.Size = new System.Drawing.Size(13, 13);
            this.lblBytesPerTrack.TabIndex = 16;
            this.lblBytesPerTrack.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Bytes Per Track:";
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(0, 232);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(586, 10);
            this.progress.Step = 1;
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Percentage:";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(210, 185);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(13, 13);
            this.lblPercentage.TabIndex = 26;
            this.lblPercentage.Text = "0";
            // 
            // tbTrackBufferSize
            // 
            this.tbTrackBufferSize.Location = new System.Drawing.Point(75, 155);
            this.tbTrackBufferSize.Name = "tbTrackBufferSize";
            this.tbTrackBufferSize.Size = new System.Drawing.Size(57, 20);
            this.tbTrackBufferSize.TabIndex = 27;
            this.tbTrackBufferSize.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Track Buffer Size";
            // 
            // progressPie
            // 
            this.progressPie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPie.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.progressPie.Location = new System.Drawing.Point(381, 22);
            this.progressPie.Name = "progressPie";
            this.progressPie.Radius = 200F;
            this.progressPie.Size = new System.Drawing.Size(193, 173);
            this.progressPie.TabIndex = 29;
            this.progressPie.Text = "pieChart1";
            this.progressPie.Thickness = 10F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 242);
            this.Controls.Add(this.progressPie);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTrackBufferSize);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblTracksPerSecond);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalTracks);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblBytesPerTrack);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbTracks);
            this.Controls.Add(this.lblSectorsPerSecond);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalSectors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBytesPerSector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDriveList);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Low Level Disk Drive Live Imager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbDriveList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBytesPerSector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSectors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Timer timerSeconds;
        private System.Windows.Forms.Label lblSectorsPerSecond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbTracks;
        private System.Windows.Forms.Label lblTracksPerSecond;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalTracks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBytesPerTrack;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.TextBox tbTrackBufferSize;
        private System.Windows.Forms.Label label8;
        private Nexus.Windows.Forms.PieChart progressPie;
    }
}


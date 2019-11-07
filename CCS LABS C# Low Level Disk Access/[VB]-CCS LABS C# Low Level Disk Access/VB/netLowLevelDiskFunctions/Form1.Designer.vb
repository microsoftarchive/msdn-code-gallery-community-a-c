Namespace netLowLevelDiskFunctions
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.btnStart = New System.Windows.Forms.Button()
			Me.lbDriveList = New System.Windows.Forms.ListBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.lblBytesPerSector = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.lblTotalSectors = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.lblSector = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.lblHash = New System.Windows.Forms.Label()
			Me.timerSeconds = New System.Windows.Forms.Timer(Me.components)
			Me.lblSectorsPerSecond = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.cbTracks = New System.Windows.Forms.CheckBox()
			Me.lblTracksPerSecond = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.lblTrack = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.lblTotalTracks = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.lblBytesPerTrack = New System.Windows.Forms.Label()
			Me.label13 = New System.Windows.Forms.Label()
			Me.progress = New System.Windows.Forms.ProgressBar()
			Me.label5 = New System.Windows.Forms.Label()
			Me.lblPercentage = New System.Windows.Forms.Label()
			Me.tbTrackBufferSize = New System.Windows.Forms.TextBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.progressPie = New Nexus.Windows.Forms.PieChart()
			Me.SuspendLayout()
			' 
			' btnStart
			' 
			Me.btnStart.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnStart.Location = New System.Drawing.Point(499, 203)
			Me.btnStart.Name = "btnStart"
			Me.btnStart.Size = New System.Drawing.Size(75, 23)
			Me.btnStart.TabIndex = 0
			Me.btnStart.Text = "Start"
			Me.btnStart.UseVisualStyleBackColor = True
'			Me.btnStart.Click += New System.EventHandler(Me.btnStart_Click)
			' 
			' lbDriveList
			' 
			Me.lbDriveList.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.lbDriveList.FormattingEnabled = True
			Me.lbDriveList.Location = New System.Drawing.Point(12, 209)
			Me.lbDriveList.Name = "lbDriveList"
			Me.lbDriveList.Size = New System.Drawing.Size(120, 17)
			Me.lbDriveList.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(24, 22)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(89, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Bytes Per Sector:"
			' 
			' lblBytesPerSector
			' 
			Me.lblBytesPerSector.AutoSize = True
			Me.lblBytesPerSector.Location = New System.Drawing.Point(121, 22)
			Me.lblBytesPerSector.Name = "lblBytesPerSector"
			Me.lblBytesPerSector.Size = New System.Drawing.Size(13, 13)
			Me.lblBytesPerSector.TabIndex = 5
			Me.lblBytesPerSector.Text = "0"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(40, 35)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(73, 13)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Total Sectors:"
			' 
			' lblTotalSectors
			' 
			Me.lblTotalSectors.AutoSize = True
			Me.lblTotalSectors.Location = New System.Drawing.Point(121, 35)
			Me.lblTotalSectors.Name = "lblTotalSectors"
			Me.lblTotalSectors.Size = New System.Drawing.Size(13, 13)
			Me.lblTotalSectors.TabIndex = 7
			Me.lblTotalSectors.Text = "0"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(72, 48)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(41, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Sector:"
			' 
			' lblSector
			' 
			Me.lblSector.AutoSize = True
			Me.lblSector.Location = New System.Drawing.Point(121, 48)
			Me.lblSector.Name = "lblSector"
			Me.lblSector.Size = New System.Drawing.Size(13, 13)
			Me.lblSector.TabIndex = 9
			Me.lblSector.Text = "0"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(44, 9)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(69, 13)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Sector Hash:"
			' 
			' lblHash
			' 
			Me.lblHash.AutoSize = True
			Me.lblHash.Font = New System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lblHash.Location = New System.Drawing.Point(121, 9)
			Me.lblHash.Name = "lblHash"
			Me.lblHash.Size = New System.Drawing.Size(12, 12)
			Me.lblHash.TabIndex = 11
			Me.lblHash.Text = "0"
			' 
			' timerSeconds
			' 
			Me.timerSeconds.Interval = 1000
'			Me.timerSeconds.Tick += New System.EventHandler(Me.timerSeconds_Tick)
			' 
			' lblSectorsPerSecond
			' 
			Me.lblSectorsPerSecond.AutoSize = True
			Me.lblSectorsPerSecond.Location = New System.Drawing.Point(121, 61)
			Me.lblSectorsPerSecond.Name = "lblSectorsPerSecond"
			Me.lblSectorsPerSecond.Size = New System.Drawing.Size(13, 13)
			Me.lblSectorsPerSecond.TabIndex = 13
			Me.lblSectorsPerSecond.Text = "0"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(9, 61)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(104, 13)
			Me.label6.TabIndex = 12
			Me.label6.Text = "Sectors per Second:"
			' 
			' cbTracks
			' 
			Me.cbTracks.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.cbTracks.AutoSize = True
			Me.cbTracks.Location = New System.Drawing.Point(12, 186)
			Me.cbTracks.Name = "cbTracks"
			Me.cbTracks.Size = New System.Drawing.Size(59, 17)
			Me.cbTracks.TabIndex = 14
			Me.cbTracks.Text = "Tracks"
			Me.cbTracks.UseVisualStyleBackColor = True
			' 
			' lblTracksPerSecond
			' 
			Me.lblTracksPerSecond.AutoSize = True
			Me.lblTracksPerSecond.Location = New System.Drawing.Point(322, 61)
			Me.lblTracksPerSecond.Name = "lblTracksPerSecond"
			Me.lblTracksPerSecond.Size = New System.Drawing.Size(13, 13)
			Me.lblTracksPerSecond.TabIndex = 22
			Me.lblTracksPerSecond.Text = "0"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(210, 61)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(101, 13)
			Me.label7.TabIndex = 21
			Me.label7.Text = "Tracks per Second:"
			' 
			' lblTrack
			' 
			Me.lblTrack.AutoSize = True
			Me.lblTrack.Location = New System.Drawing.Point(322, 48)
			Me.lblTrack.Name = "lblTrack"
			Me.lblTrack.Size = New System.Drawing.Size(13, 13)
			Me.lblTrack.TabIndex = 20
			Me.lblTrack.Text = "0"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(273, 48)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(38, 13)
			Me.label9.TabIndex = 19
			Me.label9.Text = "Track:"
			' 
			' lblTotalTracks
			' 
			Me.lblTotalTracks.AutoSize = True
			Me.lblTotalTracks.Location = New System.Drawing.Point(322, 35)
			Me.lblTotalTracks.Name = "lblTotalTracks"
			Me.lblTotalTracks.Size = New System.Drawing.Size(13, 13)
			Me.lblTotalTracks.TabIndex = 18
			Me.lblTotalTracks.Text = "0"
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(241, 35)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(70, 13)
			Me.label11.TabIndex = 17
			Me.label11.Text = "Total Tracks:"
			' 
			' lblBytesPerTrack
			' 
			Me.lblBytesPerTrack.AutoSize = True
			Me.lblBytesPerTrack.Location = New System.Drawing.Point(322, 22)
			Me.lblBytesPerTrack.Name = "lblBytesPerTrack"
			Me.lblBytesPerTrack.Size = New System.Drawing.Size(13, 13)
			Me.lblBytesPerTrack.TabIndex = 16
			Me.lblBytesPerTrack.Text = "0"
			' 
			' label13
			' 
			Me.label13.AutoSize = True
			Me.label13.Location = New System.Drawing.Point(225, 22)
			Me.label13.Name = "label13"
			Me.label13.Size = New System.Drawing.Size(86, 13)
			Me.label13.TabIndex = 15
			Me.label13.Text = "Bytes Per Track:"
			' 
			' progress
			' 
			Me.progress.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.progress.Location = New System.Drawing.Point(0, 232)
			Me.progress.Name = "progress"
			Me.progress.Size = New System.Drawing.Size(586, 10)
			Me.progress.Step = 1
			Me.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
			Me.progress.TabIndex = 23
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(139, 184)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(65, 13)
			Me.label5.TabIndex = 25
			Me.label5.Text = "Percentage:"
			' 
			' lblPercentage
			' 
			Me.lblPercentage.AutoSize = True
			Me.lblPercentage.Location = New System.Drawing.Point(210, 185)
			Me.lblPercentage.Name = "lblPercentage"
			Me.lblPercentage.Size = New System.Drawing.Size(13, 13)
			Me.lblPercentage.TabIndex = 26
			Me.lblPercentage.Text = "0"
			' 
			' tbTrackBufferSize
			' 
			Me.tbTrackBufferSize.Location = New System.Drawing.Point(75, 155)
			Me.tbTrackBufferSize.Name = "tbTrackBufferSize"
			Me.tbTrackBufferSize.Size = New System.Drawing.Size(57, 20)
			Me.tbTrackBufferSize.TabIndex = 27
			Me.tbTrackBufferSize.Text = "0"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(138, 159)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(89, 13)
			Me.label8.TabIndex = 28
			Me.label8.Text = "Track Buffer Size"
			' 
			' progressPie
			' 
			Me.progressPie.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.progressPie.BackColor = System.Drawing.SystemColors.ButtonShadow
			Me.progressPie.Location = New System.Drawing.Point(381, 22)
			Me.progressPie.Name = "progressPie"
			Me.progressPie.Radius = 200F
			Me.progressPie.Size = New System.Drawing.Size(193, 173)
			Me.progressPie.TabIndex = 29
			Me.progressPie.Text = "pieChart1"
			Me.progressPie.Thickness = 10F
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(586, 242)
			Me.Controls.Add(Me.progressPie)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.tbTrackBufferSize)
			Me.Controls.Add(Me.lblPercentage)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.progress)
			Me.Controls.Add(Me.lblTracksPerSecond)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.lblTrack)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.lblTotalTracks)
			Me.Controls.Add(Me.label11)
			Me.Controls.Add(Me.lblBytesPerTrack)
			Me.Controls.Add(Me.label13)
			Me.Controls.Add(Me.cbTracks)
			Me.Controls.Add(Me.lblSectorsPerSecond)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.lblHash)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.lblSector)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.lblTotalSectors)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.lblBytesPerSector)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.lbDriveList)
			Me.Controls.Add(Me.btnStart)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "Form1"
			Me.Text = "Low Level Disk Drive Live Imager"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnStart As System.Windows.Forms.Button
		Private lbDriveList As System.Windows.Forms.ListBox
		Private label1 As System.Windows.Forms.Label
		Private lblBytesPerSector As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private lblTotalSectors As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private lblSector As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private lblHash As System.Windows.Forms.Label
		Private WithEvents timerSeconds As System.Windows.Forms.Timer
		Private lblSectorsPerSecond As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private cbTracks As System.Windows.Forms.CheckBox
		Private lblTracksPerSecond As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private lblTrack As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private lblTotalTracks As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private lblBytesPerTrack As System.Windows.Forms.Label
		Private label13 As System.Windows.Forms.Label
		Private progress As System.Windows.Forms.ProgressBar
		Private label5 As System.Windows.Forms.Label
		Private lblPercentage As System.Windows.Forms.Label
		Private tbTrackBufferSize As System.Windows.Forms.TextBox
		Private label8 As System.Windows.Forms.Label
		Private progressPie As Nexus.Windows.Forms.PieChart
	End Class
End Namespace


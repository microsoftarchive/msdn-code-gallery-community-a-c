<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHANUControlChart
    Inherits System.Windows.Forms.UserControl

    'UserControl1은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SHANUControlChart))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblU = New System.Windows.Forms.Label()
        Me.lblN = New System.Windows.Forms.Label()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblH = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.picHol2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblmsg = New System.Windows.Forms.Label()
        Me.picHolder = New System.Windows.Forms.PictureBox()
        Me.Panel11 = New SHANUControlChart_CNT.Panel1()
        Me.Panel12 = New SHANUControlChart_CNT.Panel1()
        Me.lblMasterData = New System.Windows.Forms.Label()
        Me.frmMasteringPictuerBox = New System.Windows.Forms.PictureBox()
        Me.lblUslData = New System.Windows.Forms.Label()
        Me.lblNominalData = New System.Windows.Forms.Label()
        Me.frmDynMsrmntlblNominal = New System.Windows.Forms.Label()
        Me.frmDynMsrmntlblUsl = New System.Windows.Forms.Label()
        Me.frmDynMsrmntlblLsl = New System.Windows.Forms.Label()
        Me.lblcon = New System.Windows.Forms.Label()
        Me.lblmax = New System.Windows.Forms.Label()
        Me.lblLslData = New System.Windows.Forms.Label()
        Me.lblmin = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.frmMasteringlblmsg = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.picHol2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.frmMasteringPictuerBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.Controls.Add(Me.lblU)
        Me.Panel4.Controls.Add(Me.lblN)
        Me.Panel4.Controls.Add(Me.lblA)
        Me.Panel4.Controls.Add(Me.lblH)
        Me.Panel4.Controls.Add(Me.lblS)
        Me.Panel4.Controls.Add(Me.picHol2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.lblmsg)
        Me.Panel4.Controls.Add(Me.picHolder)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(500, 29)
        Me.Panel4.TabIndex = 122
        '
        'lblU
        '
        Me.lblU.AutoSize = True
        Me.lblU.BackColor = System.Drawing.Color.Transparent
        Me.lblU.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblU.ForeColor = System.Drawing.Color.Red
        Me.lblU.Location = New System.Drawing.Point(465, 0)
        Me.lblU.Name = "lblU"
        Me.lblU.Size = New System.Drawing.Size(23, 24)
        Me.lblU.TabIndex = 54
        Me.lblU.Text = "U"
        '
        'lblN
        '
        Me.lblN.AutoSize = True
        Me.lblN.BackColor = System.Drawing.Color.Transparent
        Me.lblN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN.ForeColor = System.Drawing.Color.Red
        Me.lblN.Location = New System.Drawing.Point(448, 0)
        Me.lblN.Name = "lblN"
        Me.lblN.Size = New System.Drawing.Size(24, 24)
        Me.lblN.TabIndex = 53
        Me.lblN.Text = "N"
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.BackColor = System.Drawing.Color.Transparent
        Me.lblA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblA.ForeColor = System.Drawing.Color.Red
        Me.lblA.Location = New System.Drawing.Point(433, 0)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(23, 24)
        Me.lblA.TabIndex = 52
        Me.lblA.Text = "A"
        '
        'lblH
        '
        Me.lblH.AutoSize = True
        Me.lblH.BackColor = System.Drawing.Color.Transparent
        Me.lblH.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblH.ForeColor = System.Drawing.Color.Red
        Me.lblH.Location = New System.Drawing.Point(416, 0)
        Me.lblH.Name = "lblH"
        Me.lblH.Size = New System.Drawing.Size(24, 24)
        Me.lblH.TabIndex = 51
        Me.lblH.Text = "H"
        '
        'lblS
        '
        Me.lblS.AutoSize = True
        Me.lblS.BackColor = System.Drawing.Color.Transparent
        Me.lblS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblS.ForeColor = System.Drawing.Color.Red
        Me.lblS.Location = New System.Drawing.Point(400, 0)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(22, 24)
        Me.lblS.TabIndex = 50
        Me.lblS.Text = "S"
        '
        'picHol2
        '
        Me.picHol2.BackColor = System.Drawing.Color.Transparent
        Me.picHol2.Location = New System.Drawing.Point(400, 0)
        Me.picHol2.Name = "picHol2"
        Me.picHol2.Size = New System.Drawing.Size(100, 30)
        Me.picHol2.TabIndex = 48
        Me.picHol2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(120, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 24)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "USL/LSL Control Limit Chart "
        '
        'lblmsg
        '
        Me.lblmsg.AutoSize = True
        Me.lblmsg.BackColor = System.Drawing.Color.Transparent
        Me.lblmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.lblmsg.Location = New System.Drawing.Point(24, 0)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(76, 24)
        Me.lblmsg.TabIndex = 10
        Me.lblmsg.Text = "SHANU"
        '
        'picHolder
        '
        Me.picHolder.BackColor = System.Drawing.Color.Transparent
        Me.picHolder.Location = New System.Drawing.Point(12, 0)
        Me.picHolder.Name = "picHolder"
        Me.picHolder.Size = New System.Drawing.Size(100, 30)
        Me.picHolder.TabIndex = 7
        Me.picHolder.TabStop = False
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = CType(resources.GetObject("Panel11.BackgroundImage"), System.Drawing.Image)
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Controls.Add(Me.frmMasteringPictuerBox)
        Me.Panel11.Controls.Add(Me.lblUslData)
        Me.Panel11.Controls.Add(Me.lblNominalData)
        Me.Panel11.Controls.Add(Me.frmDynMsrmntlblNominal)
        Me.Panel11.Controls.Add(Me.frmDynMsrmntlblUsl)
        Me.Panel11.Controls.Add(Me.frmDynMsrmntlblLsl)
        Me.Panel11.Controls.Add(Me.lblcon)
        Me.Panel11.Controls.Add(Me.lblmax)
        Me.Panel11.Controls.Add(Me.lblLslData)
        Me.Panel11.Controls.Add(Me.lblmin)
        Me.Panel11.Controls.Add(Me.frmMasteringlblmsg)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.EndColor = System.Drawing.Color.LightSteelBlue
        Me.Panel11.Location = New System.Drawing.Point(0, 29)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(500, 453)
        Me.Panel11.StartColor = System.Drawing.Color.WhiteSmoke
        Me.Panel11.TabIndex = 123
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Black
        Me.Panel12.BackgroundImage = CType(resources.GetObject("Panel12.BackgroundImage"), System.Drawing.Image)
        Me.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel12.Controls.Add(Me.lblMasterData)
        Me.Panel12.EndColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel12.Location = New System.Drawing.Point(9, 136)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(248, 88)
        Me.Panel12.StartColor = System.Drawing.Color.Black
        Me.Panel12.TabIndex = 137
        '
        'lblMasterData
        '
        Me.lblMasterData.BackColor = System.Drawing.Color.Transparent
        Me.lblMasterData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMasterData.Font = New System.Drawing.Font("Microsoft Sans Serif", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMasterData.ForeColor = System.Drawing.Color.Yellow
        Me.lblMasterData.Location = New System.Drawing.Point(0, 0)
        Me.lblMasterData.Name = "lblMasterData"
        Me.lblMasterData.Size = New System.Drawing.Size(248, 88)
        Me.lblMasterData.TabIndex = 137
        Me.lblMasterData.Text = "3.500"
        Me.lblMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMasteringPictuerBox
        '
        Me.frmMasteringPictuerBox.BackColor = System.Drawing.Color.White
        Me.frmMasteringPictuerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.frmMasteringPictuerBox.Location = New System.Drawing.Point(272, 8)
        Me.frmMasteringPictuerBox.Name = "frmMasteringPictuerBox"
        Me.frmMasteringPictuerBox.Size = New System.Drawing.Size(212, 424)
        Me.frmMasteringPictuerBox.TabIndex = 135
        Me.frmMasteringPictuerBox.TabStop = False
        '
        'lblUslData
        '
        Me.lblUslData.BackColor = System.Drawing.Color.Transparent
        Me.lblUslData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUslData.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblUslData.Location = New System.Drawing.Point(112, 8)
        Me.lblUslData.Name = "lblUslData"
        Me.lblUslData.Size = New System.Drawing.Size(142, 29)
        Me.lblUslData.TabIndex = 129
        Me.lblUslData.Text = "10.000"
        Me.lblUslData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNominalData
        '
        Me.lblNominalData.BackColor = System.Drawing.Color.Transparent
        Me.lblNominalData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNominalData.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNominalData.Location = New System.Drawing.Point(112, 86)
        Me.lblNominalData.Name = "lblNominalData"
        Me.lblNominalData.Size = New System.Drawing.Size(142, 29)
        Me.lblNominalData.TabIndex = 131
        Me.lblNominalData.Text = "5.000"
        Me.lblNominalData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDynMsrmntlblNominal
        '
        Me.frmDynMsrmntlblNominal.AutoSize = True
        Me.frmDynMsrmntlblNominal.BackColor = System.Drawing.Color.Transparent
        Me.frmDynMsrmntlblNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmDynMsrmntlblNominal.ForeColor = System.Drawing.Color.LightSlateGray
        Me.frmDynMsrmntlblNominal.Location = New System.Drawing.Point(6, 87)
        Me.frmDynMsrmntlblNominal.Name = "frmDynMsrmntlblNominal"
        Me.frmDynMsrmntlblNominal.Size = New System.Drawing.Size(97, 25)
        Me.frmDynMsrmntlblNominal.TabIndex = 134
        Me.frmDynMsrmntlblNominal.Text = "Nominal"
        '
        'frmDynMsrmntlblUsl
        '
        Me.frmDynMsrmntlblUsl.AutoSize = True
        Me.frmDynMsrmntlblUsl.BackColor = System.Drawing.Color.Transparent
        Me.frmDynMsrmntlblUsl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmDynMsrmntlblUsl.ForeColor = System.Drawing.Color.LightSlateGray
        Me.frmDynMsrmntlblUsl.Location = New System.Drawing.Point(10, 10)
        Me.frmDynMsrmntlblUsl.Name = "frmDynMsrmntlblUsl"
        Me.frmDynMsrmntlblUsl.Size = New System.Drawing.Size(56, 25)
        Me.frmDynMsrmntlblUsl.TabIndex = 133
        Me.frmDynMsrmntlblUsl.Text = "USL"
        '
        'frmDynMsrmntlblLsl
        '
        Me.frmDynMsrmntlblLsl.AutoSize = True
        Me.frmDynMsrmntlblLsl.BackColor = System.Drawing.Color.Transparent
        Me.frmDynMsrmntlblLsl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmDynMsrmntlblLsl.ForeColor = System.Drawing.Color.LightSlateGray
        Me.frmDynMsrmntlblLsl.Location = New System.Drawing.Point(10, 51)
        Me.frmDynMsrmntlblLsl.Name = "frmDynMsrmntlblLsl"
        Me.frmDynMsrmntlblLsl.Size = New System.Drawing.Size(53, 25)
        Me.frmDynMsrmntlblLsl.TabIndex = 132
        Me.frmDynMsrmntlblLsl.Text = "LSL"
        '
        'lblcon
        '
        Me.lblcon.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblcon.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcon.ForeColor = System.Drawing.Color.Transparent
        Me.lblcon.Location = New System.Drawing.Point(15, 118)
        Me.lblcon.Name = "lblcon"
        Me.lblcon.Size = New System.Drawing.Size(229, 1)
        Me.lblcon.TabIndex = 130
        '
        'lblmax
        '
        Me.lblmax.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmax.ForeColor = System.Drawing.Color.Transparent
        Me.lblmax.Location = New System.Drawing.Point(15, 81)
        Me.lblmax.Name = "lblmax"
        Me.lblmax.Size = New System.Drawing.Size(229, 1)
        Me.lblmax.TabIndex = 128
        '
        'lblLslData
        '
        Me.lblLslData.BackColor = System.Drawing.Color.Transparent
        Me.lblLslData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLslData.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLslData.Location = New System.Drawing.Point(112, 47)
        Me.lblLslData.Name = "lblLslData"
        Me.lblLslData.Size = New System.Drawing.Size(142, 29)
        Me.lblLslData.TabIndex = 127
        Me.lblLslData.Text = "1.000"
        Me.lblLslData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblmin
        '
        Me.lblmin.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmin.ForeColor = System.Drawing.Color.Transparent
        Me.lblmin.Location = New System.Drawing.Point(18, 42)
        Me.lblmin.Name = "lblmin"
        Me.lblmin.Size = New System.Drawing.Size(229, 1)
        Me.lblmin.TabIndex = 126
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'frmMasteringlblmsg
        '
        Me.frmMasteringlblmsg.AutoEllipsis = True
        Me.frmMasteringlblmsg.BackColor = System.Drawing.Color.Transparent
        Me.frmMasteringlblmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmMasteringlblmsg.ForeColor = System.Drawing.Color.Transparent
        Me.frmMasteringlblmsg.Location = New System.Drawing.Point(336, 232)
        Me.frmMasteringlblmsg.Name = "frmMasteringlblmsg"
        Me.frmMasteringlblmsg.Size = New System.Drawing.Size(48, 16)
        Me.frmMasteringlblmsg.TabIndex = 138
        Me.frmMasteringlblmsg.Visible = False
        '
        'SHANUControlChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "SHANUControlChart"
        Me.Size = New System.Drawing.Size(500, 482)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.picHol2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.frmMasteringPictuerBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblU As System.Windows.Forms.Label
    Friend WithEvents lblN As System.Windows.Forms.Label
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblH As System.Windows.Forms.Label
    Friend WithEvents lblS As System.Windows.Forms.Label
    Friend WithEvents picHol2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblmsg As System.Windows.Forms.Label
    Friend WithEvents picHolder As System.Windows.Forms.PictureBox
    Friend WithEvents Panel11 As SHANUControlChart_CNT.Panel1
    Friend WithEvents Panel12 As SHANUControlChart_CNT.Panel1
    Friend WithEvents lblMasterData As System.Windows.Forms.Label
    Friend WithEvents frmMasteringPictuerBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblUslData As System.Windows.Forms.Label
    Friend WithEvents lblNominalData As System.Windows.Forms.Label
    Friend WithEvents frmDynMsrmntlblNominal As System.Windows.Forms.Label
    Friend WithEvents frmDynMsrmntlblUsl As System.Windows.Forms.Label
    Friend WithEvents frmDynMsrmntlblLsl As System.Windows.Forms.Label
    Friend WithEvents lblcon As System.Windows.Forms.Label
    Friend WithEvents lblmax As System.Windows.Forms.Label
    Friend WithEvents lblLslData As System.Windows.Forms.Label
    Friend WithEvents lblmin As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents frmMasteringlblmsg As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			Static fTerminateCalled As Boolean
			If Not fTerminateCalled Then
				Form_Terminate_renamed()
				fTerminateCalled = True
			End If
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdSend As System.Windows.Forms.Button
	Public WithEvents txtSend As System.Windows.Forms.TextBox
	Public WithEvents tcpClient As AxMSWinsockLib.AxWinsock
	Public WithEvents txtOutput As System.Windows.Forms.TextBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdSend = New System.Windows.Forms.Button
		Me.txtSend = New System.Windows.Forms.TextBox
		Me.tcpClient = New AxMSWinsockLib.AxWinsock
		Me.txtOutput = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.tcpClient, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Client2Client"
		Me.ClientSize = New System.Drawing.Size(311, 216)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		Me.cmdSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSend.Text = "Send"
		Me.AcceptButton = Me.cmdSend
		Me.cmdSend.Size = New System.Drawing.Size(49, 17)
		Me.cmdSend.Location = New System.Drawing.Point(256, 8)
		Me.cmdSend.TabIndex = 2
		Me.cmdSend.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSend.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSend.CausesValidation = True
		Me.cmdSend.Enabled = True
		Me.cmdSend.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSend.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSend.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSend.TabStop = True
		Me.cmdSend.Name = "cmdSend"
		Me.txtSend.AutoSize = False
		Me.txtSend.Size = New System.Drawing.Size(241, 19)
		Me.txtSend.Location = New System.Drawing.Point(8, 8)
		Me.txtSend.TabIndex = 1
		Me.txtSend.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSend.AcceptsReturn = True
		Me.txtSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSend.BackColor = System.Drawing.SystemColors.Window
		Me.txtSend.CausesValidation = True
		Me.txtSend.Enabled = True
		Me.txtSend.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSend.HideSelection = True
		Me.txtSend.ReadOnly = False
		Me.txtSend.Maxlength = 0
		Me.txtSend.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSend.MultiLine = False
		Me.txtSend.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSend.TabStop = True
		Me.txtSend.Visible = True
		Me.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSend.Name = "txtSend"
		tcpClient.OcxState = CType(resources.GetObject("tcpClient.OcxState"), System.Windows.Forms.AxHost.State)
		Me.tcpClient.Location = New System.Drawing.Point(40, 56)
		Me.tcpClient.Name = "tcpClient"
		Me.txtOutput.AutoSize = False
		Me.txtOutput.Size = New System.Drawing.Size(297, 177)
		Me.txtOutput.Location = New System.Drawing.Point(8, 32)
		Me.txtOutput.MultiLine = True
		Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtOutput.TabIndex = 0
		Me.txtOutput.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtOutput.AcceptsReturn = True
		Me.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtOutput.BackColor = System.Drawing.SystemColors.Window
		Me.txtOutput.CausesValidation = True
		Me.txtOutput.Enabled = True
		Me.txtOutput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtOutput.HideSelection = True
		Me.txtOutput.ReadOnly = False
		Me.txtOutput.Maxlength = 0
		Me.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtOutput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtOutput.TabStop = True
		Me.txtOutput.Visible = True
		Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtOutput.Name = "txtOutput"
		Me.Controls.Add(cmdSend)
		Me.Controls.Add(txtSend)
		Me.Controls.Add(tcpClient)
		Me.Controls.Add(txtOutput)
		CType(Me.tcpClient, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
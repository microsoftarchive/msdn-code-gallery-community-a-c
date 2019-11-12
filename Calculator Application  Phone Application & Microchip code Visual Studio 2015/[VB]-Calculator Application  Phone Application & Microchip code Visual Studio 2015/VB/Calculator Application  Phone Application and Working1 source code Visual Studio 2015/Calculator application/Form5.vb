Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form
	Private Sub cmdSend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSend.Click
		Call tcpClient.SendData("REMOTE >>> " & txtSend.Text)
		txtOutput.Text = txtOutput.Text & "YOUR MESSAGE >>> " & txtSend.Text & vbCrLf & vbCrLf
		txtOutput.SelectionStart = Len(txtOutput.Text)
		txtSend.Text = ""
		txtSend.Focus()
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cmdSend.Enabled = False
		
		tcpClient.RemoteHost = InputBox("Enter the remote host IP address", "IP Address", "127.0.0.1")
		
		If tcpClient.RemoteHost = "" Then
			tcpClient.RemoteHost = "127.0.0.1"
		End If
		tcpClient.RemotePort = 5000
		Call tcpClient.Connect()
		
	End Sub
	
	
	'UPGRADE_NOTE: Form_Terminate was upgraded to Form_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	'UPGRADE_WARNING: frmMain event Form.Terminate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub Form_Terminate_Renamed()
		End
	End Sub
	
	
	Private Sub tcpClient_CloseEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tcpClient.CloseEvent
		cmdSend.Enabled = False
		Call tcpClient.Close()
		txtOutput.Text = txtOutput.Text & "Remote Host closed connection." & vbCrLf & vbCrLf
		txtOutput.SelectionStart = Len(txtOutput.Text)
		tcpClient.LocalPort = 5000
		tcpClient.Listen()
	End Sub
	
	Private Sub tcpClient_ConnectEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tcpClient.ConnectEvent
		cmdSend.Enabled = True
		txtOutput.Text = "*** Connected to IP Address:" & tcpClient.RemoteHostIP & " . Port #:" & tcpClient.RemotePort & vbCrLf & vbCrLf
	End Sub
	
	Private Sub tcpClient_ConnectionRequest(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles tcpClient.ConnectionRequest
		'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		If tcpClient.CtlState <> MSWinsockLib.StateConstants.sckClosed Then
			Call tcpClient.Close()
		End If
		
		tcpClient.Accept((eventArgs.requestID))
		txtOutput.Text = txtOutput.Text & "*** " & "Request From IP:" & tcpClient.RemoteHostIP & ". Remote Port: " & tcpClient.RemotePort & vbCrLf & vbCrLf
		cmdSend.Enabled = True
		
	End Sub
	
	Private Sub tcpClient_DataArrival(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles tcpClient.DataArrival
		
		Dim message As String
		Call tcpClient.GetData(message)
		txtOutput.Text = txtOutput.Text & message & vbCrLf & vbCrLf
		txtOutput.SelectionStart = Len(txtOutput.Text)
		
	End Sub
	
	Private Sub tcpClient_Error(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent) Handles tcpClient.Error
		Dim result As Short
		
		If eventArgs.Number = 10061 Then
			txtOutput.Text = "Cannot Connect to RomoteHost" & vbCrLf & vbCrLf
		Else
			result = MsgBox(eventArgs.Source & ": " & eventArgs.Description, MsgBoxStyle.OKOnly, "TCP/IP Error")
		End If
		tcpClient.Close()
		tcpClient.LocalPort = 5000
		Call tcpClient.Listen()
	End Sub
End Class
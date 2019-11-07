Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Admin
	Public Partial Class _default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(sender As Object, e As EventArgs)
			Dim mpLabel As Label


			mpLabel = DirectCast(Master.FindControl("lblLoggedOnUser"), Label)
			If mpLabel IsNot Nothing Then
				mpLabel.Text = Page.User.Identity.Name
			End If

		End Sub

		Protected Sub AlertInfo(msg As String)
			messagesText.Attributes("class") = "alert_info"
			lblMessage.Text = msg
			panelMessage.Visible = True
		End Sub

		Protected Sub AlertWarning(msg As String)
			messagesText.Attributes("class") = "alert_warning"
			lblMessage.Text = msg
			panelMessage.Visible = True
		End Sub

		Protected Sub AlertError(msg As String)
			messagesText.Attributes("class") = "alert_error"
			lblMessage.Text = msg
			panelMessage.Visible = True
		End Sub

		Protected Sub AlertSuccess(msg As String)
			messagesText.Attributes("class") = "alert_success"
			lblMessage.Text = msg
			panelMessage.Visible = True
		End Sub
	End Class
End Namespace

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Account
	Public Partial Class Register
		Inherits Page
		Protected Sub Page_PreInit(sender As Object, e As EventArgs)
			If Not [String].IsNullOrEmpty(Request.QueryString("content")) Then
				Response.Redirect("~/Account/RegisterAjax.aspx")
			End If
		End Sub

		Protected Sub Page_Load(sender As Object, e As EventArgs)
			RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
		End Sub

		Protected Sub RegisterUser_CreatedUser(sender As Object, e As EventArgs)
			FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie := False)

			Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
			If [String].IsNullOrEmpty(continueUrl) Then
				continueUrl = "~/"
			End If
			Response.Redirect(continueUrl)
		End Sub
	End Class
End Namespace

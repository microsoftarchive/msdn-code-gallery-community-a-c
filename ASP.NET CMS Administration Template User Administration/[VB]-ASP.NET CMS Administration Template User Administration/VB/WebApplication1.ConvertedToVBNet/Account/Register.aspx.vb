Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Account
	Public Partial Class Register
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(sender As Object, e As EventArgs)
			RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
		End Sub

		Protected Sub RegisterUser_CreatedUser(sender As Object, e As EventArgs)
				' createPersistentCookie 
			FormsAuthentication.SetAuthCookie(RegisterUser.UserName, False)

			Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
			If [String].IsNullOrEmpty(continueUrl) Then
				continueUrl = "~/"
			End If
			Response.Redirect(continueUrl)
		End Sub

	End Class
End Namespace

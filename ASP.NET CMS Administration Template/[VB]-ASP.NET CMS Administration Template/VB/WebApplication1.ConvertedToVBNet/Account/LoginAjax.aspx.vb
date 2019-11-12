Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Account
	Public Partial Class LoginAjax
		Inherits System.Web.UI.Page
		Public Sub Page_Load(sender As Object, e As EventArgs)
			If [String].Equals(Request.HttpMethod, "POST", StringComparison.Ordinal) Then
				HandleAjaxRequest()
			End If
		End Sub

		Protected Function GetRegisterUrl() As String
			Return ResolveUrl("Register.aspx?ReturnUrl=" & GetReturnUrl())
		End Function

		Protected Function GetHandlerUrl() As String
			Return ResolveUrl("LoginAjax.aspx?ReturnUrl=" & GetReturnUrl())
		End Function

		Private Sub HandleAjaxRequest()
			Dim errors = New List(Of String)()

			Dim username = Request.Form("UserName")
			Dim password = Request.Form("Password")
			Dim rememberMe = [String].Equals(Request.Form("RememberMe"), "on")
			Dim returnUrl = Request.QueryString("ReturnUrl")
			Dim redirect = VirtualPathUtility.ToAbsolute("~/")

			Response.ContentType = "application/json"

			AccountHelpers.Require(errors, username, "The User name field is required")
			AccountHelpers.Require(errors, password, "The Password field is required")

			If errors.Count = 0 Then
				If Membership.ValidateUser(username, password) Then
					FormsAuthentication.SetAuthCookie(username, rememberMe)
					If IsLocalUrl(returnUrl) Then
						redirect = returnUrl
					End If
				Else
					errors.Add("The user name or password provided is incorrect.")
				End If
			End If

			AccountHelpers.WriteJsonResponse(Response, errors, redirect)
		End Sub

		Private Function GetReturnUrl() As String
			Return HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
		End Function

		Private Function IsLocalUrl(url As String) As Boolean
			Return Not [String].IsNullOrEmpty(url) AndAlso ((url(0) = "/"C AndAlso (url.Length = 1 OrElse (url(1) <> "/"C AndAlso url(1) <> "\"C))) OrElse (url.Length > 1 AndAlso url(0) = "~"C AndAlso url(1) = "/"C))
		End Function
	End Class
End Namespace

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Account
	Public Partial Class RegisterAjax
		Inherits Page
		Public Sub Page_Load(sender As Object, e As EventArgs)
			If [String].Equals(Request.HttpMethod, "POST", StringComparison.Ordinal) Then
				HandleAjaxRequest()
			End If
		End Sub

		Protected Function GetHandlerUrl() As String
			Return ResolveUrl("RegisterAjax.aspx?ReturnUrl=" & GetReturnUrl())
		End Function

		Private Sub HandleAjaxRequest()
			Dim errors = New List(Of String)()

			Dim username = Request.Form("UserName")
			Dim password = Request.Form("Password")
			Dim confirmPassword = Request.Form("ConfirmPassword")
			Dim email = Request.Form("Email")

			Response.ContentType = "application/json"

			AccountHelpers.Require(errors, username, "The User name field is required")
			AccountHelpers.Require(errors, password, "The Password field is required")
			AccountHelpers.Require(errors, confirmPassword, "The Confirm password field is required")
			AccountHelpers.Require(errors, email, "The Email address field is required")
			If Not [String].Equals(password, confirmPassword, StringComparison.Ordinal) Then
				errors.Add("The Password and Confirmation password do not match.")
			End If

			If errors.Count = 0 Then
				Dim status As MembershipCreateStatus
				Membership.CreateUser(username, password, email, passwordQuestion := Nothing, passwordAnswer := Nothing, isApproved := True, _
					status := status)

				If status = MembershipCreateStatus.Success Then
					FormsAuthentication.SetAuthCookie(username, createPersistentCookie := False)
				Else
					errors.Add(ErrorCodeToString(status))
				End If
			End If

			AccountHelpers.WriteJsonResponse(Response, errors)
		End Sub

		Private Function GetReturnUrl() As String
			Return HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
		End Function

		#Region "Status Codes"
		Private Shared Function ErrorCodeToString(createStatus As MembershipCreateStatus) As String
			' See http://go.microsoft.com/fwlink/?LinkID=177550 for
			' a full list of status codes.
			Select Case createStatus
				Case MembershipCreateStatus.DuplicateUserName
					Return "User name already exists. Please enter a different user name."

				Case MembershipCreateStatus.DuplicateEmail
					Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

				Case MembershipCreateStatus.InvalidPassword
					Return "The password provided is invalid. Please enter a valid password value."

				Case MembershipCreateStatus.InvalidEmail
					Return "The e-mail address provided is invalid. Please check the value and try again."

				Case MembershipCreateStatus.InvalidAnswer
					Return "The password retrieval answer provided is invalid. Please check the value and try again."

				Case MembershipCreateStatus.InvalidQuestion
					Return "The password retrieval question provided is invalid. Please check the value and try again."

				Case MembershipCreateStatus.InvalidUserName
					Return "The user name provided is invalid. Please check the value and try again."

				Case MembershipCreateStatus.ProviderError
					Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

				Case MembershipCreateStatus.UserRejected
					Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."
				Case Else

					Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
			End Select
		End Function
		#End Region
	End Class
End Namespace

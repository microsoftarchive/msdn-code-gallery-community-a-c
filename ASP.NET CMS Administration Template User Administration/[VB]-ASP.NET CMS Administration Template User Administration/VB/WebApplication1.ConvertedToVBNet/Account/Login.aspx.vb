Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Account
	Public Partial Class Login
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(sender As Object, e As EventArgs)
			RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" & HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
		End Sub
	End Class
End Namespace

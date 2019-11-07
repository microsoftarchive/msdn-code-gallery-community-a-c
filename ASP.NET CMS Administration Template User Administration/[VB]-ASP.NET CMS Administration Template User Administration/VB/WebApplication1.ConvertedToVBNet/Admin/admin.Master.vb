Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Admin
	<PrincipalPermission(SecurityAction.Demand, Authenticated := True, Role := "Super Administrator")> _
	Public Partial Class admin
		Inherits System.Web.UI.MasterPage

		Protected Sub Page_Load(sender As Object, e As EventArgs)

		End Sub
	End Class
End Namespace

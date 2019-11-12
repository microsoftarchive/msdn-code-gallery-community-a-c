Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports System.Security.Permissions

Namespace Admin
	<PrincipalPermission(SecurityAction.Demand, Authenticated := True, Role := "Super Administrator")> _
	Public Partial Class profiles
		Inherits System.Web.UI.Page


		Protected Sub Page_Load(sender As Object, e As EventArgs)

			If Not IsPostBack Then
			End If

		End Sub


		Protected Sub lbAdd_Click(sender As Object, e As EventArgs)
			If Not Roles.RoleExists(tbRoleName.Text) Then
				Roles.CreateRole(tbRoleName.Text)
				tbRoleName.Text = ""
				GridView1.DataBind()
			End If
		End Sub

		Protected Sub lbUpdate_Click(sender As Object, e As EventArgs)

		End Sub
	End Class
End Namespace

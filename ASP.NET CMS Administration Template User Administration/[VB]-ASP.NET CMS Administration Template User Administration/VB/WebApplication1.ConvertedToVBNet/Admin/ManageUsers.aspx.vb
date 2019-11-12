Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Policy
Imports System.Data.SqlClient
Imports System.Security.Permissions
Imports System.Web.Security

Namespace Admin
	<PrincipalPermission(SecurityAction.Demand, Authenticated := True, Role := "Super Administrator")> _
	Public Partial Class ManageUsers
		Inherits System.Web.UI.Page


		Protected Sub Page_Load(sender As Object, e As EventArgs)
			Dim aID As Guid = getApplicationID()
			SqlDataSource1.SelectParameters("ApplicationId").DefaultValue = aID.ToString()

			GridView1.DataBind()

		End Sub

		' Get the applicationID from Applications table.
		Private Function getApplicationID() As Guid
			Dim appName As String = "cmsCCSLABS"
			Dim aID As New Guid()

			Try
				' Connect to Database
				Dim conn As New SqlConnection(SqlDataSource1.ConnectionString)
				Dim command As New SqlCommand("SELECT (ApplicationId) FROM aspnet_Applications WHERE ApplicationName='" & appName & "';", conn)
				conn.Open()
				aID = CType(command.ExecuteScalar(), Guid)
				conn.Close()
					' Add the error message on the page here.

			Catch ex As Exception
			End Try

			Return aID
		End Function

		Protected Sub lbAdd_Click(sender As Object, e As EventArgs)
			panelMessages.Visible = False
			lblMessages.Text = ""

			Try
					' Email address must be unique - see web.config
				Membership.CreateUser(tbMembersName.Text, tbPassword.Text, "2Unique@Email.com")
			Catch ex As Exception
				lblMessages.Text = ex.Message

				panelMessages.Visible = True
			End Try
			tbMembersName.Text = ""
			tbPassword.Text = ""
		End Sub

		Protected Sub textChanged(sender As Object, e As EventArgs)
			panelMessages.Visible = False
			lblMessages.Text = ""
		End Sub
	End Class
End Namespace

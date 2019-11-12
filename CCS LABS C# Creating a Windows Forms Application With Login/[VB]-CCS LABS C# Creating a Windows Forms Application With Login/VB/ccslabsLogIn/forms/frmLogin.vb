Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient

Namespace ccslabsLogIn.forms
	Partial Public Class frmLogin
		Inherits Form

		#region "Properties"

		Private _Authenticated As Boolean = False

		Public Property Authenticated() As Boolean
			Get
				Return _Authenticated
			End Get
			Set(ByVal value As Boolean)
				_Authenticated = value
			End Set
		End Property
		Private _Username As String = ""

		Public Property Username() As String
			Get
				Return _Username
			End Get
			Set(ByVal value As String)
				_Username = value
			End Set
		End Property

		#End Region

		Public Sub New()
			InitializeComponent()
		End Sub

		' exit the program if they do not want to login
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Application.Exit()
		End Sub

		' check that username and password are not empty
		' lookup username in database and compare passwords - if ok continue
		' if not ok, retry 2 more times then exit
		Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
			Login()
		End Sub

		Private Sub Login()

			If tbPassword.Text.Length > 0 AndAlso tbUsername.Text.Length > 0 Then
				If UserAuthenticated(tbUsername.Text, tbPassword.Text) Then
					Authenticated = True
					Me.Close() ' close this form - do not exit the application
				Else
					Authenticated = False
					MessageBox.Show("Username or Password not recognised")

				End If
			Else ' password or username is empty
				Authenticated = False
				MessageBox.Show("You need to enter both a username and a password to continue")
			End If

		End Sub

		' Does the user exist?
		' if so - is the password correct?
		Private Function UserAuthenticated(ByVal p As String, ByVal p_2 As String) As Boolean
			Try
				Dim result As Integer = DirectCast(usersTableAdapter.GetUserIDByUsernameAndPassword(p, p_2), Integer)
				Authenticated = True
				If result > 0 Then
					Return True
				End If
			Catch e1 As Exception ' FIXED: Added Exception catching  which defaults to Not Authenticated
				Authenticated = False
				Return False
			End Try
			Authenticated = False
			Return False
		End Function

		' You do not need this
		Private Sub usersBindingNavigatorSaveItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Validate()
			Me.usersBindingSource.EndEdit()
			Me.tableAdapterManager.UpdateAll(Me.applicationDataSet_Renamed)

		End Sub

		Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'applicationDataSet.Users' table. You can move, or remove it, as needed.
			Me.usersTableAdapter.Fill(Me.applicationDataSet_Renamed.Users) ' you do not need this

		End Sub

		' register the user - get Username, password x 2
		' Add user to database if passwords match
		Private Sub llRegister_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles llRegister.LinkClicked
			Dim reg As New frmRegister()
			reg.ShowDialog()
			If reg.Registered Then
				Authenticated = True
				Me.Close()
			Else
				Authenticated = True
				Me.Close()
			End If
		End Sub


	End Class
End Namespace

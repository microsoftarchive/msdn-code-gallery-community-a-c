Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace ccslabsLogIn.forms
	Partial Public Class frmRegister
		Inherits Form

		#region "Properties"

		Private _Registered As Boolean = False

		Public Property Registered() As Boolean
			Get
				Return _Registered
			End Get
			Set(ByVal value As Boolean)
				_Registered = value
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

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Registered = False ' tell calling form the user DID NOT register
			Me.Close() ' close the form
		End Sub

		' register the dude.
		Private Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
			RegisterUser()
		End Sub

		' Register the User
		Private Sub RegisterUser()
			If tbUsername.Text.Length > 0 Then ' You may want longer than 1 char minimum for usernames
				If tbPassword.Text <> tbRepeatPassword.Text Then ' passwords do not match retry
					MessageBox.Show("Passwords do not match")
					RegisterUser()
				End If
				' ok passwords do match are they empty?
				If tbPassword.Text.Length = 0 Then ' empty passwords try again!
					MessageBox.Show("Passwords can not be empty")
					RegisterUser()
				End If
				' Ok username and passwords are valid.
				' register the user !
				usersTableAdapter.Insert(tbUsername.Text, tbPassword.Text)
				Registered = True
				Me.Close()
			Else ' Fixed: Forgot the else clause !
				MessageBox.Show("Username can not be empty")
				RegisterUser()
			End If
		End Sub

		Private Sub usersBindingNavigatorSaveItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Validate()
			Me.usersBindingSource.EndEdit()
			Me.tableAdapterManager.UpdateAll(Me.applicationDataSet_Renamed)

		End Sub

		Private Sub frmRegister_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'applicationDataSet.Users' table. You can move, or remove it, as needed.
			Me.usersTableAdapter.Fill(Me.applicationDataSet_Renamed.Users)

		End Sub
	End Class
End Namespace

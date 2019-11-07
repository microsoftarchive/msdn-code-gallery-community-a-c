Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports ccslabsLogIn.forms


Namespace ccslabsLogIn
	Partial Public Class frmMain
		Inherits Form

		Private _login As New frmLogin()


		Public Sub New()
			InitializeComponent()
			_login.ShowDialog()
			If _login.Authenticated Then
				MessageBox.Show("You have logged in successfully " & _login.Username)
			Else
				MessageBox.Show("You failed to login or register - bye bye","Error",MessageBoxButtons.OK,MessageBoxIcon.Error)
				Application.Exit()
			End If
		End Sub
	End Class
End Namespace

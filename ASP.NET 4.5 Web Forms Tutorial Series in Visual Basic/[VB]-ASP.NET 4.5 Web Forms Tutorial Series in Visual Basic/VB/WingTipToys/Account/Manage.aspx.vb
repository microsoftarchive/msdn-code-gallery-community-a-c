Imports System.Collections.Generic

Imports Microsoft.AspNet.Membership.OpenAuth

Public Class Manage
    Inherits System.Web.UI.Page

    Private successMessageTextValue As String
    Protected Property SuccessMessageText As String
        Get
            Return successMessageTextValue
        End Get
        Private Set(value As String)
            successMessageTextValue = value
        End Set
    End Property

    Private canRemoveExternalLoginsValue As Boolean
    Protected Property CanRemoveExternalLogins As Boolean
        Get
            Return canRemoveExternalLoginsValue
        End Get
        Set(value As Boolean)
            canRemoveExternalLoginsValue = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Determine the sections to render
            Dim hasLocalPassword = OpenAuth.HasLocalPassword(User.Identity.Name)
            setPassword.Visible = Not hasLocalPassword
            changePassword.Visible = hasLocalPassword

            CanRemoveExternalLogins = hasLocalPassword

            ' Render success message
            Dim message = Request.QueryString("m")
            If Not message Is Nothing Then
                ' Strip the query string from action
                Form.Action = ResolveUrl("~/Account/Manage.aspx")

                Select Case message
                    Case "ChangePwdSuccess"
                        SuccessMessageText = "Your password has been changed."
                    Case "SetPwdSuccess"
                        SuccessMessageText = "Your password has been set."
                    Case "RemoveLoginSuccess"
                        SuccessMessageText = "The external login was removed."
                    Case Else
                        SuccessMessageText = String.Empty
                End Select

                successMessage.Visible = Not String.IsNullOrEmpty(SuccessMessageText)
            End If
        End If

        
    End Sub

    Protected Sub setPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsValid Then
            Dim result As SetPasswordResult = OpenAuth.AddLocalPassword(User.Identity.Name, password.Text)
            If result.IsSuccessful Then
                Response.Redirect("~/Account/Manage.aspx?m=SetPwdSuccess")
            Else
                
                ModelState.AddModelError("NewPassword", result.ErrorMessage)
                
            End If
        End If
    End Sub

    
    Public Function GetExternalLogins() As IEnumerable(Of OpenAuthAccountData)
        Dim accounts = OpenAuth.GetAccountsForUser(User.Identity.Name)
        CanRemoveExternalLogins = CanRemoveExternalLogins OrElse accounts.Count() > 1
        Return accounts
    End Function

    Public Sub RemoveExternalLogin(ByVal providerName As String, ByVal providerUserId As String)
        Dim m = If(OpenAuth.DeleteAccount(User.Identity.Name, providerName, providerUserId), "?m=RemoveLoginSuccess", String.Empty)
        Response.Redirect("~/Account/Manage.aspx" & m)
    End Sub
    

    Protected Shared Function ConvertToDisplayDateTime(ByVal utcDateTime As Nullable(Of DateTime)) As String
        ' You can change this method to convert the UTC date time into the desired display
        ' offset and format. Here we're converting it to the server timezone and formatting
        ' as a short date and a long time string, using the current thread culture.
        Return If(utcDateTime.HasValue, utcDateTime.Value.ToLocalTime().ToString("G"), "[never]")
    End Function
End Class
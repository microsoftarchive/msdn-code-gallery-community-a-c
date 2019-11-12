Imports System.Web.Security
Imports DotNetOpenAuth.AspNet
Imports Microsoft.AspNet.Membership.OpenAuth

Public Class RegisterExternalLogin
    Inherits System.Web.UI.Page

    Protected Property ProviderName As String
        Get
            Return If(DirectCast(ViewState("ProviderName"), String), String.Empty)
        End Get
        Private Set(value As String)
            ViewState("ProviderName") = value
        End Set
    End Property

    Protected Property ProviderDisplayName As String
        Get
            Return If(DirectCast(ViewState("PropertyProviderDisplayName"), String), String.Empty)
        End Get
        Private Set(value As String)
            ViewState("ProviderDisplayName") = value
        End Set
    End Property

    Protected Property ProviderUserId As String
        Get
            Return If(DirectCast(ViewState("ProviderUserId"), String), String.Empty)
        End Get

        Private Set(value As String)
            ViewState("ProviderUserId") = value
        End Set
    End Property

    Protected Property ProviderUserName As String
        Get
            Return If(DirectCast(ViewState("ProviderUserName"), String), String.Empty)
        End Get

        Private Set(value As String)
            ViewState("ProviderUserName") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ProcessProviderResult()
        End If
    End Sub

    Protected Sub logIn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CreateAndLoginUser()
    End Sub

    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RedirectToReturnUrl()
    End Sub

    Private Sub ProcessProviderResult()
        ' Process the result from an auth provider in the request
        ProviderName = OpenAuth.GetProviderNameFromCurrentRequest()

        If String.IsNullOrEmpty(ProviderName) Then
            Response.Redirect(FormsAuthentication.LoginUrl)
        End If

        ' Build the redirect url for OpenAuth verification
        Dim redirectUrl As String = "~/Account/RegisterExternalLogin.aspx"
        Dim returnUrl As String = Request.QueryString("ReturnUrl")
        If Not String.IsNullOrEmpty(returnUrl) Then
            redirectUrl &= "?ReturnUrl=" & HttpUtility.UrlEncode(returnUrl)
        End If

        ' Verify the OpenAuth payload
        Dim authResult As AuthenticationResult = OpenAuth.VerifyAuthentication(redirectUrl)
        ProviderDisplayName = OpenAuth.GetProviderDisplayName(ProviderName)
        If Not authResult.IsSuccessful Then
            Title = "External login failed"
            userNameForm.Visible = False
            
            ModelState.AddModelError("Provider", String.Format("External login with {0} failed.", ProviderDisplayName))
            
            ' To view this error, enable page tracing in web.config (<system.web><trace enabled="true"/></system.web>) and visit ~/Trace.axd
            Trace.Warn("OpenAuth", String.Format("There was an error verifying authentication with {0})", ProviderDisplayName), authResult.Error)
            Return
        End If

        ' User has logged in with provider successfully
        ' Check if user is already registered locally
        If OpenAuth.Login(authResult.Provider, authResult.ProviderUserId, createPersistentCookie:=False) Then
            RedirectToReturnUrl()
        End If

        ' Store the provider details in ViewState
        ProviderName = authResult.Provider
        ProviderUserId = authResult.ProviderUserId
        ProviderUserName = authResult.UserName

        ' Strip the query string from action
        Form.Action = ResolveUrl(redirectUrl)

        If (User.Identity.IsAuthenticated) Then
            ' User is already authenticated, add the external login and redirect to return url
            OpenAuth.AddAccountToExistingUser(ProviderName, ProviderUserId, ProviderUserName, User.Identity.Name)
            RedirectToReturnUrl()
        Else
            ' User is new, ask for their desired membership name
            userName.Text = authResult.UserName
        End If
    End Sub

    Private Sub CreateAndLoginUser()
        If Not IsValid Then
            Return
        End If

        Dim createResult As CreateResult = OpenAuth.CreateUser(ProviderName, ProviderUserId, ProviderUserName, userName.Text)

        If Not createResult.IsSuccessful Then
            
            ModelState.AddModelError("UserName", createResult.ErrorMessage)
            
        Else
            ' User created & associated OK
            If OpenAuth.Login(ProviderName, ProviderUserId, createPersistentCookie:=False) Then
                RedirectToReturnUrl()
            End If
        End If
    End Sub

    Private Sub RedirectToReturnUrl()
        Dim returnUrl As String = Request.QueryString("ReturnUrl")
        If Not String.IsNullOrEmpty(returnUrl) And OpenAuth.IsLocalUrl(returnUrl) Then
            Response.Redirect(returnUrl)
        Else
            Response.Redirect("~/")
        End If
    End Sub
End Class
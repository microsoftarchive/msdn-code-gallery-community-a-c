Imports Microsoft.AspNet.Membership.OpenAuth

Public Class OpenAuthProviders
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If IsPostBack Then
            Dim provider = Request.Form("provider")
            If provider Is Nothing Then
                Return
            End If

            Dim redirectUrl = "~/Account/RegisterExternalLogin.aspx"
            If Not String.IsNullOrEmpty(ReturnUrl) Then
                Dim resolvedReturnUrl = ResolveUrl(ReturnUrl)
                redirectUrl += "?ReturnUrl=" + HttpUtility.UrlEncode(resolvedReturnUrl)
            End If

            OpenAuth.RequestAuthentication(provider, redirectUrl)
        End If
    End Sub

    

    Public Property ReturnUrl As String

    
    Public Function GetProviderNames() As IEnumerable(Of ProviderDetails)
        Return OpenAuth.AuthenticationClients.GetAll()
    End Function
    
End Class
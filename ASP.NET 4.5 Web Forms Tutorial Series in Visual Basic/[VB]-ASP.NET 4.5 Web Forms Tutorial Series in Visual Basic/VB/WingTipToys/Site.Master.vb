Public Class SiteMaster
    Inherits MasterPage

    Const ANTI_XSRF_TOKEN_KEY As String = "__AntiXsrfToken"
    Const ANTI_XSRF_USER_NAME_KEY As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie As HttpCookie = Request.Cookies(ANTI_XSRF_TOKEN_KEY)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(ANTI_XSRF_TOKEN_KEY) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If (Not IsPostBack) Then
            ' Set Anti-XSRF token
            ViewState(ANTI_XSRF_TOKEN_KEY) = Page.ViewStateUserKey
            ViewState(ANTI_XSRF_USER_NAME_KEY) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Validate the Anti-XSRF token
            If (Not DirectCast(ViewState(ANTI_XSRF_TOKEN_KEY), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(ANTI_XSRF_USER_NAME_KEY), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If HttpContext.Current.User.IsInRole("Administrator") Then
            adminLink.Visible = True
        End If
    End Sub

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Dim usersShoppingCart As New ShoppingCartActions()
        Dim cartStr As String = String.Format("Cart ({0})", usersShoppingCart.GetCount())
        cartCount.InnerText = cartStr
    End Sub

    Public Function GetCategories() As IQueryable(Of Category)
        Dim db = New ProductContext()
        Dim query As IQueryable(Of Category) = db.Categories
        Return query
    End Function

End Class
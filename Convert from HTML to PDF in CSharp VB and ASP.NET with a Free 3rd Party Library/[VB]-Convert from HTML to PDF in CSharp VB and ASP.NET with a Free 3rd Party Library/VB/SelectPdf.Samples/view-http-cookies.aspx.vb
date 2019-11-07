Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace SelectPdf.Samples
    Partial Public Class view_http_cookies
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Dim cookies As String = String.Empty
            For Each key As String In Request.Cookies
                Dim cookie As HttpCookie = Request.Cookies(key)
                cookies += "<br/>" + cookie.Name + ": " + cookie.Value
            Next

            LitCookies.Text = cookies
        End Sub
    End Class
End Namespace

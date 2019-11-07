Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace SelectPdf.Samples
    Partial Public Class view_http_headers
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Dim headers As String = String.Empty
            For Each name As String In Request.Headers
                Dim value As String = Request.Headers(name)
                headers += Convert.ToString((Convert.ToString("<br/>") & name) + ": ") & value
            Next

            LitHeaders.Text = headers
        End Sub
    End Class
End Namespace

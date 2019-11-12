Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class http_cookies
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
                Dim url As String = Page.ResolveUrl("~/view-http-cookies.aspx")
                TxtUrl.Text = (New Uri(Request.Url, url)).AbsoluteUri
                LnkTest.NavigateUrl = url
            End If
        End Sub

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set the HTTP cookies
            converter.Options.HttpCookies.Add(TxtName1.Text, TxtValue1.Text)
            converter.Options.HttpCookies.Add(TxtName2.Text, TxtValue2.Text)
            converter.Options.HttpCookies.Add(TxtName3.Text, TxtValue3.Text)
            converter.Options.HttpCookies.Add(TxtName4.Text, TxtValue4.Text)

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

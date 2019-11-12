Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Public Class automatic_bookmarks
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
                Dim url As String = Page.ResolveUrl("~/files/document.html")
                TxtUrl.Text = (New Uri(Request.Url, url)).AbsoluteUri
                LnkTest.NavigateUrl = url
            End If
        End Sub

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set the css selectors for the automatic bookmarks
            converter.Options.PdfBookmarkOptions.CssSelectors = _
                TxtElements.Text.Split(New Char() {","c})

            ' display the bookmarks when the document is opened in a viewer
            converter.Options.ViewerPreferences.PageMode = PdfViewerPageMode.UseOutlines

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

Public Class http_post_request
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim url As String = Page.ResolveUrl("~/view-http-post-data.aspx")
            TxtUrl.Text = (New Uri(Request.Url, url)).AbsoluteUri
            LnkTest.NavigateUrl = url
        End If
    End Sub

    Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
        ' instantiate a html to pdf converter object
        Dim converter As New HtmlToPdf()

        ' set the HTTP POST parameters
        converter.Options.HttpPostParameters.Add(TxtName1.Text, TxtValue1.Text)
        converter.Options.HttpPostParameters.Add(TxtName2.Text, TxtValue2.Text)
        converter.Options.HttpPostParameters.Add(TxtName3.Text, TxtValue3.Text)
        converter.Options.HttpPostParameters.Add(TxtName4.Text, TxtValue4.Text)

        ' create a new pdf document converting an url
        Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

        ' save pdf document
        doc.Save(Response, False, "Sample.pdf")

        ' close pdf document
        doc.Close()
    End Sub
End Class
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class page_breaks
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
                TxtHtmlCode.Text = Helper.PageBreaksText()
            End If
        End Sub

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' read parameters from the webpage
            Dim htmlString As String = TxtHtmlCode.Text
            Dim baseUrl As String = TxtBaseUrl.Text

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            converter.Options.MarginTop = 10
            converter.Options.MarginBottom = 10
            converter.Options.MarginLeft = 10
            converter.Options.MarginRight = 10

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertHtmlString(htmlString, baseUrl)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

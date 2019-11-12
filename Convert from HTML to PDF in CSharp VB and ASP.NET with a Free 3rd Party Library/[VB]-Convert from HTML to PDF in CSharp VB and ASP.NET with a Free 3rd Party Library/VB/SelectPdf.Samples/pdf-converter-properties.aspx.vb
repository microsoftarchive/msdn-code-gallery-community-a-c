Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class pdf_converter_properties
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' get conversion result (contains document info from the web page)
            Dim result As HtmlToPdfResult = converter.ConversionResult

            ' set the document properties
            doc.DocumentInformation.Title = result.WebPageInformation.Title
            doc.DocumentInformation.Subject = result.WebPageInformation.Description
            doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords

            doc.DocumentInformation.Author = "Select.Pdf Samples"
            doc.DocumentInformation.CreationDate = DateTime.Now

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

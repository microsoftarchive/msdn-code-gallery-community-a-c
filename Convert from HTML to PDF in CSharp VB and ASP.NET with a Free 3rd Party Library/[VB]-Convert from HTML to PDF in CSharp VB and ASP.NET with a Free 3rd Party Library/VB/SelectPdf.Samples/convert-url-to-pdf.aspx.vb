Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class convert_url_to_pdf
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' read parameters from the webpage
            Dim url As String = TxtUrl.Text

            Dim pdf_page_size As String = DdlPageSize.SelectedValue
            Dim pageSize As PdfPageSize = DirectCast([Enum].Parse(GetType(PdfPageSize), _
                    pdf_page_size, True), PdfPageSize)

            Dim pdf_orientation As String = DdlPageOrientation.SelectedValue
            Dim pdfOrientation As PdfPageOrientation = DirectCast( _
                    [Enum].Parse(GetType(PdfPageOrientation), _
                    pdf_orientation, True), PdfPageOrientation)

            Dim webPageWidth As Integer = 1024
            Try
                webPageWidth = Convert.ToInt32(TxtWidth.Text)
            Catch
            End Try

            Dim webPageHeight As Integer = 0
            Try
                webPageHeight = Convert.ToInt32(TxtHeight.Text)
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set converter options
            converter.Options.PdfPageSize = pageSize
            converter.Options.PdfPageOrientation = pdfOrientation
            converter.Options.WebPageWidth = webPageWidth
            converter.Options.WebPageHeight = webPageHeight

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(url)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

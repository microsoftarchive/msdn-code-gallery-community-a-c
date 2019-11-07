Imports System.Collections.Generic
Imports System.Linq
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class convert_current_page_to_pdf
        Inherits System.Web.UI.Page

        Private startConversion As Boolean = False

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            startConversion = True
        End Sub

        Protected Overrides Sub Render(writer As HtmlTextWriter)
            If startConversion Then
                ' get html of the page
                Dim myWriter As TextWriter = New StringWriter()
                Dim htmlWriter As New HtmlTextWriter(myWriter)
                MyBase.Render(htmlWriter)

                ' instantiate a html to pdf converter object
                Dim converter As New HtmlToPdf()

                ' create a new pdf document converting the html string of the page
                Dim doc As PdfDocument = converter.ConvertHtmlString(myWriter.ToString(), _
                                                                     Request.Url.AbsoluteUri)

                ' save pdf document
                doc.Save(Response, False, "Sample.pdf")

                ' close pdf document
                doc.Close()
            Else
                ' render web page in browser
                MyBase.Render(writer)
            End If
        End Sub
    End Class
End Namespace

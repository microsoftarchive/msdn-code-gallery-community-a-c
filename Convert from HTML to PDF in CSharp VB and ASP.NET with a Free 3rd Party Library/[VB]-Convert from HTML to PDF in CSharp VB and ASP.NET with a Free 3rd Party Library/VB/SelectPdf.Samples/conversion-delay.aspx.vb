Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Public Class conversion_delay
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' read parameters from webpage
            Dim delay As Integer = 0
            Try
                delay = Convert.ToInt32(TxtDelay.Text)
            Catch
            End Try

            Dim timeout As Integer = 0
            Try
                timeout = Convert.ToInt32(TxtTimeout.Text)
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' specify the number of seconds the conversion is delayed
            converter.Options.MinPageLoadTime = delay

            ' set the page timeout
            converter.Options.MaxPageLoadTime = timeout

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

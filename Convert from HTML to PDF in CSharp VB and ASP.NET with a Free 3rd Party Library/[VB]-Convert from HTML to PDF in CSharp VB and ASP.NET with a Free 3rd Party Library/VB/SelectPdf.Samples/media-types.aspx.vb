Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class media_types
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set css media type
            converter.Options.CssMediaType = DirectCast( _
                [Enum].Parse(GetType(HtmlToPdfCssMediaType), DdlCssMediaType.SelectedValue, True),  _
                HtmlToPdfCssMediaType)

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

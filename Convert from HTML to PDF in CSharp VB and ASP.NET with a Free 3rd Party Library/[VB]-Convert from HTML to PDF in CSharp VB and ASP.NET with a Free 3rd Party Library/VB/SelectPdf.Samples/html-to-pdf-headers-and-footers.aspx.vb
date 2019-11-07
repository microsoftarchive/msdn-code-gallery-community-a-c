Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class html_to_pdf_headers_and_footers
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' get parameters
            Dim headerUrl As String = Server.MapPath("~/files/header.html")
            Dim footerUrl As String = Server.MapPath("~/files/footer.html")

            Dim showHeaderOnFirstPage As Boolean = ChkHeaderFirstPage.Checked
            Dim showHeaderOnOddPages As Boolean = ChkHeaderOddPages.Checked
            Dim showHeaderOnEvenPages As Boolean = ChkHeaderEvenPages.Checked

            Dim headerHeight As Integer = 50
            Try
                headerHeight = Convert.ToInt32(TxtHeaderHeight.Text)
            Catch
            End Try


            Dim showFooterOnFirstPage As Boolean = ChkFooterFirstPage.Checked
            Dim showFooterOnOddPages As Boolean = ChkFooterOddPages.Checked
            Dim showFooterOnEvenPages As Boolean = ChkFooterEvenPages.Checked

            Dim footerHeight As Integer = 50
            Try
                footerHeight = Convert.ToInt32(TxtFooterHeight.Text)
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' header settings
            converter.Options.DisplayHeader = showHeaderOnFirstPage OrElse _
                showHeaderOnOddPages OrElse showHeaderOnEvenPages
            converter.Header.DisplayOnFirstPage = showHeaderOnFirstPage
            converter.Header.DisplayOnOddPages = showHeaderOnOddPages
            converter.Header.DisplayOnEvenPages = showHeaderOnEvenPages
            converter.Header.Height = headerHeight

            Dim headerHtml As New PdfHtmlSection(headerUrl)
            headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit
            converter.Header.Add(headerHtml)

            ' footer settings
            converter.Options.DisplayFooter = showFooterOnFirstPage OrElse _
                showFooterOnOddPages OrElse showFooterOnEvenPages
            converter.Footer.DisplayOnFirstPage = showFooterOnFirstPage
            converter.Footer.DisplayOnOddPages = showFooterOnOddPages
            converter.Footer.DisplayOnEvenPages = showFooterOnEvenPages
            converter.Footer.Height = footerHeight

            Dim footerHtml As New PdfHtmlSection(footerUrl)
            footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit
            converter.Footer.Add(footerHtml)

            ' add page numbering element to the footer
            If ChkPageNumbering.Checked Then
                ' page numbers can be added using a PdfTextSection object
                Dim text As New PdfTextSection(0, 10, "Page: {page_number} of {total_pages}  ", _
                                               New System.Drawing.Font("Arial", 8))
                text.HorizontalAlign = PdfTextHorizontalAlign.Right
                converter.Footer.Add(text)
            End If

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

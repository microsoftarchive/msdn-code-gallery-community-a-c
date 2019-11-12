Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class pdf_converter_viewer_preferences
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' read parameters from the webpage
            Dim url As String = TxtUrl.Text

            Dim page_layout As String = DdlPageLayout.SelectedValue
            Dim pageLayout As PdfViewerPageLayout = DirectCast( _
                [Enum].Parse(GetType(PdfViewerPageLayout), page_layout, True),  _
                PdfViewerPageLayout)

            Dim page_mode As String = DdlPageMode.SelectedValue
            Dim pageMode As PdfViewerPageMode = DirectCast( _
                [Enum].Parse(GetType(PdfViewerPageMode), page_mode, True),  _
                PdfViewerPageMode)

            Dim centerWindow As Boolean = ChkCenterWindow.Checked
            Dim displayDocTitle As Boolean = ChkDisplayDocTitle.Checked
            Dim fitWindow As Boolean = ChkFitWindow.Checked
            Dim hideMenuBar As Boolean = ChkHideMenuBar.Checked
            Dim hideToolbar As Boolean = ChkHideToolbar.Checked
            Dim hideWindowUI As Boolean = ChkHideWindowUI.Checked

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set converter options
            converter.Options.ViewerPreferences.CenterWindow = centerWindow
            converter.Options.ViewerPreferences.DisplayDocTitle = displayDocTitle
            converter.Options.ViewerPreferences.FitWindow = fitWindow
            converter.Options.ViewerPreferences.HideMenuBar = hideMenuBar
            converter.Options.ViewerPreferences.HideToolbar = hideToolbar
            converter.Options.ViewerPreferences.HideWindowUI = hideWindowUI

            converter.Options.ViewerPreferences.PageLayout = pageLayout
            converter.Options.ViewerPreferences.PageMode = pageMode
            converter.Options.ViewerPreferences.NonFullScreenPageMode = _
                PdfViewerFullScreenExitMode.UseNone

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(url)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SelectPdf

Namespace SelectPdf.Samples
    Partial Public Class pdf_converter_security
        Inherits System.Web.UI.Page

        Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
            ' read parameters from the webpage
            Dim url As String = TxtUrl.Text

            Dim userPassword As String = TxtUserPassword.Text.Trim()
            Dim ownerPassword As String = TxtOwnerPassword.Text.Trim()

            Dim canAssembleDocument As Boolean = ChkCanAssembleDocument.Checked
            Dim canCopyContent As Boolean = ChkCanCopyContent.Checked
            Dim canEditAnnotations As Boolean = ChkCanEditAnnotations.Checked
            Dim canEditContent As Boolean = ChkCanEditContent.Checked
            Dim canFillFormFields As Boolean = ChkCanFillFormFields.Checked
            Dim canPrint As Boolean = ChkCanPrint.Checked

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set document passwords
            If Not String.IsNullOrEmpty(userPassword) Then
                converter.Options.SecurityOptions.UserPassword = userPassword
            End If
            If Not String.IsNullOrEmpty(ownerPassword) Then
                converter.Options.SecurityOptions.OwnerPassword = ownerPassword
            End If

            'set document permissions
            converter.Options.SecurityOptions.CanAssembleDocument = canAssembleDocument
            converter.Options.SecurityOptions.CanCopyContent = canCopyContent
            converter.Options.SecurityOptions.CanEditAnnotations = canEditAnnotations
            converter.Options.SecurityOptions.CanEditContent = canEditContent
            converter.Options.SecurityOptions.CanFillFormFields = canFillFormFields
            converter.Options.SecurityOptions.CanPrint = canPrint

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(url)

            ' save pdf document
            doc.Save(Response, False, "Sample.pdf")

            ' close pdf document
            doc.Close()
        End Sub
    End Class
End Namespace

Imports System.IO
Imports System.Net.Mail

Public Class convert_and_email
    Inherits System.Web.UI.Page

    Protected Sub BtnCreatePdf_Click(sender As Object, e As EventArgs)
        ' instantiate a html to pdf converter object
        Dim converter As New HtmlToPdf()

        Try
            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(TxtUrl.Text)

            ' create memory stream to save PDF
            Dim pdfStream As New MemoryStream()

            ' save pdf document into a MemoryStream
            doc.Save(pdfStream)

            ' reset stream position
            pdfStream.Position = 0

            ' create email message
            Dim message As New MailMessage()
            message.From = New MailAddress("support@selectpdf.com")
            message.[To].Add(New MailAddress(TxtEmail.Text))
            message.Subject = "SelectPdf Sample - Convert and Email as Attachment"
            message.Body = "This email should have attached the PDF document " + _
                "resulted from the conversion of the following url to pdf: " + TxtUrl.Text
            message.Attachments.Add(New Attachment(pdfStream, "Document.pdf"))

            ' send email
            Dim smtp As New SmtpClient()
            smtp.Send(message)

            ' close pdf document
            doc.Close()

            LblMessage.Text = "Email sent"
        Catch ex As Exception
            LblMessage.Text = "An error occurred: " + ex.Message
        End Try
    End Sub
End Class
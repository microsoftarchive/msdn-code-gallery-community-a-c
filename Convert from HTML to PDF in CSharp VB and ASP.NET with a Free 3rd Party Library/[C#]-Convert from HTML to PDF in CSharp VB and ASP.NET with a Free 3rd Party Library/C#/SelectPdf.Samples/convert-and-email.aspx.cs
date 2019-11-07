using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;

namespace SelectPdf.Samples
{
    public partial class convert_and_email : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            try
            {
                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

                // create memory stream to save PDF
                MemoryStream pdfStream = new MemoryStream();

                // save pdf document into a MemoryStream
                doc.Save(pdfStream);

                // reset stream position
                pdfStream.Position = 0;

                // create email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("support@selectpdf.com");
                message.To.Add(new MailAddress(TxtEmail.Text));
                message.Subject = "SelectPdf Sample - Convert and Email as Attachment";
                message.Body = "This email should have attached the PDF document " +
                    "resulted from the conversion of the following url to pdf: " +
                    TxtUrl.Text;
                message.Attachments.Add(new Attachment(pdfStream, "Document.pdf"));

                // send email
                new SmtpClient().Send(message);

                // close pdf document
                doc.Close();

                LblMessage.Text = "Email sent";
            }
            catch (Exception ex)
            {
                LblMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
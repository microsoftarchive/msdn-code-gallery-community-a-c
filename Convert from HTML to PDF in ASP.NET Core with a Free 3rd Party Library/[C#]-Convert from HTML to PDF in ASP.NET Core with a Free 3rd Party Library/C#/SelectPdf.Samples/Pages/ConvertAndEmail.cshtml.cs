using System;
using System.IO;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class ConvertAndEmailModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }
        [BindProperty]
        public string TxtEmail { get; set; }

        public void OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            try
            {
                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertUrl(TxtUrl);

                // create memory stream to save PDF
                MemoryStream pdfStream = new MemoryStream();

                // save pdf document into a MemoryStream
                doc.Save(pdfStream);

                // reset stream position
                pdfStream.Position = 0;

                // create email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("support@selectpdf.com");
                message.To.Add(new MailAddress(TxtEmail));
                message.Subject = "SelectPdf Sample - Convert and Email as Attachment";
                message.Body = "This email should have attached the PDF document " +
                    "resulted from the conversion of the following url to pdf: " +
                    TxtUrl;
                message.Attachments.Add(new Attachment(pdfStream, "Document.pdf"));

                // send email
                new SmtpClient().Send(message);

                // close pdf document
                doc.Close();

                ViewData["Message"] = "Email sent";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "An error occurred: " + ex.Message;
            }

        }
    }
}
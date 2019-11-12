using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator
{
    public partial class File_Attachments : System.Web.UI.Page
    {
        protected void createPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create a PDF document
            Document pdfDocument = new Document(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Display the attachments panel when the PDF document is opened in a PDF viewer
            pdfDocument.ViewerPreferences.PageMode = ViewerPageMode.UseAttachments;

            // Add a page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 10, true);
            titleFont.Bold = true;
            PdfFont subtitleFont = new PdfFont("Times New Roman", 8, true);

            // Add document title
            TextElement titleTextElement = new TextElement(5, 5, "Attach Files and Streams to a PDF Document", titleFont);
            pdfPage.AddElement(titleTextElement);

            // Create an attachment from a file without icon
            string fileAttachmentPath = Server.MapPath("~/DemoAppFiles/Input/Attach_Files/Attachment_File.txt");
            pdfDocument.AddFileAttachment(fileAttachmentPath, "Attachment from File");

            // Create an attachment from a stream without icon
            string fileStreamAttachmentPath = Server.MapPath("~/DemoAppFiles/Input/Attach_Files/Attachment_Stream.txt");
            byte[] attachmentData = System.IO.File.ReadAllBytes(fileStreamAttachmentPath);
            pdfDocument.AddFileAttachment(attachmentData, "Attachment_Stream.txt", "Attachment from Stream");

            // Add the text element
            string text = "Click the next icon to open the attachment from a file:";
            TextElement textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 15);

            // Create an attachment from file with paperclip icon in PDF
            string fileAttachmentWithIconPath = Server.MapPath("~/DemoAppFiles/Input/Attach_Files/Attachment_File_Icon.txt");
            // Create the attachment from file
            RectangleFloat attachFromFileIconRectangle = new RectangleFloat(0, 0, 6, 10);
            FileAttachmentElement attachFromFileElement = new FileAttachmentElement(attachFromFileIconRectangle, fileAttachmentWithIconPath);
            attachFromFileElement.IconType = FileAttachmentIcon.Paperclip;
            attachFromFileElement.Text = "Attachment from File with Paperclip Icon";
            attachFromFileElement.IconColor = RgbColor.Blue;
            pdfDocument.AddElement(attachFromFileElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "Click the next icon to open the attachment from a stream:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            // Create an attachment from stream with pushpin icon in PDF
            string fileStreamAttachmentWithIconPath = Server.MapPath("~/DemoAppFiles/Input/Attach_Files/Attachment_Stream_Icon.txt");
            byte[] attachmentDataWithIcon = System.IO.File.ReadAllBytes(fileStreamAttachmentWithIconPath);
            // Create the attachment from stream
            RectangleFloat attachFromStreamIconRectangle = new RectangleFloat(0, 0, 6, 10);
            FileAttachmentElement attachFromStreamElement = new FileAttachmentElement(attachFromStreamIconRectangle, attachmentDataWithIcon, "Attachment_Stream_Icon.txt");
            attachFromStreamElement.IconType = FileAttachmentIcon.PushPin;
            attachFromStreamElement.Text = "Attachment from Stream with Pushpin Icon";
            attachFromStreamElement.IconColor = RgbColor.Green;
            pdfDocument.AddElement(attachFromStreamElement, 10, true, false, 0, true, false);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=File_Attachments.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/File_Attachments.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/File_Attachments.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("File_Attachments");
            }
        }

        protected void demoMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Live_Demo":
                    demoMultiView.SetActiveView(liveDemoView);
                    break;
                case "Description":
                    demoMultiView.SetActiveView(descriptionView);
                    break;
                case "Sample_Code":
                    demoMultiView.SetActiveView(sampleCodeView);
                    break;
                default:
                    break;
            }
        }
    }
}
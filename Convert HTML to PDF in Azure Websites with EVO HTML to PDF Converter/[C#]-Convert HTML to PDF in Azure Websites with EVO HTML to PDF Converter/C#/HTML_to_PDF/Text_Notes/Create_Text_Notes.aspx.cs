using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.Text_Notes
{
    public partial class Create_Text_Notes : System.Web.UI.Page
    {
        protected void convertToPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                htmlToPdfConverter.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Set an adddional delay in seconds to wait for JavaScript or AJAX calls after page load completed
            // Set this property to 0 if you don't need to wait for such asynchcronous operations to finish
            htmlToPdfConverter.ConversionDelay = 2;

            string htmlWithLinksAndAttachMarkers = htmlStringTextBox.Text;
            string baseUrl = baseUrlTextBox.Text;

            // Convert a HTML string with markers for file links and attachments to a PDF document object
            Document pdfDocument = htmlToPdfConverter.ConvertHtmlToPdfDocumentObject(htmlWithLinksAndAttachMarkers, baseUrl);

            // Make the HTML element with 'text_note' mapping ID a text note
            HtmlElementMapping textNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("text_note");
            if (textNoteMapping != null)
            {
                PdfPage textNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat textNoteRectangle = textNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement textNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed text note");
                textNoteElement.NoteIcon = TextNoteIcon.Note;
                textNoteElement.Open = false;
                textNotePage.AddElement(textNoteElement);
            }

            // Make the HTML element with 'text_note_opened' mapping ID an initially opened text note
            HtmlElementMapping textNoteOpenedMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("text_note_opened");
            if (textNoteOpenedMapping != null)
            {
                PdfPage textNoteOpenedPage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat textNoteOpenedRectangle = textNoteOpenedMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement textNoteOpenedElement = new TextNoteElement(textNoteOpenedRectangle, "This is an initially opened text note");
                textNoteOpenedElement.NoteIcon = TextNoteIcon.Note;
                textNoteOpenedElement.Open = true;
                textNoteOpenedPage.AddElement(textNoteOpenedElement);
            }

            // Make the HTML element with 'help_note' mapping ID a help note
            HtmlElementMapping helpNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("help_note");
            if (helpNoteMapping != null)
            {
                PdfPage helpNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat helpNoteRectangle = helpNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement helpNoteElement = new TextNoteElement(helpNoteRectangle, "This is an initially closed help note");
                helpNoteElement.NoteIcon = TextNoteIcon.Help;
                helpNoteElement.Open = false;
                helpNotePage.AddElement(helpNoteElement);
            }

            // Make the HTML element with 'help_note_opened' mapping ID an initially opened help note
            HtmlElementMapping helpNoteOpenedMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("help_note_opened");
            if (helpNoteOpenedMapping != null)
            {
                PdfPage helpNoteOpenedPage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat helpNoteOpenedRectangle = helpNoteOpenedMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement helpNoteOpenedElement = new TextNoteElement(helpNoteOpenedRectangle, "This is an initially opened help note");
                helpNoteOpenedElement.NoteIcon = TextNoteIcon.Help;
                helpNoteOpenedElement.Open = true;
                helpNoteOpenedPage.AddElement(helpNoteOpenedElement);
            }

            // Make the HTML element with 'comment_note' mapping ID a comment note
            HtmlElementMapping commentNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("comment_note");
            if (commentNoteMapping != null)
            {
                PdfPage commentNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat commentNoteRectangle = commentNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement commentNoteElement = new TextNoteElement(commentNoteRectangle, "This is an initially closed comment note");
                commentNoteElement.NoteIcon = TextNoteIcon.Comment;
                commentNoteElement.Open = false;
                commentNotePage.AddElement(commentNoteElement);
            }

            // Make the HTML element with 'comment_note_opened' mapping ID an initially opened comment note
            HtmlElementMapping commentNoteOpenedMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("comment_note_opened");
            if (commentNoteOpenedMapping != null)
            {
                PdfPage commentNoteOpenedPage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat commentNoteOpenedRectangle = commentNoteOpenedMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement commentNoteOpenedElement = new TextNoteElement(commentNoteOpenedRectangle, "This is an initially opened comment note");
                commentNoteOpenedElement.NoteIcon = TextNoteIcon.Comment;
                commentNoteOpenedElement.Open = true;
                commentNoteOpenedPage.AddElement(commentNoteOpenedElement);
            }

            // Make the HTML element with 'paragraph_note' mapping ID a paragraph note
            HtmlElementMapping paragraphNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("paragraph_note");
            if (paragraphNoteMapping != null)
            {
                PdfPage paragraphNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat paragraphNoteRectangle = paragraphNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement paragraphNoteElement = new TextNoteElement(paragraphNoteRectangle, "This is an initially closed paragraph note");
                paragraphNoteElement.NoteIcon = TextNoteIcon.Paragraph;
                paragraphNoteElement.Open = false;
                paragraphNotePage.AddElement(paragraphNoteElement);
            }

            // Make the HTML element with 'new_paragraph_note' mapping ID a new paragraph note
            HtmlElementMapping newParagraphNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("new_paragraph_note");
            if (newParagraphNoteMapping != null)
            {
                PdfPage newParagraphNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat newParagraphNoteRectangle = newParagraphNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement newParagraphNoteElement = new TextNoteElement(newParagraphNoteRectangle, "This is an initially closed new paragraph note");
                newParagraphNoteElement.NoteIcon = TextNoteIcon.NewParagraph;
                newParagraphNoteElement.Open = false;
                newParagraphNotePage.AddElement(newParagraphNoteElement);
            }

            // Make the HTML element with 'key_note' mapping ID a key note
            HtmlElementMapping keyNoteMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("key_note");
            if (keyNoteMapping != null)
            {
                PdfPage keyNotePage = pdfDocument.GetPage(textNoteMapping.PdfRectangles[0].PageIndex);
                RectangleFloat keyNoteRectangle = keyNoteMapping.PdfRectangles[0].Rectangle;

                // Create the text note
                TextNoteElement keyNoteElement = new TextNoteElement(keyNoteRectangle, "This is an initially closed key note");
                keyNoteElement.NoteIcon = TextNoteIcon.Key;
                keyNoteElement.Open = false;
                keyNotePage.AddElement(keyNoteElement);
            }

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Text_Notes.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                string rootUrl = "http://www.evopdf.com/demo/";

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Text_Notes.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Text_Notes/Create_Text_Notes.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Text_Notes/Create_Text_Notes.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("Text_Notes");
                Master.SelectNode("Create_Text_Notes");
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
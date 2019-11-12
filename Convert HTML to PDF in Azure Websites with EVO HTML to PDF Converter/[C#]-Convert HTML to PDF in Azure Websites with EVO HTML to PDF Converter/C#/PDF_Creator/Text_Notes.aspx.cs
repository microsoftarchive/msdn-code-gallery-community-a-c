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
    public partial class Text_Notes : System.Web.UI.Page
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

            // Add a page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 10, true);
            titleFont.Bold = true;
            PdfFont subtitleFont = new PdfFont("Times New Roman", 8, true);

            // Add document title
            TextElement titleTextElement = new TextElement(5, 5, "Add Text Notes to a PDF Document", titleFont);
            pdfPage.AddElement(titleTextElement);

            // Add the text element
            string text = "Click the next icon to open the the text note:";
            TextElement textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 10);

            RectangleFloat textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement textNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed text note");
            textNoteElement.NoteIcon = TextNoteIcon.Note;
            textNoteElement.Open = false;
            pdfDocument.AddElement(textNoteElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "This is an already opened text note:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement textNoteOpenedElement = new TextNoteElement(textNoteRectangle, "This is an initially opened text note");
            textNoteOpenedElement.NoteIcon = TextNoteIcon.Note;
            textNoteOpenedElement.Open = true;
            pdfDocument.AddElement(textNoteOpenedElement, 10, true, false, 0, true, false);


            // Add the text element
            text = "Click the next icon to open the the help note:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement helpNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed help note");
            helpNoteElement.NoteIcon = TextNoteIcon.Help;
            helpNoteElement.Open = false;
            pdfDocument.AddElement(helpNoteElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "This is an already opened help note:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement helpNoteOpenedElement = new TextNoteElement(textNoteRectangle, "This is an initially opened help note");
            helpNoteOpenedElement.NoteIcon = TextNoteIcon.Help;
            helpNoteOpenedElement.Open = true;
            pdfDocument.AddElement(helpNoteOpenedElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "Click the next icon to open the comment:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement commentNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed comment note");
            commentNoteElement.NoteIcon = TextNoteIcon.Comment;
            commentNoteElement.Open = false;
            pdfDocument.AddElement(commentNoteElement, 10, true, false, 0, true, false);


            // Add the text element
            text = "This is an already opened comment:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement commentNoteOpenedElement = new TextNoteElement(textNoteRectangle, "This is an initially opened comment note");
            commentNoteOpenedElement.NoteIcon = TextNoteIcon.Comment;
            commentNoteOpenedElement.Open = true;
            pdfDocument.AddElement(commentNoteOpenedElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "Click the next icon to open the paragraph note: ";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement paragraphNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed paragraph note");
            paragraphNoteElement.NoteIcon = TextNoteIcon.Paragraph;
            paragraphNoteElement.Open = false;
            pdfDocument.AddElement(paragraphNoteElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "Click the next icon to open the new paragraph note:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement newParagraphNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed new paragraph note");
            newParagraphNoteElement.NoteIcon = TextNoteIcon.NewParagraph;
            newParagraphNoteElement.Open = false;
            pdfDocument.AddElement(newParagraphNoteElement, 10, true, false, 0, true, false);

            // Add the text element
            text = "Click the next icon to open the key note:";
            textElement = new TextElement(0, 0, 200, text, subtitleFont);
            pdfDocument.AddElement(textElement, 5, false, 10, true);

            textNoteRectangle = new RectangleFloat(0, 0, 10, 10);

            // Create the text note
            TextNoteElement keyNoteElement = new TextNoteElement(textNoteRectangle, "This is an initially closed key note");
            keyNoteElement.NoteIcon = TextNoteIcon.Key;
            keyNoteElement.Open = false;
            pdfDocument.AddElement(keyNoteElement, 10, true, false, 0, true, false);

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
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Text_Notes.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Text_Notes.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("PDF_Creator_Text_Notes");
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
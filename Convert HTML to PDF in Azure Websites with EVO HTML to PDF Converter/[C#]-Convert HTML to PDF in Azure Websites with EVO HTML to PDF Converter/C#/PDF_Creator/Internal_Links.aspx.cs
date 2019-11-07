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
    public partial class Internal_Links : System.Web.UI.Page
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

            // Add second page to PDF document
            PdfPage secondPdfPage = pdfDocument.AddPage();

            // Add third page to PDF document
            PdfPage thirdPdfPage = pdfDocument.AddPage();

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 10, true);
            titleFont.Bold = true;
            PdfFont subtitleFont = new PdfFont("Times New Roman", 8, true);

            // The links text font
            PdfFont linkTextFont = new PdfFont("Times New Roman", 8, true);
            linkTextFont.Bold = true;
            linkTextFont.Underline = true;

            // Add document title
            TextElement titleTextElement = new TextElement(5, 5, "Create Internal Links in PDF Document", titleFont);
            pdfPage.AddElement(titleTextElement);

            // Add a text in second page
            TextElement secondPageTextElement = new TextElement(5, 5, "This text is the target of an internal text link", subtitleFont);
            secondPdfPage.AddElement(secondPageTextElement);

            // Add a text in third page
            TextElement thirdPageTextElement = new TextElement(5, 5, "This text is the target of an internal image link", subtitleFont);
            thirdPdfPage.AddElement(thirdPageTextElement);

            // Make a text in PDF an internal link to the second page of the PDF document

            // Add the text element
            string text = "Click this text to go to the second page of this document!";
            TextElement linkTextElement = new TextElement(5, 30, 200, text, linkTextFont);
            linkTextElement.ForeColor = RgbColor.Navy;
            pdfPage.AddElement(linkTextElement);

            // Make the text element an internal link to the second page of this document
            RectangleFloat linkRectangle = RectangleFloat.Empty;
            // Create the destination in second page
            ExplicitDestination secondPageDestination = new ExplicitDestination(secondPdfPage, new PointFloat(5, 5));
            // Create the internal link from text element to second page
            InternalLinkElement internalLink = new InternalLinkElement(linkRectangle, secondPageDestination);

            // Add the internal link to PDF document
            pdfDocument.AddElement(internalLink, 0, true, true, 0, true, false);

            // Make an image in PDF an internal link to the third page of the PDF document

            TextElement subtitleTextElement = new TextElement(0, 0, "Click the image below to go to the third page of this document:", subtitleFont);
            pdfDocument.AddElement(subtitleTextElement, 10);

            // Add the image element
            ImageElement linkImageElement = new ImageElement(0, 0, 120, Server.MapPath("~/DemoAppFiles/Input/Images/logo.jpg"));
            pdfDocument.AddElement(linkImageElement);

            // Make the image element an internal link to the third page of this document
            linkRectangle = RectangleFloat.Empty;
            // Create the destination in third page
            ExplicitDestination thirdPageDestination = new ExplicitDestination(thirdPdfPage, new PointFloat(5, 5));
            // Create the internal link from image element to third page
            internalLink = new InternalLinkElement(linkRectangle, thirdPageDestination);

            // Add the internal link to PDF document
            pdfDocument.AddElement(internalLink, 0, true, true, 0, true, false);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Internal_Links.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Internal_Links.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Internal_Links.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Internal_Links");
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
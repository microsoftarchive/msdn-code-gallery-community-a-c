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
    public partial class Text_Elements : System.Web.UI.Page
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

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 10, true);
            titleFont.Bold = true;
            titleFont.Underline = true;

            // Create a PDF page in PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Text Elements Using Fonts Installed in System

            // Add section title
            TextElement titleTextElement = new TextElement(5, 5, "Text Elements Using Fonts Installed in System", titleFont);
            titleTextElement.ForeColor = RgbColor.DarkGreen;
            pdfPage.AddElement(titleTextElement);

            // Embed in PDF document a font with Normal style installed in system
            PdfFont embeddedSystemFontNormal = new PdfFont("Times New Roman", 10, true);

            // Add a text element using a font with Normal style installed in system
            TextElement embeddedSystemFontNormalTextElement = new TextElement(0, 0, "This text uses a font with Normal style installed in system", embeddedSystemFontNormal);
            pdfDocument.AddElement(embeddedSystemFontNormalTextElement, 5, 10);

            // Embed in PDF document a font with Bold style installed in system
            PdfFont embeddedSystemFontBold = new PdfFont("Times New Roman", 10, true);
            embeddedSystemFontBold.Bold = true;

            // Add a text element using a font with Bold style installed in system
            TextElement embeddedSystemFontBoldTextElement = new TextElement(0, 0, "This text uses a font with Bold style installed in system", embeddedSystemFontBold);
            pdfDocument.AddElement(embeddedSystemFontBoldTextElement, 3);

            // Embed in PDF document a font with Italic style installed in system
            PdfFont embeddedSystemFontItalic = new PdfFont("Times New Roman", 10, true);
            embeddedSystemFontItalic.Italic = true;

            // Add a text element using a font with Italic style installed in system
            TextElement embeddedSystemFontItalicTextElement = new TextElement(0, 0, "This text uses a font with Italic style installed in system", embeddedSystemFontItalic);
            pdfDocument.AddElement(embeddedSystemFontItalicTextElement, 3);

            // Text Elements Using Fonts From Local Files

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Elements Using Fonts From Local Files", titleFont);
            titleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(titleTextElement, -5, 15);

            // Embed a True Type font from a local file in PDF document
            PdfFont localTrueTypeFont = new PdfFont(Server.MapPath("~/DemoAppFiles/Input/Fonts/TrueType.ttf"), 10);

            // Add a text element using the local True Type font to PDF document
            TextElement localFontTtfTextElement = new TextElement(0, 0, "This text uses a True Type Font loaded from a local file", localTrueTypeFont);
            pdfDocument.AddElement(localFontTtfTextElement, 5, 10);

            // Embed an OpenType font with TrueType Outlines in PDF document
            PdfFont localOpenTypeTrueTypeFont = new PdfFont(Server.MapPath("~/DemoAppFiles/Input/Fonts/OpenTypeTrueType.otf"), 10);

            // Add a text element using the local OpenType font with TrueType Outlines to PDF document
            TextElement localOpenTypeTrueTypeFontTextElement = new TextElement(0, 0, "This text uses an Open Type Font with TrueType Outlines loaded from a local file", localOpenTypeTrueTypeFont);
            pdfDocument.AddElement(localOpenTypeTrueTypeFontTextElement);

            //  Embed an OpenType font with PostScript Outlines in PDF document
            PdfFont localOpenTypePostScriptFont = new PdfFont(Server.MapPath("~/DemoAppFiles/Input/Fonts/OpenTypePostScript.otf"), 10);

            // Add a text element using the local OpenType font with PostScript Outlines to PDF document
            TextElement localOpenTypePostScriptFontTextElement = new TextElement(0, 0, "This text uses an Open Type Font with PostScript Outlines loaded from a local file", localOpenTypePostScriptFont);
            pdfDocument.AddElement(localOpenTypePostScriptFontTextElement, 3);

            // Text Elements Using Standard PDF Fonts

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Elements Using Standard PDF Fonts", titleFont);
            titleTextElement.ForeColor = RgbColor.DarkGreen;
            pdfDocument.AddElement(titleTextElement, -5, 10);

            // Create a standard PDF font with Normal style
            PdfFont standardPdfFontNormal = new PdfFont(StdFontBaseFamily.Helvetica, 10);

            // Add a text element using the standard PDF font with Normal style
            TextElement standardPdfFontNormalTextElement = new TextElement(0, 0, "This text uses a standard PDF font with Normal style", standardPdfFontNormal);
            pdfDocument.AddElement(standardPdfFontNormalTextElement, 5, 10);

            // Create a standard PDF font with Bold style
            PdfFont standardPdfFontBold = new PdfFont(StdFontBaseFamily.HelveticaBold, 10);

            // Add a text element using the standard PDF font with Bold style
            TextElement standardPdfFontBoldTextElement = new TextElement(0, 0, "This text uses a standard PDF font with Bold style", standardPdfFontBold);
            pdfDocument.AddElement(standardPdfFontBoldTextElement, 3);

            // Create a standard PDF font with Italic style
            PdfFont standardPdfFontItalic = new PdfFont(StdFontBaseFamily.HelveticaOblique, 10);

            // Add a text element using the standard PDF font with Italic style
            TextElement standardPdfFontItalicTextElement = new TextElement(0, 0, "This text uses a standard PDF font with Italic style", standardPdfFontItalic);
            pdfDocument.AddElement(standardPdfFontItalicTextElement, 3);

            // Add a text element that flows freely in width and height

            string text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Text_Files/Text_File.txt"));

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Element that flows freely in width and height", titleFont);
            titleTextElement.ForeColor = RgbColor.DarkGreen;
            pdfDocument.AddElement(titleTextElement, -5, 10);

            // Add the text element
            TextElement freeWidthAndHeightTextElement = new TextElement(0, 0, text, embeddedSystemFontNormal);
            pdfDocument.AddElement(freeWidthAndHeightTextElement, 5, 10);

            // Add a text element with a given width that flows freely in height

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Element with a given width that flows freely in height", titleFont);
            titleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(titleTextElement, -5, 10);

            // Add the text element
            TextElement freeHeightTextElement = new TextElement(0, 0, 400, text, embeddedSystemFontNormal);
            pdfDocument.AddElement(freeHeightTextElement, 5, 10);

            // Add a text element with a given width and height

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Element with a given width and height", titleFont);
            titleTextElement.ForeColor = RgbColor.DarkGreen;
            pdfDocument.AddElement(titleTextElement, -5, 10);

            // Add the text element
            TextElement boundedTextElement = new TextElement(0, 0, 400, 50, text, embeddedSystemFontNormal);
            pdfDocument.AddElement(boundedTextElement, 5, 10);

            // Add a text element that flows freely on next PDF page

            // Add section title
            titleTextElement = new TextElement(0, 0, "Text Element that flows freely on multiple PDF pages", titleFont);
            titleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(titleTextElement, -5, 10);

            // Add the text element
            string multiPageText = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Text_Files/Large_Text_File.txt"));
            TextElement multiPageTextElement = new TextElement(0, 0, 575, multiPageText, embeddedSystemFontNormal);
            multiPageTextElement.BackColor = RgbColor.WhiteSmoke;
            pdfDocument.AddElement(multiPageTextElement, 5, 10);

            // Add a line at the bottom of the multipage text element

            LineElement bottomLine = new LineElement(0, 0, 100, 0);
            pdfDocument.AddElement(bottomLine, 0, 1);

            pdfPage = pdfDocument.AddPage();

            // Text Elements with Vertical Text

            // Add section title
            titleTextElement = new TextElement(0, 0, "Vertical Text", titleFont);
            titleTextElement.ForeColor = RgbColor.Navy;
            pdfPage.AddElement(titleTextElement);

            // Add a top to bottom vertical text
            string topBottomText = "This is a Top to Bottom Vertical Text";

            TextElement topBottomVerticalTextElement = new TextElement(0, 0, topBottomText, embeddedSystemFontNormal);
            topBottomVerticalTextElement.Translate(25, 50);
            topBottomVerticalTextElement.Rotate(90);
            pdfDocument.AddElement(topBottomVerticalTextElement);

            pdfPage = pdfDocument.AddPage();

            // Add a bottom to top vertical text
            string bottomTopText = "This is a Bottom to Top Vertical Text";
            float bottomTopTextWidth = 200;

            TextElement bottomTopVerticalTextElement = new TextElement(0, 0, bottomTopText, embeddedSystemFontNormal);
            bottomTopVerticalTextElement.Translate(0, bottomTopTextWidth);
            bottomTopVerticalTextElement.Rotate(-90);
            pdfPage.AddElement(bottomTopVerticalTextElement);

            // Add a text stamp to a PDF document

            // Create a PDF font
            PdfFont stampPdfFont = new PdfFont("Times New Roman", 24, true);
            // The stamp text
            string stampText = String.Format("Text Stamp {0}", DateTime.Now.ToString("d"));
            // Measure the text 
            float textWidth = 100;
            PdfPage page = pdfDocument.AddPage();
            // Get the PDF page drawable area width and height
            float pdfPageWidth = page.PageSize.Width;
            float pdfPageHeight = page.PageSize.Height;

            // Calculate the PDF page diagonal
            float pdfPageDiagonal = (float)Math.Sqrt(pdfPageWidth * pdfPageWidth + pdfPageHeight * pdfPageHeight);

            // The text location on PDF page diagonal
            float xStampLocation = (pdfPageDiagonal - textWidth) / 2;

            // Create the stamp as a rotated text element
            TextElement stampTextElement = new TextElement(xStampLocation, 0, stampText, stampPdfFont);
            stampTextElement.ForeColor = RgbColor.Coral;
            stampTextElement.Rotate((float)(Math.Atan(pdfPageHeight / pdfPageWidth) * (180 / Math.PI)));
            stampTextElement.Opacity = 75;

            // Add the stamp to PDF page
            page.AddElement(stampTextElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Text_Elements.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Text_Elements.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Text_Elements.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Text_Elements");
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
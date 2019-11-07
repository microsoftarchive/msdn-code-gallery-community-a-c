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
    public partial class Bookmarks : System.Web.UI.Page
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

            // Display the bookmarks panel when the PDF document is opened in a PDF viewer
            pdfDocument.ViewerPreferences.PageMode = ViewerPageMode.UseOutlines;

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 12, true);

            // Add a new PDF page to PDF document
            PdfPage page1 = pdfDocument.AddPage();
            TextElement pageText = new TextElement(0, 0, "Page 1. Destination of a Top Bookmark with Fit Width View Mode.", titleFont);
            page1.AddElement(pageText);

            // Add a new PDF page to PDF document
            PdfPage page2 = pdfDocument.AddPage();
            pageText = new TextElement(0, 0, "Page 2. Destination of a Top Bookmark with Custom Zoom Level.", titleFont);
            page2.AddElement(pageText);

            // Add a new PDF page to PDF document
            PdfPage page3 = pdfDocument.AddPage();
            pageText = new TextElement(0, 0, "Page 3. Destination of a Child Bookmark with Fit Width and Height View Mode.", titleFont);
            page3.AddElement(pageText);

            // Add a new PDF page to PDF document
            PdfPage page4 = pdfDocument.AddPage();
            pageText = new TextElement(0, page4.PageSize.Height / 2 - 20, "Page 4. Destination of a Top Bookmark for the Middle of the Page.", titleFont);
            page4.AddElement(pageText);

            // Add a new PDF page to PDF document
            PdfPage page5 = pdfDocument.AddPage();
            pageText = new TextElement(0, 0, "Page 5. Destination of a Child Bookmark with Colored Title.", titleFont);
            page5.AddElement(pageText);

            // Add a new PDF page to PDF document
            PdfPage page6 = pdfDocument.AddPage();
            pageText = new TextElement(0, 0, "Page 6. Destination of a Child Bookmark with Italic Style Title.", titleFont);
            page6.AddElement(pageText);

            // Add a top level bookmark for first page setting destination view mode to fit viewer window horizontally
            ExplicitDestination page1Destination = new ExplicitDestination(page1, new PointFloat(0, 0), DestinationViewMode.FitH);
            Bookmark page1TopBookmark = new Bookmark("Top Bookmark with Fit Width View Mode", page1Destination);
            pdfDocument.AddBookmark(page1TopBookmark);
            page1TopBookmark.Style = PdfBookmarkStyle.Bold;

            // Add a top level bookmark for second page setting the zoom level to 125%
            ExplicitDestination page2Destination = new ExplicitDestination(page2, new PointFloat(0, 0), DestinationViewMode.XYZ);
            page2Destination.ZoomPercentage = 125;
            Bookmark page2TopBookmark = new Bookmark("Top Bookmark with Custom Zoom Level", page2Destination);
            pdfDocument.AddBookmark(page2TopBookmark);
            page2TopBookmark.Style = PdfBookmarkStyle.Normal;

            // Add a child bookmark for third page setting destination view mode to fit viewer window horizontally and vertically
            ExplicitDestination page3Destination = new ExplicitDestination(page3, new PointFloat(0, 0), DestinationViewMode.Fit);
            Bookmark page3ChildBookmark = new Bookmark("Child Bookmark with Fit Width and Height View Mode", page3Destination);
            pdfDocument.AddBookmark(page3ChildBookmark, page2TopBookmark);

            // Add a top level bookmark for fourth page with destination point in the middle of the PDF page 
            ExplicitDestination page4Destination = new ExplicitDestination(page4, new PointFloat(0, page4.PageSize.Height / 2 - 20));
            Bookmark page4TopBookmark = new Bookmark("Top Bookmark for the Middle of the Page", page4Destination);
            page4TopBookmark.Style = PdfBookmarkStyle.Bold;
            page4TopBookmark.Color = RgbColor.Blue;
            pdfDocument.AddBookmark(page4TopBookmark);

            // Add a child bookmark with colored text
            ExplicitDestination page5Destination = new ExplicitDestination(page5, new PointFloat(0, 0));
            Bookmark page5ChildBookmark = new Bookmark("Child Bookmark with Colored Title", page5Destination);
            page5ChildBookmark.Color = RgbColor.Red;
            pdfDocument.AddBookmark(page5ChildBookmark, page4TopBookmark);

            // Add a child bookmark with italic style text
            ExplicitDestination page6Destination = new ExplicitDestination(page6, new PointFloat(0, 0));
            Bookmark page6ChildBookmark = new Bookmark("Child Bookmark with Italic Colored Title", page6Destination);
            page6ChildBookmark.Style = PdfBookmarkStyle.Bold | PdfBookmarkStyle.Italic;
            page6ChildBookmark.Color = RgbColor.Green;
            pdfDocument.AddBookmark(page6ChildBookmark, page4TopBookmark);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Bookmarks.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Bookmarks.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Bookmarks.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Bookmarks");
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
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Editor
{
    public partial class Stamp_PDF : System.Web.UI.Page
    {
        protected void stampPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Load the PDF document to stamp
            string pdfFileToStampPath = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/PDF_Document.pdf");
            Document pdfDocument = new Document(serverIP, serverPort, pdfFileToStampPath);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Get the stamp width and height
            float stampWidth = float.Parse(stampWidthTextBox.Text);
            float stampHeight = float.Parse(stampHeightTextBox.Text);

            // Center the stamp at the top of PDF page
            float stampXLocation = (pdfDocument.GetPage(0).PageSize.Width - stampWidth) / 2;
            float stampYLocation = 0;

            // Create the stamp template to be repeated in each PDF page
            Template stampTemplate = pdfDocument.AddTemplate(stampXLocation, stampYLocation, stampWidth, stampHeight);

            // Create the HTML element to add in stamp template
            HtmlToPdfElement stampHtmlElement = new HtmlToPdfElement(htmlStringTextBox.Text, baseUrlTextBox.Text);

            // Set the HTML viewer width for the HTML added in stamp
            stampHtmlElement.HtmlViewerWidth = 600;
            // Fit the HTML content in stamp template
            stampHtmlElement.FitWidth = true;
            stampHtmlElement.FitHeight = true;

            // Add HTML to stamp template
            stampTemplate.AddElement(stampHtmlElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Stamp_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Watermark_Stamp.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                pdfFileToStampHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/PDF_Document.pdf";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Editor/Stamp_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Editor/Stamp_PDF.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Editor");
                Master.SelectNode("Stamp_PDF_Documents");
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
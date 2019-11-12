using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.HTML_to_PDF_Elements
{
    public partial class Add_HTML_to_PDF_Elements_to_PDF : System.Web.UI.Page
    {
        protected void convertToPdfButton_Click(object sender, EventArgs e)
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

            // Create a PDF page where to add the first HTML
            PdfPage firstPdfPage = pdfDocument.AddPage();

            // The element location in PDF
            float xLocation = float.Parse(xLocationTextBox.Text);
            float yLocation = float.Parse(yLocationTextBox.Text);

            // The URL of the HTML page to convert to PDF
            string urlToConvert = urlTextBox.Text;

            // Create the HTML to PDF element
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, urlToConvert);

            // Optionally set the HTML viewer width
            htmlToPdfElement.HtmlViewerWidth = int.Parse(htmlViewerWidthTextBox.Text);

            // Optionally set the HTML viewer height
            if (htmlViewerHeightTextBox.Text.Length > 0)
                htmlToPdfElement.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);

            // Optionally set the HTML content clipping option to force the HTML content width to be exactly HtmlViewerWidth pixels
            htmlToPdfElement.ClipHtmlView = clipContentCheckBox.Checked;

            // Optionally set the destination width in PDF
            if (contentWidthTextBox.Text.Length > 0)
                htmlToPdfElement.Width = float.Parse(contentWidthTextBox.Text);

            // Optionally set the destination height in PDF
            if (contentHeightTextBox.Text.Length > 0)
                htmlToPdfElement.Height = float.Parse(contentHeightTextBox.Text);

            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            htmlToPdfElement.ConversionDelay = 2;

            // Add the HTML to PDF element to PDF document
            // The AddElementResult contains the bounds of the HTML to PDF Element in last rendered PDF page
            // such that you can start a new PDF element right under it
            firstPdfPage.AddElement(htmlToPdfElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Add_HTML_to_PDF_Elements_to_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/HTML_to_PDF_Elements/Add_HTML_to_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/HTML_to_PDF_Elements/Add_HTML_to_PDF.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("HTML_to_PDF_Elements");
                Master.SelectNode("Add_HTML_to_PDF_Elements_to_PDF_Document");
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
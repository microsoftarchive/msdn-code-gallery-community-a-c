using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator.PDF_Security
{
    public partial class Digital_Signatures : System.Web.UI.Page
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

            // Add a page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            string htmlWithDigitalSignatureMarker = htmlStringTextBox.Text;
            string baseUrl = baseUrlTextBox.Text;

            // Add a HTML string with a marker for digital signature to PDF document
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(htmlWithDigitalSignatureMarker, baseUrl);
            pdfPage.AddElement(htmlToPdfElement);

            string certificateFilePath = Server.MapPath(@"~/DemoAppFiles/Input/Certificates/evopdf.pfx");

            // Create the digital signature
            DigitalSignatureElement signature = new DigitalSignatureElement(certificateFilePath, "evopdf", 0);
            signature.Reason = "Protect the document from unwanted changes";
            signature.ContactInfo = "The contact email is support@evopdf.com";
            signature.Location = "Development server";
            pdfDocument.AddElement(signature);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Digital_Signatures.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Digital_Signatures.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/PDF_Security/Digital_Signatures.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/PDF_Security/Digital_Signatures.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.ExpandNode("PDF_Creator_PDF_Security");
                Master.SelectNode("PDF_Creator_Digital_Signatures");
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
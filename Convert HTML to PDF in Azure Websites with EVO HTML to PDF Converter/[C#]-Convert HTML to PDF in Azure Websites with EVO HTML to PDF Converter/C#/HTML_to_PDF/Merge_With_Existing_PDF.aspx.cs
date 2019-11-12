using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF
{
    public partial class Merge_With_Existing_PDF : System.Web.UI.Page
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

            // Set the PDF file to be inserted before conversion result
            string pdfFileBefore = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf");
            htmlToPdfConverter.PdfDocumentOptions.AddStartDocument(pdfFileBefore);

            // Set the PDF file to be added after conversion result
            string pdfFileAfter = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf");
            htmlToPdfConverter.PdfDocumentOptions.AddEndDocument(pdfFileAfter);

            // The URL to convert
            string url = urlTextBox.Text;

            // Convert the HTML page to a PDF document and add the external PDF documents
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Merge_HTML_with_Existing_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Merge_Existing_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Merge_Existing_PDF.html"));

                string currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                string rootUrl = "http://www.evopdf.com/demo/";

                pdfBeforeHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf";
                pdfAfterHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf";

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.SelectNode("Merge_With_Existing_PDF");
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
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator.Headers_and_Footers
{
    public partial class Page_Numbers_in_HTML : System.Web.UI.Page
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

            // Add a PDF page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Create the document footer template
            pdfDocument.AddFooterTemplate(50);

            // ----- Add HTML with Page Numbering to Footer -----

            // Create a variable HTML element with page numbering
            string htmlStringWithPageNumbers = htmlWithPageNumbersTextBox.Text;
            string baseUrl = baseUrlTextBox.Text;
            HtmlToPdfVariableElement footerHtmlWithPageNumbers = new HtmlToPdfVariableElement(htmlStringWithPageNumbers, baseUrl);

            // Set the HTML element to fit the container height
            footerHtmlWithPageNumbers.FitHeight = true;

            // Add variable HTML element with page numbering to footer
            pdfDocument.Footer.AddElement(footerHtmlWithPageNumbers);

            // Optionally draw a line at the top of the footer
            if (drawFooterLineCheckBox.Checked)
            {
                float footerWidth = pdfDocument.GetPage(0).PageSize.Width;

                // Create a line element for the top of the footer
                LineElement footerLine = new LineElement(0, 0, footerWidth, 0);

                // Set line color
                footerLine.ForeColor = RgbColor.Gray;

                // Add line element to the bottom of the footer
                pdfDocument.Footer.AddElement(footerLine);
            }

            // Create a HTML to PDF element to add to document
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(0, 0, urlTextBox.Text);

            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            htmlToPdfElement.ConversionDelay = 2;

            // Optionally add a space between footer and the page body
            // Leave this option not set for no spacing
            htmlToPdfElement.BottomSpacing = float.Parse(footerSpacingTextBox.Text);

            // Add the HTML to PDF element to document
            // This will raise the PrepareRenderPdfPageEvent event where the header and footer visibilit per page can be changed
            pdfPage.AddElement(htmlToPdfElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Write the memory buffer in a PDF file// Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Page_Numbers_in_HTML.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                string htmlWithPageNumbers = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Page_Numbers_in_HTML.html"));

                htmlWithPageNumbersTextBox.Text = htmlWithPageNumbers;
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Headers_and_Footers/Page_Numbers_in_HTML.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Headers_and_Footers/Page_Numbers_in_HTML.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.ExpandNode("PDF_Creator_Headers_and_Footers");
                Master.SelectNode("PDF_Creator_Page_Numbers_in_HTML");
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
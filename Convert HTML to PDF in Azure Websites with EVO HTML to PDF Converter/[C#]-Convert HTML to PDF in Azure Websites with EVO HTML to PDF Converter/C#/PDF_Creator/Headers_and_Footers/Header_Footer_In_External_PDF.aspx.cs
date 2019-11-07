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
    public partial class Header_Footer_In_External_PDF : System.Web.UI.Page
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

            // Add a default document header
            AddHeader(pdfDocument, true);

            // Add a default document footer
            AddFooter(pdfDocument, true, true);

            // Create a HTML to PDF element to add to document
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(0, 0, urlTextBox.Text);

            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            htmlToPdfElement.ConversionDelay = 2;

            // Add HTML to PDF element to document
            pdfPage.AddElement(htmlToPdfElement);

            // Insert an external PDF document in the beginning of the final PDF document
            string pdfFileBefore = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf");
            pdfDocument.InsertDocument(0, pdfFileBefore, addHeaderFooterInInsertedPdfCheckBox.Checked,
                            showHeaderInFirstPageCheckBox.Checked, showFooterInFirstPageCheckBox.Checked);

            // Append an external PDF document at the end of the final PDF document
            string pdfFileAfter = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf");
            pdfDocument.AppendDocument(pdfFileAfter, addHeaderFooterInAppendedPdfCheckBox.Checked, true, true);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Header_Footer_in_External_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        /// <summary>
        /// Add a header to document
        /// </summary>
        /// <param name="pdfDocument">The PDF document object</param>
        /// <param name="drawHeaderLine">A flag indicating if a line should be drawn at the bottom of the header</param>
        private void AddHeader(Document pdfDocument, bool drawHeaderLine)
        {
            string headerHtmlString = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Header_HTML.html"));
            string headerBaseUrl = "http://www.evopdf.com/demo/DemoAppFiles/Input/HTML_Files/";

            // Create the document footer template
            pdfDocument.AddHeaderTemplate(60);

            // Create a HTML element to be added in header
            HtmlToPdfElement headerHtml = new HtmlToPdfElement(headerHtmlString, headerBaseUrl);

            // Set the HTML element to fit the container height
            headerHtml.FitHeight = true;

            // Add HTML element to header
            pdfDocument.Header.AddElement(headerHtml);

            if (drawHeaderLine)
            {
                float headerWidth = pdfDocument.GetPage(0).PageSize.Width;
                float headerHeight = pdfDocument.Header.Height;

                // Create a line element for the bottom of the header
                LineElement headerLine = new LineElement(0, headerHeight - 1, headerWidth, headerHeight - 1);

                // Set line color
                headerLine.ForeColor = RgbColor.Gray;

                // Add line element to the bottom of the header
                pdfDocument.Header.AddElement(headerLine);
            }
        }

        /// <summary>
        /// Add a footer to document
        /// </summary>
        /// <param name="pdfDocument">The PDF document object</param>
        /// <param name="addPageNumbers">A flag indicating if the page numbering is present in footer</param>
        /// <param name="drawFooterLine">A flag indicating if a line should be drawn at the top of the footer</param>
        private void AddFooter(Document pdfDocument, bool addPageNumbers, bool drawFooterLine)
        {
            string footerHtmlString = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Footer_HTML.html"));
            string footerBaseUrl = "http://www.evopdf.com/demo/DemoAppFiles/Input/HTML_Files/";

            // Create the document footer template
            pdfDocument.AddFooterTemplate(60);

            // Set footer background color
            RectangleElement backColorRectangle = new RectangleElement(0, 0, pdfDocument.Footer.Width, pdfDocument.Footer.Height);
            backColorRectangle.BackColor = RgbColor.WhiteSmoke;
            pdfDocument.Footer.AddElement(backColorRectangle);

            // Create a HTML element to be added in footer
            HtmlToPdfElement footerHtml = new HtmlToPdfElement(footerHtmlString, footerBaseUrl);

            // Set the HTML element to fit the container height
            footerHtml.FitHeight = true;

            // Add HTML element to footer
            pdfDocument.Footer.AddElement(footerHtml);

            // Add page numbering
            if (addPageNumbers)
            {
                // Create a text element with page numbering place holders &p; and & P;
                TextElement footerText = new TextElement(0, 30, "Page &p; of &P;  ", new PdfFont("Times New Roman", 10, true));

                // Align the text at the right of the footer
                footerText.TextAlign = HorizontalTextAlign.Right;

                // Set page numbering text color
                footerText.ForeColor = RgbColor.Navy;

                // Embed the text element font in PDF
                footerText.EmbedSysFont = true;

                // Add the text element to footer
                pdfDocument.Footer.AddElement(footerText);
            }

            if (drawFooterLine)
            {
                float footerWidth = pdfDocument.GetPage(0).PageSize.Width;

                // Create a line element for the top of the footer
                LineElement footerLine = new LineElement(0, 0, footerWidth, 0);

                // Set line color
                footerLine.ForeColor = RgbColor.Gray;

                // Add line element to the bottom of the footer
                pdfDocument.Footer.AddElement(footerLine);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                string rootUrl = "http://www.evopdf.com/demo/";

                pdfBeforeHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf";
                pdfAfterHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Headers_and_Footers/Header_Footer_In_External_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Headers_and_Footers/Header_Footer_In_External_PDF.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.ExpandNode("PDF_Creator_Headers_and_Footers");
                Master.SelectNode("PDF_Creator_Header_Footer_in_External_PDF");
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
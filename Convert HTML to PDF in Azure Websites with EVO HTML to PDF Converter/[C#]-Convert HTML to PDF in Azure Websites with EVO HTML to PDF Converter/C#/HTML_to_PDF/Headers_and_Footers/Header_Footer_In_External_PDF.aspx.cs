﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.Headers_and_Footers
{
    public partial class Header_Footer_In_External_PDF : System.Web.UI.Page
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
            htmlToPdfConverter.PdfDocumentOptions.AddStartDocument(pdfFileBefore, addHeaderFooterInInsertedPdfCheckBox.Checked,
                                showHeaderInFirstPageCheckBox.Checked, showFooterInFirstPageCheckBox.Checked);

            // Set the PDF file to be added after conversion result
            string pdfFileAfter = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf");
            htmlToPdfConverter.PdfDocumentOptions.AddEndDocument(pdfFileAfter, addHeaderFooterInAppendedPdfCheckBox.Checked, true, true);

            // Enable header in the generated PDF document
            htmlToPdfConverter.PdfDocumentOptions.ShowHeader = true;

            // Draw header elements
            if (htmlToPdfConverter.PdfDocumentOptions.ShowHeader)
                DrawHeader(htmlToPdfConverter, true);

            // Enable footer in the generated PDF document
            htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;

            // Draw footer elements
            if (htmlToPdfConverter.PdfDocumentOptions.ShowFooter)
                DrawFooter(htmlToPdfConverter, true, true);

            string url = urlTextBox.Text;

            // Convert the HTML page to a PDF document and add the external PDF documents
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

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
        /// Draw the header elements
        /// </summary>
        /// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
        /// <param name="drawHeaderLine">A flag indicating if a line should be drawn at the bottom of the header</param>
        private void DrawHeader(HtmlToPdfConverter htmlToPdfConverter, bool drawHeaderLine)
        {
            string headerHtmlString = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Header_HTML.html"));
            string headerBaseUrl = "http://www.evopdf.com/demo/DemoAppFiles/Input/HTML_Files/";

            // Set the header height in points
            htmlToPdfConverter.PdfHeaderOptions.HeaderHeight = 60;

            // Set header background color
            htmlToPdfConverter.PdfHeaderOptions.HeaderBackColor = RgbColor.White;

            // Create a HTML element to be added in header
            HtmlToPdfElement headerHtml = new HtmlToPdfElement(headerHtmlString, headerBaseUrl);

            // Set the HTML element to fit the container height
            headerHtml.FitHeight = true;

            // Add HTML element to header
            htmlToPdfConverter.PdfHeaderOptions.AddElement(headerHtml);

            if (drawHeaderLine)
            {
                // Calculate the header width based on PDF page size and margins
                float headerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
                            htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;

                // Calculate header height
                float headerHeight = htmlToPdfConverter.PdfHeaderOptions.HeaderHeight;

                // Create a line element for the bottom of the header
                LineElement headerLine = new LineElement(0, headerHeight - 1, headerWidth, headerHeight - 1);

                // Set line color
                headerLine.ForeColor = RgbColor.Gray;

                // Add line element to the bottom of the header
                htmlToPdfConverter.PdfHeaderOptions.AddElement(headerLine);
            }
        }

        /// <summary>
        /// Draw the footer elements
        /// </summary>
        /// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
        /// <param name="addPageNumbers">A flag indicating if the page numbering is present in footer</param>
        /// <param name="drawFooterLine">A flag indicating if a line should be drawn at the top of the footer</param>
        private void DrawFooter(HtmlToPdfConverter htmlToPdfConverter, bool addPageNumbers, bool drawFooterLine)
        {
            string footerHtmlString = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Footer_HTML.html"));
            string baseUrl = "http://www.evopdf.com/demo/DemoAppFiles/Input/HTML_Files/";
            
            // Set the footer height in points
            htmlToPdfConverter.PdfFooterOptions.FooterHeight = 60;

            // Set footer background color
            htmlToPdfConverter.PdfFooterOptions.FooterBackColor = RgbColor.WhiteSmoke;

            // Create a HTML element to be added in footer
            HtmlToPdfElement footerHtml = new HtmlToPdfElement(footerHtmlString, baseUrl);

            // Set the HTML element to fit the container height
            footerHtml.FitHeight = true;

            // Add HTML element to footer
            htmlToPdfConverter.PdfFooterOptions.AddElement(footerHtml);

            // Add page numbering
            if (addPageNumbers)
            {
                // Create a text element with page numbering place holders &p; and & P;
                TextElement footerText = new TextElement(0, 30, "Page &p; of &P;  ",
                    new PdfFont("Times New Roman", 10, true));

                // Align the text at the right of the footer
                footerText.TextAlign = HorizontalTextAlign.Right;

                // Set page numbering text color
                footerText.ForeColor = RgbColor.Navy;

                // Embed the text element font in PDF
                footerText.EmbedSysFont = true;

                // Add the text element to footer
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerText);
            }

            if (drawFooterLine)
            {
                // Calculate the footer width based on PDF page size and margins
                float footerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
                            htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;

                // Create a line element for the top of the footer
                LineElement footerLine = new LineElement(0, 0, footerWidth, 0);

                // Set line color
                footerLine.ForeColor = RgbColor.Gray;

                // Add line element to the bottom of the footer
                htmlToPdfConverter.PdfFooterOptions.AddElement(footerLine);
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

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Headers_and_Footers/Header_Footer_In_External_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Headers_and_Footers/Header_Footer_In_External_PDF.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("Headers_and_Footers");
                Master.SelectNode("Header_Footer_in_External_PDF");
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
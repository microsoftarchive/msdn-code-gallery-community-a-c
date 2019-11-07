using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Text;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.HTML_Elements_Location
{
    public partial class Select_in_HTML_Elements_to_Retrieve : System.Web.UI.Page
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

            Document pdfDocument = null;

            // Convert HTML page or string with mapping attributes to a PDF document object 
            // The document can be further modified to highlight the selected elements
            if (convertHtmlRadioButton.Checked)
            {
                string htmlWithMappingAttributes = htmlStringTextBox.Text;
                string baseUrl = baseUrlTextBox.Text;

                // Convert a HTML string with mapping attributes to a PDF document object
                pdfDocument = htmlToPdfConverter.ConvertHtmlToPdfDocumentObject(htmlWithMappingAttributes, baseUrl);
            }
            else
            {
                string url = urlTextBox.Text;

                // Convert a HTML page with mapping attributes to a PDF document object
                pdfDocument = htmlToPdfConverter.ConvertUrlToPdfDocumentObject(url);
            }

            // Display detailed information about the selected elements
            StringBuilder htmlElementInfoBuilder = new StringBuilder();
            for (int mappingIndex = 0; mappingIndex < htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.Count; mappingIndex++)
            {
                HtmlElementMapping htmlElementInfo = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetByIndex(mappingIndex);

                // Get other information about HTML element
                string htmlElementTagName = htmlElementInfo.HtmlElementTagName;
                string htmlElementID = htmlElementInfo.HtmlElementId;
                string htmlElementMappingID = htmlElementInfo.MappingId;
                string htmlElementCssClasssName = htmlElementInfo.HtmlElementCssClassName;
                string htmlElementHtmlCode = htmlElementInfo.HtmlElementOuterHtml;
                string htmlElementInnerHtml = htmlElementInfo.HtmlElementInnerHtml;
                string htmlElementText = htmlElementInfo.HtmlElementText;
                NameValuePairsCollection htmlElementAttributes = htmlElementInfo.HtmlElementAttributes;
                PdfRectangle[] htmlElementRectanglesInPdf = htmlElementInfo.PdfRectangles;

                htmlElementInfoBuilder.AppendFormat("<br/>---------------------------------------- HTML Element Info ----------------------------------------<br/><br/>");
                htmlElementInfoBuilder.AppendFormat("<b>Tag Name:</b> {0}<br/>", htmlElementTagName);
                htmlElementInfoBuilder.AppendFormat("<b>Element ID:</b> {0}<br/>", htmlElementID);
                htmlElementInfoBuilder.AppendFormat("<b>Mapping ID:</b> {0}<br/>", htmlElementMappingID);
                htmlElementInfoBuilder.AppendFormat("<b>Text:</b> {0}<br/>", htmlElementText);

                htmlElementInfoBuilder.AppendFormat("<b>Attributes:</b><br/>");
                for (int i = 0; i < htmlElementAttributes.Count; i++)
                {
                    NameValuePair nameValuePair = htmlElementAttributes.GetByIndex(i);
                    htmlElementInfoBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;{0} = \"{1}\"<br/>", nameValuePair.Name, nameValuePair.Value);
                }


                htmlElementInfoBuilder.AppendFormat("<b>Location in PDF:</b><br/>");
                for (int i = 0; i < htmlElementRectanglesInPdf.Length; i++)
                {
                    PdfPage pdfPage = pdfDocument.GetPage(htmlElementRectanglesInPdf[i].PageIndex);
                    int pdfPageIndex = htmlElementRectanglesInPdf[i].PageIndex;
                    RectangleFloat rectangleInPdfPage = htmlElementRectanglesInPdf[i].Rectangle;

                    htmlElementInfoBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;PDF Page Index: {0}<br>", pdfPageIndex);
                    htmlElementInfoBuilder.AppendFormat("&nbsp;&nbsp;&nbsp;Rectangle: X = {0:N2} pt , Y = {1:N2} pt , W = {2:N2} pt , H = {3:N2} pt<br/>",
                            rectangleInPdfPage.X, rectangleInPdfPage.Y, rectangleInPdfPage.Width, rectangleInPdfPage.Height);
                }

                htmlElementInfoBuilder.AppendFormat("<br/>");
            }

            PdfPage lastPdfPage = pdfDocument.GetPage(htmlToPdfConverter.ConversionSummary.LastPageIndex);
            RectangleFloat lastPageRectangle = htmlToPdfConverter.ConversionSummary.LastPageRectangle;

            HtmlToPdfElement htmlElementInfoHtml = new HtmlToPdfElement(0, lastPageRectangle.Y + lastPageRectangle.Height + 1, htmlElementInfoBuilder.ToString(), null);
            lastPdfPage.AddElement(htmlElementInfoHtml);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Select_in_HTML_Elements_to_Retrieve.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/HTML_Elements_Info.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                urlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/HTML_Elements_Info.html";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/HTML_Elements_Location/Select_in_HTML.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/HTML_Elements_Location/Select_in_HTML.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("HTML_Elements_Location_in_PDF");
                Master.SelectNode("Select_in_HTML_Elements_to_Retrieve");
            }
        }

        protected void convertHtmlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            urlPanel.Visible = convertUrlRadioButton.Checked;
            htmlStringPanel.Visible = !convertUrlRadioButton.Checked;
        }

        protected void convertUrlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            urlPanel.Visible = convertUrlRadioButton.Checked;
            htmlStringPanel.Visible = !convertUrlRadioButton.Checked;
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

        protected void viewHtmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(urlTextBox.Text);
        }
    }
}
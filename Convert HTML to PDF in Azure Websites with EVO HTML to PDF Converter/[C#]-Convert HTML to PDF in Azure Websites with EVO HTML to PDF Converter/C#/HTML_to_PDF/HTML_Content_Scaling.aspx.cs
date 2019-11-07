using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF
{
    public partial class HTML_Content_Scaling : System.Web.UI.Page
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

            // Html Viewer Options

            // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
            // This is a preferred width of the browser but the actual HTML content width can be larger in case the HTML page 
            // cannot be entirely displayed in the given viewer width
            // This property gives the size of the HTML content which can be further scaled to fit the PDF page based on selected options
            // The HTML content size is in pixels and the PDF page size is in points (1 point = 1/72 inches)
            // The converter is using a 96 DPI resolution to transform pixels to points with the following formula: Points = Pixels/96 * 72            
            htmlToPdfConverter.HtmlViewerWidth = int.Parse(htmlViewerWidthTextBox.Text);

            // Set HTML viewer height in pixels to convert the top part of a HTML page 
            // Leave it not set to convert the entire HTML
            if (htmlViewerHeightTextBox.Text.Length > 0)
                htmlToPdfConverter.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);

            // Set the HTML content clipping option to force the HTML content width to be exactly HtmlViewerWidth pixels
            // If this option is false then the actual HTML content width can be larger than HtmlViewerWidth pixels in case the HTML page 
            // cannot be entirely displayed in the given viewer width
            // By default this option is false and the HTML content is not clipped
            htmlToPdfConverter.ClipHtmlView = clipContentCheckBox.Checked;

            // PDF Page Options

            // Set PDF page size which can be a predefined size like A4 or a custom size in points 
            // Leave it not set to have a default A4 PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = SelectedPdfPageSize();

            // Set PDF page orientation to Portrait or Landscape
            // Leave it not set to have a default Portrait orientation for PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = SelectedPdfPageOrientation();

            // Set PDF page margins in points or leave them not set to have a PDF page without margins
            htmlToPdfConverter.PdfDocumentOptions.LeftMargin = float.Parse(leftMarginTextBox.Text);
            htmlToPdfConverter.PdfDocumentOptions.RightMargin = float.Parse(rightMarginTextBox.Text);
            htmlToPdfConverter.PdfDocumentOptions.TopMargin = float.Parse(topMarginTextBox.Text);
            htmlToPdfConverter.PdfDocumentOptions.BottomMargin = float.Parse(bottomMarginTextBox.Text);

            // HTML Content Destination and Spacing Options

            // Set HTML content destination in PDF page
            if (xLocationTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfDocumentOptions.X = float.Parse(xLocationTextBox.Text);
            if (yLocationTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfDocumentOptions.Y = float.Parse(yLocationTextBox.Text);
            if (contentWidthTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfDocumentOptions.Width = float.Parse(contentWidthTextBox.Text);
            if (contentHeightTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfDocumentOptions.Height = float.Parse(contentHeightTextBox.Text);

            // Set HTML content top and bottom spacing or leave them not set to have no spacing for the HTML content
            htmlToPdfConverter.PdfDocumentOptions.TopSpacing = float.Parse(topSpacingTextBox.Text);
            htmlToPdfConverter.PdfDocumentOptions.BottomSpacing = float.Parse(bottomSpacingTextBox.Text);

            // Scaling Options

            // Use this option to fit the HTML content width in PDF page width
            // By default this property is true and the HTML content can be resized to fit the PDF page width
            htmlToPdfConverter.PdfDocumentOptions.FitWidth = fitWidthCheckBox.Checked;

            // Use this option to enable the HTML content stretching when its width is smaller than PDF page width
            // This property has effect only when FitWidth option is true
            // By default this property is false and the HTML content is not stretched
            htmlToPdfConverter.PdfDocumentOptions.StretchToFit = stretchCheckBox.Checked;

            // Use this option to automatically dimension the PDF page to display the HTML content unscaled
            // This property has effect only when the FitWidth property is false
            // By default this property is true and the PDF page is automatically dimensioned when FitWidth is false
            htmlToPdfConverter.PdfDocumentOptions.AutoSizePdfPage = autoSizeCheckBox.Checked;

            // Use this option to fit the HTML content height in PDF page height
            // If both FitWidth and FitHeight are true then the HTML content will resized if necessary to fit both width and height 
            // preserving the aspect ratio at the same time
            // By default this property is false and the HTML content is not resized to fit the PDF page height
            htmlToPdfConverter.PdfDocumentOptions.FitHeight = fitHeightCheckBox.Checked;

            // Use this option to render the whole HTML content into a single PDF page
            // The PDF page size is limited to 14400 points
            // By default this property is false
            htmlToPdfConverter.PdfDocumentOptions.SinglePage = singlePageCheckBox.Checked;

            string url = urlTextBox.Text;

            // Convert the HTML page to a PDF document using the scaling options
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=HTML_Content_Scaling.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        private PdfPageSize SelectedPdfPageSize()
        {
            switch (pdfPageSizeDropDownList.SelectedValue)
            {
                case "A0":
                    return PdfPageSize.A0;
                case "A1":
                    return PdfPageSize.A1;
                case "A10":
                    return PdfPageSize.A10;
                case "A2":
                    return PdfPageSize.A2;
                case "A3":
                    return PdfPageSize.A3;
                case "A4":
                    return PdfPageSize.A4;
                case "A5":
                    return PdfPageSize.A5;
                case "A6":
                    return PdfPageSize.A6;
                case "A7":
                    return PdfPageSize.A7;
                case "A8":
                    return PdfPageSize.A8;
                case "A9":
                    return PdfPageSize.A9;
                case "ArchA":
                    return PdfPageSize.ArchA;
                case "ArchB":
                    return PdfPageSize.ArchB;
                case "ArchC":
                    return PdfPageSize.ArchC;
                case "ArchD":
                    return PdfPageSize.ArchD;
                case "ArchE":
                    return PdfPageSize.ArchE;
                case "B0":
                    return PdfPageSize.B0;
                case "B1":
                    return PdfPageSize.B1;
                case "B2":
                    return PdfPageSize.B2;
                case "B3":
                    return PdfPageSize.B3;
                case "B4":
                    return PdfPageSize.B4;
                case "B5":
                    return PdfPageSize.B5;
                case "Flsa":
                    return PdfPageSize.Flsa;
                case "HalfLetter":
                    return PdfPageSize.HalfLetter;
                case "Ledger":
                    return PdfPageSize.Ledger;
                case "Legal":
                    return PdfPageSize.Legal;
                case "Letter":
                    return PdfPageSize.Letter;
                case "Letter11x17":
                    return PdfPageSize.Letter11x17;
                case "Note":
                    return PdfPageSize.Note;
                default:
                    return PdfPageSize.A4;
            }
        }

        private PdfPageOrientation SelectedPdfPageOrientation()
        {
            return (pdfPageOrientationDropDownList.SelectedValue == "Portrait") ?
                PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pdfPageSizeDropDownList.SelectedValue = "A4";
                pdfPageOrientationDropDownList.SelectedValue = "Portrait";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/HTML_Content_Scaling.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/HTML_Content_Scaling.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.SelectNode("HTML_Content_Scaling");
            }
        }

        protected void fitWidthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoSizeCheckBox.Visible = !fitWidthCheckBox.Checked;
            stretchCheckBox.Visible = fitWidthCheckBox.Checked;
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
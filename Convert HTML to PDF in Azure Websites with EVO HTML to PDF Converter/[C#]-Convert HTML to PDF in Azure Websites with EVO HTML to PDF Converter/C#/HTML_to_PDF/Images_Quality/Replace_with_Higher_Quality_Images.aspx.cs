using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.Images_Quality
{
    public partial class Replace_with_Higher_Quality_Images : System.Web.UI.Page
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

            // Select all images from HTML page
            htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementSelectors = new string[] { "img" };

            // Exclude the original images from rendering becuase they will be replaced by an image from local file system
            htmlToPdfConverter.HiddenHtmlElementsSelectors = new string[] { "img" };

            // Convert a HTML string with images to replace to a PDF document object
            Document pdfDocument = htmlToPdfConverter.ConvertUrlToPdfDocumentObject(urlTextBox.Text);

            // Replace the images selected in HTML using special attributes with images from local file system
            int mappingsCount = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.Count;
            for (int i = 0; i < mappingsCount; i++)
            {
                HtmlElementMapping imageElementInfo = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetByIndex(i);
                PdfPage imagePdfPage = pdfDocument.GetPage(imageElementInfo.PdfRectangles[0].PageIndex);
                RectangleFloat imageRectangle = imageElementInfo.PdfRectangles[0].Rectangle;

                ImageElement newImageElement = new ImageElement(imageRectangle.X, imageRectangle.Y, imageRectangle.Width, imageRectangle.Height,
                                Server.MapPath("~/DemoAppFiles/Input/Images/box.jpg"));
                newImageElement.EnlargeEnabled = true;
                imagePdfPage.AddElement(newImageElement);
            }

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Replace_with_Higher_Quality_Images.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Images_Quality/Replace_with_Higher_Quality.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Images_Quality/Replace_with_Higher_Quality.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("Images_Quality");
                Master.SelectNode("Replace_Images");
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

        protected void viewHtmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(urlTextBox.Text);
        }
    }
}
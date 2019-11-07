using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator
{
    public partial class Image_Elements : System.Web.UI.Page
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

            // The titles font used to mark various sections of the PDF document
            PdfFont titleFont = new PdfFont("Times New Roman", 12, true);
            titleFont.Bold = true;
            PdfFont subtitleFont = new PdfFont("Times New Roman", 8, true);
            subtitleFont.Bold = true;

            // Create a PDF page in PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Add section title
            TextElement titleTextElement = new TextElement(5, 5, "Images Scaling", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfPage.AddElement(titleTextElement);

            // Add an unscaled image

            // Add section title
            TextElement subtitleTextElement = new TextElement(0, 0, "Unscaled small image with normal resolution", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            string imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/picture_small.jpg");
            ImageElement unscaledImageElement = new ImageElement(0, 0, imagePath);
            pdfDocument.AddElement(unscaledImageElement, 10);

            // Add a large image scaled down to same size in PDF

            // Add section title
            subtitleTextElement = new TextElement(0, 0, "Scaled down large image has higher resolution", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/picture_large.jpg");
            ImageElement scaledDownImageElement = new ImageElement(0, 0, 50, imagePath);
            pdfDocument.AddElement(scaledDownImageElement, 10);

            // Add a border around the scaled down image
            RectangleElement borderElement = new RectangleElement(0, 0, 0, 0);
            pdfDocument.AddElement(borderElement);

            // Add an unscaled small image

            // Add section title
            subtitleTextElement = new TextElement(0, 0, "Unscaled small image", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/picture_smaller.jpg");
            unscaledImageElement = new ImageElement(0, 0, imagePath);
            pdfDocument.AddElement(unscaledImageElement, 10);

            // Add an enlarged image

            // Add section title
            subtitleTextElement = new TextElement(0, 0, "Enlarged small image has lower resolution", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/picture_smaller.jpg");
            ImageElement enlargedImageElement = new ImageElement(0, 0, 200, imagePath);
            // Allow the image to be enlarged
            enlargedImageElement.EnlargeEnabled = true;
            pdfDocument.AddElement(enlargedImageElement, 10);

            // Scale an image preserving the aspect ratio

            // Add section title
            subtitleTextElement = new TextElement(0, 0, "Scaled down image preserving aspect ratio", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/landscape.jpg");
            ImageElement keepAspectImageElement = new ImageElement(0, 0, 80, 80, true, imagePath);
            pdfDocument.AddElement(keepAspectImageElement, 10);

            borderElement = new RectangleElement(0, 0, 0, 0);
            borderElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(borderElement);

            // Scale an image without preserving aspect ratio
            // This can produce a distorted image

            // Add section title
            subtitleTextElement = new TextElement(0, 0, "Scaled down image without preserving aspect ratio", subtitleFont);
            subtitleTextElement.ForeColor = RgbColor.Navy;
            pdfDocument.AddElement(subtitleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/landscape.jpg");
            ImageElement notKeepAspectImageElement = new ImageElement(0, 0, 80, 80, false, imagePath);
            pdfDocument.AddElement(notKeepAspectImageElement, 10);

            borderElement = new RectangleElement(0, 0, 0, 0);
            borderElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(borderElement);

            // Add transparent images

            // Add section title
            titleTextElement = new TextElement(0, 0, "Transparent Images", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfDocument.AddElement(titleTextElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/transparent.png");
            ImageElement trasparentImageElement = new ImageElement(0, 0, 150, imagePath);
            pdfDocument.AddElement(trasparentImageElement, 10);

            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/rose.png");
            trasparentImageElement = new ImageElement(0, 0, 150, imagePath);
            pdfDocument.AddElement(trasparentImageElement, 10);

            // Rotate images

            // Add a new page to document
            pdfPage = pdfDocument.AddPage();

            // Add section title
            titleTextElement = new TextElement(0, 0, "Rotated Images", titleFont);
            titleTextElement.ForeColor = RgbColor.Black;
            pdfPage.AddElement(titleTextElement);
            
            // Add a not rotated image
            imagePath = Server.MapPath("~/DemoAppFiles/Input/Images/compass.png");
            ImageElement noRotationImageElement = new ImageElement(0, 25, 125, imagePath);
            pdfPage.AddElement(noRotationImageElement);

            // The rotated coordinates system location
            float rotatedImageXLocation = 125;
            float rotatedImageYLocation = 175;

            // Add the image rotated 90 degrees
            ImageElement rotate90ImageElement = new ImageElement(0, 0, 125, imagePath);
            rotate90ImageElement.Translate(rotatedImageXLocation, rotatedImageYLocation);
            rotate90ImageElement.Rotate(90);
            pdfPage.AddElement(rotate90ImageElement);

            rotatedImageXLocation = 125;
            rotatedImageYLocation = 450;

            // Add the image rotated 180 degrees
            ImageElement rotate180ImageElement = new ImageElement(0, 0, 125, imagePath);
            rotate180ImageElement.Translate(rotatedImageXLocation, rotatedImageYLocation);
            rotate180ImageElement.Rotate(180);
            pdfPage.AddElement(rotate180ImageElement);

            rotatedImageXLocation = 0;
            rotatedImageYLocation = 600;

            // Add the image rotated 270 degrees
            ImageElement rotate270ImageElement = new ImageElement(0, 0, 125, imagePath);
            rotate270ImageElement.Translate(rotatedImageXLocation, rotatedImageYLocation);
            rotate270ImageElement.Rotate(270);
            pdfPage.AddElement(rotate270ImageElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Image_Elements.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Image_Elements.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Image_Elements.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Image_Elements");
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
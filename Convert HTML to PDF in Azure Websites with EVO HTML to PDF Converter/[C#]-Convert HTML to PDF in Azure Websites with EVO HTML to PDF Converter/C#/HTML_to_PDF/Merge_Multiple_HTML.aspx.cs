using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF
{
    public partial class Merge_Multiple_HTML : System.Web.UI.Page
    {
        protected void convertToPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create the PDF document where to add the HTML documents
            Document pdfDocument = new Document(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Create a PDF page where to add the first HTML
            PdfPage firstPdfPage = pdfDocument.AddPage();

            // Create the first HTML to PDF element
            HtmlToPdfElement firstHtml = new HtmlToPdfElement(0, 0, firstUrlTextBox.Text);

            // Optionally set a delay before conversion to allow asynchronous scripts to finish
            firstHtml.ConversionDelay = 2;

            // Add the first HTML to PDF document
            firstPdfPage.AddElement(firstHtml);

            PdfPage secondPdfPage = null;

            // Create the second HTML to PDF element
            HtmlToPdfElement secondHtml = new HtmlToPdfElement(0, 0, secondUrlTextBox.Text);

            // Optionally set a delay before conversion to allow asynchronous scripts to finish
            secondHtml.ConversionDelay = 2;

            if (startNewPageCheckBox.Checked)
            {
                // Create a PDF page where to add the second HTML
                secondPdfPage = pdfDocument.AddPage();

                // Add the second HTML to PDF document
                secondPdfPage.AddElement(secondHtml);
            }
            else
            {
                // Add the second HTML right after the first one
                pdfDocument.AddElement(secondHtml);
            }

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Merge_Multipe_HTML.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Merge_Multiple_HTML.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Merge_Multiple_HTML.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.SelectNode("Merge_Multiple_HTML");
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
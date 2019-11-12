using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.PDF_Actions
{
    public partial class Execute_JavaScript_Button_Clicked : System.Web.UI.Page
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

            string htmlWithButton = htmlStringTextBox.Text;
            string baseUrl = baseUrlTextBox.Text;

            // Convert a HTML string with a button to a PDF document object
            Document pdfDocument = htmlToPdfConverter.ConvertHtmlToPdfDocumentObject(htmlWithButton, baseUrl);

            // Get the button location in PDF
            HtmlElementMapping buttonMapping = htmlToPdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult.GetElementByMappingId("javascript_button");
            if (buttonMapping != null)
            {
                PdfPage buttonPdfPage = pdfDocument.GetPage(buttonMapping.PdfRectangles[0].PageIndex);
                RectangleFloat buttonRectangle = buttonMapping.PdfRectangles[0].Rectangle;

                // The font used for buttons text in PDF document
                PdfFont buttonTextFont = new PdfFont("Times New Roman", 8, true);

                // Create a PDF form button
                PdfFormButton pdfButton = new PdfFormButton(buttonRectangle, "Execute Acrobat JavaScript", buttonTextFont);
                pdfButton.Style.BackColor = RgbColor.Beige;
                pdfDocument.Form.AddButton(buttonPdfPage, pdfButton);

                // Set JavaScript action to be executed when the button is clicked
                string javaScript = null;
                if (alertMessageRadioButton.Checked)
                {
                    // JavaScript to display an alert mesage 
                    javaScript = String.Format("app.alert(\"{0}\")", alertMessageTextBox.Text);
                }
                else if (printDialogRadioButton.Checked)
                {
                    // JavaScript to open the print dialog
                    javaScript = "print()";
                }
                else if (zoomLevelRadioButton.Checked)
                {
                    // JavaScript to set an initial zoom level 
                    javaScript = String.Format("zoom={0}", int.Parse(zoomLevelTextBox.Text));
                }

                // Set the JavaScript action
                pdfButton.Action = new PdfActionJavaScript(javaScript);
            }

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Button_JavaScript_Actions.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Button_JavaScript_Actions.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/PDF_Actions/Execute_JavaScript_Button.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/PDF_Actions/Execute_JavaScript_Button.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("PDF_Actions");
                Master.SelectNode("Execute_JavaScript_Button_Clicked");
            }
        }

        protected void alertMessageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            zoomLevelPanel.Visible = zoomLevelRadioButton.Checked;
            alertMessagePanel.Visible = alertMessageRadioButton.Checked;
        }

        protected void printDialogRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            zoomLevelPanel.Visible = zoomLevelRadioButton.Checked;
            alertMessagePanel.Visible = alertMessageRadioButton.Checked;
        }

        protected void zoomLevelRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            zoomLevelPanel.Visible = zoomLevelRadioButton.Checked;
            alertMessagePanel.Visible = alertMessageRadioButton.Checked;
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
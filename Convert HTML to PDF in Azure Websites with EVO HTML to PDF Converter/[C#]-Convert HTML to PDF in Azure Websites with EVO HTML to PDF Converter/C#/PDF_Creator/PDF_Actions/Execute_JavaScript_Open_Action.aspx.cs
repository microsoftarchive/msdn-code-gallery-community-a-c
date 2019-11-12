using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator.PDF_Actions
{
    public partial class Execute_JavaScript_Open_Action : System.Web.UI.Page
    {
        protected void convertToPdfButton_Click(object sender, EventArgs e)
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

            // Add a page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // Create a HTML to PDF element to add to document
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(urlTextBox.Text);

            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            htmlToPdfElement.ConversionDelay = 2;

            // Add the HTML to PDF element to document
            pdfPage.AddElement(htmlToPdfElement);

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
            pdfDocument.OpenAction = new PdfActionJavaScript(javaScript);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Execute_Acrobat_JavaScript.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/PDF_Actions/Execute_JavaScript_Open.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/PDF_Actions/Execute_JavaScript_Open.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.ExpandNode("PDF_Creator_PDF_Actions");
                Master.SelectNode("PDF_Creator_Execute_JavaScript_Open_Action");
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
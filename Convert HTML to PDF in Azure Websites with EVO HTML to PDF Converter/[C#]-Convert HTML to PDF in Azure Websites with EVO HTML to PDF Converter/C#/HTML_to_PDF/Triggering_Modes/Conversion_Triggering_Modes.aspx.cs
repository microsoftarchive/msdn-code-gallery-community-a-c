using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.Triggering_Modes
{
    public partial class Conversion_Triggering_Modes : System.Web.UI.Page
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

            // Set the conversion triggering mode
            if (autoRadioButton.Checked)
            {
                // Set Auto triggering mode
                htmlToPdfConverter.TriggeringMode = TriggeringMode.Auto;
            }
            else if (delayedRadioButton.Checked)
            {
                // Set delayed triggering moe
                htmlToPdfConverter.ConversionDelay = int.Parse(conversionDelayTextBox.Text);
            }
            else if (manualRadioButton.Checked)
            {
                // Set manual triggering mode
                // The conversion starts when the evoPdfConverter.startConversion() is called 
                // in JavaScript code of the converted HTML page
                htmlToPdfConverter.TriggeringMode = TriggeringMode.Manual;
            }

            byte[] outPdfBuffer = null;

            if (convertHtmlRadioButton.Checked)
            {
                string htmlWithForm = htmlStringTextBox.Text;
                string baseUrl = baseUrlTextBox.Text;

                // Convert the HTML string with page-break-inside:avoid styles to a PDF document in a memory buffer
                outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlWithForm, baseUrl);
            }
            else
            {
                string url = urlTextBox.Text;

                // Convert the HTML page with page-break-inside:avoid styles to a PDF document in a memory buffer
                outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
            }

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Conversion_Triggering_Modes.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Triggering_Modes.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                urlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/Triggering_Modes.html";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Triggering_Modes/Triggering_Modes.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Triggering_Modes/Triggering_Modes.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("Triggering_Modes");
                Master.SelectNode("Select_Triggering_Mode");
            }
        }

        protected void autoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            conversionDelayPanel.Visible = delayedRadioButton.Checked;
        }

        protected void delayedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            conversionDelayPanel.Visible = delayedRadioButton.Checked;
        }

        protected void manualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            conversionDelayPanel.Visible = delayedRadioButton.Checked;
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
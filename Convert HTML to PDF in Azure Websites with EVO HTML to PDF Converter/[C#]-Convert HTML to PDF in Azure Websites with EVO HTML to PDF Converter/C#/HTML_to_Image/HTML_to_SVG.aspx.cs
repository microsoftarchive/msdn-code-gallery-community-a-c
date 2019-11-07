using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_Image
{
    public partial class HTML_to_SVG : System.Web.UI.Page
    {
        protected void convertToSvgButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create a HTML to SVG converter object with default settings
            HtmlToSvgConverter htmlToSvgConverter = new HtmlToSvgConverter(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                htmlToSvgConverter.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToSvgConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
            htmlToSvgConverter.HtmlViewerWidth = int.Parse(htmlViewerWidthTextBox.Text);

            // Set HTML viewer height in pixels to convert the top part of a HTML page 
            // Leave it not set to convert the entire HTML
            if (htmlViewerHeightTextBox.Text.Length > 0)
                htmlToSvgConverter.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);
            
            // Set the maximum time in seconds to wait for HTML page to be loaded 
            // Leave it not set for a default 60 seconds maximum wait time
            htmlToSvgConverter.NavigationTimeout = int.Parse(navigationTimeoutTextBox.Text);

            // Set an adddional delay in seconds to wait for JavaScript or AJAX calls after page load completed
            // Set this property to 0 if you don't need to wait for such asynchcronous operations to finish
            if (conversionDelayTextBox.Text.Length > 0)
                htmlToSvgConverter.ConversionDelay = int.Parse(conversionDelayTextBox.Text);

            // The buffer to receive the generated SVG document
            byte[] outSvgBuffer = null;

            if (convertUrlRadioButton.Checked)
            {
                string url = urlTextBox.Text;

                // Convert the HTML page given by an URL to a SVG document in a memory buffer
                outSvgBuffer = htmlToSvgConverter.ConvertUrl(url);
            }
            else
            {
                string htmlString = htmlStringTextBox.Text;
                string baseUrl = baseUrlTextBox.Text;

                // Convert a HTML string with a base URL to a SVG document in a memory buffer
                outSvgBuffer = htmlToSvgConverter.ConvertHtml(htmlString, baseUrl);
            }

            // Send the SVG as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "image/svg+xml");

            // Instruct the browser to open the SVG file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=HTML_to_SVG.svg; size={0}", outSvgBuffer.Length.ToString()));

            // Write the SVG document buffer to HTTP response
            Response.BinaryWrite(outSvgBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urlPanel.Visible = convertUrlRadioButton.Checked;
                htmlStringPanel.Visible = !convertUrlRadioButton.Checked;

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_Image/HTML_to_SVG.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_Image/HTML_to_SVG.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_Image");
                Master.SelectNode("Convert_HTML_to_SVG");
            }
        }

        protected void convertUrlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            urlPanel.Visible = convertUrlRadioButton.Checked;
            htmlStringPanel.Visible = !convertUrlRadioButton.Checked;
        }

        protected void convertHtmlRadioButton_CheckedChanged(object sender, EventArgs e)
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
    }
}
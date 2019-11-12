using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.HTTP_Headers_and_Cookies
{
    public partial class Add_HTTP_Headers_to_Request : System.Web.UI.Page
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

            // Add custom HTTP headers

            if (header1NameTextBox.Text.Length > 0 && header1ValueTextBox.Text.Length > 0)
                htmlToPdfConverter.HttpRequestHeaders.Add(header1NameTextBox.Text, header1ValueTextBox.Text);

            if (header2NameTextBox.Text.Length > 0 && header2ValueTextBox.Text.Length > 0)
                htmlToPdfConverter.HttpRequestHeaders.Add(header2NameTextBox.Text, header2ValueTextBox.Text);

            if (header3NameTextBox.Text.Length > 0 && header3ValueTextBox.Text.Length > 0)
                htmlToPdfConverter.HttpRequestHeaders.Add(header3NameTextBox.Text, header3ValueTextBox.Text);

            if (header4NameTextBox.Text.Length > 0 && header4ValueTextBox.Text.Length > 0)
                htmlToPdfConverter.HttpRequestHeaders.Add(header4NameTextBox.Text, header4ValueTextBox.Text);

            if (header5NameTextBox.Text.Length > 0 && header5ValueTextBox.Text.Length > 0)
                htmlToPdfConverter.HttpRequestHeaders.Add(header5NameTextBox.Text, header5ValueTextBox.Text);

            // Convert the HTML page to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(urlTextBox.Text);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=HTTP_Headers.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/HTTP_Headers_Cookies/Add_HTTP_Headers.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/HTTP_Headers_Cookies/Add_HTTP_Headers.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("HTTP_Headers_and_Cookies");
                Master.SelectNode("Add_HTTP_Headers");
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
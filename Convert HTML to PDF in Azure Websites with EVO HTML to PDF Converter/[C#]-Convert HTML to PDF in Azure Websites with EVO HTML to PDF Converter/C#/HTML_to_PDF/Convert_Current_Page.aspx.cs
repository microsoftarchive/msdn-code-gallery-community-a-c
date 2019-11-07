using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF
{
    public partial class Convert_Current_Page : System.Web.UI.Page
    {
        // Controls if the current HTML page will be rendered to PDF or as a normal page
        bool convertToPdf = false;

        protected void convertToPdfButton_Click(object sender, EventArgs e)
        {
            // The current ASP.NET page will be rendered to PDF when its Render method will be called by framework
            convertToPdf = true;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (convertToPdf)
            {
                // Get the current page HTML string by rendering into a TextWriter object
                TextWriter outTextWriter = new StringWriter();
                HtmlTextWriter outHtmlTextWriter = new HtmlTextWriter(outTextWriter);
                base.Render(outHtmlTextWriter);

                // Obtain the current page HTML string
                string currentPageHtmlString = outTextWriter.ToString();

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
                
                // Use the current page URL as base URL
                string baseUrl = "http://www.evopdf.com/demo/HTML_to_PDF/";

                // Convert the current page HTML string to a PDF document in a memory buffer
                byte[] outPdfBuffer = htmlToPdfConverter.ConvertHtml(currentPageHtmlString, baseUrl);

                // Send the PDF as response to browser

                // Set response content type
                Response.AddHeader("Content-Type", "application/pdf");

                // Instruct the browser to open the PDF file as an attachment or inline
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Convert_Current_Page.pdf; size={0}", outPdfBuffer.Length.ToString()));

                // Write the PDF document buffer to HTTP response
                Response.BinaryWrite(outPdfBuffer);

                // End the HTTP response and stop the current page processing
                Response.End();
            }
            else
            {
                base.Render(writer);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Convert_Current_Page.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Convert_Current_Page.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.SelectNode("Convert_Current_Page");
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

        protected void haveCarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            selectCarTypePanel.Visible = haveCarCheckBox.Checked;
        }
    }
}
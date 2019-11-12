using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.Table_of_Contents
{
    public partial class Define_in_HTML_Table_of_Contents_Items : System.Web.UI.Page
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

            // Optionally set the table of contents title
            htmlToPdfConverter.TableOfContentsOptions.Title = "Table of Contents";

            // Optionally set the title style using CSS sttributes
            htmlToPdfConverter.TableOfContentsOptions.TitleStyle = "color:navy; font-family:'Times New Roman'; font-size:28px; font-weight:normal";

            // Optionally set the style of level 1 items in table of contents
            string level1TextStyle = "color:navy; font-family:'Times New Roman'; font-size:20px; font-weight:normal; font-style:normal; background-color:#F0F0F0";
            htmlToPdfConverter.TableOfContentsOptions.SetItemStyle(1, level1TextStyle);

            // Optionally set the page numbers style of level 1 items in table of contents
            string level1PageNumberStyle = "color:navy; padding-right:3px; background-color:#F0F0F0; font-size:14px; font-weight:bold";
            htmlToPdfConverter.TableOfContentsOptions.SetPageNumberStyle(1, level1PageNumberStyle);

            byte[] outPdfBuffer = null;

            if (convertHtmlRadioButton.Checked)
            {
                string htmlWithBookmarkAttributes = htmlStringTextBox.Text;
                string baseUrl = baseUrlTextBox.Text;

                // Convert a HTML string with table of contents to a PDF document in a memory buffer
                outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlWithBookmarkAttributes, baseUrl);
            }
            else
            {
                string url = urlTextBox.Text;

                // Convert a HTML page with table of contents to a PDF document in a memory buffer
                outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
            }

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Define_in_HTML_Table_of_Contents.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Table_of_Contents.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                urlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/Table_of_Contents.html";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/Table_of_Contents/Define_in_HTML.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/Table_of_Contents/Define_in_HTML.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("Table_of_Contents");
                Master.SelectNode("Define_in_HTML_Table_of_Contents");
            }
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
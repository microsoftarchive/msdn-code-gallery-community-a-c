using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.HTTP_GET_and_POST
{
    public partial class GET_and_POST_HTTP_Methods : System.Web.UI.Page
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

            string param1Name = param1NameTextBox.Text.Length > 0 ? param1NameTextBox.Text : "param1";
            string param1Value = param1ValueTextBox.Text.Length > 0 ? param1ValueTextBox.Text : "Value 1";

            string param2Name = param2NameTextBox.Text.Length > 0 ? param2NameTextBox.Text : "param2";
            string param2Value = param2ValueTextBox.Text.Length > 0 ? param2ValueTextBox.Text : "Value 2";

            string param3Name = param3NameTextBox.Text.Length > 0 ? param3NameTextBox.Text : "param3";
            string param3Value = param3ValueTextBox.Text.Length > 0 ? param3ValueTextBox.Text : "Value 3";

            string param4Name = param4NameTextBox.Text.Length > 0 ? param4NameTextBox.Text : "param4";
            string param4Value = param4ValueTextBox.Text.Length > 0 ? param4ValueTextBox.Text : "Value 4";

            string param5Name = param5NameTextBox.Text.Length > 0 ? param5NameTextBox.Text : "param5";
            string param5Value = param5ValueTextBox.Text.Length > 0 ? param5ValueTextBox.Text : "Value 5";

            string urlToConvert = urlTextBox.Text;

            if (postMethodRadioButton.Checked)
            {
                htmlToPdfConverter.HttpPostFields.Add(param1Name, param1Value);
                htmlToPdfConverter.HttpPostFields.Add(param2Name, param2Value);
                htmlToPdfConverter.HttpPostFields.Add(param3Name, param3Value);
                htmlToPdfConverter.HttpPostFields.Add(param4Name, param4Value);
                htmlToPdfConverter.HttpPostFields.Add(param5Name, param5Value);
            }
            else
            {
                Uri getMethodUri = new Uri(urlTextBox.Text);

                string query = getMethodUri.Query.Length > 0 ? "&" : "?" + String.Format("{0}={1}", param1Name, param1Value);
                query += String.Format("&{0}={1}", param2Name, param2Value);
                query += String.Format("&{0}={1}", param3Name, param3Value);
                query += String.Format("&{0}={1}", param4Name, param4Value);
                query += String.Format("&{0}={1}", param5Name, param5Value);

                urlToConvert = urlTextBox.Text + query;
            }

            // Convert the HTML page to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(urlToConvert);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=GET_and_POST.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/HTTP_GET_and_POST/GET_and_POST_HTTP_Methods.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/HTTP_GET_and_POST/GET_and_POST_HTTP_Methods.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("HTTP_GET_and_POST");
                Master.SelectNode("Access_Using_HTTP_GET_and_POST");
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
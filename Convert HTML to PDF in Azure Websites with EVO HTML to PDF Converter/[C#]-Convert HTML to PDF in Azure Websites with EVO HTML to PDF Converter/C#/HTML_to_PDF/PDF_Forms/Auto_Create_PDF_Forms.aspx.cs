using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.PDF_Forms
{
    public partial class Auto_Create_PDF_Forms : System.Web.UI.Page
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

            // Enable the automatic conversion of the HTML form to a PDF form 
            htmlToPdfConverter.PdfFormOptions.AutoPdfFormEnabled = createPdfFormCheckBox.Checked;

            // Set the submit buttons style
            htmlToPdfConverter.PdfFormOptions.SubmitButtonStyle.BackColor = RgbColor.Beige;

            // Set the style of various types of text boxes
            htmlToPdfConverter.PdfFormOptions.TextBoxStyle.BackColor = RgbColor.AliceBlue;
            htmlToPdfConverter.PdfFormOptions.PasswordTextBoxStyle.BackColor = RgbColor.MistyRose;
            htmlToPdfConverter.PdfFormOptions.MultilineTextBoxStyle.BackColor = RgbColor.AliceBlue;

            // Set the radio buttons style
            htmlToPdfConverter.PdfFormOptions.RadioButtonsGroupStyle.BackColor = RgbColor.AntiqueWhite;

            // Set the checkboxes styles
            htmlToPdfConverter.PdfFormOptions.CheckBoxStyle.BackColor = RgbColor.AntiqueWhite;

            // set the drop down lists style
            htmlToPdfConverter.PdfFormOptions.ComboBoxStyle.BackColor = RgbColor.LightCyan;

            byte[] outPdfBuffer = null;

            if (convertHtmlRadioButton.Checked)
            {
                // Convert a HTML string to a PDF document with form fields
                string htmlWithForm = htmlStringTextBox.Text;
                outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlWithForm, String.Empty);
            }
            else
            {
                // Convert the HTML page to a PDF document with form fields
                string url = urlTextBox.Text;
                outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
            }

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Auto_Create_PDF_Forms.pdf; size={0}", outPdfBuffer.Length.ToString()));

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

                htmlStringTextBox.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/HTML_Files/HTML_Form.html"));
                baseUrlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/";

                urlTextBox.Text = rootUrl + "DemoAppFiles/Input/HTML_Files/HTML_Form.html";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/PDF_Forms/Auto_Create_PDF_Forms.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/PDF_Forms/Auto_Create_PDF_Forms.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("PDF_Forms");
                Master.SelectNode("HTML_Forms_to_PDF_Forms");
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
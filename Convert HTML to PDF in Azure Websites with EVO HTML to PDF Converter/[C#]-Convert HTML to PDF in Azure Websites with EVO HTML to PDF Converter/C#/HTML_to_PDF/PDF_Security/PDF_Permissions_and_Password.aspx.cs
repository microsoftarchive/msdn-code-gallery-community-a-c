using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.PDF_Security
{
    public partial class PDF_Permissions_and_Password : System.Web.UI.Page
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

            // Set user and owner passwords
            if (userPasswordTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfSecurityOptions.UserPassword = userPasswordTextBox.Text;

            if (ownerPasswordTextBox.Text.Length > 0)
                htmlToPdfConverter.PdfSecurityOptions.OwnerPassword = ownerPasswordTextBox.Text;

            if (htmlToPdfConverter.PdfSecurityOptions.UserPassword != null && htmlToPdfConverter.PdfSecurityOptions.UserPassword.Length > 0 &&
                (htmlToPdfConverter.PdfSecurityOptions.OwnerPassword == null || htmlToPdfConverter.PdfSecurityOptions.OwnerPassword.Length == 0 ||
                htmlToPdfConverter.PdfSecurityOptions.UserPassword == htmlToPdfConverter.PdfSecurityOptions.OwnerPassword))
            {
                // A user password is set but the owner password is not set or is identical to user password
                // Set a different owner password
                htmlToPdfConverter.PdfSecurityOptions.OwnerPassword = htmlToPdfConverter.PdfSecurityOptions.UserPassword + "_owner";
            }

            // Set PDF document permissions
            htmlToPdfConverter.PdfSecurityOptions.CanPrint = printEnabledCheckBox.Checked;
            htmlToPdfConverter.PdfSecurityOptions.CanCopyContent = copyContentEnabledCheckBox.Checked;
            htmlToPdfConverter.PdfSecurityOptions.CanEditContent = editContentEnabledCheckBox.Checked;
            htmlToPdfConverter.PdfSecurityOptions.CanEditAnnotations = editAnnotationsEnabledCheckBox.Checked;
            htmlToPdfConverter.PdfSecurityOptions.CanFillFormFields = fillFormFieldsEnabledCheckBox.Checked;

            // Convert the HTML page to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(urlTextBox.Text);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Set_Permissions_Password.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/PDF_Security/PDF_Permissions.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/PDF_Security/PDF_Permissions.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("PDF_Security_Features");
                Master.SelectNode("PDF_Permissions_and_Password");
            }
        }

        protected void editContentEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (editContentEnabledCheckBox.Checked)
                fillFormFieldsEnabledCheckBox.Checked = true;
        }

        protected void editAnnotationsEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (editAnnotationsEnabledCheckBox.Checked)
                fillFormFieldsEnabledCheckBox.Checked = true;
        }

        protected void fillFormFieldsEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!fillFormFieldsEnabledCheckBox.Checked)
            {
                editContentEnabledCheckBox.Checked = false;
                editAnnotationsEnabledCheckBox.Checked = false;
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
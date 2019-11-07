using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.HTML_to_PDF.PDF_Viewer_Preferences
{
    public partial class Set_Viewer_Preferences : System.Web.UI.Page
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

            // Set the PDF Viewer Preferences

            // Set page layout to continuous one column, single page, two column left, two column right
            htmlToPdfConverter.PdfViewerPreferences.PageLayout = SelectedPageLayout();
            // Set page mode to default, display bookmarks, display thumbnails, display attachments
            htmlToPdfConverter.PdfViewerPreferences.PageMode = SelectedPageMode();

            // Hide the viewer menu
            htmlToPdfConverter.PdfViewerPreferences.HideMenuBar = hideMenuBarCheckBox.Checked;
            // Hide the viewer toolbar
            htmlToPdfConverter.PdfViewerPreferences.HideToolbar = hideToolbarCheckBox.Checked;
            // Hide scroll bars and navigation controls
            htmlToPdfConverter.PdfViewerPreferences.HideWindowUI = hideWindowUICheckBox.Checked;

            // Display the document title in viewer title bar
            htmlToPdfConverter.PdfViewerPreferences.DisplayDocTitle = displayDocTitleCheckBox.Checked;

            // Convert the HTML page to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(urlTextBox.Text);

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Set_PDF_Viewer_Preferences.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        private ViewerPageLayout SelectedPageLayout()
        {
            switch (pageLayoutComboBox.SelectedValue)
            {
                case "Single Page":
                    return ViewerPageLayout.SinglePage;
                case "One Column":
                    return ViewerPageLayout.OneColumn;
                case "Two Column Left":
                    return ViewerPageLayout.TwoColumnLeft;
                case "Two Column Right":
                    return ViewerPageLayout.TwoColumnRight;
                default:
                    return ViewerPageLayout.OneColumn;
            }
        }

        private ViewerPageMode SelectedPageMode()
        {
            switch (pageModeComboBox.SelectedValue)
            {
                case "Default":
                    return ViewerPageMode.UseNone;
                case "Display Outlines":
                    return ViewerPageMode.UseOutlines;
                case "Display Thumbnails":
                    return ViewerPageMode.UseThumbs;
                case "Display Full Screen":
                    return ViewerPageMode.FullScreen;
                case "Display Optional Content Group":
                    return ViewerPageMode.UseOC;
                case "Display Attachments":
                    return ViewerPageMode.UseAttachments;
                default:
                    return ViewerPageMode.UseNone;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageLayoutComboBox.SelectedValue = "One Column";
                pageModeComboBox.SelectedValue = "Default";

                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/HTML_to_PDF/PDF_Viewer/Set_Viewer_Preferences.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/HTML_to_PDF/PDF_Viewer/Set_Viewer_Preferences.html"));

                Master.CollapseAll();
                Master.ExpandNode("HTML_to_PDF");
                Master.ExpandNode("PDF_Viewer_Preferences");
                Master.SelectNode("Set_Viewer_Preferences");
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
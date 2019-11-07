using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Editor
{
    public partial class Merge_PDF : System.Web.UI.Page
    {
        protected void mergePdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create the merge result PDF document
            Document mergeResultPdfDocument = new Document(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                mergeResultPdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            mergeResultPdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // The documents to merge must remain opened until the PDF document resulted after merge is saved
            // The merged documents can be automatically closed when the document resulted after merge is closed
            // if the AutoCloseAppendedDocs property of the PDF document resulted after merge is set on true like
            // in this demo applcation

            // Load the first PDF document to merge
            string firstPdfFilePath = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf");
            // Merge the first PDF document
            mergeResultPdfDocument.AppendDocument(firstPdfFilePath);

            // Load the second PDF document to merge
            string secondPdfFilePath = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf");
            // Merge the second PDF document
            mergeResultPdfDocument.AppendDocument(secondPdfFilePath);

            // Save the merge result PDF document in a memory buffer
            byte[] outPdfBuffer = mergeResultPdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Merge_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Editor/Merge_PDF.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Editor/Merge_PDF.html"));

                string currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                string rootUrl = "http://www.evopdf.com/demo/";

                firstPdfFileHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf";
                secondPdfFileHyperLink.NavigateUrl = rootUrl + "DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf";

                Master.CollapseAll();
                Master.ExpandNode("PDF_Editor");
                Master.SelectNode("Merge_PDF");
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
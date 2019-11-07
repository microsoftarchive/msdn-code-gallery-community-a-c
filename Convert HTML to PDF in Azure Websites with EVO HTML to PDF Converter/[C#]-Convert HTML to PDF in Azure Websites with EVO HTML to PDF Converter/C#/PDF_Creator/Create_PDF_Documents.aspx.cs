using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator
{
    public partial class Create_PDF_Documents : System.Web.UI.Page
    {
        protected void createPdfButton_Click(object sender, EventArgs e)
        {
            // Get the PDF Standard
            // By default the Full PDF standard is used
            PdfStandardSubset pdfStandard = PdfStandardSubset.Full;
            if (pdfARadioButton.Checked)
                pdfStandard = PdfStandardSubset.Pdf_A_1b;
            else if (pdfXRadioButton.Checked)
                pdfStandard = PdfStandardSubset.Pdf_X_1a;

            // Get the Color Space
            // By default the RGB color space is used
            ColorSpace pdfColorSpace = ColorSpace.RGB;
            if (grayScaleRadioButton.Checked)
                pdfColorSpace = ColorSpace.Gray;
            else if (cmykRadioButton.Checked)
                pdfColorSpace = ColorSpace.CMYK;

            // Create the PDF document
            Document pdfDocument = null;

            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            if (pdfStandard == PdfStandardSubset.Full && pdfColorSpace == ColorSpace.RGB)
            {
                // Create a PDF document with default standard and color space
                pdfDocument = new Document(serverIP, serverPort);
            }
            else
            {
                // Create a PDF document with the selected standard and color space
                pdfDocument = new Document(serverIP, serverPort, pdfStandard, pdfColorSpace);
            }

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Get the selected PDF page size
            PdfPageSize pdfPageSize = SelectedPdfPageSize();

            // Get the selected PDF page orientation
            PdfPageOrientation pdfPageOrientation = SelectedPdfPageOrientation();

            // Get the PDF page margins
            PdfMargins pdfPageMargins = new PdfMargins(float.Parse(leftMarginTextBox.Text), float.Parse(rightMarginTextBox.Text),
                    float.Parse(topMarginTextBox.Text), float.Parse(bottomMarginTextBox.Text));

            // Create a PDF page in PDF document
            PdfPage firstPdfPage = pdfDocument.AddPage(pdfPageSize, pdfPageMargins, pdfPageOrientation);

            // The URL of the HTML page to convert to PDF
            string urlToConvert = "http://www.evopdf.com";

            // Create the HTML to PDF element
            HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(urlToConvert);

            // Optionally set a delay before conversion to allow asynchonous scripts to finish
            htmlToPdfElement.ConversionDelay = 2;

            // Add the HTML to PDF element to PDF document
            firstPdfPage.AddElement(htmlToPdfElement);

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Create_PDF_Documents.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        private PdfPageSize SelectedPdfPageSize()
        {
            switch (pdfPageSizeDropDownList.SelectedValue)
            {
                case "A0":
                    return PdfPageSize.A0;
                case "A1":
                    return PdfPageSize.A1;
                case "A10":
                    return PdfPageSize.A10;
                case "A2":
                    return PdfPageSize.A2;
                case "A3":
                    return PdfPageSize.A3;
                case "A4":
                    return PdfPageSize.A4;
                case "A5":
                    return PdfPageSize.A5;
                case "A6":
                    return PdfPageSize.A6;
                case "A7":
                    return PdfPageSize.A7;
                case "A8":
                    return PdfPageSize.A8;
                case "A9":
                    return PdfPageSize.A9;
                case "ArchA":
                    return PdfPageSize.ArchA;
                case "ArchB":
                    return PdfPageSize.ArchB;
                case "ArchC":
                    return PdfPageSize.ArchC;
                case "ArchD":
                    return PdfPageSize.ArchD;
                case "ArchE":
                    return PdfPageSize.ArchE;
                case "B0":
                    return PdfPageSize.B0;
                case "B1":
                    return PdfPageSize.B1;
                case "B2":
                    return PdfPageSize.B2;
                case "B3":
                    return PdfPageSize.B3;
                case "B4":
                    return PdfPageSize.B4;
                case "B5":
                    return PdfPageSize.B5;
                case "Flsa":
                    return PdfPageSize.Flsa;
                case "HalfLetter":
                    return PdfPageSize.HalfLetter;
                case "Ledger":
                    return PdfPageSize.Ledger;
                case "Legal":
                    return PdfPageSize.Legal;
                case "Letter":
                    return PdfPageSize.Letter;
                case "Letter11x17":
                    return PdfPageSize.Letter11x17;
                case "Note":
                    return PdfPageSize.Note;
                default:
                    return PdfPageSize.A4;
            }
        }

        private PdfPageOrientation SelectedPdfPageOrientation()
        {
            return (pdfPageOrientationDropDownList.SelectedValue == "Portrait") ?
                PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pdfPageSizeDropDownList.SelectedValue = "A4";
                pdfPageOrientationDropDownList.SelectedValue = "Portrait";
                
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/Create_PDF_Documents.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/Create_PDF_Documents.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Create_PDF_Documents");
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
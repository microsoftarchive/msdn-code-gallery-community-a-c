using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

// Use EVO PDF Namespace
using EvoPdf.HtmlToPdfClient;

namespace EvoHtmlToPdfDemo.PDF_Creator
{
    public partial class PDF_Forms : System.Web.UI.Page
    {
        protected void createPdfButton_Click(object sender, EventArgs e)
        {
            // Get the server IP and port
            String serverIP = textBoxServerIP.Text;
            uint serverPort = uint.Parse(textBoxServerPort.Text);

            // Create a PDF document
            Document pdfDocument = new Document(serverIP, serverPort);

            // Set optional service password
            if (textBoxServicePassword.Text.Length > 0)
                pdfDocument.ServicePassword = textBoxServicePassword.Text;

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Add a page to PDF document
            PdfPage pdfPage = pdfDocument.AddPage();

            // The font used for titles in PDF document
            PdfFont titlesFont = new PdfFont("Times New Roman", 10, true);
            titlesFont.Bold = true;
            // The font used for field names in PDF document
            PdfFont fieldNameFont = new PdfFont("Times New Roman", 10, true);
            // The font used for buttons text in PDF document
            PdfFont buttonTextFont = new PdfFont("Times New Roman", 10, false);
            // The font used for PDF form text box fields
            PdfFont textFieldFont = new PdfFont(StdFontBaseFamily.Helvetica, 8);
            // The font used for PDF form combo box fields
            PdfFont comboBoxFieldFont = new PdfFont(StdFontBaseFamily.Helvetica, 8);

            // Add document title
            TextElement titleTextElement = new TextElement(5, 5, "Create PDF Forms", titlesFont);
            pdfPage.AddElement(titleTextElement);

            // Add a text box field to PDF form
            TextElement fieldNameTextElement = new TextElement(5, 30, 60, "First name:", fieldNameFont);
            pdfPage.AddElement(fieldNameTextElement);
            RectangleFloat fieldBoundingRectangle = new RectangleFloat(0, 50, 150, 15);
            // Create the form field
            PdfFormTextBox firstNameTextBoxField = new PdfFormTextBox(fieldBoundingRectangle, "Enter First Name", textFieldFont);
            pdfDocument.AddFormField(firstNameTextBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            firstNameTextBoxField.Name = "firstName";
            // Set the form field default value
            firstNameTextBoxField.DefaultValue = "A default first name";
            // Set form field style 
            firstNameTextBoxField.Style.BackColor = RgbColor.AliceBlue;

            // Add a text box field to PDF form
            fieldNameTextElement = new TextElement(0, 75, 60, "Last name:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);
            fieldBoundingRectangle = new RectangleFloat(0, 90, 150, 15);
            // Create the form field
            PdfFormTextBox textBoxField = new PdfFormTextBox(fieldBoundingRectangle, "Enter Last Name", textFieldFont);
            pdfDocument.AddFormField(textBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            textBoxField.Name = "lastName";
            // Set the form field default value
            textBoxField.DefaultValue = "A default last name";
            // Set form field style 
            textBoxField.Style.BackColor = RgbColor.MistyRose;

            // Add a password text box field to PDF form
            fieldNameTextElement = new TextElement(0, 105, 60, "Password:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);
            fieldBoundingRectangle = new RectangleFloat(0, 120, 150, 15);
            // Create the form field
            PdfFormTextBox passwordTextBoxField = new PdfFormTextBox(fieldBoundingRectangle, "", textFieldFont);
            pdfDocument.AddFormField(passwordTextBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            passwordTextBoxField.Name = "password";
            // Set form field style 
            passwordTextBoxField.Style.BackColor = RgbColor.AliceBlue;
            // Set the password mode for the text box
            passwordTextBoxField.IsPassword = true;

            // Add a radio buttons group to PDF form
            fieldNameTextElement = new TextElement(0, 0, 60, "Gender:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);

            // Create the radio buttons group
            PdfFormRadioButtonsGroup radioButtonsGroup = new PdfFormRadioButtonsGroup();
            pdfDocument.AddFormField(radioButtonsGroup);
            // Set unique form field name used when the form is submitted
            radioButtonsGroup.Name = "gender";
            // Set style of the radio buttons in this group
            radioButtonsGroup.Style.BackColor = RgbColor.AntiqueWhite;

            // Add the first radio button to group
            RectangleFloat radioButtonRectangle = new RectangleFloat(0, 0, 50, 10);
            // Create the form field
            PdfFormRadioButton radioButtonFieldMale = new PdfFormRadioButton(radioButtonRectangle, "male");
            radioButtonsGroup.AddRadioButton(radioButtonFieldMale, 10, true, false, 0, true, false);

            fieldNameTextElement = new TextElement(0, 0, 30, "Male", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, true, false, 0, true, false);

            // Add the second radio button to group
            radioButtonRectangle = new RectangleFloat(0, 0, 50, 10);
            // Create the form field
            PdfFormRadioButton radioButtonFieldFemale = new PdfFormRadioButton(radioButtonRectangle, "female");
            radioButtonsGroup.AddRadioButton(radioButtonFieldFemale, 15, true, false, 0, true, false);

            fieldNameTextElement = new TextElement(0, 0, 30, "Female", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, true, false, 0, true, false);

            // Set the selected radio btton in group
            radioButtonsGroup.SetCheckedRadioButton(radioButtonFieldFemale);

            // Add a checkbox field to PDF form
            fieldNameTextElement = new TextElement(0, 0, 60, "Vehicle:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);
            fieldBoundingRectangle = new RectangleFloat(0, 0, 10, 10);
            // Create the form field
            PdfFormCheckBox checkBoxField = new PdfFormCheckBox(fieldBoundingRectangle, true);
            pdfDocument.AddFormField(checkBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            checkBoxField.Name = "haveCar";
            // Set form field style 
            checkBoxField.Style.BackColor = RgbColor.AntiqueWhite;
            // Set checkbox field checked state
            checkBoxField.Checked = true;

            fieldNameTextElement = new TextElement(0, 0, 50, "I have a car", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 10, true, false, 0, true, false);

            // Add a combo box list field to PDF form
            fieldNameTextElement = new TextElement(0, 0, 60, "Vehicle Type:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);

            fieldBoundingRectangle = new RectangleFloat(0, 0, 50, 15);
            string[] comboBoxItems = new string[] { "Volvo", "Saab", "Audi", "Opel" };
            // Create the form field
            PdfFormComboBox comboBoxField = new PdfFormComboBox(fieldBoundingRectangle, comboBoxItems, comboBoxFieldFont);
            pdfDocument.AddFormField(comboBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            comboBoxField.Name = "vehicleType";
            // Set the form field default value
            comboBoxField.DefaultValue = "Audi";
            // Set form field style 
            comboBoxField.Style.BackColor = RgbColor.LightCyan;
            // Set selected item in combo box
            comboBoxField.Value = "Audi";

            // Add a multiline text box field to PDF form
            fieldNameTextElement = new TextElement(0, 0, 60, "Comments:", fieldNameFont);
            pdfDocument.AddElement(fieldNameTextElement, 5, false, 10, true);

            fieldBoundingRectangle = new RectangleFloat(0, 0, 150, 60);
            // Create the form field
            PdfFormTextBox multilineTextBoxField = new PdfFormTextBox(fieldBoundingRectangle,
                    "Enter your comments here:\r\nFirst comment line\r\nSecond comment line", textFieldFont);
            pdfDocument.AddFormField(multilineTextBoxField, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            multilineTextBoxField.Name = "comments";
            // Set form field style 
            multilineTextBoxField.Style.BackColor = RgbColor.AliceBlue;
            // Set the multiline mode for text box field
            multilineTextBoxField.IsMultiLine = true;

            // Add a form submit button to PDF form
            fieldBoundingRectangle = new RectangleFloat(0, 0, 75, 15);
            PdfFormButton submitFormButton = new PdfFormButton(fieldBoundingRectangle, "Submit", buttonTextFont);
            pdfDocument.AddFormField(submitFormButton, 5, false, 10, true);
            // Set unique form field name used when the form is submitted
            submitFormButton.Name = "submitFormButton";
            // Set form field style 
            submitFormButton.Style.BackColor = RgbColor.Beige;
            // Create the form submit action
            PdfSubmitFormAction submitFormAction = new PdfSubmitFormAction(submitUrlTextBox.Text);
            submitFormAction.Flags |= PdfFormSubmitFlags.ExportFormat;
            if (getMethodRadioButton.Checked)
                submitFormAction.Flags |= PdfFormSubmitFlags.GetMethod;
            // Set the form submit button action
            submitFormButton.Action = submitFormAction;

            // Add a form reset button to PDF form
            fieldBoundingRectangle = new RectangleFloat(0, 0, 75, 15);
            PdfFormButton resetFormButton = new PdfFormButton(fieldBoundingRectangle, "Reset", buttonTextFont);
            pdfDocument.AddFormField(resetFormButton, 10, true, false, 0, true, false);
            // Set unique form field name used when the form is submitted
            resetFormButton.Name = "resetFormButton";
            // Set form field style 
            resetFormButton.Style.BackColor = RgbColor.Beige;
            // Create the form reset action
            PdfResetFormAction resetFormAction = new PdfResetFormAction();

            // Set the form reset button action
            resetFormButton.Action = resetFormAction;

            // Save the PDF document in a memory buffer
            byte[] outPdfBuffer = pdfDocument.Save();

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Create_PDF_Forms.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sampleCodeLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Code_Samples/CSharp/AspNet/PDF_Creator/PDF_Forms.html"));
                descriptionLiteral.Text = System.IO.File.ReadAllText(Server.MapPath("~/DemoAppFiles/Input/Descriptions/AspNet/PDF_Creator/PDF_Forms.html"));

                Master.CollapseAll();
                Master.ExpandNode("PDF_Creator");
                Master.SelectNode("Create_PDF_Forms");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class pdf_converter_security : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // read parameters from the webpage
            string url = TxtUrl.Text;

            string userPassword = TxtUserPassword.Text.Trim();
            string ownerPassword = TxtOwnerPassword.Text.Trim();

            bool canAssembleDocument = ChkCanAssembleDocument.Checked;
            bool canCopyContent = ChkCanCopyContent.Checked;
            bool canEditAnnotations = ChkCanEditAnnotations.Checked;
            bool canEditContent = ChkCanEditContent.Checked;
            bool canFillFormFields = ChkCanFillFormFields.Checked;
            bool canPrint = ChkCanPrint.Checked;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set document passwords
            if (!string.IsNullOrEmpty(userPassword))
            {
                converter.Options.SecurityOptions.UserPassword = userPassword;
            }
            if (!string.IsNullOrEmpty(ownerPassword))
            {
                converter.Options.SecurityOptions.OwnerPassword = ownerPassword;
            }

            //set document permissions
            converter.Options.SecurityOptions.CanAssembleDocument = canAssembleDocument;
            converter.Options.SecurityOptions.CanCopyContent = canCopyContent;
            converter.Options.SecurityOptions.CanEditAnnotations = canEditAnnotations;
            converter.Options.SecurityOptions.CanEditContent = canEditContent;
            converter.Options.SecurityOptions.CanFillFormFields = canFillFormFields;
            converter.Options.SecurityOptions.CanPrint = canPrint;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}
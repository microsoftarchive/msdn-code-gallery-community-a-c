using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class PdfConverterSecurityModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public string TxtUserPassword { get; set; }

        [BindProperty]
        public string TxtOwnerPassword { get; set; }

        [BindProperty]
        public bool ChkCanAssembleDocument { get; set; }

        [BindProperty]
        public bool ChkCanCopyContent { get; set; }

        [BindProperty]
        public bool ChkCanEditAnnotations { get; set; }

        [BindProperty]
        public bool ChkCanEditContent { get; set; }

        [BindProperty]
        public bool ChkCanFillFormFields { get; set; }

        [BindProperty]
        public bool ChkCanPrint { get; set; }


        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set document passwords
            if (!string.IsNullOrEmpty(TxtUserPassword))
            {
                converter.Options.SecurityOptions.UserPassword = TxtUserPassword;
            }
            if (!string.IsNullOrEmpty(TxtOwnerPassword))
            {
                converter.Options.SecurityOptions.OwnerPassword = TxtOwnerPassword;
            }

            //set document permissions
            converter.Options.SecurityOptions.CanAssembleDocument = ChkCanAssembleDocument;
            converter.Options.SecurityOptions.CanCopyContent = ChkCanCopyContent;
            converter.Options.SecurityOptions.CanEditAnnotations = ChkCanEditAnnotations;
            converter.Options.SecurityOptions.CanEditContent = ChkCanEditContent;
            converter.Options.SecurityOptions.CanFillFormFields = ChkCanFillFormFields;
            converter.Options.SecurityOptions.CanPrint = ChkCanPrint;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class HtmlToPdfConverterLinksModel : PageModel
    {
        public void OnGet()
        {
            TxtUrl = Helper.WWWRoot(Request) + Url.Content("~/files/document.html");
        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public bool ChkInternalLinks { get; set; }

        [BindProperty]
        public bool ChkExternalLinks { get; set; }


        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set links options
            converter.Options.InternalLinksEnabled = ChkInternalLinks;
            converter.Options.ExternalLinksEnabled = ChkExternalLinks;

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
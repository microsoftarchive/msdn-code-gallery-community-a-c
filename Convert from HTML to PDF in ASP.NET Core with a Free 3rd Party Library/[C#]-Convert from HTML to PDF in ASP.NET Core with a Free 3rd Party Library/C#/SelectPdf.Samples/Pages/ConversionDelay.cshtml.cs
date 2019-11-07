using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class ConversionDelayModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public int delay { get; set; }

        [BindProperty]
        public int timeout { get; set; }

        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // specify the number of seconds the conversion is delayed
            converter.Options.MinPageLoadTime = delay;

            // set the page timeout
            converter.Options.MaxPageLoadTime = timeout;

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
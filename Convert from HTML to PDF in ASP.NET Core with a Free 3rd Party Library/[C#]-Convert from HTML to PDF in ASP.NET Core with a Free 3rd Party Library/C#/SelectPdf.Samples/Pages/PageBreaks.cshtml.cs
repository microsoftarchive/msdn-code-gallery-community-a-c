using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class PageBreaksModel : PageModel
    {
        public void OnGet()
        {
            TxtHtmlCode = Helper.PageBreaksText();
        }

        [BindProperty]
        public string TxtHtmlCode { get; set; }

        [BindProperty]
        public string TxtBaseUrl { get; set; }

        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.MarginTop = 10;
            converter.Options.MarginBottom = 10;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(TxtHtmlCode, TxtBaseUrl);

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
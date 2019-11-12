using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class PdfConverterPropertiesModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }

        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl);

            // get conversion result (contains document info from the web page)
            HtmlToPdfResult result = converter.ConversionResult;

            // set the document properties
            doc.DocumentInformation.Title = result.WebPageInformation.Title;
            doc.DocumentInformation.Subject = result.WebPageInformation.Description;
            doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords;

            doc.DocumentInformation.Author = "SelectPdf Samples";
            doc.DocumentInformation.CreationDate = DateTime.Now;

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
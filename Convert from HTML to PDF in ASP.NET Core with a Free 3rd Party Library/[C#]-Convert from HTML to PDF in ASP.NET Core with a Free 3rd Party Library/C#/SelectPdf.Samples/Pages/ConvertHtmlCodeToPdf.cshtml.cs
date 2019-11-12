using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectPdf.Samples.Pages
{
    public class ConvertHtmlCodeToPdfModel : PageModel
    {
        public void OnGet()
        {
            DdlPageSize = "A4";

            TxtHtmlCode = @"<html>
    <body>
        Hello World from selectpdf.com.
    </body>
</html>
";
        }

        [BindProperty]
        public string TxtHtmlCode { get; set; }

        [BindProperty]
        public string TxtBaseUrl { get; set; }

        [BindProperty]
        public string DdlPageSize { get; set; }

        public List<SelectListItem> PageSizes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "A1", Text = "A1" },
            new SelectListItem { Value = "A2", Text = "A2" },
            new SelectListItem { Value = "A3", Text = "A3" },
            new SelectListItem { Value = "A4", Text = "A4" },
            new SelectListItem { Value = "A5", Text = "A5" },
            new SelectListItem { Value = "Letter", Text = "Letter" },
            new SelectListItem { Value = "HalfLetter", Text = "HalfLetter" },
            new SelectListItem { Value = "Ledger", Text = "Ledger" },
            new SelectListItem { Value = "Legal", Text = "Legal" },
        };

        [BindProperty]
        public string DdlPageOrientation { get; set; }

        public List<SelectListItem> PageOrientations { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Portrait", Text = "Portrait" },
            new SelectListItem { Value = "Landscape", Text = "Landscape" },
        };

        [BindProperty]
        public string TxtWidth { get; set; }

        [BindProperty]
        public string TxtHeight { get; set; }

        public IActionResult OnPost()
        {
            // read parameters from the webpage
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                DdlPageSize, true);

            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                DdlPageOrientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(TxtWidth);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(TxtHeight);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

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
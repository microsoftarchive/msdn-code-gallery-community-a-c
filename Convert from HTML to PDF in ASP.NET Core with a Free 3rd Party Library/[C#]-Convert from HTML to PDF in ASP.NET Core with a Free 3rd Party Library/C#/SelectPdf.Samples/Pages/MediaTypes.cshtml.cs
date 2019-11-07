using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectPdf.Samples.Pages
{
    public class MediaTypesModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public string DdlCssMediaType { get; set; }

        public List<SelectListItem> CssMediaTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Screen", Text = "Screen" },
            new SelectListItem { Value = "Print", Text = "Print" },
        };


        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set css media type
            converter.Options.CssMediaType = (HtmlToPdfCssMediaType)Enum.Parse(
                typeof(HtmlToPdfCssMediaType), DdlCssMediaType, true);

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
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectPdf.Samples.Pages
{
    public class HtmlToPdfConverterModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public string DdlRenderingEngine { get; set; }

        public List<SelectListItem> RenderingEngines { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "WebKit", Text = "WebKit" },
            new SelectListItem { Value = "WebKitRestricted", Text = "WebKit Restricted" },
            new SelectListItem { Value = "Blink", Text = "Blink" },
        };

        public IActionResult OnPost()
        {
            // read parameters from the webpage
            RenderingEngine renderingEngine =
                (RenderingEngine)Enum.Parse(typeof(RenderingEngine), DdlRenderingEngine, true);

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the rendering engine
            converter.Options.RenderingEngine = renderingEngine;

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
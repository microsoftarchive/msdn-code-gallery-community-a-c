using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class HttpCookiesModel : PageModel
    {
        public void OnGet()
        {
            TxtUrl = Helper.WWWRoot(Request) + Url.Content("~/ViewHttpCookies");
        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public string TxtName1 { get; set; }

        [BindProperty]
        public string TxtValue1 { get; set; }

        [BindProperty]
        public string TxtName2 { get; set; }

        [BindProperty]
        public string TxtValue2 { get; set; }

        [BindProperty]
        public string TxtName3 { get; set; }

        [BindProperty]
        public string TxtValue3 { get; set; }

        [BindProperty]
        public string TxtName4 { get; set; }

        [BindProperty]
        public string TxtValue4 { get; set; }


        public IActionResult OnPost()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the HTTP cookies
            converter.Options.HttpCookies.Add(TxtName1, TxtValue1);
            converter.Options.HttpCookies.Add(TxtName2, TxtValue2);
            converter.Options.HttpCookies.Add(TxtName3, TxtValue3);
            converter.Options.HttpCookies.Add(TxtName4, TxtValue4);

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
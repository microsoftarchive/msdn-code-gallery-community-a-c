using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class HtmlToPdfHeadersAndFootersModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public bool showHeaderOnFirstPage { get; set; }

        [BindProperty]
        public bool showHeaderOnOddPages { get; set; }

        [BindProperty]
        public bool showHeaderOnEvenPages { get; set; }

        [BindProperty]
        public int headerHeight { get; set; }

        [BindProperty]
        public bool showFooterOnFirstPage { get; set; }

        [BindProperty]
        public bool showFooterOnOddPages { get; set; }

        [BindProperty]
        public bool showFooterOnEvenPages { get; set; }

        [BindProperty]
        public int footerHeight { get; set; }

        [BindProperty]
        public bool showPageNumbering { get; set; }


        public IActionResult OnPost()
        {
            // get parameters
            string headerUrl = Startup.ServerPath + @"\wwwroot\files\header.html";
            string footerUrl = Startup.ServerPath + @"\wwwroot\files\footer.html";

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // header settings
            converter.Options.DisplayHeader = showHeaderOnFirstPage ||
                showHeaderOnOddPages || showHeaderOnEvenPages;
            converter.Header.DisplayOnFirstPage = showHeaderOnFirstPage;
            converter.Header.DisplayOnOddPages = showHeaderOnOddPages;
            converter.Header.DisplayOnEvenPages = showHeaderOnEvenPages;
            converter.Header.Height = headerHeight;

            PdfHtmlSection headerHtml = new PdfHtmlSection(headerUrl);
            headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            converter.Header.Add(headerHtml);

            // footer settings
            converter.Options.DisplayFooter = showFooterOnFirstPage ||
                showFooterOnOddPages || showFooterOnEvenPages;
            converter.Footer.DisplayOnFirstPage = showFooterOnFirstPage;
            converter.Footer.DisplayOnOddPages = showFooterOnOddPages;
            converter.Footer.DisplayOnEvenPages = showFooterOnEvenPages;
            converter.Footer.Height = footerHeight;

            PdfHtmlSection footerHtml = new PdfHtmlSection(footerUrl);
            footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            converter.Footer.Add(footerHtml);

            // add page numbering element to the footer
            if (showPageNumbering)
            {
                // page numbers can be added using a PdfTextSection object
                PdfTextSection text = new PdfTextSection(0, 10,
                    "Page: {page_number} of {total_pages}  ",
                    new System.Drawing.Font("Arial", 8));
                text.HorizontalAlign = PdfTextHorizontalAlign.Right;
                converter.Footer.Add(text);
            }

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
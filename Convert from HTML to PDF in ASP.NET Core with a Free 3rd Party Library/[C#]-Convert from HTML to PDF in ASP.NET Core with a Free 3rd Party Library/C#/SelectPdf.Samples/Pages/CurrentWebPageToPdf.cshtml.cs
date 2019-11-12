using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Threading.Tasks;

namespace SelectPdf.Samples.Pages
{
    public class CurrentWebPageToPdfModel : PageModel
    {
        private readonly IViewRenderService _viewRenderService;

        public CurrentWebPageToPdfModel(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public void OnGet()
        {
            TxtSampleText = "sample text";
            DdlDropDownList1 = "Value3";

            ChkSampleCheckbox = true;

            TxtSampleText2 = "1000";
            TxtSampleText3 = "800";
        }

        [BindProperty]
        public string TxtSampleText { get; set; }

        [BindProperty]
        public string DdlDropDownList1 { get; set; }

        public List<SelectListItem> DropDownList1Values { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Value1", Text = "Value1" },
            new SelectListItem { Value = "Value2", Text = "Value2" },
            new SelectListItem { Value = "Value3", Text = "Value3" },
            new SelectListItem { Value = "Value4", Text = "Value4" },
        };

        [BindProperty]
        public bool ChkSampleCheckbox { get; set; }

        [BindProperty]
        public string TxtSampleText2 { get; set; }

        [BindProperty]
        public string TxtSampleText3 { get; set; }

        public async Task<IActionResult> OnPost()
        {
            string htmlString = await _viewRenderService.RenderToStringAsync("CurrentWebPageToPdf", "~/Pages/_Layout.cshtml", new CurrentWebPageToPdfModel(_viewRenderService)
            {
                TxtSampleText = this.TxtSampleText,
                DdlDropDownList1 = this.DdlDropDownList1,
                ChkSampleCheckbox = this.ChkSampleCheckbox,
                TxtSampleText2 = this.TxtSampleText2,
                TxtSampleText3 = this.TxtSampleText3,
            });

            // get base url
            string baseUrl = Startup.WebRootPath;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting a html string
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

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
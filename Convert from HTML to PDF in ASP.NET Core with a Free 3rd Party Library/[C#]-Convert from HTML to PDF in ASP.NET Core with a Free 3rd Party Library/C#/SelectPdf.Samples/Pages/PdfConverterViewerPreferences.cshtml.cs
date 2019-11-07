using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectPdf.Samples.Pages
{
    public class PdfConverterViewerPreferencesModel : PageModel
    {
        public void OnGet()
        {
            DdlPageLayout = "OneColumn";
            DdlPageMode = "UseNone";
        }

        [BindProperty]
        public string TxtUrl { get; set; }

        [BindProperty]
        public string DdlPageLayout { get; set; }

        public List<SelectListItem> PageLayouts { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "SinglePage", Text = "SinglePage" },
            new SelectListItem { Value = "OneColumn", Text = "OneColumn" },
            new SelectListItem { Value = "TwoColumnLeft", Text = "TwoColumnLeft" },
            new SelectListItem { Value = "TwoColumnRight", Text = "TwoColumnRight" },
        };

        [BindProperty]
        public string DdlPageMode { get; set; }

        public List<SelectListItem> PageModes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "UseNone", Text = "UseNone" },
            new SelectListItem { Value = "UseOutlines", Text = "UseOutlines" },
            new SelectListItem { Value = "UseThumbs", Text = "UseThumbs" },
            new SelectListItem { Value = "FullScreen", Text = "FullScreen" },
            new SelectListItem { Value = "UseOC", Text = "UseOC" },
            new SelectListItem { Value = "UseAttachments", Text = "UseAttachments" },
        };

        [BindProperty]
        public bool ChkCenterWindow { get; set; }

        [BindProperty]
        public bool ChkDisplayDocTitle { get; set; }

        [BindProperty]
        public bool ChkFitWindow { get; set; }

        [BindProperty]
        public bool ChkHideMenuBar { get; set; }

        [BindProperty]
        public bool ChkHideToolbar { get; set; }

        [BindProperty]
        public bool ChkHideWindowUI { get; set; }


        public IActionResult OnPost()
        {
            // read parameters from the webpage
            PdfViewerPageLayout pageLayout = (PdfViewerPageLayout)Enum.Parse(
                typeof(PdfViewerPageLayout), DdlPageLayout, true);

            PdfViewerPageMode pageMode = (PdfViewerPageMode)Enum.Parse(
                typeof(PdfViewerPageMode), DdlPageMode, true);

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.ViewerPreferences.CenterWindow = ChkCenterWindow;
            converter.Options.ViewerPreferences.DisplayDocTitle = ChkDisplayDocTitle;
            converter.Options.ViewerPreferences.FitWindow = ChkFitWindow;
            converter.Options.ViewerPreferences.HideMenuBar = ChkHideMenuBar;
            converter.Options.ViewerPreferences.HideToolbar = ChkHideToolbar;
            converter.Options.ViewerPreferences.HideWindowUI = ChkHideWindowUI;

            converter.Options.ViewerPreferences.PageLayout = pageLayout;
            converter.Options.ViewerPreferences.PageMode = pageMode;
            converter.Options.ViewerPreferences.NonFullScreenPageMode =
                PdfViewerFullScreenExitMode.UseNone;

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
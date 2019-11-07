using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace SelectPdf.Samples.Pages
{
    public class ViewHttpHeadersModel : PageModel
    {
        public void OnGet()
        {
            string headers = string.Empty;
            foreach (KeyValuePair<string, StringValues> header in Request.Headers)
            {
                headers += "<br/>" + header.Key + ": " + header.Value;
            }

            ViewData.Add("HeadersValue", headers);
        }
    }
}
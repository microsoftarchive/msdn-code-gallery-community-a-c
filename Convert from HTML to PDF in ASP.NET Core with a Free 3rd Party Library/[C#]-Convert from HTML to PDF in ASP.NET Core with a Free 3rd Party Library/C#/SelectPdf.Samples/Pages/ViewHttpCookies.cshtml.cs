using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SelectPdf.Samples.Pages
{
    public class ViewHttpCookiesModel : PageModel
    {
        public void OnGet()
        {
            string cookies = string.Empty;
            foreach (string key in Request.Cookies.Keys)
            {
                string cookie = Request.Cookies[key];
                cookies += "<br/>" + key + ": " + cookie;
            }

            ViewData.Add("cookiesValue", cookies);
        }
    }
}
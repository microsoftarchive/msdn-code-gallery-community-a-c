using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace SelectPdf.Samples.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ViewHttpPostDataModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            StringBuilder output = new StringBuilder();
            output.Append("<br/>Request method: " +
                Request.Method + "<br/>");

            // Parse POST form fields collection.
            foreach (KeyValuePair<string, StringValues> element in Request.Form)
            {
                output.Append("Name: " + element.Key + "<br/>");

                // Get all values under this key.
                String[] values = element.Value.ToArray();
                for (int j = 0; j < values.Length; j++)
                {
                    output.Append("Value: " + values[j] + "<br/>");
                }
                output.Append("<br/>");

            }

            ViewData.Add("PostDataValue", output.ToString());

        }
    }
}
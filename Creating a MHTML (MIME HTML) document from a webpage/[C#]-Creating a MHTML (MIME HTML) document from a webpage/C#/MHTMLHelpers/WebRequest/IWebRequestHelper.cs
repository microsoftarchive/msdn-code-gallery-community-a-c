using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHTMLHelpers.WebRequest
{
    
    public interface IWebRequestHelper
    {
        
        WebRequestResult GetContent(String url);
        string GetAbsoluteUrl(string baseUrl, string url);

    }

}

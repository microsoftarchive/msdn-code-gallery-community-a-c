using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHTMLHelpers.WebRequest
{
    
    public class WebRequestResult
    {

        public string Url { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }

    }

}

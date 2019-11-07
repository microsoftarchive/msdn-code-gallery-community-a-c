using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousDownloader.ViewModel
{
    [System.ComponentModel.DesignerCategory("")]
    public class CustomWebClient : WebClient
    {
        public object Data { get; set; }
        public Stopwatch Clock { get; set; }
    }
}

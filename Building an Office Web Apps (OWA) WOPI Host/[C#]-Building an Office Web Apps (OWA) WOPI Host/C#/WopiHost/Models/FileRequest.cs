using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Models
{
    public class FileRequest
    {
        public string name { get; set; }

        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
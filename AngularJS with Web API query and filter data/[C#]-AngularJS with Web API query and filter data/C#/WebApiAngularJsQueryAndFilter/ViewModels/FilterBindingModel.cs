using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class FilterBindingModel
    {
        public FilterBindingModel() { }

        public List<int> Authors { get; set; }
        public List<int> Publishers { get; set; }
        public List<int> Classifications { get; set; }
    }
}
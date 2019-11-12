using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class SearchQueryBindingModel
    {
        public string SearchText { get; set; }
        public OrderByOptions OrderBy { get; set; }
        public BookQueryFilters Filters { get; set; }
    }
}
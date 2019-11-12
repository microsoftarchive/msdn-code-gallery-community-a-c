using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class QueryBindingModel
    {
        public QueryBindingModel()
        {

        }

        public string SearchText { get; set; }
        public OrderByOptions OrderBy { get; set; }
        public List<int> Authors { get; set; }
        public List<int> Publishers { get; set; }
        public List<int> Classifications { get; set; }
    }
}
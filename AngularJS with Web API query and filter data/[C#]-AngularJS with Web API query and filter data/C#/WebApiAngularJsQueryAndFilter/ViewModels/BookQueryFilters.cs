using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class BookQueryFilters
    {
        public BookQueryFilters()
        {
            this.Classifications = new List<ClassificationViewModel>();
            this.Publishers = new List<PublisherViewModel>();
        }

        public IEnumerable<ClassificationViewModel> Classifications { get; set; }
        public IEnumerable<PublisherViewModel> Publishers { get; set; }
    }
}
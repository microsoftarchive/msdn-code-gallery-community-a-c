using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAngularJsQueryAndFilter.Models;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            this.Authors = new List<AuthorViewModel>();
            this.Classifications = new List<ClassificationViewModel>();
            this.Publishers = new List<PublisherViewModel>();
        }

        public List<AuthorViewModel> Authors { get; set; }
        public List<PublisherViewModel> Publishers { get; set; }
        public List<ClassificationViewModel> Classifications { get; set; }
    }
}
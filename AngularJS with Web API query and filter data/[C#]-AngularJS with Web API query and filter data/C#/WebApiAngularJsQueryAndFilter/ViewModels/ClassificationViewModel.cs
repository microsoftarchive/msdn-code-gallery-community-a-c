using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAngularJsQueryAndFilter.Models;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class ClassificationViewModel
    {
        public ClassificationViewModel()
        {

        }

        public ClassificationViewModel(Classification classification)
        {
            this.Id = classification.Id;
            this.Name = classification.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
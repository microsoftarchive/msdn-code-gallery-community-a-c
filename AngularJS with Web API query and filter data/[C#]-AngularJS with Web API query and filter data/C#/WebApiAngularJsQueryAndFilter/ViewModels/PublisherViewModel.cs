using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAngularJsQueryAndFilter.Models;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class PublisherViewModel
    {
        public PublisherViewModel()
        {

        }

        public PublisherViewModel(Publisher publisher)
        {
            this.Id = publisher.Id;
            this.Name = publisher.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
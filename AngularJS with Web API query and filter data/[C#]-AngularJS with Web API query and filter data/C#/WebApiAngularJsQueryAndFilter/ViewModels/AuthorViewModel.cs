using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAngularJsQueryAndFilter.Models;

namespace WebApiAngularJsQueryAndFilter.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
        }

        public AuthorViewModel(Author author)
        {
            this.Id = author.Id;
            this.Name = author.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
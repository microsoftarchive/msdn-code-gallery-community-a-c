using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Breeze.WebApi;
using MyContact.Models;
using Newtonsoft.Json.Linq;

namespace MyContact.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {

        readonly EFContextProvider<MyContactDBContext> _contextProvider =
            new EFContextProvider<MyContactDBContext>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();

        }

        [HttpGet]
        public IQueryable<Contact> Contacts()
        {
            return _contextProvider.Context.Contacts;

        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);

        }

        //[HttpGet]
        //public Contact CreateContact() 
        //{
        //    return new Contact();
        //}


    }
}

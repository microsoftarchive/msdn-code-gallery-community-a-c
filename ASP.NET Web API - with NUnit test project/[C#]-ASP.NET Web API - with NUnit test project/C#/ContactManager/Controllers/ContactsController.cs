using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ContactManager.Models;
using ContactManager.Models.Entities;
using AutoMapper;
using ContactManager.Messages;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ContactManager.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactRepository repository;
        Exception ex = new Exception();

        
        public ContactsController(IContactRepository repository)
        {
            this.repository = repository;

            Mapper.CreateMap<Contact,ContactDTO>();
            Mapper.AssertConfigurationIsValid();
        }

        #region GetContact

        [HttpGet]
        public ContactResponse Get()
        {
            ContactResponse response = new ContactResponse();
            response.contacts = Mapper.Map<List<Contact>, List<ContactDTO>>(this.repository.GetContacts());

            return response;
        }

        [HttpGet]
        public ContactResponse Get(int id)
        {
            ContactResponse response = new ContactResponse();
            response.contact = Mapper.Map<Contact, ContactDTO>(this.repository.GetContact(id));

            return response;
        }
        #endregion

        //[HttpGet]
        //public ContactResponse contct(int id)
        //{
        //    ContactResponse response = new ContactResponse();

        //    response.contact = Mapper.Map<Contact, ContactDTO>(this.repository.GetContact(id));

        //    if (response.contact == null)
        //    {
        //        ExceptionPolicy.HandleException(ex.Messag, "MyPolicy");
        //    }

        //    return response;

        //}


    }
}

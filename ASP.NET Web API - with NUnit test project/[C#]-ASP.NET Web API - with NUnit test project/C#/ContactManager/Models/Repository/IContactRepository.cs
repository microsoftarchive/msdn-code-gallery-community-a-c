using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models;
using ContactManager.Models.Entities;

namespace ContactManager.Models
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();

        Contact GetContact(int id);

    }
}
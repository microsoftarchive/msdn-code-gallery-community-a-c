using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models.Entities;

namespace ContactManager.Models.Repository
{
    public class ContactRepository : IContactRepository 
    {
        public Contact GetContact(int id)
        {
            using(var context = ContactFactory.CreateContext())
            {
                var contactItem = (from contact in context.Contacts where contact.ID == id select contact).SingleOrDefault();
                return contactItem;
                
            }
        }

        public List<Contact> GetContacts()
        {
            using(var context = ContactFactory.CreateContext())
            {
                var contactList = (from contacts in context.Contacts select contacts).ToList();

                return contactList;
            }
        }
    }
}
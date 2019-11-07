using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity.Infrastructure;
using System.Web.Security;

namespace ContactManager.Models
{
    public class ContactManagerRepository : IContactRepository
    {
        private ContactManagerContext db = new ContactManagerContext();

        public void Update(Contact updatedContact)
        {
            var contact = this.Get(updatedContact.ContactId);
            contact.Name = updatedContact.Name;
            contact.Address = updatedContact.Address;
            contact.City = updatedContact.City;
            contact.State = updatedContact.State;
            contact.Zip = updatedContact.Zip;
            contact.Email = updatedContact.Email;
            contact.Twitter = updatedContact.Twitter;
            db.SaveChanges();
        }

        public Contact Get(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

        public IQueryable<Contact> GetAll()
        {
            return db.Contacts;
        }

        public void Post(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public Contact Delete(int id)
        {
            Contact contact = Get(id);
            if (contact == null)
            {
                return null;
            }

            db.Contacts.Remove(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return contact;
        }
    }
}
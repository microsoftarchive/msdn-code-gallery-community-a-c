using ContactManager.Models;

namespace ContactManager.Models
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class SampleContactRepository : IContactRepository
    {
        private int nextContactID;

        private IList<Contact> contacts; 

        public SampleContactRepository()
        {
            contacts = new List<Contact>(SampleData.Contacts);
            nextContactID = contacts.Count + 1;
        }

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
        }

        public Contact Get(int id)
        {
            return contacts.SingleOrDefault(c => c.ContactId == id);
        }

        public IQueryable<Contact> GetAll()
        {
            return contacts.AsQueryable();
        }

        public void Post(Contact contact)
        {
            contact.ContactId = nextContactID++;
            contacts.Add(contact);
        }

        public Contact Delete(int id)
        {
            var contact = this.Get(id);
            contacts.Remove(contact);
            return contact;
        }
    }
}
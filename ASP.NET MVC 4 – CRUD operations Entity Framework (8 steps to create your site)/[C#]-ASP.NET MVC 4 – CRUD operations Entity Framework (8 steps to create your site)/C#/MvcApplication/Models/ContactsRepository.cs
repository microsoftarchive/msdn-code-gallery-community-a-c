using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcApplication.Models
{ 
    public class ContactsRepository : IContactsRepository
    {
        ModelContainer context = new ModelContainer();

        public IQueryable<Contacts> All
        {
            get { return context.Contacts; }
        }

        public IQueryable<Contacts> AllIncluding(params Expression<Func<Contacts, object>>[] includeProperties)
        {
            IQueryable<Contacts> query = context.Contacts;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Contacts Find(int id)
        {
            return context.Contacts.Find(id);
        }

        public void InsertOrUpdate(Contacts contacts)
        {
            if (contacts.Id == default(int)) {
                // New entity
                context.Contacts.Add(contacts);
            } else {
                // Existing entity
                context.Entry(contacts).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var contacts = context.Contacts.Find(id);
            context.Contacts.Remove(contacts);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IContactsRepository : IDisposable
    {
        IQueryable<Contacts> All { get; }
        IQueryable<Contacts> AllIncluding(params Expression<Func<Contacts, object>>[] includeProperties);
        Contacts Find(int id);
        void InsertOrUpdate(Contacts contacts);
        void Delete(int id);
        void Save();
    }
}
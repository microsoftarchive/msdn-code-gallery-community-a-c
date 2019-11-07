using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcApplication.Models
{ 
    public class ClientsRepository : IClientsRepository
    {
        ModelContainer context = new ModelContainer();

        public IQueryable<Clients> All
        {
            get { return context.Clients; }
        }

        public IQueryable<Clients> AllIncluding(params Expression<Func<Clients, object>>[] includeProperties)
        {
            IQueryable<Clients> query = context.Clients;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Clients Find(int id)
        {
            return context.Clients.Find(id);
        }

        public void InsertOrUpdate(Clients clients)
        {
            if (clients.Id == default(int)) {
                // New entity
                context.Clients.Add(clients);
            } else {
                // Existing entity
                context.Entry(clients).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var clients = context.Clients.Find(id);
            context.Clients.Remove(clients);
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

    public interface IClientsRepository : IDisposable
    {
        IQueryable<Clients> All { get; }
        IQueryable<Clients> AllIncluding(params Expression<Func<Clients, object>>[] includeProperties);
        Clients Find(int id);
        void InsertOrUpdate(Clients clients);
        void Delete(int id);
        void Save();
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CustomerRepository : iCustomerRepository
    {
        Customer_Entities context;
        public CustomerRepository(Customer_Entities context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return this.context.Customers.ToList();
        }
        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Customer model)
        {
            context.Entry(model).State = EntityState.Added;
        }
        public void Update(Customer model)
        {
            context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Customer model = context.Customers.FirstOrDefault(x => x.Id == id);
            context.Entry(model).State = EntityState.Deleted;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

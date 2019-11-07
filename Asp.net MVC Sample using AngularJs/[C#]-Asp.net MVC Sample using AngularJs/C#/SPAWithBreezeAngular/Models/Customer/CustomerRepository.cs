using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SPAWithBreezeAngular.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        Customer Add(Customer item);
        void Remove(int id);
        bool Update(Customer item);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _db;

        public CustomerRepository()
        {
            _db = new CustomerContext();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customers;
        }

        public Customer Get(int id)
        {
            return _db.Customers.Find(id);
        }

        public Customer Add(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer;
        }

        public void Remove(int id)
        {
            Customer customer = _db.Customers.Find(id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

        public bool Update(Customer item)
        {
            Customer newCustomer =_db.Customers.Find(item.CustomerID);
            if (newCustomer == null)
                return false;

            newCustomer.Email = item.Email;
            newCustomer.Name = item.Name;
            _db.SaveChanges();
            return true;
        }

    }
}
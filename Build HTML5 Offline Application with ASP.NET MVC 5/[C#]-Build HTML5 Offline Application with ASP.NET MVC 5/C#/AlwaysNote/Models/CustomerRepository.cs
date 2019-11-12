using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlwaysNote.Models
{
    public class CustomerRepository
    {
        public void Update(int id, string name, string note) {
            Customer customer = null;
      
            using (AlwaysNoteDataContext db =
                        new AlwaysNoteDataContext())
            {
                var query = from c in db.Customers
                            where c.CustomerID == id
                            select c;
      
                customer = query.SingleOrDefault<Customer>();
      
                customer.Name = name;
                customer.Note = note;
      
                db.SubmitChanges();
            }
        }
      
        public int Add(string name, string note)
        {
            Customer customer = null;
      
            using (AlwaysNoteDataContext db =
                        new AlwaysNoteDataContext())
            {
                customer = new Customer();
                customer.Name = name;
                customer.Note = note;
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges();
            }
      
            int id = customer.CustomerID;
      
            return id;
        }
    }
}
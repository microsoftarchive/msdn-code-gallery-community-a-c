using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    interface iCustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        void Add(Customer model);

        void Update(Customer model);

        void Delete(int id);

        void Save();
    }
}

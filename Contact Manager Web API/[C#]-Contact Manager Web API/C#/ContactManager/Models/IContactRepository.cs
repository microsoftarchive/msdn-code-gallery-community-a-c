using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace ContactManager.Models
{
    public interface IContactRepository
    {
        void Update(Contact updatedContact);

        Contact Get(int id);

        IQueryable<Contact> GetAll();

        void Post(Contact contact);

        Contact Delete(int id);
    }
}
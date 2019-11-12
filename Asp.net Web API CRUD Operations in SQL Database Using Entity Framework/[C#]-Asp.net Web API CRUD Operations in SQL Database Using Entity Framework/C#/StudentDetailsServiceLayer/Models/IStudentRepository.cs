using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsServiceLayer.Models
{
    public interface IStudentRepository
    {
        List<Table> GetAll();
        Table Get(int id);
        Table Add(Table student);
        void Remove(int id);
        bool Update(Table student);
    }
}

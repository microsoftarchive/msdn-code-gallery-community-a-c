using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetailsServiceLayer.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student student);
        void Remove(int id);
        bool Update(Student student);
    }
}

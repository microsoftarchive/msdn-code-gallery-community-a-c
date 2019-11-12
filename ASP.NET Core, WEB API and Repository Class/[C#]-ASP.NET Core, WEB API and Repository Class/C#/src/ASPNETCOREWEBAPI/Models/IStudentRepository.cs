using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREWEBAPI.Models
{
    public interface IStudentRepository
    {
        IEnumerable<StudentMasters> GetAll();
        void Add(StudentMasters info);
    }
}

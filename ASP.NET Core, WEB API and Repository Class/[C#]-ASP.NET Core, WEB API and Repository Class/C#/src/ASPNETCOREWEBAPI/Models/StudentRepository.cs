using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREWEBAPI.Models
{
    public class StudentRepository: IStudentRepository
    {
        private static ConcurrentDictionary<string, StudentMasters> stdMaster = new ConcurrentDictionary<string, StudentMasters>();

        public StudentRepository()
        {

            Add(new StudentMasters
            {
                StdName = "Shanu",
                Phone = "+821039120700",
                Email = "syedshanumcain@gmail.com",
                Address = "Seoul,Korea"
            });

        }

        public IEnumerable<StudentMasters> GetAll()
        {
            return stdMaster.Values;
        }

        public void Add(StudentMasters studentInfo)
        {
            stdMaster[studentInfo.StdName] = studentInfo;
        }
    }
}

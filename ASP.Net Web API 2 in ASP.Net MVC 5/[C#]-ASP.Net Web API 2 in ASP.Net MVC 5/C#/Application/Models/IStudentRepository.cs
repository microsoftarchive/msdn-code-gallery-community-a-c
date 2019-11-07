using Application.Models.StudentApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student AddStudent(Student student);
    }
}

using Application.Models;
using Application.Models.StudentApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Controllers
{
    public class StudentsController : ApiController
    {
        static readonly IStudentRepository studentRepository = new StudentRepository();

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAllStudents();
        }
    }
}

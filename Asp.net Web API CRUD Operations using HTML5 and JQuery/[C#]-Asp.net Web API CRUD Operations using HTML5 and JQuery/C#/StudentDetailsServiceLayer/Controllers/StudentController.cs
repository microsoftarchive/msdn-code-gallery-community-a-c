using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDetailsServiceLayer.Models;

namespace StudentDetailsServiceLayer.Controllers
{
    public class StudentController : ApiController
    {
        static readonly IStudentRepository studentRepository = new StudentRepository();

        public IEnumerable<Student> GetAllStudents()
        {
            return studentRepository.GetAll();
        }

        public HttpResponseMessage GetStudent(int id)
        {
            Student student = studentRepository.Get(id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Student Not found for the Given ID");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
        }

        public IEnumerable<Student> GetStudentsByGender(string gender)
        {
            return studentRepository.GetAll().Where(
                s => string.Equals(s.gender, gender, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Student> GetStudentsByAge(int age)
        {
            return studentRepository.GetAll().Where(
                s => string.Equals(s.age.ToString(), age.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostStudent(Student student)
        {
            student = studentRepository.Add(student);
            var response = Request.CreateResponse<Student>(HttpStatusCode.Created, student);
            string uri = Url.Link("DefaultApi", new { id = student.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutStudent(int id, Student student)
        {
            student.id = id;
            if (!studentRepository.Update(student))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Student for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteProduct(int id)
        {
            studentRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}

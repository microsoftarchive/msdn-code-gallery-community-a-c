using Application.Models.StudentApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> items = new List<Student>();
        private int next = 1;
        public StudentRepository()
        {
            AddStudent(new Student { ID = 1, Name = "Chourouk", City = "Hammamet", Course = "Software engineering" });
            AddStudent(new Student { ID = 2, Name = "Khaled", City = "Gabes", Course = "Mobile development" });
            AddStudent(new Student { ID = 3, Name = "Sirine", City = "Nabeul", Course = "Medecine" });
            AddStudent(new Student { ID = 4, Name = "Israa", City = "Rades", Course = "Design" });
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return items;
        }

        public Student AddStudent(Student student)
        {
            if (items == null)
            {
                throw new ArgumentNullException("student");
            }

            student.ID = next++;
            items.Add(student);
            return student;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetailsServiceLayer.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        private int _nextId = 1;

        public StudentRepository()
        {
            Add(new Student { name = "Mike", id = 1, gender = "Male", age = 15 });
            Add(new Student { name = "Jacob", id = 2, gender = "Male", age = 14 });
            Add(new Student { name = "Robin", id = 3, gender = "Male", age = 15 });
            Add(new Student { name = "Adam", id = 4, gender = "Male", age = 15 });
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student Get(int id)
        {
            return students.Find(s => s.id == id);
        }

        public bool Add(Student student)
        {
            bool addResult = false;
            if (student == null)
            {
                return addResult;
            }
            int index = students.FindIndex(s => s.id == student.id);
            if (index == -1)
            {
                students.Add(student);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            students.RemoveAll(s => s.id == id);
        }

        public bool Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }
            int index = students.FindIndex(s => s.id == student.id);
            if (index == -1)
            {
                return false;
            }
            students.RemoveAt(index);
            students.Add(student);
            return true;
        }
    }
}
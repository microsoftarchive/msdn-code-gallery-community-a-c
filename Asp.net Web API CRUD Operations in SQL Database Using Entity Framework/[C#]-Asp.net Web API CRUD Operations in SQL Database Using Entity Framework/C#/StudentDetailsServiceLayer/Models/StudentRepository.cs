using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetailsServiceLayer.Models
{
    public class StudentRepository : IStudentRepository
    {
        StudentEntities studentEnties;
        public StudentRepository()
        {
            studentEnties = new StudentEntities();
        }

        public List<Table> GetAll()
        {
            return studentEnties.Tables.ToList();
        }

        public Table Get(int id)
        {
            var students = studentEnties.Tables.Where(x => x.Id == id);
            if (students.Count() > 0)
            {
                return students.Single();
            }
            else
            {
                return null;
            }
        }

        public Table Add(Table student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("item");
            }
            studentEnties.Tables.Add(student);
            studentEnties.SaveChanges();
            return student;
        }

        public void Remove(int id)
        {
            Table student = Get(id);
            if (student != null)
            {
                studentEnties.Tables.Remove(student);
                studentEnties.SaveChanges();
            }
        }

        public bool Update(Table student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            Table studentInDB = Get(student.Id);

            if (studentInDB == null)
            {
                return false;
            }

            studentEnties.Tables.Remove(studentInDB);
            studentEnties.SaveChanges();

            studentEnties.Tables.Add(student);
            studentEnties.SaveChanges();

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContosoUniversity.DAL;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",       HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",      HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",       HireDate = DateTime.Parse("2004-02-12") }
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), Administrator = instructors[0] },
                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), Administrator = instructors[1] },
                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), Administrator = instructors[2] },
                new Department { Name = "Economics",   Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), Administrator = instructors[3] }
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { CourseID = 1050, Title = "Chemistry",      Credits = 3, DepartmentID = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = 4 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = 4 },
                new Course { CourseID = 1045, Title = "Calculus",       Credits = 4, DepartmentID = 2 },
                new Course { CourseID = 3141, Title = "Trigonometry",   Credits = 4, DepartmentID = 2 },
                new Course { CourseID = 2021, Title = "Composition",    Credits = 3, DepartmentID = 1 },
                new Course { CourseID = 2042, Title = "Literature",     Credits = 4, DepartmentID = 1 }
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            courses[0].Instructors.Add(instructors[0]);
            courses[0].Instructors.Add(instructors[1]);
            courses[1].Instructors.Add(instructors[2]);
            courses[2].Instructors.Add(instructors[2]);
            courses[3].Instructors.Add(instructors[3]);
            courses[4].Instructors.Add(instructors[3]);
            courses[5].Instructors.Add(instructors[3]);
            courses[6].Instructors.Add(instructors[3]);
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { Student = students[0], CourseID = 1050, Grade = 1 },
                new Enrollment { Student = students[0], CourseID = 4022, Grade = 3 },
                new Enrollment { Student = students[0], CourseID = 4041, Grade = 1 },
                new Enrollment { Student = students[1], CourseID = 1045, Grade = 2 },
                new Enrollment { Student = students[2], CourseID = 3141, Grade = 4 },
                new Enrollment { Student = students[2], CourseID = 2021, Grade = 4 },
                new Enrollment { Student = students[3], CourseID = 1050 },
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { Instructor = instructors[0], Location = "Smith 17" },
                new OfficeAssignment { Instructor = instructors[1], Location = "Gowan 27" },
                new OfficeAssignment { Instructor = instructors[2], Location = "Thompson 304" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.Add(s));
            context.SaveChanges();
        }
    }
}
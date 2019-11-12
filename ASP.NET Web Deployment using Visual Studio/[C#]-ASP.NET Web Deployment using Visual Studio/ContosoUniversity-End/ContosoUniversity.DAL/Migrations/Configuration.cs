namespace ContosoUniversity.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11"), BirthDate = DateTime.Parse("1918-08-12"), OfficeAssignment = new OfficeAssignment { Location = "Smith 17" } },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",    HireDate = DateTime.Parse("2002-07-06"), BirthDate = DateTime.Parse("1960-03-15"), OfficeAssignment = new OfficeAssignment { Location = "Gowan 27" } },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",       HireDate = DateTime.Parse("1998-07-01"), BirthDate = DateTime.Parse("1970-01-11"), OfficeAssignment = new OfficeAssignment { Location = "Thompson 304" } },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",      HireDate = DateTime.Parse("2001-01-15"), BirthDate = DateTime.Parse("1975-04-11") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",       HireDate = DateTime.Parse("2004-02-12"), BirthDate = DateTime.Parse("1957-10-12") }
            }; 
            instructors.ForEach(s => context.Instructors.AddOrUpdate(i => i.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), PersonID = 1 },
                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), PersonID = 2 },
                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), PersonID = 3 },
                new Department { Name = "Economics",   Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), PersonID = 4 }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(d => d.Name, s));
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
            courses.ForEach(s => context.Courses.AddOrUpdate(s));
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
        }
    }
}

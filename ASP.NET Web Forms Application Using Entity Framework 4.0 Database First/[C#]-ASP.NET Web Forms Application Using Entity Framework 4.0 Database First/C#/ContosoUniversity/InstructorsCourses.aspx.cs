using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class InstructorsCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CourseAssignedLabel.Visible = false;
            CourseRemovedLabel.Visible = false;
        }

        protected void InstructorsDropDownList_DataBound(object sender, EventArgs e)
        {
            PopulateDropDownLists();
        }

        protected void InstructorsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDropDownLists();
        }

        protected void AssignCourseButton_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolEntities())
            {
                var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
                var instructor = (from p in context.People
                                  where p.PersonID == instructorID
                                  select p).First();
                var courseID = Convert.ToInt32(UnassignedCoursesDropDownList.SelectedValue);
                var course = (from c in context.Courses
                              where c.CourseID == courseID
                              select c).First();
                instructor.Courses.Add(course);
                try
                {
                    context.SaveChanges();
                    PopulateDropDownLists();
                    CourseAssignedLabel.Text = "Assignment successful.";
                }
                catch (Exception)
                {
                    CourseAssignedLabel.Text = "Assignment unsuccessful.";
                    //Add code to log the error. 
                }
                CourseAssignedLabel.Visible = true;
            }
        }

        protected void RemoveCourseButton_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolEntities())
            {
                var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
                var instructor = (from p in context.People
                                  where p.PersonID == instructorID
                                  select p).First();
                var courseID = Convert.ToInt32(AssignedCoursesDropDownList.SelectedValue);
                var courses = instructor.Courses;
                var courseToRemove = new Course();
                foreach (Course c in courses)
                {
                    if (c.CourseID == courseID)
                    {
                        courseToRemove = c;
                        break;
                    }
                }
                try
                {
                    courses.Remove(courseToRemove);
                    context.SaveChanges();
                    PopulateDropDownLists();
                    CourseRemovedLabel.Text = "Removal successful.";
                }
                catch (Exception)
                {
                    CourseRemovedLabel.Text = "Removal unsuccessful.";
                    //Add code to log the error. 
                }
                CourseRemovedLabel.Visible = true;
            }
        }

        private void PopulateDropDownLists()
        {
            using (var context = new SchoolEntities())
            {
                var allCourses = context.GetCourses().ToList();

                var instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue);
                var instructor = (from p in context.People.Include("Courses")
                                  where p.PersonID == instructorID
                                  select p).First();

                var assignedCourses = instructor.Courses.AsEnumerable();
                var unassignedCourses = allCourses.Except(assignedCourses.AsEnumerable()).ToList();
                
                UnassignedCoursesDropDownList.DataSource = unassignedCourses;
                UnassignedCoursesDropDownList.DataBind();
                UnassignedCoursesDropDownList.Visible = true;
                
                AssignedCoursesDropDownList.DataSource = assignedCourses;
                AssignedCoursesDropDownList.DataBind();
                AssignedCoursesDropDownList.Visible = true;
            }
        }
    }
}
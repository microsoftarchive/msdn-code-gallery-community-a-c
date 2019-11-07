using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class Instructors : System.Web.UI.Page
    {
        private TextBox instructorOfficeTextBox;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearStudentGradesDataSource();
            }
        }
        
        protected void InstructorsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void InstructorOfficeTextBox_Init(object sender, EventArgs e)
        {
            instructorOfficeTextBox = sender as TextBox;
        }

        protected void InstructorsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (var context = new SchoolEntities())
            {
                var instructorBeingUpdated = Convert.ToInt32(e.Keys[0]);
                var officeAssignment = (from o in context.OfficeAssignments
                                        where o.InstructorID == instructorBeingUpdated
                                        select o).FirstOrDefault();

                try
                {
                    if (String.IsNullOrWhiteSpace(instructorOfficeTextBox.Text) == false)
                    {
                        if (officeAssignment == null)
                        {
                            context.OfficeAssignments.AddObject(OfficeAssignment.CreateOfficeAssignment(instructorBeingUpdated, instructorOfficeTextBox.Text, null));
                        }
                        else
                        {
                            officeAssignment.Location = instructorOfficeTextBox.Text;
                        }
                    }
                    else
                    {
                        if (officeAssignment != null)
                        {
                            context.DeleteObject(officeAssignment);
                        }
                    }
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    ErrorMessageLabel.Visible = true;
                    ErrorMessageLabel.Text = "Update failed.";
                    //Add code to log the error. 
                }
            }
        }

        protected void CourseDetailsEntityDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
        {
            var course = e.Results.Cast<Course>().FirstOrDefault();
            if (course != null)
            {
                var studentGrades = course.StudentGrades.ToList();
                GradesListView.DataSource = studentGrades;
                GradesListView.DataBind();
            }
        }

        private void ClearStudentGradesDataSource()
        {
            var emptyStudentGradesList = new List<StudentGrade>();
            GradesListView.DataSource = emptyStudentGradesList;
            GradesListView.DataBind();
        }
    }
}
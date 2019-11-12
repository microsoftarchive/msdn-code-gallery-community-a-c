Public Class InstructorsCourses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CourseAssignedLabel.Visible = False
        CourseRemovedLabel.Visible = False
    End Sub

    Protected Sub InstructorsDropDownList_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles InstructorsDropDownList.DataBound
        PopulateDropDownLists()
    End Sub

    Protected Sub InstructorsDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InstructorsDropDownList.SelectedIndexChanged
        PopulateDropDownLists()
    End Sub

    Protected Sub AssignCourseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AssignCourseButton.Click
        Using context = New SchoolEntities()
            Dim instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue)
            Dim instructor = (
                From p In context.People
                Where p.PersonID = instructorID
                Select p).First()
            Dim courseID = Convert.ToInt32(UnassignedCoursesDropDownList.SelectedValue)
            Dim course = (
                From c In context.Courses
                Where c.CourseID = courseID
                Select c).First()
            instructor.Courses.Add(course)
            Try
                context.SaveChanges()
                PopulateDropDownLists()
                CourseAssignedLabel.Text = "Assignment successful."
            Catch e1 As Exception
                CourseAssignedLabel.Text = "Assignment unsuccessful."
                'Add code to log the error. 
            End Try
            CourseAssignedLabel.Visible = True
        End Using
    End Sub

    Protected Sub RemoveCourseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveCourseButton.Click
        Using context = New SchoolEntities()
            Dim instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue)
            Dim instructor = (
                From p In context.People
                Where p.PersonID = instructorID
                Select p).First()
            Dim courseID = Convert.ToInt32(AssignedCoursesDropDownList.SelectedValue)
            Dim courses = instructor.Courses
            Dim courseToRemove = New Course()
            For Each course In courses
                If course.CourseID = courseID Then
                    courseToRemove = course
                    Exit For
                End If
            Next course
            Try
                courses.Remove(courseToRemove)
                context.SaveChanges()
                PopulateDropDownLists()
                CourseRemovedLabel.Text = "Removal successful."
            Catch e1 As Exception
                CourseRemovedLabel.Text = "Removal unsuccessful."
                'Add code to log the error. 
            End Try
            CourseRemovedLabel.Visible = True
        End Using
    End Sub

    Private Sub PopulateDropDownLists()
        Using context = New SchoolEntities()
            Dim allCourses = context.GetCourses()

            Dim instructorID = Convert.ToInt32(InstructorsDropDownList.SelectedValue)
            Dim instructor = (
                From p In context.People.Include("Courses")
                Where p.PersonID = instructorID
                Select p).First()

            Dim assignedCourses = instructor.Courses.ToList()
            Dim unassignedCourses = allCourses.Except(assignedCourses.AsEnumerable()).ToList()

            UnassignedCoursesDropDownList.DataSource = unassignedCourses
            UnassignedCoursesDropDownList.DataBind()
            UnassignedCoursesDropDownList.Visible = True

            AssignedCoursesDropDownList.DataSource = assignedCourses
            AssignedCoursesDropDownList.DataBind()
            AssignedCoursesDropDownList.Visible = True
        End Using
    End Sub

End Class
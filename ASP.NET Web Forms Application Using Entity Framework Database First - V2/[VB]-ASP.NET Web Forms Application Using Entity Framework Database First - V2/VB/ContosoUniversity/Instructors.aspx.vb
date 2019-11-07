Public Class Instructors
    Inherits System.Web.UI.Page

    Private instructorOfficeTextBox As TextBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ClearStudentGradesDataSource()
        End If
    End Sub

    Protected Sub InstructorOfficeTextBox_Init(ByVal sender As Object, ByVal e As EventArgs)
        instructorOfficeTextBox = CType(sender, TextBox)
    End Sub

    Protected Sub InstructorsGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs) Handles InstructorsGridView.RowUpdating
        Using context = New SchoolEntities()
            Dim instructorBeingUpdated = Convert.ToInt32(e.Keys(0))
            Dim officeAssignment = (
                From o In context.OfficeAssignments
                Where o.InstructorID = instructorBeingUpdated
                Select o).FirstOrDefault()

            Try
                If String.IsNullOrWhiteSpace(instructorOfficeTextBox.Text) = False Then
                    If officeAssignment Is Nothing Then
                        context.OfficeAssignments.AddObject(officeAssignment.CreateOfficeAssignment(instructorBeingUpdated, instructorOfficeTextBox.Text, Nothing))
                    Else
                        officeAssignment.Location = instructorOfficeTextBox.Text
                    End If
                Else
                    If officeAssignment IsNot Nothing Then
                        context.DeleteObject(officeAssignment)
                    End If
                End If
                context.SaveChanges()
            Catch ex As Exception
                e.Cancel = True
                ErrorMessageLabel.Visible = True
                ErrorMessageLabel.Text = "Update failed."
                'Add code to log the error. 
            End Try
        End Using
    End Sub

    Protected Sub CourseDetailsEntityDataSource_Selected(ByVal sender As Object, ByVal e As EntityDataSourceSelectedEventArgs) Handles CourseDetailsEntityDataSource.Selected
        Dim course = e.Results.Cast(Of Course)().FirstOrDefault()
        If course IsNot Nothing Then
            Dim studentGrades = course.StudentGrades.ToList()
            GradesListView.DataSource = studentGrades
            GradesListView.DataBind()
        End If
    End Sub

    Private Sub ClearStudentGradesDataSource()
        Dim emptyStudentGradesList = New List(Of StudentGrade)()
        GradesListView.DataSource = emptyStudentGradesList
        GradesListView.DataBind()
    End Sub

End Class
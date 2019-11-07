Imports System.Text
Imports ContosoUniversity
Imports System.Collections.Generic

Namespace ContosoUniversity.Tests
	Friend Class MockSchoolRepository
        Implements IDisposable, ISchoolRepository

        Private departments As New List(Of Department)()
		Private instructors As New List(Of InstructorName)()
        Private officeAssignments As New List(Of OfficeAssignment)()

        Public Function GetOfficeAssignments(ByVal sortExpression As String) As IEnumerable(Of OfficeAssignment) Implements ISchoolRepository.GetOfficeAssignments
            Return officeAssignments
        End Function

        Public Sub InsertOfficeAssignment(ByVal officeAssignment As OfficeAssignment) Implements ISchoolRepository.InsertOfficeAssignment
            officeAssignments.Add(officeAssignment)
        End Sub

        Public Sub DeleteOfficeAssignment(ByVal officeAssignment As OfficeAssignment) Implements ISchoolRepository.DeleteOfficeAssignment
            officeAssignments.Remove(officeAssignment)
        End Sub

        Public Sub UpdateOfficeAssignment(ByVal officeAssignment As OfficeAssignment, ByVal origOfficeAssignment As OfficeAssignment) Implements ISchoolRepository.UpdateOfficeAssignment
            officeAssignments.Remove(origOfficeAssignment)
            officeAssignments.Add(officeAssignment)
        End Sub

        Public Function GetDepartments() As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartments
            Return departments
        End Function

        Public Function GetDepartments(ByVal sortExpression As String) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartments
            Return departments
        End Function

        Public Function GetDepartmentsByName(ByVal sortExpression As String, ByVal nameSearchString As String) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartmentsByName
            Return departments
        End Function

        Public Sub InsertDepartment(ByVal department As Department) Implements ISchoolRepository.InsertDepartment
            departments.Add(department)
        End Sub

        Public Sub DeleteDepartment(ByVal department As Department) Implements ISchoolRepository.DeleteDepartment
            departments.Remove(department)
        End Sub

        Public Sub UpdateDepartment(ByVal department As Department, ByVal origDepartment As Department) Implements ISchoolRepository.UpdateDepartment
            departments.Remove(origDepartment)
            departments.Add(department)
        End Sub

        Public Function GetInstructorNames() As IEnumerable(Of InstructorName) Implements ISchoolRepository.GetInstructorNames
            Return instructors
        End Function

        Public Function GetDepartmentsByAdministrator(ByVal administrator As Int32) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartmentsByAdministrator
            Return (
                From d In departments
                Where d.Administrator = administrator
                Select d)
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose

        End Sub
    End Class
End Namespace
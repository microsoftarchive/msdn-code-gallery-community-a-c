Public Interface ISchoolRepository
    Inherits IDisposable

    Function GetDepartments() As IEnumerable(Of Department)
    Function GetDepartments(ByVal sortExpression As String) As IEnumerable(Of Department)
    Function GetDepartmentsByName(ByVal sortExpression As String, ByVal nameSearchString As String) As IEnumerable(Of Department)
    Function GetDepartmentsByAdministrator(ByVal administrator As Int32) As IEnumerable(Of Department)
    Sub InsertDepartment(ByVal department As Department)
    Sub DeleteDepartment(ByVal department As Department)
    Sub UpdateDepartment(ByVal department As Department, ByVal origDepartment As Department)
    Function GetInstructorNames() As IEnumerable(Of InstructorName)
    Function GetOfficeAssignments(ByVal sortExpression As String) As IEnumerable(Of OfficeAssignment)
    Sub InsertOfficeAssignment(ByVal OfficeAssignment As OfficeAssignment)
    Sub DeleteOfficeAssignment(ByVal OfficeAssignment As OfficeAssignment)
    Sub UpdateOfficeAssignment(ByVal OfficeAssignment As OfficeAssignment, ByVal origOfficeAssignment As OfficeAssignment)
End Interface

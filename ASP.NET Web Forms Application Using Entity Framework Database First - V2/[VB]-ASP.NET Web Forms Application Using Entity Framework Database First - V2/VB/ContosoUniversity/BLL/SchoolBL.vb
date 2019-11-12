Public Class SchoolBL
    Private schoolRepository As ISchoolRepository

    Public Sub New()
        Me.schoolRepository = New SchoolRepository()
    End Sub

    Public Sub New(ByVal schoolRepository As ISchoolRepository)
        Me.schoolRepository = schoolRepository
    End Sub

    Public Function GetDepartments() As IEnumerable(Of Department)
        Return schoolRepository.GetDepartments()
    End Function

    Public Function GetDepartments(ByVal sortExpression As String) As IEnumerable(Of Department)
        Return schoolRepository.GetDepartments(sortExpression)
    End Function

    Public Function GetDepartmentsByName(ByVal sortExpression As String, ByVal nameSearchString As String) As IEnumerable(Of Department)
        Return schoolRepository.GetDepartmentsByName(sortExpression, nameSearchString)
    End Function

    Public Sub InsertDepartment(ByVal department As Department)
        ValidateOneAdministratorAssignmentPerInstructor(department)
        Try
            schoolRepository.InsertDepartment(department)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDepartment(ByVal department As Department)
        Try
            schoolRepository.DeleteDepartment(department)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDepartment(ByVal department As Department, ByVal origDepartment As Department)
        ValidateOneAdministratorAssignmentPerInstructor(department)
        Try
            schoolRepository.UpdateDepartment(department, origDepartment)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try

    End Sub

    Public Function GetInstructorNames() As IEnumerable(Of InstructorName)
        Return schoolRepository.GetInstructorNames()
    End Function

    Public Function GetOfficeAssignments(ByVal sortExpression As String) As IEnumerable(Of OfficeAssignment)
        If String.IsNullOrEmpty(sortExpression) Then
            sortExpression = "Person.LastName"
        End If
        Return schoolRepository.GetOfficeAssignments(sortExpression)
    End Function

    Public Sub InsertOfficeAssignment(ByVal officeAssignment As OfficeAssignment)
        Try
            schoolRepository.InsertOfficeAssignment(officeAssignment)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub DeleteOfficeAssignment(ByVal officeAssignment As OfficeAssignment)
        Try
            schoolRepository.DeleteOfficeAssignment(officeAssignment)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub UpdateOfficeAssignment(ByVal officeAssignment As OfficeAssignment, ByVal origOfficeAssignment As OfficeAssignment)
        Try
            schoolRepository.UpdateOfficeAssignment(officeAssignment, origOfficeAssignment)
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Private Sub ValidateOneAdministratorAssignmentPerInstructor(ByVal department As Department)
        If department.Administrator IsNot Nothing Then
            Dim duplicateDepartment = schoolRepository.GetDepartmentsByAdministrator(department.Administrator.GetValueOrDefault()).FirstOrDefault()
            If duplicateDepartment IsNot Nothing AndAlso duplicateDepartment.DepartmentID <> department.DepartmentID Then
                Throw New DuplicateAdministratorException(
                    String.Format("Instructor {0} {1} is already administrator of the {2} department.",
                                  duplicateDepartment.Person.FirstMidName,
                                  duplicateDepartment.Person.LastName,
                                  duplicateDepartment.Name))
            End If
        End If
    End Sub

    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                schoolRepository.Dispose()
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose()
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class

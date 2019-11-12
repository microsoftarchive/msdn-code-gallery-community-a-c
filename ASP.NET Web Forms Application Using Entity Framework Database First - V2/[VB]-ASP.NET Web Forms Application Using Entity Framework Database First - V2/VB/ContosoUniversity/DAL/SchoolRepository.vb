Imports System.Data.Objects


Public Class SchoolRepository
    Implements IDisposable, ISchoolRepository
    Private context As New SchoolEntities()

    Public Sub New()
        context.Departments.MergeOption = MergeOption.NoTracking
        context.InstructorNames.MergeOption = MergeOption.NoTracking
        context.OfficeAssignments.MergeOption = MergeOption.NoTracking
    End Sub

    Public Function GetDepartments() As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartments
        Return GetDepartments("")
    End Function

    Public Function GetDepartments(ByVal sortExpression As String) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartments
        If String.IsNullOrWhiteSpace(sortExpression) Then
            sortExpression = "Name"
        End If
        Return context.Departments.Include("Person").OrderBy("it." & sortExpression).ToList()
    End Function

    Public Function GetDepartmentsByName(ByVal sortExpression As String, ByVal nameSearchString As String) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartmentsByName
        If String.IsNullOrWhiteSpace(sortExpression) Then
            sortExpression = "Name"
        End If
        If String.IsNullOrWhiteSpace(nameSearchString) Then
            nameSearchString = ""
        End If
        'Return context.Departments.Include("Person").Include("Courses").OrderBy("it." & sortExpression).Where(Function(d) d.Name.Contains(nameSearchString)).ToList()

        'Dim departments = New ObjectQuery(Of Department)("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." & sortExpression).Include("Person").Include("Courses").Where(Function(d) d.Name.Contains(nameSearchString))
        'Dim commandText As String = CType(departments, ObjectQuery).ToTraceString()
        'Return departments.ToList()

        Dim departments = New ObjectQuery(Of Department)("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." & sortExpression).Where(Function(d) d.Name.Contains(nameSearchString)).ToList()
        For Each d As Department In departments
            d.Courses.Load()
            d.PersonReference.Load()
        Next
        Return departments
    End Function

    Public Function GetDepartmentsByAdministrator(ByVal administrator As Int32) As IEnumerable(Of Department) Implements ISchoolRepository.GetDepartmentsByAdministrator
        'Return New ObjectQuery(Of Department)("SELECT VALUE d FROM Departments as d", context, MergeOption.NoTracking).Include("Person").Where(Function(d) d.Administrator = administrator).ToList()
        Return context.CompiledDepartmentsByAdministratorQuery(administrator)
    End Function

    Public Sub InsertDepartment(ByVal department As Department) Implements ISchoolRepository.InsertDepartment
        Try
            department.DepartmentID = GenerateDepartmentID()
            context.Departments.AddObject(department)
            context.SaveChanges()
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDepartment(ByVal department As Department) Implements ISchoolRepository.DeleteDepartment
        Try
            context.Departments.Attach(department)
            context.Departments.DeleteObject(department)
            SaveChanges()
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDepartment(ByVal department As Department, ByVal origDepartment As Department) Implements ISchoolRepository.UpdateDepartment
        Try
            context.Departments.Attach(origDepartment)
            context.ApplyCurrentValues("Departments", department)
            SaveChanges()
        Catch ex As Exception
            'Include catch blocks for specific exceptions first, 
            'and handle or log the error as appropriate in each. 
            'Include a generic catch block like this one last. 
            Throw ex
        End Try
    End Sub

    Public Function GetInstructorNames() As IEnumerable(Of InstructorName) Implements ISchoolRepository.GetInstructorNames
        'Return context.InstructorNames.OrderBy("it.FullName").ToList()
        Return context.CompiledInstructorNamesQuery()
    End Function

    Private Function GenerateDepartmentID() As Int32
        Dim maxDepartmentID As Int32 = 0
        Dim department = (
            From d In GetDepartments()
            Order By d.DepartmentID Descending
            Select d).FirstOrDefault()
        If department IsNot Nothing Then
            maxDepartmentID = department.DepartmentID + 1
        End If
        Return maxDepartmentID
    End Function

    Public Function GetOfficeAssignments(ByVal sortExpression As String) As IEnumerable(Of OfficeAssignment) Implements ISchoolRepository.GetOfficeAssignments
        Return New ObjectQuery(Of OfficeAssignment)("SELECT VALUE o FROM OfficeAssignments AS o", context).Include("Person").OrderBy("it." & sortExpression).ToList()
    End Function

    Public Sub InsertOfficeAssignment(ByVal officeAssignment As OfficeAssignment) Implements ISchoolRepository.InsertOfficeAssignment
        context.OfficeAssignments.AddObject(officeAssignment)
        context.SaveChanges()
    End Sub

    Public Sub DeleteOfficeAssignment(ByVal officeAssignment As OfficeAssignment) Implements ISchoolRepository.DeleteOfficeAssignment
        context.OfficeAssignments.Attach(officeAssignment)
        context.OfficeAssignments.DeleteObject(officeAssignment)
        context.SaveChanges()
    End Sub

    Public Sub UpdateOfficeAssignment(ByVal officeAssignment As OfficeAssignment, ByVal origOfficeAssignment As OfficeAssignment) Implements ISchoolRepository.UpdateOfficeAssignment
        context.OfficeAssignments.Attach(origOfficeAssignment)
        context.ApplyCurrentValues("OfficeAssignments", officeAssignment)
        SaveChanges()
    End Sub

    Public Sub SaveChanges()
        Try
            context.SaveChanges()
        Catch ocex As OptimisticConcurrencyException
            context.Refresh(RefreshMode.StoreWins, ocex.StateEntries(0).Entity)
            Throw ocex
        End Try
    End Sub

    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                context.Dispose()
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class

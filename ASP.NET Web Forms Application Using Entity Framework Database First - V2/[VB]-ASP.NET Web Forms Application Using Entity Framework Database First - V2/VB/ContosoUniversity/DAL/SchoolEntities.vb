Imports System.Data.Objects

Partial Public Class SchoolEntities
    Private Shared ReadOnly compiledInstructorNamesQueryFunction As Func(Of SchoolEntities, IQueryable(Of InstructorName)) =
        CompiledQuery.Compile(Function(context As SchoolEntities) From i In context.InstructorNames Order By i.FullName Select i)

    Public Function CompiledInstructorNamesQuery() As IEnumerable(Of InstructorName)
        Return compiledInstructorNamesQueryFunction(Me).ToList()
    End Function


    Private Shared ReadOnly compiledDepartmentsByAdministratorQueryFunction As Func(Of SchoolEntities, Int32, IQueryable(Of Department)) =
        CompiledQuery.Compile(Function(context As SchoolEntities, administrator As Int32) From d In context.Departments.Include("Person") Where d.Administrator = administrator Select d)

    Public Function CompiledDepartmentsByAdministratorQuery(ByVal administrator As Int32) As IEnumerable(Of Department)
        Return compiledDepartmentsByAdministratorQueryFunction(Me, administrator).ToList()
    End Function
End Class

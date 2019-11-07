Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ContosoUniversity

Namespace ContosoUniversity.Tests
	''' <summary>
	''' Summary description for UnitTest1
	''' </summary>
	<TestClass>
	Public Class UnitTest1
		Public Sub New()
			'
			' TODO: Add constructor logic here
			'
		End Sub

		Private testContextInstance As TestContext

		''' <summary>
		'''Gets or sets the test context which provides
		'''information about and functionality for the current test run.
		'''</summary>
		Public Property TestContext() As TestContext
			Get
				Return testContextInstance
			End Get
			Set(ByVal value As TestContext)
				testContextInstance = value
			End Set
		End Property

		#Region "Additional test attributes"
		'
		' You can use the following additional attributes as you write your tests:
		'
		' Use ClassInitialize to run code before running the first test in the class
		' [ClassInitialize()]
		' public static void MyClassInitialize(TestContext testContext) { }
		'
		' Use ClassCleanup to run code after all tests in a class have run
		' [ClassCleanup()]
		' public static void MyClassCleanup() { }
		'
		' Use TestInitialize to run code before running each test 
		' [TestInitialize()]
		' public void MyTestInitialize() { }
		'
		' Use TestCleanup to run code after each test has run
		' [TestCleanup()]
		' public void MyTestCleanup() { }
		'
		#End Region

		Private Function CreateSchoolBL() As SchoolBL
			Dim schoolRepository = New MockSchoolRepository()
			Dim schoolBL = New SchoolBL(schoolRepository)
			schoolBL.InsertDepartment(New Department() With {.Name = "First Department", .DepartmentID = 0, .Administrator = 1, .Person = New Instructor () With {.FirstMidName = "Admin", .LastName = "One"}})
			schoolBL.InsertDepartment(New Department() With {.Name = "Second Department", .DepartmentID = 1, .Administrator = 2, .Person = New Instructor() With {.FirstMidName = "Admin", .LastName = "Two"}})
			schoolBL.InsertDepartment(New Department() With {.Name = "Third Department", .DepartmentID = 2, .Administrator = 3, .Person = New Instructor() With {.FirstMidName = "Admin", .LastName = "Three"}})
			Return schoolBL
		End Function

		<TestMethod, ExpectedException(GetType(DuplicateAdministratorException))>
		Public Sub AdministratorAssignmentRestrictionOnInsert()
			Dim schoolBL = CreateSchoolBL()
			schoolBL.InsertDepartment(New Department() With {.Name = "Fourth Department", .DepartmentID = 3, .Administrator = 2, .Person = New Instructor() With {.FirstMidName = "Admin", .LastName = "Two"}})
		End Sub

		<TestMethod, ExpectedException(GetType(DuplicateAdministratorException))>
		Public Sub AdministratorAssignmentRestrictionOnUpdate()
			Dim schoolBL = CreateSchoolBL()
			Dim origDepartment = (
			    From d In schoolBL.GetDepartments()
			    Where d.Name = "Second Department"
			    Select d).First()
			Dim department = (
			    From d In schoolBL.GetDepartments()
			    Where d.Name = "Second Department"
			    Select d).First()
			department.Administrator = 1
			schoolBL.UpdateDepartment(department, origDepartment)
		End Sub
	End Class
End Namespace

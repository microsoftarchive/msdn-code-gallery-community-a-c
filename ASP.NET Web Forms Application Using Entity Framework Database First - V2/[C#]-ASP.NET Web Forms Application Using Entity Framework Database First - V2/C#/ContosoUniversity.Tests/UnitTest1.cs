using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContosoUniversity.BLL;
using ContosoUniversity.DAL;

namespace ContosoUniversity.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private SchoolBL CreateSchoolBL()
        {
            var schoolRepository = new MockSchoolRepository();
            var schoolBL = new SchoolBL(schoolRepository);
            schoolBL.InsertDepartment(new Department() { Name = "First Department", DepartmentID = 0, Administrator = 1, Person = new Instructor () { FirstMidName = "Admin", LastName = "One" } });
            schoolBL.InsertDepartment(new Department() { Name = "Second Department", DepartmentID = 1, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
            schoolBL.InsertDepartment(new Department() { Name = "Third Department", DepartmentID = 2, Administrator = 3, Person = new Instructor() { FirstMidName = "Admin", LastName = "Three" } });
            return schoolBL;
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateAdministratorException))]
        public void AdministratorAssignmentRestrictionOnInsert()
        {
            var schoolBL = CreateSchoolBL();
            schoolBL.InsertDepartment(new Department() { Name = "Fourth Department", DepartmentID = 3, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateAdministratorException))]
        public void AdministratorAssignmentRestrictionOnUpdate()
        {
            var schoolBL = CreateSchoolBL();
            var origDepartment = (from d in schoolBL.GetDepartments()
                                  where d.Name == "Second Department"
                                  select d).First();
            var department = (from d in schoolBL.GetDepartments()
                              where d.Name == "Second Department"
                              select d).First();
            department.Administrator = 1;
            schoolBL.UpdateDepartment(department, origDepartment);
        }
    }
}

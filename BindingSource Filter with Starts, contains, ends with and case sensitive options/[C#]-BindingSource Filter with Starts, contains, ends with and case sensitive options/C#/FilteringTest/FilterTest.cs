using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operations;
using ExtensionLibrary;
using System.Windows.Forms;

namespace FilteringTest
{
    /// <summary>
    /// This test class sole purpose is to test functionality prior to placing them
    /// in use within a application.
    /// 
    /// Let's say you want specific functionality such as a field starts with in a 
    /// DataTable which is the data source of a BindingSource with the capability to
    /// do case sensitive and case insensitive filtering. We write the code, here the
    /// final code is in the Extensions library as language extensions. We create test
    /// such as below and while doing so run a SQL SELECT statement say in SQL-Server Management Studio,
    /// get the record count and validate that count against the count returned by the
    /// extension method. If they don't match then your code would need to alter to match to what
    /// you want. Once you have validated this they can be put to use in your application.
    /// </summary>
    [TestClass]
    public class FilterTest
    {
        /// <summary>
        /// Get all rows
        /// </summary>
        [TestMethod]
        public void ReturnAllRowsNoFiltering()
        {
            var ops = new DataOperations();
            var dt = ops.GetAll();
            Assert.IsTrue(dt.Rows.Count == 93,"Incorrect row count");            
        }
        [TestMethod]
        public void RowFitler_EqualsCaseSensitive()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilter("ContactTitle", "Owner", true);

            // assert
            Assert.IsTrue(bsContact.Count == 19, 
                "Expected 19 records");

        }
        /// <summary>
        /// This test will validate a new view can be created 
        /// along with a direct view on the data.
        /// </summary>
        [TestMethod]
        public void RowFitler_EqualsCaseSensitiveUsingNewView()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            var newView = bsContact.RowFilterNewView("ContactTitle", "Owner", true);

            // assert 1
            Assert.IsTrue(bsContact.Count == 19,
                "Expected 19 records");

            // act 2
            bsContact.RowFilter("ContactTitle", "Order Administrator", true);

            // assert 2
            Assert.IsTrue(bsContact.Count == 2,
                "Expected 2 records");



        }
        [TestMethod]
        public void RowFitler_EqualsCaseSensitive_DataDoesNotMeetCondition()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilter("ContactTitle", "owner", true);

            // assert
            Assert.IsTrue(bsContact.Count == 0, 
                "Expected 0 records");
        }
        /// <summary>
        /// Test to ensure the extension method HasData functions properly
        /// </summary>
        [TestMethod]
        public void BindingSource_HasData()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();

            // act
            bsContact.DataSource = ops.GetAll();

            // assert
            Assert.IsTrue(bsContact.HasData(), 
                "Expected data");
        }
        /// <summary>
        /// Expects the extension method HasData functions with no data
        /// </summary>
        [TestMethod]
        public void BindingSource_Has_No_Data()
        {
            var bsContact = new BindingSource();
            Assert.IsFalse(bsContact.HasData(), "Expected  nodata");
        }
        /// <summary>
        /// Get all contact names starting with An case sensitive
        /// </summary>
        [TestMethod]
        public void ContactNameStartsWith_CaseSensitive_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterStartsWith("ContactName", "An", true);           

            // assert
            Assert.IsTrue(bsContact.Count == 6, 
                "Expected six records");
        }
        /// <summary>
        /// Get all contact names starting with An case sensitive using an overload of RowFilter
        /// </summary>
        [TestMethod]
        public void ContactNameStartsWith_CaseSensitive_OverLoad_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilter("ContactName", "An", BindingSourceExtensions.FilterCondition.StartsWith, true);

            // assert
            Assert.IsTrue(bsContact.Count == 6, 
                "Expected six records");
        }
        /// <summary>
        /// Get all contact names starting with An case sensitive where
        /// in this case there are no records to match because we have
        /// the last parameter as true.
        /// </summary>
        [TestMethod]
        public void ContactNameStartsWith_CaseSensitive_Bad()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterStartsWith("ContactName", "an",true);
            
            // assert
            Assert.IsTrue(bsContact.Count == 0, 
                "Expected zero records");
        }
        /// <summary>
        /// Get all contact names that contain exactly Ro
        /// </summary>
        [TestMethod]
        public void ContactNameContains_CaseSensitive_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterContains("ContactName", "Ro", true);

            // assert
            Assert.IsTrue(bsContact.Count == 5, 
                "Expected five records");
        }
        /// <summary>
        /// Get all contact names that contain exactly Ro using RowFilter overload
        /// </summary>
        [TestMethod]
        public void ContactNameContains_CaseSensitive_OverLoad_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilter("ContactName", "Ro", BindingSourceExtensions.FilterCondition.Contains, true);

            // assert
            Assert.IsTrue(bsContact.Count == 5, 
                "Expected five records");
        }
        /// <summary>
        /// Get all contact names that contain ro where case sensitive will
        /// return a different count then above.
        /// </summary>
        [TestMethod]
        public void ContactNameContains_CaseSensitive_Bad()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterContains("ContactName", "ro", true);

            // assert
            Assert.IsTrue(bsContact.Count == 7, 
                "Expected 7 records");
        }
        [TestMethod]
        public void ContactTitleEndsWith_CaseSensitive_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterEndsWith("ContactTitle", "Manager", true);

            // assert
            Assert.IsTrue(bsContact.Count == 33, 
                "Expected 33 records");
        }
        [TestMethod]
        public void ContactTitleEndsWith_CaseSensitive_With_ApostropheEmbedded_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterEndsWith("CompanyName", "Bon app'", true);

            // assert
            Assert.IsTrue(bsContact.Count == 1,
                "Expected 33 records");
        }
        [TestMethod]
        public void ContactTitleEndsWith_CaseSensitive_OverLoad_Good()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilter("ContactTitle", "Manager", BindingSourceExtensions.FilterCondition.EndsWith, true);

            // assert
            Assert.IsTrue(bsContact.Count == 33, 
                "Expected 33 records");
        }
        [TestMethod]
        public void ContactTitleEndsWith_CaseSensitive_Bad()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterEndsWith("ContactTitle", "manager", true);

            // asert
            Assert.IsTrue(bsContact.Count == 0, 
                "Expected 0 records");
        }
        /// <summary>
        /// Here we expect to find ContactTitle ending with Manager exact, ContactTitle
        /// starting with Sales exact.
        /// 
        /// In a real app you would need to provide an user interface to build these conditions.
        /// </summary>
        [TestMethod]
        public void FreeForm_CaseSensitive_OnBoth_Conditions()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterFreeForm("ContactTitle LIKE '%Manager' OR ContactTitle LIKE 'Sales%'", true);

            // assert
            Assert.IsTrue(bsContact.Count == 62, 
                "Expected 62 records");
        }
        [TestMethod]
        public void FreeForm_CaseSensitive_OnAll()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterFreeForm("Country IN ('Argentina', 'Canada', 'UK')", true);

            // assert
            Assert.IsTrue(bsContact.Count == 13, 
                "Expected 13 records");
        }
        [TestMethod]
        public void FreeForm_CaseSensitive_OnAll_Bad()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act - Canada is missing the ending 'a'
            bsContact.RowFilterFreeForm("Country IN ('Argentina', 'Canad', 'UK')", true);

            // assert
            Assert.IsTrue(bsContact.Count == 10, 
                "Expected 10 records");
        }
        /// <summary>
        /// Deviation from above, note in the above test we had Sales case sensitive, here we kept case sensitive
        /// but asked for sales which does not match what is in the table.
        /// </summary>
        [TestMethod]
        public void FreeForm_CaseSensitive_OnBoth_Conditions_LastField_NotExact()
        {
            // arrange
            var bsContact = new BindingSource();
            var ops = new DataOperations();
            bsContact.DataSource = ops.GetAll();

            // act
            bsContact.RowFilterFreeForm("ContactTitle LIKE '%Manager' OR ContactTitle LIKE 'sales%'", true);

            // assert
            Assert.IsTrue(bsContact.Count == 33, "Expected 33 records");
        }
    }
}

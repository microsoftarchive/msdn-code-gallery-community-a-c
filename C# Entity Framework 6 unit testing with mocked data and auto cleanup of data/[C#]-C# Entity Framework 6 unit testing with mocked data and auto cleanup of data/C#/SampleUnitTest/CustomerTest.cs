using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityLibrary;
using System.Collections.Generic;
using System.Linq;

namespace SampleUnitTest
{

    [TestClass]
    public class CustomerTest : CustomerCreateData
    {
        [TestTraits(Trait.Customers)]
        [TestMethod()]
        public void Customers_Has_SalesRepresentatives()
        {

            // ARRANGE create a list of customers
            CreateMockData();

            // get back the customers from the database table
            IEnumerable<Customer> customers = GetSandboxEntities<Customer>();

            //ACT
            var anySaleRepresenative = customers.Any(cust => cust.ContactTitle == "Sales Representative");

            //ASSERT
            Assert.IsTrue(anySaleRepresenative, 
                "Expected to have some Sales Representative contacts");

        }
        [TestTraits(Trait.Customers)]
        [TestMethod()]
        public void LocateSpecificCustomerByContactNameAndContactTitle()
        {

            CreateMockData();

            var customers = GetSandboxEntities<Customer>();

            var result = (customers.Where(cust => cust.ContactName == "Christina Berglund" && cust.ContactTitle == "Order Administrator")).Count();

            Assert.AreEqual(1, result, 
                "Expected one customer");

        }
    }
}

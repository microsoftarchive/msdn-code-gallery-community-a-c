using System.Collections.Generic;
using EntityLibrary;

namespace SampleUnitTest
{
    public class CustomerCreateData : TestBase
    {
        public void CreateMockData()
        {
            AddSandboxEntities(CreateCustomers());
            DbContext.SaveChanges();
        }
        public List<Customer> CreateCustomers()
        {
            var customerList = new List<Customer>
            {
                new Customer
                {
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    ContactTitle = "Sales Representative"
                },
                new Customer
                {
                    CompanyName = "Ana Trujillo Emparedados y helados",
                    ContactName = "Ana Trujillo",
                    ContactTitle = "Owner"
                },
                new Customer
                {
                    CompanyName = "Antonio Moreno Taqueria",
                    ContactName = "Antonio Moreno",
                    ContactTitle = "Owner"
                },
                new Customer
                {
                    CompanyName = "Around the Horn",
                    ContactName = "Thomas Hardy",
                    ContactTitle = "Sales Representative"
                },
                new Customer
                {
                    CompanyName = "Berglunds snabbkop",
                    ContactName = "Christina Berglund",
                    ContactTitle = "Order Administrator"
                },
                new Customer
                {
                    CompanyName = "Blauer See Delikatessen",
                    ContactName = "Hanna Moos",
                    ContactTitle = "Sales Representative"
                },
                new Customer
                {
                    CompanyName = "France restauration",
                    ContactName = "Carine Schmitt",
                    ContactTitle = "Marketing Manager"
                },
                new Customer
                {
                    CompanyName = "Morgenstern Gesundkost",
                    ContactName = "Alexander Feuer",
                    ContactTitle = "Marketing Assistant"
                },
                new Customer
                {
                    CompanyName = "Simons bistro ",
                    ContactName = "Dominique Perrier",
                    ContactTitle = "Marketing Manager"
                },
                new Customer
                {
                    CompanyName = "Island Trading",
                    ContactName = "Helen Bennett",
                    ContactTitle = "Marketing Manager"
                }
            };


            return customerList;

        }

    }
}

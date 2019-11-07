using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

namespace EmployeeManagement.Data
{
    public class EmployeeMongo
    {
        public EmployeeMongo()
        {
        }

        public void GetAllEmployeeDetails()
        {

            EmployeeManagementMongoDB obj = new EmployeeManagementMongoDB();
            obj.GetAllEmployeeDetails();
            try
            {

                MongoClient client = new MongoClient("mongodb://localhost:27017");
                MongoServer server = client.GetServer();
                MongoDatabase test = server.GetDatabase("EmployeeManagement");

                var TestEmployees = test.GetCollection("TestEmployee");
                TestEmployees.Remove(Query.EQ("Name", "Balaji"));


            }
            catch (Exception ex)
            {
            }
        }

        ~EmployeeMongo()
        {
        }
    }

    public class TestEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

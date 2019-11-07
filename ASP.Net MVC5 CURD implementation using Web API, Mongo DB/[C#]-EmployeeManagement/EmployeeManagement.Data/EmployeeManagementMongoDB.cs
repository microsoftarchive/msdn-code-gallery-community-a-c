
using System;
using System.Collections.Generic;
using EmployeeManagement.SharedLibraries;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Configuration;

namespace EmployeeManagement.Data
{
    /// <summary>
    /// This class implementation used for communicate back-end for employee data's interaction, like to store, retrive, delete, update.
    /// </summary>
    public class EmployeeManagementMongoDB : IEmployeeManagement
    {
        MongoClient mongoClient;
        MongoServer mongoServer;
        MongoDatabase colEmployeeManagement;

        /// <summary>
        /// To establish connection, and get EmployeeManagement collection.
        /// </summary>
        public EmployeeManagementMongoDB()
        {
            string mongoServerConfig = Convert.ToString(ConfigurationManager.AppSettings["MONGO_SERVER"]);
            try
            {
                mongoClient = new MongoClient(mongoServerConfig);
                mongoServer = mongoClient.GetServer();
                colEmployeeManagement = mongoServer.GetDatabase("EmployeeManagement");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This method used to add new resource into backend.
        /// </summary>
        /// <param name="employeeData">Just JSON structure =>> {"AddressInfo":{"StreetName":" ------","Country":"********88","City":"######","PostalCode":"000-894","State":"######"},"BirthDate":"1986-05-06T00:00:00+05:30","Comments":"","DateHired":"1986-05-06T00:00:00+05:30","DepartmentID":1004,"Email":"abc@outlook.com","EmployeeID":123456,"Extension":2434,"FirstName":"AAAA","LastName":"ZZZZZ","SocialSecurityNumber":"jk12345","Title":"Engineer","Voice":"1234567890"}</param>
        /// <returns>If added successfully it return true or return false for unsuccess.</returns>
        public bool AddNewEmployee(IEmployee employeeData)
        {
            bool transactionStatus = false;
            try
            {
                var TestEmployees = colEmployeeManagement.GetCollection("EmployeeDetails");
                TestEmployees.Insert(new Employee
                {
                    AddressInfo = employeeData.AddressInfo,
                    BirthDate = employeeData.BirthDate,
                    Comments = employeeData.Comments,
                    DateHired = employeeData.DateHired,
                    DepartmentID = employeeData.DepartmentID,
                    Email = employeeData.Email,
                    EmployeeID = employeeData.EmployeeID,
                    Extension = employeeData.Extension,
                    FirstName = employeeData.FirstName,
                    LastName = employeeData.LastName,
                    SocialSecurityNumber = employeeData.SocialSecurityNumber,
                    Title = employeeData.Title,
                    Voice = employeeData.Voice
                });
                transactionStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transactionStatus;
        }

        /// <summary>
        /// Delete resource object in back end.
        /// </summary>
        /// <param name="EmployeeId">Employee Id</param>
        /// <returns>True : executed success</returns>
        public bool DeleteEmployee(int EmployeeId)
        {
            bool transactionStatus = false;
            try
            {
                var employeeDetails = colEmployeeManagement.GetCollection("EmployeeDetails");
                employeeDetails.Remove(Query.EQ("EmployeeID", EmployeeId));
                transactionStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transactionStatus;
        }

        /// <summary>
        /// This method used for update existing resource.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="employeeData">Posted Data  => {"AddressInfo":{"StreetName":" !!!!!!","Country":"@@@@@@@@","City":"#######","PostalCode":"099-08","State":"$$$$$"},"BirthDate":"1986-05-06T00:00:00+05:30","Comments":"","DateHired":"1986-05-06T00:00:00+05:30","DepartmentID":1004,"Email":"abc@outlook.com","EmployeeID":12345,"Extension":2434,"FirstName":"AAAA","LastName":"ZZZZZ","SocialSecurityNumber":"jk12345","Title":"Engineer","Voice":"1234567890"}</param>
        /// <returns>True : Success, False : failure.</returns>
        public bool EditEmployee(int id, IEmployee employeeData)
        {
            bool transactionStatus = false;
            DateTime baseDateValue = Convert.ToDateTime("1/1/001");
            try
            {
                var employeeDetails = colEmployeeManagement.GetCollection("EmployeeDetails");
                var employeeDetail = employeeDetails.FindOne(Query.EQ("EmployeeID", id));
                var oldAddress = employeeDetail["AddressInfo"];

                oldAddress["City"] = (employeeData.AddressInfo.City != null) ? employeeData.AddressInfo.City : oldAddress["City"];
                oldAddress["Country"] = (employeeData.AddressInfo.Country != null) ? employeeData.AddressInfo.Country : oldAddress["Country"];
                oldAddress["PostalCode"] = (employeeData.AddressInfo.PostalCode != null) ? employeeData.AddressInfo.PostalCode : oldAddress["PostalCode"];
                oldAddress["State"] = (employeeData.AddressInfo.State != null) ? employeeData.AddressInfo.State : oldAddress["State"];
                oldAddress["StreetName"] = (employeeData.AddressInfo.StreetName != null) ? employeeData.AddressInfo.StreetName : oldAddress["StreetName"];

                employeeDetail["AddressInfo"] = oldAddress;
                employeeDetail["BirthDate"] = (employeeData.BirthDate != null && employeeData.BirthDate != baseDateValue) ? employeeData.BirthDate : employeeDetail["BirthDate"];
                employeeDetail["Comments"] = (employeeData.Comments != null) ? employeeData.Comments : employeeDetail["Comments"];
                employeeDetail["DateHired"] = (employeeData.DateHired != null && employeeData.DateHired != baseDateValue) ? employeeData.DateHired : employeeDetail["DateHired"];
                employeeDetail["DepartmentID"] = (employeeData.DepartmentID != null) ? employeeData.DepartmentID : employeeDetail["DepartmentID"];
                employeeDetail["Email"] = (employeeData.Email != null) ? employeeData.Email : employeeDetail["Email"];
                employeeDetail["EmployeeID"] = (employeeData.EmployeeID != null) ? employeeData.EmployeeID : employeeDetail["EmployeeID"];
                employeeDetail["Extension"] = (employeeData.Extension != null) ? employeeData.Extension : employeeDetail["Extension"];
                employeeDetail["FirstName"] = (employeeData.FirstName != null) ? employeeData.FirstName : employeeDetail["FirstName"];
                employeeDetail["LastName"] = (employeeData.LastName != null) ? employeeData.LastName : employeeDetail["LastName"];
                employeeDetail["SocialSecurityNumber"] = (employeeData.SocialSecurityNumber != null) ? employeeData.SocialSecurityNumber : employeeDetail["SocialSecurityNumber"];
                employeeDetail["Title"] = (employeeData.Title != null) ? employeeData.Title : employeeDetail["Title"];
                employeeDetail["Voice"] = (employeeData.Voice != null) ? employeeData.Voice : employeeDetail["Voice"];
                employeeDetails.Save(employeeDetail);
                transactionStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transactionStatus;
        }

        /// <summary>
        /// To Get All Employee Detail in form of JSON structure.
        /// </summary>
        /// <returns>JSON are : {"AddressInfo":{"StreetName":" QQQQQQQQQQQ","Country":"IAN","City":"Comdi","PostalCode":"12345","State":"eeeeeee"},"BirthDate":"1986-05-06T00:00:00+05:30","Comments":"","DateHired":"1986-05-06T00:00:00+05:30","DepartmentID":1004,"Email":"abc@outlook.com","EmployeeID":123456,"Extension":2434,"FirstName":"AAAAAa","LastName":"ZZZZZZz","SocialSecurityNumber":"jk123456","Title":"Engineer","Voice":"1234567890"}</returns>
        public List<IEmployee> GetAllEmployeeDetails()
        {
            List<IEmployee> employeeCollection = new List<IEmployee>();
            try
            {
                var employeeDetails = colEmployeeManagement.GetCollection("EmployeeDetails");
                var result = employeeDetails.FindAll();
                foreach (var item in result)
                {
                    employeeCollection.Add(new Employee
                    {
                        AddressInfo = new Address { City = Convert.ToString(item["AddressInfo"]["City"]), Country = Convert.ToString(item["AddressInfo"]["Country"]), PostalCode = Convert.ToString(item["AddressInfo"]["PostalCode"]), State = Convert.ToString(item["AddressInfo"]["State"]), StreetName = Convert.ToString(item["AddressInfo"]["StreetName"]) },
                        BirthDate = Convert.ToDateTime(item["BirthDate"].ToString()),
                        Comments = Convert.ToString(item["Comments"]),
                        DateHired = Convert.ToDateTime(item["BirthDate"].ToString()),
                        DepartmentID = Convert.ToInt32(item["DepartmentID"]),
                        Email = Convert.ToString(item["Email"]),
                        EmployeeID = Convert.ToInt32(item["EmployeeID"]),
                        Extension = Convert.ToInt32(item["Extension"]),
                        FirstName = Convert.ToString(item["FirstName"]),
                        LastName = Convert.ToString(item["LastName"]),
                        SocialSecurityNumber = Convert.ToString(item["SocialSecurityNumber"]),
                        Title = Convert.ToString(item["Title"]),
                        Voice = Convert.ToString(item["Voice"])
                    });
                }
                //return employeeCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeCollection;
        }

        /// <summary>
        /// This function used for get single resource.
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>{"AddressInfo":{"StreetName":" QQQQQQQQQQQ","Country":"IAN","City":"Comdi","PostalCode":"12345","State":"eeeeeee"},"BirthDate":"1986-05-06T00:00:00+05:30","Comments":"","DateHired":"1986-05-06T00:00:00+05:30","DepartmentID":1004,"Email":"abc@outlook.com","EmployeeID":123456,"Extension":2434,"FirstName":"AAAAAa","LastName":"ZZZZZZz","SocialSecurityNumber":"jk123456","Title":"Engineer","Voice":"1234567890"}</returns>
        public IEmployee GetEmployeeDetail(int employeeId)
        {
            IEmployee employeeCollection;
            try
            {
                var employeeDetails = colEmployeeManagement.GetCollection("EmployeeDetails");
                var item = employeeDetails.FindOne(Query.EQ("EmployeeID", employeeId));
                employeeCollection = new Employee()
                {
                    AddressInfo = new Address { City = Convert.ToString(item["AddressInfo"]["City"]), Country = Convert.ToString(item["AddressInfo"]["Country"]), PostalCode = Convert.ToString(item["AddressInfo"]["PostalCode"]), State = Convert.ToString(item["AddressInfo"]["State"]), StreetName = Convert.ToString(item["AddressInfo"]["StreetName"]) },
                    BirthDate = Convert.ToDateTime(item["BirthDate"].ToString()),
                    Comments = Convert.ToString(item["Comments"]),
                    DateHired = Convert.ToDateTime(item["BirthDate"].ToString()),
                    DepartmentID = Convert.ToInt32(item["DepartmentID"]),
                    Email = Convert.ToString(item["Email"]),
                    EmployeeID = Convert.ToInt32(item["EmployeeID"]),
                    Extension = Convert.ToInt32(item["Extension"]),
                    FirstName = Convert.ToString(item["FirstName"]),
                    LastName = Convert.ToString(item["LastName"]),
                    SocialSecurityNumber = Convert.ToString(item["SocialSecurityNumber"]),
                    Title = Convert.ToString(item["Title"]),
                    Voice = Convert.ToString(item["Voice"])
                };
                return employeeCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

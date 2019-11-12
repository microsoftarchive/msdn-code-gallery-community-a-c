
using EmployeeManagement.SharedLibraries;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;


namespace EmployeeManagement.Core
{
    public class ServiceConsumer
    {
        private static string apiURL = string.Empty;

        static ServiceConsumer()
        {
            apiURL = Convert.ToString( ConfigurationManager.AppSettings["EMPLOYEEMANAGEMENT_API"]);
        }
        public IEnumerable<Employee> GetAllEmployeeData()
        {
            IEnumerable<Employee> employee = new List<Employee>();

            try
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("api/values").Result;
                    //This method throws an exception if the HTTP response status is an error code.
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            employee = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    return employee;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return employee;
        }

        public async Task<IEmployee> GetEmployee(int empId)
        {
            IEmployee empDetails = new Employee();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/values/" + empId);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        empDetails = await response.Content.ReadAsAsync<Employee>();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return empDetails;
        }

        public bool AddNewEmployee(IEmployee empData)
        {
            bool status = false;
            try
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //string aaa = @"{""AddressInfo"":{""StreetName"":"" QQQQQQQQQQQ = "",""Country"":""IAN"",""City"":""Comdi"",""PostalCode"":""12345"",""State"":""eeeeeee""},""BirthDate"":""1986-06-05"",""Comments"":"" ccccccccccccc"",""DateHired"":""1986-06-05"",""DepartmentID"":null,""Email"":""abc@outlook.com"",""Extension"":""2434"",""FirstName"":""AAAAAa"",""LastName"":""ZZZZZZz"",""SocialSecurityNumber"":""jk123456"",""Title"":""Engineer"",""Voice"":""ZZZZZZz""}";
                    string aaa = JsonConvert.SerializeObject(empData);


                    HttpContent putContent = new StringContent(aaa, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("api/values/", putContent).Result;
                    //This method throws an exception if the HTTP response status is an error code.
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            status = true;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public bool EditEmployeeDetails(int empId, IEmployee empData)
        {
            bool status = false;

            try
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //string aaa = @"{""AddressInfo"":{""StreetName"":"" QQQQQQQQQQQ = "",""Country"":""IAN"",""City"":""Comdi"",""PostalCode"":""12345"",""State"":""eeeeeee""},""BirthDate"":""1986-06-05"",""Comments"":"" ccccccccccccc"",""DateHired"":""1986-06-05"",""DepartmentID"":null,""Email"":""abc@outlook.com"",""Extension"":""2434"",""FirstName"":""AAAAAa"",""LastName"":""ZZZZZZz"",""SocialSecurityNumber"":""jk123456"",""Title"":""Engineer"",""Voice"":""ZZZZZZz""}";
                    string aaa =  JsonConvert.SerializeObject(empData);


                    HttpContent putContent = new StringContent(aaa, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("api/values/" + empId, putContent).Result;
                    //This method throws an exception if the HTTP response status is an error code.
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            status = true;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public bool DeleteEmployee(int empId)
        {
            bool status = false;
            try
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.DeleteAsync("api/values/" + empId ).Result;
                    //This method throws an exception if the HTTP response status is an error code.
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            status = true;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public void test()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = client.GetAsync("api/values").Result;
                //This method throws an exception if the HTTP response status is an error code.
                resp.EnsureSuccessStatusCode();
                var books = resp.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            }
            catch(Exception ex)
            {

            }

        }
    }
}

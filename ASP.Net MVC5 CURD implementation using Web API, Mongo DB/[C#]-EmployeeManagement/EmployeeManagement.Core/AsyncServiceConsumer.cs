
using EmployeeManagement.SharedLibraries;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;


namespace EmployeeManagement.Core
{
    public static class AsyncServiceConsumer
    {
        private static string apiURL = @"http://10.187.144.30/EmployeeManagementService/";

        static AsyncServiceConsumer()
        {
            apiURL = ConfigurationManager.AppSettings["employeeServiceEndpoint"];
        }
        public static async Task<IEnumerable<Employee>> GetAllEmployeeData()
        {
            IEnumerable<Employee> employee = new List<Employee>();
            IList<Employee> emp = new List<Employee>();
            emp.Add(new Employee { });
            try
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/values");
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            employee = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
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

        public static async Task<IEmployee> GetEmployee(int empId)
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

        public static async Task<bool> AddNewEmployee(IEmployee empData)
        {
            bool status = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/values/", empData);
                    if (response.IsSuccessStatusCode)
                    {
                        status = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return status;
        }

        public static async Task<bool> EditEmployeeDetails(int empId, IEmployee empData)
        {
            bool status = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/values/" + empId, empData);
                    if (response.IsSuccessStatusCode)
                    {
                        status = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return status;
        }

        public static async Task<bool> DeleteEmployee(int empId)
        {
            bool status = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync("api/values/" + empId);
                    if (response.IsSuccessStatusCode && response.StatusCode.Equals("204"))
                    {
                        status = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return status;
        }
    }
}

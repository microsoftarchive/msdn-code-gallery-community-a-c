/*
    Project Name    : Employee Management

    Date            : 03/01/2015
*/

using EmployeeManagement.Data;
using EmployeeManagement.SharedLibraries;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Services.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        IEmployeeManagement employeeDataAccess = new EmployeeManagementMongoDB();
        // GET api/values
        public IList<IEmployee> Get()
        {
            try
            {
                var employee = employeeDataAccess.GetAllEmployeeDetails();
                if (employee == null)
                {
                    throw new Exception();
                }
                return employee;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Requested collection may be empty or Null")),
                    StatusCode = HttpStatusCode.NotFound,
                    ReasonPhrase = "Requested collection may be empty or Null"
                };
                throw new HttpResponseException(resp);
            }
        }

        // GET api/values/5
        public IEmployee Get(int id)
        {
            try
            {
                var employee = employeeDataAccess.GetEmployeeDetail(id);
                if (employee == null)
                {
                    throw new Exception();
                }
                return employee;
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Requested collection may be empty or Null")),
                    StatusCode = HttpStatusCode.NotFound,
                    ReasonPhrase = "Requested collection may be empty or Null"
                };
                throw new HttpResponseException(resp);
            }
        }

        // POST api/values
        public void Post(Employee value)
        {
            try
            {
                if (!employeeDataAccess.AddNewEmployee(value))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Unable to process this request, due to some internal error")),
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Unable to process this request, due to some internal error"
                };
                throw new HttpResponseException(resp);
            }

        }

        // PUT api/values/5
        public void Put(int id, Employee value)
        {
            try
            {
                if (!employeeDataAccess.EditEmployee(id, value))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Unable to process this request, due to some internal error")),
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Unable to process this request, due to some internal error"
                };
                throw new HttpResponseException(resp);
            }

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            try
            {
                if (!employeeDataAccess.DeleteEmployee(id))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("Unable to process this request, due to some internal error")),
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Unable to process this request, due to some internal error"
                };
                throw new HttpResponseException(resp);
            }

        }
    }
}

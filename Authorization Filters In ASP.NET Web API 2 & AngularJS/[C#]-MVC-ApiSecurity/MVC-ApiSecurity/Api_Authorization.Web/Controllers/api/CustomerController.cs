using Api_Authorization.Business.CustomerFactory;
using Api_Authorization.Models;
using Api_Authorization.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Authorization.Web.Controllers.api
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private CustomersMgt objCust = null;

        //Get
        [BasicAuthorization, HttpGet, Route("GetCustomers/{pageNumber:int}/{pageSize:int}")]
        public IHttpActionResult GetCustomers(int pageNumber, int pageSize)
        {
            objCust = new CustomersMgt();
            return Json(objCust.GetCustomer(pageNumber, pageSize));
        }

        //Post
        [BasicAuthorization, HttpPost, Route("SaveCustomer")]
        public IHttpActionResult SaveCustomer(Customer model)
        {
            objCust = new CustomersMgt();
            return Json(objCust.SaveCustomer(model));
        }

        //Put
        [BasicAuthorization, HttpPut, Route("UpdateCustomer")]
        public IHttpActionResult UpdateCustomer(Customer model)
        {
            objCust = new CustomersMgt();
            return Json(objCust.UpdateCustomer(model));
        }

        //Delete
        [BasicAuthorization, HttpDelete, Route("DeleteCustomer/{CustomerID:int}")]
        public IHttpActionResult DeleteCustomer(int CustomerID)
        {
            objCust = new CustomersMgt();
            return Json(objCust.DeleteCustomer(CustomerID));
        }
    }
}

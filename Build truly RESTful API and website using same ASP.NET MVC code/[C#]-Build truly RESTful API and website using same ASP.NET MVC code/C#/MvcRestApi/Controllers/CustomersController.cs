using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestApi.Models;
using Microsoft.Web.Mvc;
using MvpRestApiLib;
using System.Web.UI;

namespace MvcRestApi.Controllers
{
    public class CustomersController : Controller
    {
        // Controller supports the following URL
        // /Customers/{customerId}/Orders/{orderId}

        private CustomerModel GetModel()
        {
            var customerModel = base.HttpContext.Cache["CustomerModel"] as CustomerModel;
            if (customerModel == null)
            {
                customerModel = new CustomerModel();
                base.HttpContext.Cache["CustomerModel"] = customerModel;
            }
            return customerModel;
        }

        // GET /Customers
        // Return all customers.
        [EnableJson, EnableXml]
        [HttpGet, OutputCache(NoStore=true, Location=OutputCacheLocation.None)]        
        public ActionResult Index(string verb)
        {
            if (verb == "New")
                return View("NewCustomer", new Customer());
            else
                return View(GetModel().Customers);
        }

        // POST /Customers
        // Add a new customer.
        [EnableJson, EnableXml]
        [HttpPost, OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
        [ActionName("Index")]
        public ActionResult AddNewCustomer(Customer newCustomer)
        {
            List<Customer> customers = new List<Customer>(GetModel().Customers);
            newCustomer.CustomerId = "CUS" + customers.Count.ToString("0000");
            customers.Add(newCustomer);
            GetModel().Customers = customers;

            return RedirectToAction("SingleCustomer", new { customerId = newCustomer.CustomerId });
        }

        // GET /Customers/CUS0001
        // Return a single customer data.
        [EnableJson, EnableXml]
        [HttpGet, OutputCache(NoStore = true, Location = OutputCacheLocation.None)]        
        public ActionResult SingleCustomer(string customerId)
        {
            var customer = GetModel().Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
                return new HttpNotFoundResult("Customer with ID: " + customerId + " not found");
            
            return View("SingleCustomer", customer);
        }

        // DELETE /Customers/CUS0001
        // Delete a single customer.
        [EnableJson, EnableXml]
        [HttpDelete]
        [ActionName("SingleCustomer")]
        public ActionResult SingleCustomerDelete(string customerId)
        {
            List<Customer> customers = new List<Customer>(GetModel().Customers);
            customers.Remove(customers.Find(c => c.CustomerId == customerId));
            GetModel().Customers = customers;
            return RedirectToAction("Index", "Customers");
        }

        // POST /Customers/CUS0001(?verb=Delete)
        // Update/Delete a single customer
        [HttpPost]
        [EnableJson, EnableXml]
        public ActionResult SingleCustomer(Customer changeCustomer, string customerId, string verb)
        {
            if (verb == "Delete")
            {
                return SingleCustomerDelete(customerId);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var existingCustomer = GetModel().Customers.First(c => c.CustomerId == customerId);
                    existingCustomer.Name = changeCustomer.Name;
                    existingCustomer.Country = changeCustomer.Country;

                    ViewData["Message"] = "Saved";
                    return SingleCustomer(customerId);
                }
                else
                {
                    throw new ApplicationException("Invalid model state");
                }
            }            
        }

        // GET /Customers/CUS0001/Orders(/ORD0001)
        // Return customer orders. If orderId specified, then return a single order.
        [EnableJson, EnableXml]        
        [HttpGet, OutputCache(NoStore = true, Location = OutputCacheLocation.None)]        
        public ActionResult SingleCustomerOrders(string customerId, string orderId)
        {
            if (!string.IsNullOrEmpty(orderId))
                return View("SingleCustomerSingleOrder", GetModel()
                    .Customers.First(c => c.CustomerId == customerId)
                    .Orders.First(o => o.OrderId == orderId));
            else
                return View("SingleCustomerOrders", GetModel()
                    .Customers.First(c => c.CustomerId == customerId)
                    .Orders);

        }

        // POST /Customers/CUS0001/Orders/ORD0001(?verb=Delete)
        // Update/Delete a single order.
        [HttpPost]
        [EnableJson, EnableXml]
        public ActionResult SingleCustomerOrders(Order changedOrder, string customerId, string orderId, string verb)
        {
            if (verb == "Delete")
            {
                var customer = GetModel().Customers.First(c => c.CustomerId == customerId);
                List<Order> orders = new List<Order>(customer.Orders);
                orders.Remove(orders.Find(o => o.OrderId == orderId));
                customer.Orders = orders;
                return RedirectToAction("SingleCustomer", "Customers", new { customerId = customerId });
            }            
            else 
            {
                if (ModelState.IsValid)
                {
                    var existingOrder = GetModel().Customers.First(c => c.CustomerId == customerId)
                        .Orders.First(o => o.OrderId == orderId);
                    existingOrder.ProductName = changedOrder.ProductName;
                    existingOrder.ProductPrice = changedOrder.ProductPrice;
                    existingOrder.ProductQuantity = changedOrder.ProductQuantity;

                    ViewData["Message"] = "Saved";
                    return SingleCustomerOrders(customerId, orderId);
                }
                else
                {
                    throw new ApplicationException("Invalid model state");
                }
            }            
        }

        
    }
}

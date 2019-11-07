using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMgrMvc.Models;

namespace EmployeeMgrMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            northwndEntities nw = new northwndEntities();
            return View(nw.Employees);
        }

        public ActionResult Details(int id)
        {
            return View(GetEmployee(id));
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                northwndEntities nw = new northwndEntities();
                nw.AddToEmployees(emp);
                nw.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        
        public ActionResult Edit(int id)
        {
            return View(GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                northwndEntities nw = new northwndEntities();
                Employee origEmp = GetEmployee(emp.EmployeeID);
                nw.Employees.Attach(emp);
                nw.ApplyOriginalValues("Employees", origEmp);
                nw.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        [NonAction]
        private Employee GetEmployee(int id)
        {
            northwndEntities nw = new northwndEntities();
            var empQuery = from e in nw.Employees
                           where e.EmployeeID == id
                           select e;
            Employee emp = empQuery.FirstOrDefault();
            return emp;
        }
    }
}

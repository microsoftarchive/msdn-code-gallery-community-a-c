using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NtierMvc.BusinessLogic;
using NtierMvc.Common;
using NtierMvc.Model;

namespace NtierMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private LoggingHandler _loggingHandler;

        public EmployeesController()
        {
            _loggingHandler = new LoggingHandler();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_loggingHandler != null)
                {
                    _loggingHandler.Dispose();
                    _loggingHandler = null;
                }
            }

            base.Dispose(disposing);
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                InsertEmployee(int.Parse(collection["Id"]),
                                collection["Name"],
                                int.Parse(collection["Age"]),
                                collection["HiringDate"].Trim().Length == 0
                                ? (DateTime?)null
                                : DateTime.ParseExact(collection["HiringDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                                decimal.Parse(collection["GrossSalary"]));

                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var employee = SelectEmployeeById(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                UpdateEmployee(int.Parse(collection["Id"]),
                                collection["Name"],
                                int.Parse(collection["Age"]),
                                collection["HiringDate"].Trim().Length == 0
                                ? (DateTime?)null
                                : DateTime.ParseExact(collection["HiringDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                                decimal.Parse(collection["GrossSalary"]));

                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DeleteEmployee(id);

                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListAll");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListAll()
        {
            try
            {
                var employees = from e in ListAllEmployees()
                                orderby e.Id
                                select e;
                return View(employees);
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        #region Private Methods

        private List<EmployeesEntity> ListAllEmployees()
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    return employees.SelectAllEmployees();
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
            return null;
        }

        private EmployeesEntity SelectEmployeeById(int id)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    return employees.SelectEmployeeById(id);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
            return null;
        }

        private void InsertEmployee(int id, string name, int age, DateTime? hiringDate, decimal grossSalary)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    var entity = new EmployeesEntity();
                    entity.Id = id;
                    entity.Name = name;
                    entity.Age = age;
                    entity.HiringDate = hiringDate;
                    entity.GrossSalary = grossSalary;
                    var opSuccessful = employees.InsertEmployee(entity);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }

        private void UpdateEmployee(int id, string name, int age, DateTime? hiringDate, decimal grossSalary)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    var entity = new EmployeesEntity();
                    entity.Id = id;
                    entity.Name = name;
                    entity.Age = age;
                    entity.HiringDate = hiringDate;
                    entity.GrossSalary = grossSalary;
                    var opSuccessful = employees.UpdateEmployee(entity);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }

        private void DeleteEmployee(int id)
        {
            try
            {
                using (var employees = new EmployeesBusiness())
                {
                    var opSuccessful = employees.DeleteEmployeeById(id);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }


        #endregion

    }
}



using System.Web.Mvc;
using EmployeeManagement.SharedLibraries;
using EmployeeManagement.Web.BusinessCommunication;
using EmployeeManagement.Core;

namespace EmployeeManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewEmployee(Employee postedEmployee)
        {
            IEmployeeService serviceContext = new EmployeeService();
            var temp = serviceContext.AddNewEmployee(postedEmployee);
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee postedEmployee, int employeeId)
        {
            IEmployeeService serviceContext = new EmployeeService();
            var temp = serviceContext.UpdateEmployeeInformation(postedEmployee, employeeId);
            return Json(temp, JsonRequestBehavior.AllowGet);

            //return Json(new { response = "Success", status = "true" });
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int empId)
        {
            IEmployeeService serviceContext = new EmployeeService();
            var temp = serviceContext.DeleteEmployee(empId);
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllEmployeeList()
        {
            //EmployeeManagementServiceAccess obj = new EmployeeManagementServiceAccess(); //var items = obj.GetAllEmployeeDetails();
            IEmployeeService serviceContext = new EmployeeService();
            var temp = serviceContext.GetAllEmployeeCollection();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        public static void test()
        {
            EmployeeManagementServiceAccess obj = new EmployeeManagementServiceAccess();

            var items = obj.GetAllEmployeeDetails();
        }
    }
}
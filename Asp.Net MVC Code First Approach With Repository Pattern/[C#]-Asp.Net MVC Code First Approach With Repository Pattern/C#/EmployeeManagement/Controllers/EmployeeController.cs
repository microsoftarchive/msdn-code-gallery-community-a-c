using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private IRepository<Employee> _repository = null;
        public EmployeeController()
        {
            this._repository = new Repository<Employee>();
        }

        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }


        public ActionResult Edit(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        public ActionResult Details(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }
        public ActionResult Delete(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var employee = _repository.GetById(Id);
            _repository.Delete(Id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}

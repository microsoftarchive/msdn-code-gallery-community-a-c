using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;     
using AlwaysNote.Models;
      
namespace AlwaysNote.Controllers
{
    public class CustomerInputModel
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public int ID { get; set; }
        public string Key { get; set; }
    }
      
    public class CustomerViewModel
    {
        public string ID { get; set; }
        public string Key { get; set; }
    }
      
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Save(CustomerInputModel model)
        {
            CustomerRepository repository =
                        new CustomerRepository();
      
            int id = 0;
      
            if (model.ID > 0)
            {
                id = model.ID;
                repository.Update(id, model.Name, model.Note);
            }
            else
            {
                id = repository.Add(model.Name, model.Note);
            }
      
            CustomerViewModel vm = new CustomerViewModel();
            vm.ID = id.ToString();
            vm.Key = model.Key;
      
            return Json(vm);
        }
      
    }
}
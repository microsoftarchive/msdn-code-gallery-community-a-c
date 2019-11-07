using PDM.IRepository;
using PDM.Model;
using PDM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDM.Web.Controllers
{
    public class ProductModelController : Controller
    {
        private IRepositoryBase<ProductModel> repository = new ProductModelRepository();
        public ActionResult Index()
        {
            ProductModel model = new ProductModel();
            model.ProductModelCollection = repository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Create(model);
            }
            return RedirectToAction("List");
        }

        public PartialViewResult List()
        {
            return PartialView(repository.GetAll().ToList());
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = repository.GetByID(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
            }
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var model = repository.GetByID(id);
            return PartialView(model);
        }

        public ActionResult Delete(int id)
        {
            var model = repository.GetByID(id);
            return PartialView(model);
        }


        [HttpPost]
        public ActionResult Delete(ProductModel model)
        {
            repository.Delete(model.ProductModelID);
            return RedirectToAction("List");
        }

        public PartialViewResult Search(string name)
        {
            var result = repository.SearchByName(name).ToList();
            return PartialView("List", result);
        }

        public JsonResult CheckDuplicate(string name)
        {
            var item = repository.GetAll().Where(x => x.Name == name).Select(y => y.Name).FirstOrDefault();

            if (string.IsNullOrEmpty(item)) //test if the value of SourceDirectory is valid
            {
                return Json(true, JsonRequestBehavior.AllowGet); // indicates its valid
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet); // indicates its not valid
            }
        }
    }
}
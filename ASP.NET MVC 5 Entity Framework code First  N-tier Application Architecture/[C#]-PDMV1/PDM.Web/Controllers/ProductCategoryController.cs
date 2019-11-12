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
    public class ProductCategoryController : Controller
    {
        private IRepositoryBase<ProductCategory> repository = new ProductCategoryRepository();
        public ActionResult Index()
        {
            ProductCategory category = new ProductCategory();
            category.ProductCategoryCollection = repository.GetAll().ToList();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            repository.Create(category);
            return RedirectToAction("List");
        }

        public PartialViewResult List()
        {
            return PartialView(repository.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.GetByID(id);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            repository.Update(category);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var catgory = repository.GetByID(id);
            return PartialView(catgory);
        }

        public ActionResult Delete(int id)
        {
            var catgory = repository.GetByID(id);
            return PartialView(catgory);
        }

        [HttpPost]
        public ActionResult Delete(ProductCategory category)
        {
            repository.Delete(category.ProductCategoryID);
            return RedirectToAction("List");
        }

        public PartialViewResult Search(string name)
        {
            var result = (repository.GetAll().Where(x => x.Name == name).ToList());
            return PartialView("List", result);
        }
        public JsonResult CheckDuplicate(string name)
        {
            var item = (repository.GetAll().Where(x => x.Name == name).Select(y => y.Name).FirstOrDefault());

            if (string.IsNullOrEmpty(item))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
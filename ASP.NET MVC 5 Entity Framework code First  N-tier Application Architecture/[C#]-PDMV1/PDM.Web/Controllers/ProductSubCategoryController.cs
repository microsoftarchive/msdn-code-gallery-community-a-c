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
    public class ProductSubCategoryController : Controller
    {
        private IRepositoryBase<ProductSubCategory> repository = new ProductSubCategoryRepository();

        public ActionResult Index()
        {
            ProductSubCategory category = new ProductSubCategory();
            category.ProductSubCategoryCollection = repository.GetAll().OrderByDescending(x => x.ModifiedDate).ToList();
            IRepositoryBase<ProductCategory> repositoryCategory = new ProductCategoryRepository();
            category.ProductCategoryCollection = repositoryCategory.GetAll().ToList();
            return View(category);
        }


        [HttpPost]
        public ActionResult Create(ProductSubCategory subcategory, int ProductCategoryID)
        {
            (repository as IProductSubCategoryRepository).CreateProductSubCategory(subcategory, ProductCategoryID);
            return RedirectToAction("List");
        }
        public PartialViewResult List()
        {
            return PartialView(repository.GetAll().OrderByDescending(x => x.ModifiedDate).ToList());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repository.GetByID(id);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Edit(ProductSubCategory category)
        {
            repository.Update(category);
            return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            var category = repository.GetByID(id);
            return PartialView(category);
        }
        public ActionResult Delete(int id)
        {
            var category = repository.GetByID(id);
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Delete(ProductSubCategory category)
        {
            repository.Delete(category.ProductSubCategoryID);
            return RedirectToAction("List");
        }

        public PartialViewResult Search(string name)
        {
            var result = repository.GetAll().Where(x => x.Name == name).ToList();
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
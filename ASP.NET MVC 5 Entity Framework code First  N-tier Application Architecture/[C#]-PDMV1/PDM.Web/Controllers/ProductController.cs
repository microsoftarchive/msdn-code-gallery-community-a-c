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
    public class ProductController : Controller
    {
        private IRepositoryBase<Product> repository = new ProductRepository();
        public ActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            Product product = new Product();
            GetProduct(product);
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product, int ProductModelId, int ProductCategoryID, int ProductSubCategoryID, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    IRepositoryBase<Photo> repositoryPhoto = new PhotoRepository();
                    Photo photo = new Photo();
                    photo.Name = file.FileName;
                    photo.Image = new byte[file.ContentLength];
                    file.InputStream.Read(photo.Image, 0, file.ContentLength);
                    product.PhotoID = repositoryPhoto.Create(photo);
                }
                (repository as IProductRepository).Create(product, ProductModelId, ProductCategoryID, ProductSubCategoryID);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public PartialViewResult List()
        {
            return PartialView(repository.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = repository.GetByID(id);
            GetProduct(product);
            ViewBag.ProductModelID = product.ProductModelId;
            IRepositoryBase<ProductSubCategory> repositorySubCategory = new ProductSubCategoryRepository();
            ViewBag.ProductCategoryID = repositorySubCategory.GetAll().Where(x => x.ProductSubCategoryID == product.ProductSubCategoryID).Select(y => y.ProductCategoryID).FirstOrDefault();
            ViewBag.ProductSubCategoryID = product.ProductSubCategoryID;
            return View(product);
        }

        [HttpPost]

        public ActionResult Edit(Product product, int ProductModelId, int ProductCategoryID, int ProductSubCategoryID, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    IRepositoryBase<Photo> repositoryPhoto = new PhotoRepository();
                    Photo photo = repositoryPhoto.GetByID(product.PhotoID);
                    photo.Name = file.FileName;
                    photo.Image = new byte[file.ContentLength];
                    file.InputStream.Read(photo.Image, 0, file.ContentLength);
                    product.PhotoID = repositoryPhoto.Update(photo);
                }
                (repository as IProductRepository).Edit(product, ProductModelId, ProductSubCategoryID);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = repository.GetByID(id);
            GetProduct(product);
            return PartialView(product);
        }

        public ActionResult Delete(int id)
        {
            var product = repository.GetByID(id);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            repository.Delete(product.ProductID);
            return RedirectToAction("List");
        }

        public FileContentResult GetImage(int id)
        {
            IRepositoryBase<Photo> repositoryPhoto = new PhotoRepository();
            var photo = repositoryPhoto.GetByID(id);
            return File(photo.Image, photo.Name);

        }

        public JsonResult GetSubCategory(int selectedValue)
        {
            IRepositoryBase<ProductSubCategory> repositorySubCategory = new ProductSubCategoryRepository();
            var items = repositorySubCategory.GetAll().Where(x => x.ProductCategoryID == selectedValue).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(string name)
        {
            var result = (from p in repository.GetAll()
                          where p.Name.ToLower().Contains(name.ToLower())
                          select new { p.Name }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public Product GetProduct(Product product)
        {
            IRepositoryBase<ProductCategory> repositoryCategory = new ProductCategoryRepository();
            product.ProductCategoryCollection = repositoryCategory.GetAll().ToList();
            IRepositoryBase<ProductSubCategory> repositorySubCategory = new ProductSubCategoryRepository();
            product.ProductSubCategoryCollection = repositorySubCategory.GetAll().ToList();
            IRepositoryBase<ProductModel> repositoryProductModel = new ProductModelRepository();
            product.ProductModelCollection = repositoryProductModel.GetAll().ToList();
            return product;
        }
    }
}
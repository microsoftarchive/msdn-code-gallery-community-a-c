using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcAlbum.Models;
using PagedList;
using mvcAlbum.ViewModels;

namespace mvcAlbum.Controllers
{ 
    public class ImagesController : Controller
    {
        private ImageContext db = new ImageContext();

        //
        // GET: /Image/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString,  int? page)
        {
            ViewBag.CurrentSort = sortOrder; 
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Image desc" : "";
         
     

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString; 

            
            var Images = from s in db.Images.Include(m => m.Categorys)
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Images = Images.Where(s => s.ImageName.ToUpper().Contains(searchString.ToUpper())
                                       || s.Description.ToUpper().Contains(searchString.ToUpper()));
            } 


            switch (sortOrder)
            {
                case "Image desc":
                    Images = Images.OrderByDescending(s => s.ImageName);
                    break;
                case "Category desc":
                    Images = Images.OrderByDescending(s => s.Categorys.Name);
                    break;
                default:
                    Images = Images.OrderBy(s => s.ImageID);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(Images.ToPagedList(pageNumber, pageSize)); 
        }

        //
        // GET: /Image/Details/5

        public ViewResult Details(int id)
        {
            Image Image = db.Images.Find(id);
            return View(Image);
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        } 

        //
        // POST: /Image/Create

        [HttpPost]
        public ActionResult Create(Image Image, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                db.Images.Add(Image);
                db.SaveChanges();

                if (file != null && file.ContentLength > 0){

                   var path = Path.Combine(Server.MapPath("~/uploads"),
                       Image.ImageID.ToString() + ".jpg"); 
                   file.SaveAs(path);}


                return RedirectToAction("Index");  
            }


            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", Image.CategoryID);
            return View(Image);
        }
        
        //
        // GET: /Image/Edit/5
 
        public ActionResult Edit(int id)
        {
            Image Image = db.Images.Find(id);

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", Image.CategoryID);
            return View(Image);
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        public ActionResult Edit(Image Image, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Image).State = EntityState.Modified;
                db.SaveChanges();

                if (file != null && file.ContentLength > 0)
                {

                    var path = Path.Combine(Server.MapPath("~/uploads"), Image.ImageID.ToString() + ".jpg");
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", Image.CategoryID);
            return View(Image);
        }

        //
        // GET: /Image/Delete/5
 
        public ActionResult Delete(int id)
        {
            Image Image = db.Images.Find(id);
            return View(Image);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Image Image = db.Images.Find(id);
            db.Images.Remove(Image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcAlbum.Models;

namespace mvcAlbum.Controllers
{ 
    public class CategoryController : Controller
    {
        private ImageContext db = new ImageContext();

        //
        // GET: /Category/

        public ViewResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Category/Details/5

        public ViewResult Details(int id)
        {
            Category Category = db.Categories.Find(id);
            return View(Category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category Category)
        {
    try 
        { 

            if (ModelState.IsValid)
            {
                db.Categories.Add(Category);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
        } 
         catch (DataException) 
        { 
             ModelState.AddModelError("", "Unable to save changes. Try again");
         }
            return View(Category);
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category Category = db.Categories.Find(id);
            return View(Category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Category);
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            Category Category = db.Categories.Find(id);
            return View(Category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Category Category = db.Categories.Find(id);
            db.Categories.Remove(Category);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemoAzureSQLServer.Models;

namespace MVCDemoAzureSQLServer
{
    public class ModelController : Controller
    {
        private MVCDemoEntities db = new MVCDemoEntities();

        // GET: /Model/
        public ActionResult Index()
        {
            var modelset = db.ModelSet.Include(m => m.Car);
            return View(modelset.ToList());
        }

        // GET: /Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.ModelSet.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /Model/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.CarSet, "Id", "Brand");
            return View();
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,CarId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.ModelSet.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.CarSet, "Id", "Brand", model.CarId);
            return View(model);
        }

        // GET: /Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.ModelSet.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.CarSet, "Id", "Brand", model.CarId);
            return View(model);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,CarId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.CarSet, "Id", "Brand", model.CarId);
            return View(model);
        }

        // GET: /Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.ModelSet.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.ModelSet.Find(id);
            db.ModelSet.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

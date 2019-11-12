using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_Using_Entity_Framework_Code_First.DAL;
using MVC_CRUD_Using_Entity_Framework_Code_First.Models;

namespace MVC_CRUD_Using_Entity_Framework_Code_First.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private EmployeeDetailsDbContext db = new EmployeeDetailsDbContext();

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View(db.employeeDetails.ToList());
        }

        // GET: EmployeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.employeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeDetailsId,EmpName,EmpAddress,EmpEmailId")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                db.employeeDetails.Add(employeeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.employeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeDetailsId,EmpName,EmpAddress,EmpEmailId")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.employeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetails employeeDetails = db.employeeDetails.Find(id);
            db.employeeDetails.Remove(employeeDetails);
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

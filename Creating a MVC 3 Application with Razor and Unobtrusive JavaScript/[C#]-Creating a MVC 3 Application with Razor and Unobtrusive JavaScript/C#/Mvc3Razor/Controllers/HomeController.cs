using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3Razor.Models;

namespace Mvc3Razor.Controllers {
    public class HomeController : Controller {

        // The __usrs class is replacement for a real data access strategy.
        private static Users _usrs = new Users();

        public ActionResult Index() {
            return View(_usrs._usrList);
        }

        public ViewResult Details(string id) {
            return View(_usrs.GetUser(id));
        }

        public ViewResult Edit(string id) {
            return View(_usrs.GetUser(id));
        }

        [HttpPost]
        public ViewResult Edit(UserModel um) {

            if (!TryUpdateModel(um)) {
                ViewBag.updateError = "Update Failure";
                return View(um);
            }

            // ToDo: add persistent to DB.
            _usrs.Update(um);
            return View("Details", um);
        }

        public ActionResult About() {
            return View();
        }

        public ViewResult Create() {
            return View(new UserModel());
        }

        [HttpPost]
        public ViewResult Create(UserModel um) {

            if (!TryUpdateModel(um)) {
                ViewBag.updateError = "Create Failure";
                return View(um);
            }

            // ToDo: add persistent to DB.
            _usrs.Create(um);
            return View("Details", um);
        }

        public ViewResult Delete(string id) {
            return View(_usrs.GetUser(id));
        }

        [HttpPost]
        public RedirectToRouteResult Delete(string id, FormCollection collection) {
            _usrs.Remove(id);
            return RedirectToAction("Index");
        }


    }
}

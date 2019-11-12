using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDDL.Models;

namespace CascadingDDL.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string Countries, string States) {

            int stateID = -1;
            if (!int.TryParse(States, out stateID)) {
                ViewBag.YouSelected = "You must select a Country and State";
                return View();
            }

            var state = from s in State.GetStates()
                        where s.StateID == stateID
                        select s.StateName;

            var country = from s in Country.GetCountries()
                          where s.Code == Countries
                          select s.Name;


            ViewBag.YouSelected = "You selected " + country.SingleOrDefault()
                                 + " And " + state.SingleOrDefault();
            return View("Info");
        }

        public ActionResult About() {

            return View();
        }

        public SelectList GetCountrySelectList() {

            var countries = Country.GetCountries();
            return new SelectList(countries.ToArray(),
                                "Code",
                                "Name");

        }

        public ActionResult IndexDDL() {

            ViewBag.Country = GetCountrySelectList();
            return View();
        }

        [HttpPost]
        public ActionResult IndexDDL(string Countries, string States) {

            ViewBag.Countries = GetCountrySelectList();

            int stateID = -1;
            if (!int.TryParse(States, out stateID)) {
                ViewBag.YouSelected = "You must select a Country and State";
                return View();
            }

            var state = from s in State.GetStates()
                        where s.StateID == stateID
                        select s.StateName;

            var country = from s in Country.GetCountries()
                          where s.Code == Countries
                          select s.Name;


            ViewBag.YouSelected = "You selected " + country.SingleOrDefault()
                                 + " And " + state.SingleOrDefault();
            return View("Info");

        }

        public ActionResult CountryList() {
            var countries = Country.GetCountries();

            if (HttpContext.Request.IsAjaxRequest())
                return Json(GetCountrySelectList(), JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }

        public ActionResult StateList(string ID) {
            string Code = ID;
            var states = from s in State.GetStates()
                         where s.Code == Code
                         select s;

            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(
                                states.ToArray(),
                                "StateID",
                                "StateName")
                           , JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }

    }
}

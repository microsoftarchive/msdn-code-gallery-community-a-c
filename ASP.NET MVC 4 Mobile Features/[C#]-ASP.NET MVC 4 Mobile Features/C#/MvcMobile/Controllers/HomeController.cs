using System;
using System.Linq;
using System.Web.Mvc;
using MvcMobile.Models;

namespace MvcMobile.Controllers {
    public class HomeController : Controller {
        public ViewResult Index() {
            ViewBag.NumSessions = Sessions.All.Count;
            return View();
        }

        public ViewResult AllSpeakers() {
            var allSpeakers = Sessions.All.SelectMany(x => x.Speakers).Distinct().OrderBy(x => x);
            return View(allSpeakers);
        }

        public ViewResult AllTags() {
            var allTags = Sessions.All.SelectMany(x => x.Tags).Distinct().OrderBy(x => x);
            return View(allTags);
        }

        public ViewResult AllDates() {
            var allDates = Sessions.All.Select(x => x.StartDate).Distinct().OrderBy(x => x);
            return View(allDates);
        }

        public ViewResult SessionsBySpeaker(string speaker) {
            ViewBag.Title = "Sessions by " + speaker;
            var sessions = Sessions.All.Where(session => session.Speakers.Contains(speaker)).OrderBy(x => x.StartDate);
            return View("SessionsTable", sessions);
        }

        public ViewResult SessionsByTag(string tag) {
            ViewBag.Title = "Sessions tagged " + tag;
            var sessions = Sessions.All.Where(session => session.Tags.Contains(tag)).OrderBy(x => x.Title);
            return View("SessionsTable", sessions);
        }

        public ViewResult SessionsByDate(DateTime date) {
            ViewBag.Title = "Sessions on at " + date.ToString("ddd, MMM dd, h:mm tt");
            var sessions = Sessions.All.Where(session => session.StartDate == date).OrderBy(x => x.Title);
            return View("SessionsTable", sessions);
        }

        public ActionResult SessionByCode(string code) {
            if (String.IsNullOrEmpty(code)) {
                return RedirectToAction("AllTags");
            }

            var session = Sessions.All.Single(x => x.Code == code);
            return View(session);
        }
    }
}
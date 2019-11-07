using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlex.Controllers
{
    public class CinemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: Cinemas/Details/5
        public ActionResult Details(int id)
        {
            ViewData["CinemaId"] = id;
            return View();
        }
    }
}
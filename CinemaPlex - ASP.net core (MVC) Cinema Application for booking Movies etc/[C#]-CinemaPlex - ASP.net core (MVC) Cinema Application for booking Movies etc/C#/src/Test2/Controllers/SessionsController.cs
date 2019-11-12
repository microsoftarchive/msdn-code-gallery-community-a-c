using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlex.Controllers
{
    public class SessionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int id)
        {
            ViewData["SessionID"] = id;
            return View();
        }
    }
}
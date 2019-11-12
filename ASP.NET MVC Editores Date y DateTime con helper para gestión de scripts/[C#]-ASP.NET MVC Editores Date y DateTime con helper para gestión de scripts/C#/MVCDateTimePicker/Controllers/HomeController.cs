using MVCDateTimePicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDateTimePicker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Persona persona)
        {
            return View(persona);
        }
    }
}
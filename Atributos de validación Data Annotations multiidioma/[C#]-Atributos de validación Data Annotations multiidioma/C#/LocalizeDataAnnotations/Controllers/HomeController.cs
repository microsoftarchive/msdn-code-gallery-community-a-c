using LocalizeDataAnnotations.Infrastructure;
using LocalizeDataAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizeDataAnnotations.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index(Persona persona)
        {
            return View(persona);
        }

        public ViewResult Resource(PersonaResource persona)
        {
            return View("Index", persona);
        }

        public ViewResult BBDD(PersonaBBDD persona)
        {
            return View("Index", persona);
        }

        public ViewResult CustomAttr(PersonaCustomAttr persona)
        {
            return View("Index", persona);
        }

    }
}
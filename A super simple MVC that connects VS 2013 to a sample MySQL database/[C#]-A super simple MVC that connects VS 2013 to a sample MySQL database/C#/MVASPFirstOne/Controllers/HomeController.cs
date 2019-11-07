//******* Start copying code here **********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCASPFirstOne.Models;

namespace MVCASPFirstOne.controllers
{
    public class HomeController : Controller
    {
        cActorName thePerson = new cActorName(12);   
        public ActionResult Index()
        {
            return View(thePerson);
        }  
    }
}
//****** Stop copying code here ***********

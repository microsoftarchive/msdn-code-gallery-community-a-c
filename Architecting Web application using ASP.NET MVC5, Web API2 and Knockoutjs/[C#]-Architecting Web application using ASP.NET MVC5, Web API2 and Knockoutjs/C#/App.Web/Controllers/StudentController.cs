using System;
using System.Web.Mvc;
using App.Web.ViewModels;

namespace App.Web.Controllers
{

    public class StudentController : Controller
    {

        public ActionResult Create()
        {
            var studentViewModel = new StudentViewModel();

            studentViewModel.StudentID = Guid.Empty;

            return View(studentViewModel);
        }


    }
}
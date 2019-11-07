using AjaxForm.Models;
using AjaxForm.Serialization;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AjaxForm.Controllers
{
    public class UserController : BaseController
    {
        public static List<UserViewModel> users = new List<UserViewModel>();

        public ActionResult Index()
        {
            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                users.Add(model);
                return NewtonSoftJsonResult(new ResponseData<string> { RedirectUrl = @Url.Action("Index", "User") });
            }
            return CreateModelStateErrors();
        }
    }
}
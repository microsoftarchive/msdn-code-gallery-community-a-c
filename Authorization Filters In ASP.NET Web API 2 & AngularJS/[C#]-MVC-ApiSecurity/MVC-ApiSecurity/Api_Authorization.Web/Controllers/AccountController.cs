using Api_Authorization.Business.UserFactory;
using Api_Authorization.Models;
using Api_Authorization.Models.ViewModel;
using Api_Authorization.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api_Authorization.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserAuthentications objAuth = null;

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public JsonResult Login(loginUserModel model)
        {
            objAuth = new UserAuthentications();
            loggedUserModel loggeddata = null; Session["UserSession"] = null;

            try
            {
                if (model != null)
                {
                    loggeddata = objAuth.MemberAuthentication(model);
                    loggeddata.Ip = HostService.GetIP();
                    Session["UserSession"] = loggeddata;
                    Session["UserID"] = loggeddata.UserId;
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return Json(loggeddata, JsonRequestBehavior.AllowGet);
        }

        // GET: Account/GetSession
        [HttpGet]
        public JsonResult GetSession()
        {
            return Json(Session["UserSession"], JsonRequestBehavior.AllowGet);
        }

        // GET: Account/Logout
        [HttpGet]
        public JsonResult Logout()
        {
            bool result = false;
            try
            {
                if (Session["UserSession"] != null)
                {
                    Session["UserSession"] = null;
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    result = true;
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
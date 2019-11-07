using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using shanuMVCUserRoles.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace shanuMVCUserRoles.Controllers
{
	[Authorize]
	public class MenuController : Controller
    {
		public string RoleName { get; set; }
		// GET: Users
		public Boolean isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				RoleName = s[0].ToString();
                if (RoleName == "Admin")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		// GET: Menu
		public ActionResult Index()
        {

			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ViewBag.Name = user.Name;
				//	ApplicationDbContext context = new ApplicationDbContext();
				//	var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				//var s=	UserManager.GetRoles(user.GetUserId());
				ViewBag.displayMenu = "No";

				if (isAdminUser())
				{
					ViewBag.UserRole = RoleName;
					ViewBag.displayMenu = "YES";
					return View();
				}
				else
				{
					return RedirectToAction("Index", "Home");
				}
				
			}
			else
			{
				return RedirectToAction("Index", "Home");

				ViewBag.Name = "Not Logged IN";
			}
			return RedirectToAction("Index", "Home");

		}
    }
}
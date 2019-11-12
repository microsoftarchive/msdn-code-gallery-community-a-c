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
	public class UsersController : Controller
    {
		public string RoleName { get; set; }
		// GET: Users
		
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ViewBag.Name = user.Name;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				RoleName = s[0].ToString();
				ViewBag.displayMenu = "No";
				ViewBag.UserRole = RoleName;
				if (RoleName == "Admin")
				{				
					ViewBag.displayMenu = "Yes";
				}
				
				return View();
			}
			else
			{
			return	RedirectToAction("Index", "Home");
			}

			


		}
	}
}
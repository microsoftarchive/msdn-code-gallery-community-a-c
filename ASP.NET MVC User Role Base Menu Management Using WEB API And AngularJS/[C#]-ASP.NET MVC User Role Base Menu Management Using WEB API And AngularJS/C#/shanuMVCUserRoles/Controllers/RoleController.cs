using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace shanuMVCUserRoles.Controllers
{
	[Authorize]
	public class RoleController : Controller
    {
		ApplicationDbContext context;

		public RoleController()
		{
			context = new ApplicationDbContext();
		}



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

		/// <summary>
		/// Get All Roles
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			var Roles = context.Roles.ToList();
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

					return View(Roles);
				}
				else
				{
					return RedirectToAction("Index", "Home");
				}
			
			}
			else
			{
				return RedirectToAction("Index", "Home");
			
			}

		
			

		}
		
		/// <summary>
		/// Create  a New role
		/// </summary>
		/// <returns></returns>
		public ActionResult Create()
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
					var Role = new IdentityRole();
					return View(Role);
				}
				else
				{
				return	RedirectToAction("Index", "Home");
				}
			
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

			
		}

		/// <summary>
		/// Create a New Role
		/// </summary>
		/// <param name="Role"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(IdentityRole Role)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (!isAdminUser())
				{
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

			context.Roles.Add(Role);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
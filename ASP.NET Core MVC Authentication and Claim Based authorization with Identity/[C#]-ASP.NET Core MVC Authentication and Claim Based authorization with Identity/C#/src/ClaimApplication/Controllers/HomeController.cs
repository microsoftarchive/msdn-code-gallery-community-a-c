using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClaimApplication.Data;
using Microsoft.AspNetCore.Authorization;

namespace ClaimApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            string userName = userManager.GetUserName(User);
            return View("Index", userName);
        }
    }
}

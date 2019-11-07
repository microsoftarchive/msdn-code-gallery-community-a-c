using ClaimApplication.Data;
using ClaimApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySampleApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
            return View(model);
        }

        [Authorize(Policy = "AddEditUser")]
        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            model.UserClaims = ClaimData.UserClaims.Select(c => new SelectListItem
            {
                Text = c,
                Value = c
            }).ToList();
            return PartialView("_AddUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Email = model.Email
                };
                List<SelectListItem> userClaims = model.UserClaims.Where(c => c.Selected).ToList();
                foreach (var claim in userClaims)
                {
                    user.Claims.Add(new IdentityUserClaim<string>
                    {
                        ClaimType = claim.Value,
                        ClaimValue = claim.Value
                    });
                }

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [Authorize(Policy = "AddEditUser")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            EditUserViewModel model = new EditUserViewModel();

            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    model.Name = applicationUser.Name;
                    model.Email = applicationUser.Email;
                    var claims = await userManager.GetClaimsAsync(applicationUser);
                    model.UserClaims = ClaimData.UserClaims.Select(c => new SelectListItem
                    {
                        Text = c,
                        Value = c,
                        Selected = claims.Any(x => x.Value == c)
                    }).ToList();
                }
                else
                {
                    model.UserClaims = ClaimData.UserClaims.Select(c => new SelectListItem
                    {
                        Text = c,
                        Value = c
                    }).ToList();
                }

            }
            return PartialView("_EditUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    applicationUser.Name = model.Name;
                    applicationUser.Email = model.Email;
                    var claims = await userManager.GetClaimsAsync(applicationUser);
                    List<SelectListItem> userClaims = model.UserClaims.Where(c => c.Selected && claims.Any(u => u.Value != c.Value)).ToList();
                    foreach (var claim in userClaims)
                    {
                        applicationUser.Claims.Add(new IdentityUserClaim<string>
                        {
                            ClaimType = claim.Value,
                            ClaimValue = claim.Value
                        });
                    }
                    IdentityResult result = await userManager.UpdateAsync(applicationUser);
                    List<Claim> userRemoveClaims = claims.Where(c => model.UserClaims.Any(u => u.Value == c.Value && !u.Selected)).ToList();
                    foreach (Claim claim in userRemoveClaims)
                    {
                        await userManager.RemoveClaimAsync(applicationUser, claim);
                    }
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("_EditUser", model);
        }

        [Authorize(Policy = "DeleteUser")]
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.Name;
                }
            }
            return PartialView("_DeleteUser", name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id, IFormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}

using Microsoft.AspNet.Identity;
using Models;
using Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC5_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ItmUserManager _identityService;

        public AccountController(ItmUserManager IdentityService)
        {
            _identityService = IdentityService;
        }

        #region Views By GET
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Manage()//ManageMessageId? message)
        {
            //ViewBag.StatusMessage =
            //    message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
            //    : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
            //    : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
            //    : message == ManageMessageId.Error ? "An error has occurred."
            //    : "";
            ViewBag.HasLocalPassword = true;// HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }
        #endregion

        #region Form Submition By Post
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.CreateAsync(model.UserName, model.Password, model.ConfirmPassword);
                if (result.Succeeded)
                {
                    await _identityService.SignInAsync(model.UserName, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(tmIdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _identityService.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await _identityService.SignInAsync(user.UserName, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _identityService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            //bool hasPassword = HasPassword();
            //ViewBag.HasLocalPassword = hasPassword;
            //ViewBag.ReturnUrl = Url.Action("Manage");
            //if (hasPassword)
            //{
            //    if (ModelState.IsValid)
            //    {
            var result = await _identityService.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            //        if (result.Succeeded)
            //        {
            //            return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
            //        }
            //        else
            //        {
            //            AddErrors(result);
            //        }
            //    }
            //}
            //else
            //{
            //    // User does not have a password so remove any validation errors caused by a missing OldPassword field
            //    ModelState state = ModelState["OldPassword"];
            //    if (state != null)
            //    {
            //        state.Errors.Clear();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        IdentityResult result = await _identityService.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
            //        if (result.Succeeded)
            //        {
            //            return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
            //        }
            //        else
            //        {
            //            AddErrors(result);
            //        }
            //    }
            //}

            //// If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion
    }
}
namespace MvcApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Security;

    using MVCRegistrationActivities;

    using MvcApplication1.Infrastructure;
    using MvcApplication1.Models;

    [Authorize]
    public class AccountController : Controller
    {
        #region Public Methods and Operators

        [AllowAnonymous, ExportModelStateToTempData]
        public ActionResult Cancel(string verificationCode)
        {
            Guid instanceId;

            if (!Guid.TryParse(verificationCode, out instanceId))
            {
                this.ModelState.AddModelError(
                    "", string.Format("The verification code \"{0}\" is invalid, try using your email", verificationCode));
                return this.RedirectToAction("CancelEmail");
            }

            if (!verification.CancelRegistration(instanceId))
            {
                this.ModelState.AddModelError(
                    "", "Unable to cancel verification the registration process, auto-cancel will occur automatically");
                return this.RedirectToAction("CancelEmail");
            }
            return this.RedirectToAction("CancelComplete");
        }

        [AllowAnonymous]
        public ActionResult CancelComplete()
        {
            return this.View();
        }

        [AllowAnonymous, ImportModelStateFromTempData]
        public ActionResult CancelEmail()
        {
            return this.ContextDependentView();
        }

        [AllowAnonymous, ImportModelStateFromTempData]
        [HttpPost]
        public ActionResult CancelEmail(CancelModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return this.View();
            }

            if (verification.CancelRegistration(model.Email))
            {
                return this.RedirectToAction("CancelComplete");
            }

            this.ModelState.AddModelError("", "Cannot locate user with your email address");
            return this.View();
        }

        public ActionResult ChangePassword()
        {
            return this.View();
        }

        /// <summary>
        /// POST: /Account/ChangePassword 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>The view</returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    var currentUser = Membership.GetUser(this.User.Identity.Name, userIsOnline: true);
                    Debug.Assert(currentUser != null, "currentUser != null");
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return this.RedirectToAction("ChangePasswordSuccess");
                }
                this.ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// GET: /Account/ChangePasswordSuccess 
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult ChangePasswordSuccess()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Confirmation()
        {
            return this.View();
        }

        /// <summary>
        /// POST: /Account/JsonLogin
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="returnUrl">The return URL</param>
        /// <returns>View</returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(LoginModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.UserApproved(model))
                {
                    // Allow the user to resend the confirmation email
                    this.ModelState.AddModelError(
                        "",
                        "Your registration is not complete yet, please check your inbox for messages or click <a href='"
                        + this.Url.Action("ResendConfirmation") + "'>here</a>");
                }
                else if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    // TODO: Notice how we have to check to see if the user is approved here
                    if (this.UserApproved(model))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        return this.Json(new { success = true, redirect = returnUrl });
                    }

                    // Allow the user to resend the confirmation email
                    this.ModelState.AddModelError(
                        "",
                        "Your registration is not complete yet, please check your inbox for messages or click <a href='"
                        + this.Url.Action("ResendConfirmation") + "'>here</a>");
                }
                else
                {
                    this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed
            return this.Json(new { errors = this.GetErrorsFromModelState() });
        }

/// <summary>
/// Provides registration support for the registration pop-up dialog
/// </summary>
/// <param name="model">The model</param>
/// <returns>An action result</returns>
/// <remarks>
/// The default implementation of this method creates and automatically approves users.  In this case we don't want to approve a user until their email is verified.  
/// The default implementation also implicitly logs in the created user.  In this case we do not want to log in the newly created user.
/// </remarks>
[AllowAnonymous]
[HttpPost]
public ActionResult JsonRegister(RegisterModel model)
{
    if (this.ModelState.IsValid)
    {
        // Attempt to register the user
        MembershipCreateStatus createStatus;

        // TODO: Notice how we set isApproved = false until email verification is complete
        Membership.CreateUser(
            model.UserName,
            model.Password,
            model.Email,
            passwordQuestion: null,
            passwordAnswer: null,
            isApproved: false,
            providerUserKey: null,
            status: out createStatus);

        if (createStatus == MembershipCreateStatus.Success)
        {
            // TODO: Notice how we do not log in here but start the verification process
            this.VerifyRegistration(model);

            // TODO: Notice how we redirect to the confirmation page
            return this.Json(new { success = true, redirect = this.Url.Action("Confirmation") });
        }
        this.ModelState.AddModelError("", ErrorCodeToString(createStatus));
    }

    // If we got this far, something failed
    return this.Json(new { errors = this.GetErrorsFromModelState() });
}

        /// <summary>
        /// GET: /Account/LogOff 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET: /Account/Login 
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return this.ContextDependentView();
        }

        /// <summary>
        /// POST: /Account/Login
        /// </summary>
        /// <param name="model">Loging model</param>
        /// <param name="returnUrl">The return URL</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    // TODO: Notice how we have to check to see if the user is approved here
                    if (this.UserApproved(model))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        if (this.Url.IsLocalUrl(returnUrl))
                        {
                            return this.Redirect(returnUrl);
                        }
                        return this.RedirectToAction("Index", "Home");
                    }

                    // Allow the user to resend the confirmation email
                    this.ModelState.AddModelError(
                        "",
                        "Your registration is not complete yet, please check your inbox for messages or click <a href='"
                        + this.Url.Action("ResendConfirmation") + "'>here</a>");
                }
                this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.ContextDependentView();
        }

        //
        // POST: /Account/JsonRegister

        //
        // POST: /Account/Register

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;

                // TODO: Notice how we set isApproved = false until email verification is complete
                Membership.CreateUser(
                    model.UserName,
                    model.Password,
                    model.Email,
                    passwordQuestion: null,
                    passwordAnswer: null,
                    isApproved: false,
                    providerUserKey: null,
                    status: out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    // TODO: Notice how we do not log in here but start the verification process
                    this.VerifyRegistration(model);

                    // TODO: Notice how we redirect to the confirmation page
                    return this.RedirectToAction("Confirmation", "Account");
                }
                this.ModelState.AddModelError("", ErrorCodeToString(createStatus));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResendConfirmation()
        {
            return this.ContextDependentView();
        }

        private readonly RegistrationVerification<AccountRegistration> verification = new RegistrationVerification<AccountRegistration>();
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResendConfirmation(ConfirmationModel model)
        {
            if (verification.ResendRegistrationEmail(model.Email))
            {
                return this.RedirectToAction("Confirmation", "Account");
            }

            this.ModelState.AddModelError("", "Cannot locate user with your email address");
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Verification()
        {
            if (verification.CompleteRegistration(this.Request.QueryString["verificationCode"]))
            return this.RedirectToAction("VerificationComplete");
            this.ModelState.AddModelError("", "Invalid verification code, your registration may have expired you can <a href='" + Url.Action("Register") + "'>Register</a> or <a href='"+Url.Action("ResendConfirmation")+"'>Resend the registration email</a> ");
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult VerificationComplete()
        {
            return this.View();
        }

        #endregion

        #region Methods

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return
                        "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        //
        // GET: /Account/ChangePassword

        private ActionResult ContextDependentView()
        {
            var actionName = this.ControllerContext.RouteData.GetRequiredString("action");
            if (this.Request.QueryString["content"] != null)
            {
                this.ViewBag.FormAction = "Json" + actionName;
                return this.PartialView();
            }
            this.ViewBag.FormAction = actionName;
            return this.View();
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return this.ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        private bool UserApproved(LoginModel model)
        {
            var user = Membership.GetUser(model.UserName);
            return user != null && user.IsApproved;
        }

        private void VerifyRegistration(RegisterModel model)
        {
            // Create a verification workflow using the helper
            var workflow = new RegistrationVerification<AccountRegistration>();

            Debug.Assert(this.Request.Url != null, "Request.Url != null");

            // TODO: Notice how we setup the registration system with sever email templates
            workflow.VerifyRegistration(
                new RegistrationData
                    {
                        // HTML files created by Visual Studio are UTF8 encoded
                        BodyEncoding = Encoding.UTF8,
                        // These arguments can be used to insert data into the HTML mail template
                        BodyArguments = new[] { model.UserName },
                        // These templates will be used in-order to provide email reminders.  After the 
                        // last email, the verification process will give up and delete the account
                        EmailTemplates =
                            new[]
                                {
                                    this.Server.MapPath("~/Content/RegistrationVerificationEmail.html"),
                                    this.Server.MapPath("~/Content/Reminder1Email.html"),
                                    this.Server.MapPath("~/Content/FinalReminderEmail.html") },
                        IsBodyHtml = true,
                        // TODO: Modify email properties as required
                        From = "todo@tempuri.org",
                        Sender = "todo@tempuri.org",
                        Subject = "Registration almost complete",
                        To = new[] { model.Email },
                        // Created extension methods to provide fully qualified URLs for email
                        VerificationUrl = this.Url.FullyQualifiedAction("Verification"),
                        CancelUrl = this.Url.FullyQualifiedAction("Cancel"),
                        StylesUrl = this.Url.FullyQualifiedContent("~/Content/Site.css"),
                        UserName = model.UserName,
                        UserEmail = model.Email,
                    });
        }

        #endregion
    }
}
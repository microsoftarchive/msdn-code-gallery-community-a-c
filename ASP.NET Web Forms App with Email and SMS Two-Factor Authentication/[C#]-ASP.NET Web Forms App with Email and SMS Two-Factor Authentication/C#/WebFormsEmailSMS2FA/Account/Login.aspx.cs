using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebFormsEmailSMS2FA.Models;

namespace WebFormsEmailSMS2FA.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

              // Require the user to have a confirmed email before they can log on.
              var user = manager.FindByName(Email.Text);
              if (user != null)
              {
                if (!user.EmailConfirmed)
                {
                  FailureText.Text = "Invalid login attempt. You must have a confirmed email address. Enter your email and password, then press 'Resend Confirmation'.";
                  ErrorMessage.Visible = true;
                  ResendConfirm.Visible = true;
                }
                else
                {
                  // This doen't count login failures towards account lockout
                  // To enable password failures to trigger lockout, change to shouldLockout: true
                  var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                  switch (result)
                  {
                      case SignInStatus.Success:
                          IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                          break;
                      case SignInStatus.LockedOut:
                          Response.Redirect("/Account/Lockout");
                          break;
                      case SignInStatus.RequiresVerification:
                          Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                          Request.QueryString["ReturnUrl"],
                                                          RememberMe.Checked),
                                            true);
                          break;
                      case SignInStatus.Failure:
                      default:
                          FailureText.Text = "Invalid login attempt";
                          ErrorMessage.Visible = true;
                          break;
                    }
                }
              }
           }
        }

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
          var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
          var user = manager.FindByName(Email.Text);
          if (user != null)
          {
            if (!user.EmailConfirmed)
            {
              string code = manager.GenerateEmailConfirmationToken(user.Id);
              string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
              manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

              FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
              ErrorMessage.Visible = true;
              ResendConfirm.Visible = false;
            }
          }
        }
    }       
}
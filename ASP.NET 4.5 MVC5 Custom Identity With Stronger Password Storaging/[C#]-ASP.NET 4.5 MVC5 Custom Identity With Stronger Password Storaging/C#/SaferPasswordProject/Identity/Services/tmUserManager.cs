using Identity.Store;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TM.Hashing;

namespace Identity.Services
{
    public class tmUserManager : ItmUserManager
    {
        private readonly tmUserStore<tmIdentityUser> UserManager;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public tmUserManager()
        {
            UserManager = new tmUserStore<tmIdentityUser>(new tmUserContext());
        }

        public async Task<tmIdentityResult> CreateAsync(string username, string password, string passwordConfirmation)
        {
            var user = await UserManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new tmIdentityUser();
                user.UserName = username;
                try
                {
                    user.PasswordHash = HashingConfig.HashPassword(password);
                    await UserManager.CreateAsync(user);
                }
                catch (Exception ex)
                {
                    return new tmIdentityResult(ex.Message);
                }

                return new tmIdentityResult();
            }

            return new tmIdentityResult("Username already registered");
        }

        public async Task<tmIdentityUser> FindAsync(string username, string password)
        {
            return await UserManager.FindAsync(username, password);
        }

        public async Task SignInAsync(string username, bool isPersistent)
        {
            var user = await UserManager.FindByNameAsync(username);
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }

        public async Task<int> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            return await UserManager.ChangePasswordAsync(userId, currentPassword, HashingConfig.HashPassword(newPassword));
        }
    }
}
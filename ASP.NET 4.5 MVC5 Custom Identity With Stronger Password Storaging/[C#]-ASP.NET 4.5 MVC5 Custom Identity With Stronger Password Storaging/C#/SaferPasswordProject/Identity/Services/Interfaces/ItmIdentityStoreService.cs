using Microsoft.AspNet.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public interface ItmUserManager
    {
        Task<tmIdentityResult> CreateAsync(string username, string password, string passwordConfirmation);
        Task SignInAsync(string username, bool isPersistent);
        Task<tmIdentityUser> FindAsync(string username, string password);
        void SignOut();
        Task<int> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}

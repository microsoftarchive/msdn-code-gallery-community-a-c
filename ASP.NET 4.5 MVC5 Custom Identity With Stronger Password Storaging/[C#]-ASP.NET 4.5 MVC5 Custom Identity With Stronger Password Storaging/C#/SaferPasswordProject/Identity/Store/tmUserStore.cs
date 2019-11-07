using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using TM.Hashing;

namespace Identity.Store
{
    public class tmUserStore<IUser> : IUserStore<tmIdentityUser>, IUserPasswordStore<tmIdentityUser>
    {
        public tmUserStore(tmUserContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IPasswordHasher PasswordHasher { get; set; }
        public IIdentityValidator<string> PasswordValidator { get; set; }
        protected UserStore<IdentityUser> Store { get; private set; }
        private tmUserContext _dbContext { get; set; }

        #region IUserStore Implemented Methods
        public async Task CreateAsync(tmIdentityUser user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.DateUTCCreated = DateTime.UtcNow;
            user.TimeStamp = DateTime.UtcNow;

            this._dbContext.Users.Add(user);
            this._dbContext.Configuration.ValidateOnSaveEnabled = false;

            if (await this._dbContext.SaveChangesAsync() == 0)
                throw new Exception("Error creating new user");
        }
        public async Task UpdateAsync(tmIdentityUser user)
        {
            user.TimeStamp = DateTime.UtcNow;

            this._dbContext.Users.Attach(user);
            this._dbContext.Entry(user).State = EntityState.Modified;

            await this._dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(tmIdentityUser user)
        {
            this._dbContext.Users.Remove(user);

            await this._dbContext.SaveChangesAsync();
        }
        public async Task<tmIdentityUser> FindByIdAsync(string userId)
        {
            return await this._dbContext.Users.SingleOrDefaultAsync(u => !string.IsNullOrEmpty(u.Id) && string.Compare(u.Id, userId, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public async Task<tmIdentityUser> FindByNameAsync(string userName)
        {
            return await this._dbContext.Users.SingleOrDefaultAsync(u => !string.IsNullOrEmpty(u.UserName) && string.Compare(u.UserName, userName, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        #endregion

        #region IUserPasswordStore Implemented Methods
        public async Task<string> GetPasswordHashAsync(tmIdentityUser user)
        {
            user = await this.FindByNameAsync(user.UserName);
            return user.PasswordHash;
        }
        public async Task<bool> HasPasswordAsync(tmIdentityUser user)
        {
            user = await this.FindByNameAsync(user.UserName);
            return !string.IsNullOrEmpty(user.PasswordHash);
        }
        public async Task SetPasswordHashAsync(tmIdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            await this.UpdateAsync(user);
        }
        #endregion

        #region IDisposable Implemented Methods
        public void Dispose()
        {
            this._dbContext.Dispose();
        }
        #endregion

        public async Task<tmIdentityUser> FindAsync(string userName, string password)
        {
            var user = await this._dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user != null && HashingConfig.VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(tmIdentityUser user, string authenticationType)
        {
            user = await this.FindByNameAsync(user.UserName);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.AuthenticationMethod, authenticationType)
                };
                return new System.Security.Claims.ClaimsIdentity(claims, authenticationType);
            }

            return null;
        }

        public async Task<int> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await this.FindByIdAsync(userId);
            if (HashingConfig.VerifyPassword(currentPassword, user.PasswordHash))
            {
                user.PasswordHash = newPassword;
                user.TimeStamp = DateTime.UtcNow;
            }
            return await this._dbContext.SaveChangesAsync();
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Models
{
    public class tmIdentityUser : IUser
    {
        public tmIdentityUser() { }
        public tmIdentityUser(string userName)
        {
            this.UserName = userName;
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime DateUTCCreated { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }

    public class tmUserContext : tmDbContext<tmIdentityUser>
    {
        public IDbSet<tmIdentityUser> Users { get; set; }
        public tmUserContext()
            : base("tmConnection")
        {
            this.Users = this.Set<tmIdentityUser>();
        }
    }

    public class tmDbContext<TUser> : DbContext where TUser : IUser
    {
        public tmDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
    }

}
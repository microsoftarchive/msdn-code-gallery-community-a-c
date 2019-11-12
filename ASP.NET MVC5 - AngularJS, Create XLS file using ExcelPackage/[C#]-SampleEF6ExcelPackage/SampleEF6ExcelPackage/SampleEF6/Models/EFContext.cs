using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleEF6.Models
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=DefaultConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
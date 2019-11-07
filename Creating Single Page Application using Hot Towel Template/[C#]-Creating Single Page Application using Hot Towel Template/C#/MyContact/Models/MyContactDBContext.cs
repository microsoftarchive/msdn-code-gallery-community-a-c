using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace MyContact.Models
{
    public class MyContactDBContext : DbContext
    {
        //WebConfig - Connection string name has to mention here for connecting the database.
        public MyContactDBContext()
            : base(nameOrConnectionString: "MyContactDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<MyContactDBContext>(null);

        }

        public DbSet<Contact> Contacts { get; set; }

    }
}

namespace SampleEF6.Migrations
{
    using SampleEF6.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleEF6.Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SampleEF6.Models.EFContext";
        }

        protected override void Seed(SampleEF6.Models.EFContext context)
        {
            context.Contacts.AddOrUpdate(
              p => p.Name,
              new Contact { Name = "João Sousa", Address= "Street x", City = "Porto", Country = "Portugal" },
              new Contact { Name = "Steve Jon", Address = "Street y", City = "Porto", Country = "Portugal" },
              new Contact { Name = "Peter", Address = "Street z", City = "Porto", Country = "Portugal" }
            );            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUniqueConstraintHandling.Models
{
    public class SampleContext : DbContext
    {
        public SampleContext()
        {
            Configure();
        }

        public SampleContext(string connectionString):base(connectionString)
        {
            Configure();    
        }

        public DbSet<Book> Books { get; set; }

        private void Configure()
        {
            System.Data.Entity.Database.SetInitializer<SampleContext>(new SampleInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true; 
        }        
    }
}

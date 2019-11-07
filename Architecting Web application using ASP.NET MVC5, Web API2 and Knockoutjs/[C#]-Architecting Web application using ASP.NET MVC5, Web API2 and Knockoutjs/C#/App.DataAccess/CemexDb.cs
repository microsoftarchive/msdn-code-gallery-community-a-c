using System.Configuration;
using System.Data.Entity;
using App.Domain;

namespace App.DataAccess
{

    public class CemexDb : DbContext
    {
        public CemexDb() : base(ConfigurationManager.ConnectionStrings["CemexDb"].ConnectionString)
        {
        }

        public CemexDb(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Country> Country { get; set; }


        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CemexDb>(null);
        }
    }

    internal class Initialiser : DropCreateDatabaseAlways<CemexDb>
    {
        protected override void Seed(CemexDb context)
        {
            context.SaveChanges();
        }
    }

}
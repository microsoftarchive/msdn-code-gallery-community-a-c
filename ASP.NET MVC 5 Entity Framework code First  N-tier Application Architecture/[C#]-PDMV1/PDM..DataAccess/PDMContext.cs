using PDM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataAccess
{
    public class PDMContext : DbContext
    {
        public PDMContext()
            : base("PDMConnection")
        {
        }
        public DbSet<ProductModel> ProductModel { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductSubCategory> ProductSubCategory { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Photo> Photo { get; set; }
    }
}

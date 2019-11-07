namespace ProductService.Migrations
{
    using ProductService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductService.Models.ProductServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductService.Models.ProductServiceContext context)
        {
            context.Suppliers.AddOrUpdate(new Models.Supplier[] {
                new Models.Supplier() { Key = "CTSO", Name = "Contoso, Ltd." },
                new Models.Supplier() { Key = "FBRK", Name = "Fabrikam, Inc." },
                new Models.Supplier() { Key = "WING", Name = "Wingtip Toys" }
            });

            context.Products.AddOrUpdate(new Product[] {
                new Product() { ID = 1, Name = "Hat", Price = 15, Category = "Apparel", SupplierId = "CTSO" },
                new Product() { ID = 2, Name = "Socks", Price = 5, Category = "Apparel", SupplierId = "FBRK" },
                new Product() { ID = 3, Name = "Scarf", Price = 12, Category = "Apparel", SupplierId = "CTSO" },
                new Product() { ID = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys", SupplierId = "WING" },
                new Product() { ID = 5, Name = "Puzzle", Price = 8, Category = "Toys", SupplierId = "WING" },
            });
        }
    }
}

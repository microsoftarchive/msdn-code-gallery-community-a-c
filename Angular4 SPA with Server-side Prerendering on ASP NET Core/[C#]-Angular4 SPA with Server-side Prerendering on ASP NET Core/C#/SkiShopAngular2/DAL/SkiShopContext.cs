using SkiShopAngular2.Models;
using Microsoft.EntityFrameworkCore;

namespace SkiShopAngular2.DAL
{
    public class SkiShopContext:DbContext
    {

        public SkiShopContext(DbContextOptions<SkiShopContext> options)  
            : base(options) // options: startup.cs -> configureservice -> adddbcontext<> connectionstring
        {
            
        }


        // Since lazy loading is not supported in EF Core 1.1, we won't use virtual keywork for DbSet
        public DbSet<Style> Styles { get; set;} 
        public DbSet<Sku> Skus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<IdealFor> IdealFors { get; set; }
        public DbSet<StyleIdealFor> StyleIdealFors { get; set; }
        public DbSet<StockLocation> StockLocations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // Configuration for keys and properties
            // Unfortunately EntityTypeConfiguration is not supported by EF Core

            modelbuilder.Entity<Style>(s =>
                {
                    s.HasKey(st => st.StyleId);

                    s.Property(st=>st.StyleNo)
                        .IsRequired();
                    s.Property(st => st.StyleName)
                        .IsRequired()
                        .HasMaxLength(200);
                    s.Property(st => st.Gender)
                        .IsRequired()
                        .HasMaxLength(30);
                    s.Property(st => st.ImageSmall)
                        .IsRequired()
                        .HasMaxLength(300);
                    s.Property(st => st.ImageBig)
                        .IsRequired()
                        .HasMaxLength(300);
                    s.Property(st => st.PriceCurrent)
                        .IsRequired()
                        .HasColumnType($"decimal(8,2)");
                    s.Property(st => st.PriceRegular)
                        .IsRequired()
                        .HasColumnType($"decimal(8,2)");
                    s.Property(st => st.BrandName)
                        .IsRequired()
                        .HasMaxLength(50);
                    s.Property(st => st.CategoryName)
                        .IsRequired()
                        .HasMaxLength(30);
                }
            );

            modelbuilder.Entity<Sku>(s =>
                {
                    s.HasKey(sk => sk.SkuId);
                    s.HasIndex(sk => sk.SkuNo);

                    s.Property(sk => sk.SkuNo)
                        .IsRequired();
                    s.Property(sk => sk.Size)
                        .IsRequired()
                        .HasMaxLength(50);
                    s.Property(sk => sk.RowVersion)
                        .IsRowVersion();  // IsRequired
                    s.Property(sk=>sk.StyleNo)
                        .IsRequired();
                }
            );

            modelbuilder.Entity<Category>(c =>
                {
                    c.HasKey(ca => ca.CategoryId);

                    c.Property(ca => ca.CategoryName)
                        .IsRequired()
                        .HasMaxLength(30);
                }
            );

            modelbuilder.Entity<Brand>(b =>
                {
                    b.HasKey(br => br.BrandId);

                    b.Property(br => br.BrandName)
                        .IsRequired()
                        .HasMaxLength(50);
                    b.Property(br => br.MadeIn)
                        .IsRequired()
                        .HasMaxLength(50);
                }
            );

            modelbuilder.Entity<IdealFor>(i =>
                {
                    i.HasKey(ide => ide.IdealForId);

                    i.Property(ide => ide.IdealForWhat)
                        .IsRequired()
                        .HasMaxLength(50);
                }
            );

            modelbuilder.Entity<StockLocation>(s =>
                {
                    s.HasKey(sl => sl.StockLocationId);

                    s.Property(sl => sl.Zone)
                        .HasMaxLength(10);
                    s.Property(sl => sl.Slot)
                        .HasMaxLength(10);
                }
            );

            modelbuilder.Entity<Order>(o =>
            {
                o.HasKey(or => or.OrderId);

                o.Property(or => or.Name)
                    .IsRequired();
                o.Property(or => or.Street)
                    .IsRequired();
                o.Property(or => or.City)
                    .IsRequired();
                o.Property(or => or.Province)
                    .IsRequired();
                o.Property(or => or.Postcode)
                    .IsRequired();
                o.Property(or => or.Email)
                    .IsRequired();
                o.Property(or => or.TotalValue)
                    .IsRequired()
                    .HasColumnType($"decimal(8,2)");
            });

            modelbuilder.Entity<OrderItem>(oi =>
            {
                oi.HasKey(oit => oit.OrderItemId);

                oi.Property(oit => oit.SkuNo)
                    .IsRequired();
                oi.Property(oit => oit.Skis)
                    .IsRequired();
                oi.Property(oit => oit.Size)
                    .IsRequired();
                oi.Property(oit => oit.Price)
                    .IsRequired()
                    .HasColumnType($"decimal(8,2)");
                oi.Property(oit => oit.Quantity)
                    .IsRequired();
                oi.Property(oit => oit.Subtotal)
                    .IsRequired()
                    .HasColumnType($"decimal(8,2)");
            });

            // Relationships 1/3: one-to-zero or one
            modelbuilder.Entity<Style>() // Style is principal 
                .HasOne(s => s.StockLocation) // StockLocation is dependent
                .WithOne(sl => sl.Style)
                .HasForeignKey<StockLocation>(sl => sl.StyleId);

            // Relationship 2/3: one-to-many
            modelbuilder.Entity<Style>() // Style is dependent
                   .HasOne(s => s.Category) // Category is principal
                   .WithMany(c => c.Styles)
                   .HasForeignKey(s => s.CategoryName)
                   .HasPrincipalKey(c => c.CategoryName);  // alternate key: unique

            modelbuilder.Entity<Style>()
                .HasOne(s => s.Brand)
                .WithMany(b => b.Styles)
                .HasForeignKey(s => s.BrandName)
                .HasPrincipalKey(b => b.BrandName);

            modelbuilder.Entity<Sku>()
                .HasOne(sk => sk.Style)
                .WithMany(st => st.Skus)
                .HasForeignKey(sk => sk.StyleNo)
                .HasPrincipalKey(st => st.StyleNo);

            modelbuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .HasPrincipalKey(o => o.OrderId);

            // Relationships 3/3: many-to-many
            // many-to-many: 2 one-to-many with an Entity class for the join table
            // many-to-many: 1/3
            modelbuilder.Entity<StyleIdealFor>()
                .HasKey(si => new { si.StyleId, si.IdealForId});

            modelbuilder.Entity<StyleIdealFor>() // many-to-many: 2/3
                .HasOne(si => si.Style)
                .WithMany(s => s.StyleIdealFors)
                .HasForeignKey(si => si.StyleId);

            modelbuilder.Entity<StyleIdealFor>() // many-to-many: 3/3
                .HasOne(si => si.IdealFor)
                .WithMany(i => i.StyleIdealFors)
                .HasForeignKey(si => si.IdealForId);

        }

        }
}

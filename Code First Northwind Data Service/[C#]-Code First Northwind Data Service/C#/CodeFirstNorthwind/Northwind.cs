using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace CodeFirstNorthwind
{
public class NorthwindContext : DbContext
{
    // Use the constructor to target a specific named connection string
    public NorthwindContext()
        : base("name=NorthwindEntities")
    {
        // Disable proxy creation as this messes up the data service.
        this.Configuration.ProxyCreationEnabled = false;

        // Create Northwind if it doesn't already exist.
        this.Database.CreateIfNotExists();
    }

    // Disable creation of the EdmMetadata table.
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
}
    [Table("Customers")]
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    [Table("Employees")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }       
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        [ForeignKey("ReportsTo")]
        public virtual Employee Manager{ get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    [Table("Order Details")]
    public class OrderDetail : IValidatableObject
    {
        [Key, Column(Order = 1)]
        public int OrderID { get; set; }
        [Key, Column(Order = 2)]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }  
        public short Quantity { get; set; }        
        public float Discount { get; set; }
        public Order Orders { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        // Validate for the Discount property.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (Discount < 0 || Discount > 1)
            {
                yield return new ValidationResult
                 ("Discount must be a value between zero and one", new[] { "Discount" });
            }
        }
    }
    [Table("Orders")]
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //public Shipper Shipper { get; set; }
    }
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        // public Category Category  { get ;  set;}
        public ICollection<OrderDetail> Order_Detail { get; set; }
        // public Supplier Suppliers { get ;  set;}
    }
}
    
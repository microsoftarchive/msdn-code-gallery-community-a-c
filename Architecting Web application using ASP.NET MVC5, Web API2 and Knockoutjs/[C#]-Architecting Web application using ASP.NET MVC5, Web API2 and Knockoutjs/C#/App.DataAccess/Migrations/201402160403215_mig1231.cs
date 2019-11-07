namespace MVC5EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1231 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "Subscribe", c => c.String());
            AddColumn("dbo.Students", "GenderId", c => c.Int(nullable: false));
            DropTable("dbo.PaymentTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeID = c.Guid(nullable: false),
                        Description = c.String(),
                        RequiresCreditCard = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            DropColumn("dbo.Students", "GenderId");
            DropColumn("dbo.Students", "Subscribe");
            DropColumn("dbo.Students", "DateOfBirth");
            DropColumn("dbo.Students", "LastName");
            DropTable("dbo.Countries");
        }
    }
}

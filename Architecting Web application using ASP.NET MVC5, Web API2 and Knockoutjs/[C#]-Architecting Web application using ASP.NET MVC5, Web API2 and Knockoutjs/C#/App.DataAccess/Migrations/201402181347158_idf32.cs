namespace MVC5EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idf32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PaymentMethods", c => c.String());
            AddColumn("dbo.Students", "Remarks", c => c.String());
            AddColumn("dbo.Students", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Gender", c => c.String());
            DropColumn("dbo.Students", "Subscribe");
            DropColumn("dbo.Students", "GenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "GenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Subscribe", c => c.String());
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "CountryId");
            DropColumn("dbo.Students", "Remarks");
            DropColumn("dbo.Students", "PaymentMethods");
        }
    }
}

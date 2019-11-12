namespace MVC5EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1233 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.Int(nullable: false));
        }
    }
}

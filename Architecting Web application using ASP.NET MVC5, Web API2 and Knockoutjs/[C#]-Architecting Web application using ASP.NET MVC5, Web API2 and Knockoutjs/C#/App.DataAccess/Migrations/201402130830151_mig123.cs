namespace MVC5EntityFrameworkDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Guid(nullable: false),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeID = c.Guid(nullable: false),
                        Description = c.String(),
                        RequiresCreditCard = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Student");
        }
    }
}

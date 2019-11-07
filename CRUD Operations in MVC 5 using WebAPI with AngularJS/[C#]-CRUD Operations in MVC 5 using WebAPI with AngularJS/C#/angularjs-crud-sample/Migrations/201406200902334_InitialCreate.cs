namespace angularjs_crud_sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.FriendId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Friends");
        }
    }
}

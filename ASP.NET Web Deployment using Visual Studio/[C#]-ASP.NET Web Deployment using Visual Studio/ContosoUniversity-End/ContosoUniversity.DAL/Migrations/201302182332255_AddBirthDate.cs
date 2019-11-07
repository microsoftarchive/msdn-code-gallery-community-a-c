namespace ContosoUniversity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "BirthDate");
        }
    }
}

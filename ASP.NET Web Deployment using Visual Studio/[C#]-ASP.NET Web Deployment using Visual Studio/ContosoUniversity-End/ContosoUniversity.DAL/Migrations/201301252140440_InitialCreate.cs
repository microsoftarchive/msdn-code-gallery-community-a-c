namespace ContosoUniversity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Person", t => t.PersonID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Person", t => t.PersonID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        Grade = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PersonID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseInstructor", new[] { "PersonID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "PersonID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssignment", new[] { "PersonID" });
            DropIndex("dbo.Department", new[] { "PersonID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropForeignKey("dbo.CourseInstructor", "PersonID", "dbo.Person");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "PersonID", "dbo.Person");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.OfficeAssignment", "PersonID", "dbo.Person");
            DropForeignKey("dbo.Department", "PersonID", "dbo.Person");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.Enrollment");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Person");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
        }
    }
}

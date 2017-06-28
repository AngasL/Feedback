namespace Feedback.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        attendanceId = c.Int(nullable: false, identity: true),
                        ArravalTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TeacherId = c.Int(),
                        StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.attendanceId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GradeId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatetoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CatetoryId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        CatetoryId = c.Int(),
                        StudentId = c.Int(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Categories", t => t.CatetoryId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CatetoryId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Feedbacks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Feedbacks", "CatetoryId", "dbo.Categories");
            DropForeignKey("dbo.attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.attendances", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Feedbacks", new[] { "TeacherId" });
            DropIndex("dbo.Feedbacks", new[] { "StudentId" });
            DropIndex("dbo.Feedbacks", new[] { "CatetoryId" });
            DropIndex("dbo.Students", new[] { "GradeId" });
            DropIndex("dbo.attendances", new[] { "StudentId" });
            DropIndex("dbo.attendances", new[] { "TeacherId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.attendances");
        }
    }
}

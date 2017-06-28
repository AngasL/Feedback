namespace Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        AttendenceId = c.Int(nullable: false, identity: true),
                        ArravalTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RecordedBy_TeacherId = c.Int(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendenceId)
                .ForeignKey("dbo.Teachers", t => t.RecordedBy_TeacherId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.RecordedBy_TeacherId)
                .Index(t => t.Student_StudentId);
            
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
                        Grade_GradeId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeId)
                .Index(t => t.Grade_GradeId);
            
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
                        Category_CatetoryId = c.Int(),
                        Student_StudentId = c.Int(),
                        Teacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Categories", t => t.Category_CatetoryId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId)
                .Index(t => t.Category_CatetoryId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Teacher_TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Feedbacks", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Feedbacks", "Category_CatetoryId", "dbo.Categories");
            DropForeignKey("dbo.Attendences", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Grade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.Attendences", "RecordedBy_TeacherId", "dbo.Teachers");
            DropIndex("dbo.Feedbacks", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Feedbacks", new[] { "Student_StudentId" });
            DropIndex("dbo.Feedbacks", new[] { "Category_CatetoryId" });
            DropIndex("dbo.Students", new[] { "Grade_GradeId" });
            DropIndex("dbo.Attendences", new[] { "Student_StudentId" });
            DropIndex("dbo.Attendences", new[] { "RecordedBy_TeacherId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Attendences");
        }
    }
}

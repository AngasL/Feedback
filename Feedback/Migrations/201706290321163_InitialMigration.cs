namespace Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendenceId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ArravalTime = c.DateTime(nullable: false),
                        LeavingTime = c.DateTime(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttendenceId)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
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
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
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
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Comments = c.String(),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseGrades",
                c => new
                    {
                        Course_CourseId = c.Int(nullable: false),
                        Grade_GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseId, t.Grade_GradeId })
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeId, cascadeDelete: true)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Grade_GradeId);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Course_CourseId })
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.TeacherGrades",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Grade_GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Grade_GradeId })
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeId, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Grade_GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Feedbacks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Feedbacks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Students", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.TeacherGrades", "Grade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.TeacherGrades", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseGrades", "Grade_GradeId", "dbo.Grades");
            DropForeignKey("dbo.CourseGrades", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherGrades", new[] { "Grade_GradeId" });
            DropIndex("dbo.TeacherGrades", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.TeacherCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.CourseGrades", new[] { "Grade_GradeId" });
            DropIndex("dbo.CourseGrades", new[] { "Course_CourseId" });
            DropIndex("dbo.Feedbacks", new[] { "CourseId" });
            DropIndex("dbo.Feedbacks", new[] { "TeacherId" });
            DropIndex("dbo.Feedbacks", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "GradeId" });
            DropIndex("dbo.Attendances", new[] { "GradeId" });
            DropIndex("dbo.Attendances", new[] { "TeacherId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropTable("dbo.TeacherGrades");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.CourseGrades");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
            DropTable("dbo.Grades");
            DropTable("dbo.Attendances");
        }
    }
}

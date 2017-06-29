using System.Linq;
using Feedback.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace Feedback.Repositories
{
    public class SchoolRepository : DbContext, ISchoolRepository
    {
        public SchoolRepository() : base("FeedbackEitities")
        {
        }

        #region properties
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Models.Feedback> Feedbacks { get; set; }
        public virtual DbSet<Attendance> Attendences { get; set; }
        public virtual DbSet<Course> Catetories { get; set; }
        public DbSet<Grade> Grades { set; get; }
        #endregion

        #region interface methods
        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Attendance> GetAttendances(int gradeId)
        {
            return Attendences.Where(a => a.Grade.GradeId == gradeId);
        }

        public IEnumerable<Models.Feedback> GetAllFeedbacks()
        {
            return Feedbacks;
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolRepository>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
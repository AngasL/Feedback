using System.Linq;
using Feedback.Models;
using System.Data.Entity;

namespace Feedback.Repositories
{
    public class SchoolRepository : DbContext, ISchoolRepository
    {
        public SchoolRepository() : base("FeedbackEitities")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Models.Feedback> Feedbacks { get; set; }
        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<Category> Catetories { get; set; }

        public DbSet<Grade> Grades { set; get; }

        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.StudentId == id);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolRepository>());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class SchoolContextInitializer : DropCreateDatabaseIfModelChanges<SchoolRepository>
    {
        protected override void Seed(SchoolRepository context)
        {
            base.Seed(context);
        }
    }
}
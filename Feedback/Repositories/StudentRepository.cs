using System.Linq;
using Feedback.Models;
using System.Data.Entity;

namespace Feedback.Repositories
{
    public class StudentRepository : DbContext, IStudentRepository
    {
        public StudentRepository() : base("FeedbackEitities")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { set; get; }

        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbContextInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<StudentRepository>
    {
        protected override void Seed(StudentRepository context)
        {
            base.Seed(context);
        }
    }
}
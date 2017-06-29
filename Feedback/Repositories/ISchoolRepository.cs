using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Repositories
{
    public interface ISchoolRepository
    {
        Student GetStudent(int id);
        IEnumerable<Attendance> GetAttendances(int gradeId);
        IEnumerable<Models.Feedback> GetAllFeedbacks();
    }
}

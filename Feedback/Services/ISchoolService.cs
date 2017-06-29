using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Services
{
    public interface ISchoolService
    {
        string GetServiceName();
        IEnumerable<Attendance> GetAttendence(int gradeId);
    }
}

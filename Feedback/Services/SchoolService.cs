using Feedback.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feedback.Models;

namespace Feedback.Services
{
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _repository;

        public SchoolService(ISchoolRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Attendance> GetAttendence(int gradeId)
        {
            return _repository.GetAttendances(gradeId);
        }

        public string GetServiceName()
        {
            return _repository.GetStudent(1)?.Name;
        }
    }
}
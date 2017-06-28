using Feedback.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.Services
{
    public class TestService : ITestService
    {
        private ISchoolRepository _repository;

        public TestService(ISchoolRepository repository)
        {
            this._repository = repository;
        }
        public string GetServiceName()
        {
            return _repository.GetStudent(1)?.Name;
        }
    }
}
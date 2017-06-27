using Feedback.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.Services
{
    public class TestService : ITestService
    {
        private IStudentRepository _repository;

        public TestService(IStudentRepository repository)
        {
            this._repository = repository;
        }
        public string GetServiceName()
        {
            return _repository.GetStudent(1)?.Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feedback.Models;
using Feedback.Repositories;

namespace Feedback.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ISchoolRepository _repository;

        public FeedbackService(ISchoolRepository reponsitory)
        {
            this._repository = reponsitory;
        }

        public IEnumerable<Models.Feedback> GetAllFeedbacks()
        {
            return _repository.GetAllFeedbacks();
        }
    }
}
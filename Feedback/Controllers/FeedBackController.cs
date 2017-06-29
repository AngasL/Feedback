using Feedback.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            this._service = service;
        }

        // GET: FeedBack
        public ActionResult Index()
        {
            var feedbacks = _service.GetAllFeedbacks();

            return View(feedbacks);
        }
    }
}
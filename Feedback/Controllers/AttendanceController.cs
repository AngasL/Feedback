using Feedback.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ISchoolService _service;

        public AttendanceController(ISchoolService service)
        {
            this._service = service;
        }
        // GET: Attendence
        [HttpGet]
        public ActionResult Index(int gradeId)
        {
            var attendances = _service.GetAttendence(gradeId);
            return View();
        }
    }
}
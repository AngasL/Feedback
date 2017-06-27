using Feedback.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class HomeController : Controller
    {
        private ITestService _service;

        public HomeController()
        {

        }

        public HomeController(ITestService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            var content = _service.GetServiceName();
            ViewBag.Content = content;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Service;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoTestService _demoTestService;
        public HomeController(IDemoTestService demoTestService)
        {
            _demoTestService = demoTestService;
        }
        public ActionResult Index()
        {
            return Content(_demoTestService.GetTestName());
        }
    }
}
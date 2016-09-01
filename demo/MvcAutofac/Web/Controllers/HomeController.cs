using MvcAutofac.Framework;
using MvcAutofac.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
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
            IDemoTestService demoService = _demoTestService;//构造器注入实例

            //demoService = EngineContext.Resolve<IDemoTestService>();//获取默认已注入实例

            //demoService = EngineContext.ResolveEnum<IDemoTestService, DemoType>(DemoType.Demo1);//通过枚举获取注入实例

            demoService = EngineContext.Resolve<IDemoTestService>(DemoType.Demo2.ToString());//通过名称

            return Content(demoService.GetTestName());

        }
    }
}
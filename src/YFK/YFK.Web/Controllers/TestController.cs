using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YFK.Core.Logger;

namespace YFK.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            #region 日志记录测试
            ILogger logger = new FileLogger();
            ILogger logger2 = new Log4netLogger();
            logger.Info("我是一条日志信息");
            logger.Debug("我是一条测试信息");
            logger2.Info("我是一条日志信息");
            logger2.Debug("我是一条测试信息");
            try
            {
                int i = 1, j = 0;
                i = i / j;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                logger2.Error(ex);
            }
            #endregion
            return View();
        }
    }
}
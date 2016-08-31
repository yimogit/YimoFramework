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
            ILogger logger = new Log4netLogger();
            WriteTestLog(logger);
            logger = new FileLogger();//bin下。
            WriteTestLog(logger);
            logger = new NLogger();
            WriteTestLog(logger);
            #endregion
            return View();
        }
        static void WriteTestLog(ILogger logger)
        {
            logger.Info("输出信息");
            logger.Debug("测试信息");
            logger.Warn("警告信息");
            try
            {
                int i = 1, j = 0;
                i = i / j;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
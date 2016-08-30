using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ILogger logger = new Log4netLogger();
            logger.Info("记录信息");
            logger.Debug("测试");
            try
            {
                int i = 0, j = 0;
                i = i / j;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return Content("");
        }

    }
}

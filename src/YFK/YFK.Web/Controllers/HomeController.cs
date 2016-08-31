using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using YFK.Core.Logger;

namespace YFK.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id = "")
        {

            string domin = Request.Headers["host"];
            //Regex r = new Regex(@"[\u4e00-\u9fa5]+");
            //Match mc = r.Match(domin);
            //if (mc.Length != 0)//含中文域名
            //{
            //    IdnMapping dd = new IdnMapping();
            //    domin = dd.GetUnicode(domin);
            //}
            IdnMapping dd = new IdnMapping();
            domin = dd.GetUnicode(domin);
            ViewBag.Domin = domin + " | "+id;
            return View();
        }
    }
}
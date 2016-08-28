using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YFK.Core.Configuration;
using YFK.MvcFramework.RouteExtensions;

namespace YFK.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string adminDomin = YFKConfig.Instance.WebSetting.AdminDomin;// "admin.yimo.dev";
            string webDomin = YFKConfig.Instance.WebSetting.MainDomin;// "www.yimo.dev";
            //上面的域名需要在IIS中绑定
            routes.MapAreaRoute(
                "YFK.Admin",
                routes.MapRouteDomain(
                    name: "domin/Admin/Home/Index",
                    domain: adminDomin,
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new string[] { "YFK.Admin.Controllers" }
                )
            );
            
            routes.MapRouteDomain(
                name: "Web/Home/Index",
                domain: webDomin,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "YFK.Web.Controllers" }
            );

        }
    }
}


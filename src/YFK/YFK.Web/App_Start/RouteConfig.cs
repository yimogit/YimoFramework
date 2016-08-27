using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YFK.MvcFramework.RouteExtensions;

namespace YFK.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            const string adminDomin="admin.yimo.dev";
            const string webDomin="www.yimo.dev";
            //上面的域名需要在IIS中绑定
            routes.MapAreaRoute(
                "YFK.Admin",
                routes.MapRouteDomain(
                    name: "Admin/Home/Index",
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


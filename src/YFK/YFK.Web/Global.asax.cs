using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YFK.MvcFramework;
using Autofac;
using Autofac.Integration.Mvc;
using YFK.Core.Logger;

namespace YFK.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //添加自定义视图引擎
            ViewEngines.Engines.Add(new YFK.MvcFramework.Themes.ThemeViewEngine());

            EngineContext.Install(e =>
            {

                e.Register<ILogger>(c => new FileLogger()).InstancePerLifetimeScope();//构造器注入
                var assembly = Assembly.GetExecutingAssembly();
                e.RegisterControllers(assembly);//注册所有Controller
            });
        }
    }
}

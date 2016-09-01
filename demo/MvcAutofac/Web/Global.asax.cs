using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcAutofac.Framework;
using MvcAutofac.Service;
using System.Reflection;
using Autofac.Core;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            EngineContext.Install(e =>
            {
                e.Register<IDemoTestService>(c => new DemoTestService()).InstancePerLifetimeScope();//构造器注入
                e.RegisterType<DemoTestService>().Keyed<IDemoTestService>(DemoType.Demo1);//枚举注入
                e.RegisterType<DemoTestService2>().Named<IDemoTestService>(DemoType.Demo2.ToString());//根据Name值注册
                var assembly = Assembly.GetExecutingAssembly();
                e.RegisterControllers(assembly);//注册所有Controller
            });
        }
    }
}

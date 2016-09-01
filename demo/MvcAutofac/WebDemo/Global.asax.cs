using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebDemo.Service;
using Autofac;
using Autofac.Integration.Mvc;

namespace WebDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterType<DemoTestService>();
            builder.Register<IDemoTestService>(c => new DemoTestService()).InstancePerLifetimeScope();

            var assembly = Assembly.GetExecutingAssembly();
            //注册所有Controller
            builder.RegisterControllers(assembly).PropertiesAutowired();//PropertiesAutowired();可使用属性注入
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}

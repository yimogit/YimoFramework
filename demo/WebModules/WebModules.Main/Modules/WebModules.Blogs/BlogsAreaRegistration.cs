using System.Web.Mvc;

namespace WebModules.Blogs
{
    /// <summary>
    /// blogs模块路由注册
    /// </summary>
    public class BlogsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WebModules.Blogs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WebModules.Blogs",
                "blogs/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new string[] { "WebModules.Blogs.Controllers" }
            );
        }
    }
}

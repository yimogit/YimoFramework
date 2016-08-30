using System.Collections.Generic;
using System.Web.Mvc;

namespace WebModules.Core.Themes
{
    /// <summary>
    /// 自定义视图引擎
    /// </summary>
    /// <remarks>
    /// ViewEngines.Engines.Add(new MvcProjectMain.AreasViewEngine.ThemableRazorViewEngine());
    /// </remarks>
    public class ThemableRazorViewEngine : RazorViewEngine
    {
        //所有区域分离到Modules文件夹,{2}为区域名
        public ThemableRazorViewEngine()
        {
            ViewEngines.Engines.Clear();
            AreaViewLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml",
            };

            AreaMasterLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml",
            };

            AreaPartialViewLocationFormats = new[]
            {
               "~/Modules/{2}/Views/{1}/{0}.cshtml", 
               "~/Modules/{2}/Views/Shared/{0}.cshtml", 
            };

            ViewLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml",
            };

            MasterLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml", 
            };
            PartialViewLocationFormats = new[]
            {
               "~/Views/{1}/{0}.cshtml", 
               "~/Views/Shared/{0}.cshtml", 
            };

            FileExtensions = new[] { "cshtml" };
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YFK.MvcFramework.Themes
{ 
    /// <summary>
    /// 自定义视图引擎
    /// </summary>
    /// <remarks>
    /// 需要并在Gloabl.asax中添加自定义视图引擎
    /// </remarks>
    public class ThemeViewEngine : RazorViewEngine
    {
        public ThemeViewEngine()
        {
            ViewEngines.Engines.Clear();//移除默认的视图查找
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom.View
{
    public class MyCustomVirtualPathProviderViewEngine : VirtualPathProviderViewEngine // IViewEngine
    {
        public MyCustomVirtualPathProviderViewEngine()
        {
            this.ViewLocationFormats = new string[]
            { "~/Views/{1}/{2}", "~/Views/Shared/{2}" };
            this.PartialViewLocationFormats = new string[]
            { "~/Views/{1}/{2}", "~/Views/Shared/{2}" };
        }
        protected override IView CreatePartialView
        (ControllerContext controllerContext, string partialPath)
        {
            var physicalpath =
            controllerContext.HttpContext.Server.MapPath(partialPath);
            return new MyCustomView(physicalpath);
        }
        protected override IView CreateView
        (ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new MyCustomView(physicalpath);
        }
    }
}
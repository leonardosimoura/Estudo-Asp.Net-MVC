using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyCustomExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, filterContext.Controller.GetType().ToString(),"Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "CustomError",
                ViewData = new ViewDataDictionary(model)
            };            
        }
    }
}
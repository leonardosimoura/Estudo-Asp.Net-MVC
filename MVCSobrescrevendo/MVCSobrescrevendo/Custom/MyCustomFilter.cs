using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyCustomFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {

            
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }

    public class MyCustomFilter2 : ActionFilterAttribute
    {
        Guid IdExecucao;
        public MyCustomFilter2()
        {
           
        }

        //
        // Summary:
        //     Called by the ASP.NET MVC framework after the action method executes.
        //
        // Parameters:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
            var action = filterContext.ActionDescriptor.ActionName;
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //Poderia Chama algum metodo do HD insights ou da google para rastrear usando IdExecucao
            IdExecucao = Guid.NewGuid(); // Reseta o IdExecucao
            base.OnActionExecuted(filterContext);
        }

        //
        // Summary:
        //     Called by the ASP.NET MVC framework before the action method executes.
        //
        // Parameters:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IdExecucao = Guid.NewGuid(); // Reseta o IdExecucao
            var action = filterContext.ActionDescriptor.ActionName;
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            
            base.OnActionExecuting(filterContext);
        }

        //
        // Summary:
        //     Called by the ASP.NET MVC framework after the action result executes.
        //
        // Parameters:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
          
            base.OnResultExecuting(filterContext);
        }

        //
        // Summary:
        //     Called by the ASP.NET MVC framework before the action result executes.
        //
        // Parameters:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyCustomResultFilter : IResultFilter
    {
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
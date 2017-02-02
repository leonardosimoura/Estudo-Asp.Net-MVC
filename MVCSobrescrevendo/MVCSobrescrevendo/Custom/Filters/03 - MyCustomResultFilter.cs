using System;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom.Filters
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
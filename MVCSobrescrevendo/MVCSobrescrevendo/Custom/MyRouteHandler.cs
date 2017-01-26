using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MVCSobrescrevendo.Custom
{
    public class MyRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string importantValue = requestContext.HttpContext.Request.Browser.Browser;
            if (!string.IsNullOrWhiteSpace(importantValue))
            {
                requestContext.RouteData.Values["action"] = importantValue +
                requestContext.RouteData.Values["action"];
            }

            return base.GetHttpHandler(requestContext);
        }

        protected override SessionStateBehavior GetSessionStateBehavior(RequestContext requestContext)
        {
            return base.GetSessionStateBehavior(requestContext);
        }
    }

    public class MyRouteHandler2 : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            throw new NotImplementedException();
        }
    }
}
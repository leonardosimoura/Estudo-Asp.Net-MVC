using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyCustomAuthorizationFilter : IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
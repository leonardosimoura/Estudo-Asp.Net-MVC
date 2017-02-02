using System;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom.Filters
{
    public class MyCustomAuthorizationFilter : IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
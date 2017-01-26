using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSobrescrevendo.Custom
{
    public class MyHttpModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {
            throw new NotImplementedException();
        }

        void IHttpModule.Init(HttpApplication context)
        {
            throw new NotImplementedException();
        }
    }
}
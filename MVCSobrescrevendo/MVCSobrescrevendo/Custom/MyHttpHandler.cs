using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSobrescrevendo.Custom
{
    public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
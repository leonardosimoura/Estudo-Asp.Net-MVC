using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSobrescrevendo.Custom
{
    public class MyHttpHandler : IHttpHandler
    {
        // <system.webServer>
        //    <handlers><add verb = "*" path="*.sample" name="HelloWorldHandler"type="HelloWorldHandler"/></handlers>
        // </system.webServer>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var t = context;
        }
    }
}
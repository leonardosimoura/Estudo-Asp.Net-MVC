using System.Web;

namespace MVCSobrescrevendo.Custom.HttpHandler
{
    public class MyCustomHttpHandler : IHttpHandler
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
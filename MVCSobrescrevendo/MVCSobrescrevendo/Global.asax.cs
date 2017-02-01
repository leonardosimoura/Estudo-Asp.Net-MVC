using MVCSobrescrevendo.Custom;
using MVCSobrescrevendo.Custom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCSobrescrevendo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new MyCustomControllerFactory("MVCSobrescrevendo.Controllers"));


            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder("pt-BR"));
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder("pt-BR"));

            ModelBinders.Binders.DefaultBinder = new MyCustomModelBinder();

            ViewEngines.Engines.Add(new MyCustomVirtualPathProviderViewEngine());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exception = Server.GetLastError();
            //Server.ClearError();
            //Response.Redirect("/Home/Error");
        }
    }
}

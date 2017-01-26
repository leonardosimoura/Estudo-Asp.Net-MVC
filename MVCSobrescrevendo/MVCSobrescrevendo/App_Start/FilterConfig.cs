using MVCSobrescrevendo.Custom;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new MyExceptionFilter());

            filters.Add(new MyCustomFilter2());


        }
    }
}

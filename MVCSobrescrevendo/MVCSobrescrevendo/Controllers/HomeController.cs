using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Controllers
{
    public class HomeController : Controller
    {
        private string mensagem;
        public HomeController(string mensagem)
        {
            this.mensagem = mensagem;
        }
        public ActionResult Index()
        {
            ViewBag.Mensagem = mensagem;
            return View();
        }

        //add no webConfig  <system.web> <customErrors mode="On"/>
        [HandleError(ExceptionType = typeof(NotImplementedException), View = "Error" )]
        [HandleError(ExceptionType = typeof(DivideByZeroException), View = "ErrorDivideByZero")]
        
        public ActionResult About()
        {
            //throw new NotImplementedException();
            var erro = 1 / Convert.ToInt32(0);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [RequireHttps]        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
using MVCViews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormPadrao(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                return View("Index", model);
            }

            return View("Index");
        }
        [HttpPost]
        public ActionResult FormAjax(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //return Json(model);
            }
            ViewBag.Message = "Retorno de Partial";
            return PartialView("_alertSucess");
        }

        public JsonResult RemoteValidation(string Senha)
        {

            if (Senha == "123456")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json("Senha tem que ser 123456", JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult CarregarPartial(LoginViewModel model)
        {
            //throw new NotImplementedException();

            return PartialView("_PartialLogin", model);
        }

        [ChildActionOnly] // @Html.Action("CarregarChilddAction")
        public ActionResult CarregarChildAction()
        {

            return PartialView("_CarregarChildAction");
        }
        
        [NonAction] 
        /* Por Default todos os metodos são acessados pela url ( Pois o MVC utiliza a System.Reflection internamente )
         * com NonAction isso não ocorre com esse metodo
        */
        public int MetodoTeste()
        {
            return 1;
        }
    }
}
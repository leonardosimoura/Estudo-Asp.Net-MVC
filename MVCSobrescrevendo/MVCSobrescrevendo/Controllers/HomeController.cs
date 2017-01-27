using MVCSobrescrevendo.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        //Olhar nas rotas
        // Url /Home/Index/1/2
        public ActionResult ChromeIndex(string id , string id2)
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


        
        public ActionResult ModelBinder()
        {

            var listaAno = new List<string>();

            for (int i = 1950; i <= 2017; i++)
            {
                listaAno.Add(i.ToString());
            }

            ViewBag.Ano = new SelectList(listaAno);

            var listaMes = new List<object>();
            for (int i = 1; i < 13; i++)
            {
                listaMes.Add(new { Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), MesValor = 1 });
            }

            ViewBag.Mes = new SelectList(listaMes, "MesValor", "Mes");

            var listaDia = new List<string> ();

            for (int i = 1; i <= 30; i++)
            {
                listaDia.Add(i.ToString());
            }

            ViewBag.Dia = new SelectList(listaDia);


            return View();
        }


        public ActionResult HtmlHelper()
        {
            var lista = new List<UsuarioAniversario>();

            lista.Add(new UsuarioAniversario() { Usuario = "Leonardo", DataAniversario = new DateTime(1992, 11, 06) });
            lista.Add(new UsuarioAniversario() { Usuario = "Leonardo", DataAniversario = new DateTime(1992, 11, 06) });
            lista.Add(new UsuarioAniversario() { Usuario = "Leonardo", DataAniversario = new DateTime(1992, 11, 06) });
            lista.Add(new UsuarioAniversario() { Usuario = "Leonardo", DataAniversario = new DateTime(1992, 11, 06) });

            return View(lista);
        }

        [HttpPost]
        public ActionResult ModelBinder(UsuarioAniversario model)
        {
            return RedirectToAction("Index");
        }

    }
}
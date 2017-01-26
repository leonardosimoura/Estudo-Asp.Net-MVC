using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext contContext, ModelBindingContext bindContext, PropertyDescriptor propDesc)
        {
            if (propDesc.PropertyType == typeof(DateTime))
            {
                if (!string.IsNullOrEmpty(contContext.HttpContext.Request.Form[propDesc.Name + "Ano"]))
                {
                    var ano = int.Parse(contContext.HttpContext.Request.Form[propDesc.Name + "Ano"]);
                    var mes = int.Parse(contContext.HttpContext.Request.Form[propDesc.Name + "Mes"]);
                    var dia = int.Parse(contContext.HttpContext.Request.Form[propDesc.Name + "Dia"]);

                    var hora = 0;
                    var minuto = 0;
                    var segundo = 0;

                    int.TryParse(contContext.HttpContext.Request.Form[propDesc.Name + "Hora"], out hora);
                    int.TryParse(contContext.HttpContext.Request.Form[propDesc.Name + "Minuto"], out minuto);
                    int.TryParse(contContext.HttpContext.Request.Form[propDesc.Name + "Segundo"], out segundo);

                    DateTime data = new DateTime(ano, mes, dia, hora, minuto, segundo);
                    propDesc.SetValue(bindContext.Model, data);
                    return;
                }

            }

            base.BindProperty(contContext, bindContext, propDesc);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom.ModelBinder
{
    //Com o nome da Classe : ClassModelBinder
    public class DateTimeModelBinder : IModelBinder
    {
        private string cultureInfo;

        public DateTimeModelBinder(string cultureInfo)
        {
            this.cultureInfo = cultureInfo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != null)
            {
                var date = valueProviderResult.AttemptedValue;
                var ms = new ModelState();
                ms.Value = valueProviderResult;
                bindingContext.ModelState.Add(new KeyValuePair<string, ModelState>(bindingContext.ModelName, ms));

                if (String.IsNullOrWhiteSpace(date))
                    return null;

                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
                DateTime datetime;

                if (DateTime.TryParse(date, Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out datetime))
                {
                    return datetime;
                }
                else
                {
                    ms.Errors.Add(String.Format("Valor {0} inválido para {1}", date, bindingContext.ModelName));
                    return null;
                }
            }
            return null;
        }
    }
}
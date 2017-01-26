using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MVCSobrescrevendo.Custom
{
    public class MyControllerFactory : IControllerFactory
    {

        private readonly string _controllerNamespace;
        public MyControllerFactory(string controllerNamespace)
        {
            _controllerNamespace = controllerNamespace;
        }
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
           
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));

            var construtores = controllerType.GetConstructors().ToList();            

            var construtor = construtores.First();
            
            var parametros = construtor.GetParameters().ToList();

            IController controller = null;

            if (parametros.Count > 0)
            {
                var listObj = new List<object>();

                foreach (var item in parametros)
                {
                    object obj = null;

                    if (item.ParameterType == typeof(string))
                    {
                        obj = "Criado Pela MyControllerFactory";
                    }
                    else if (item.ParameterType == typeof(int))
                    {
                        obj = 150;
                    }
                    else if (item.ParameterType == typeof(decimal))
                    {
                        obj = decimal.Parse("100");
                    }
                    else if (item.ParameterType == typeof(float))
                    {
                        obj = float.Parse("50");
                    }

                    listObj.Add(obj);
                }

                controller = Activator.CreateInstance(controllerType, listObj.ToArray()) as Controller;
            }
            else
            {
                controller = Activator.CreateInstance(controllerType) as Controller;
            }
            
           
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
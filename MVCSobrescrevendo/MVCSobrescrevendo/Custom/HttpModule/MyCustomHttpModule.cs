using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSobrescrevendo.Custom
{
    public class MyCustomHttpModule : IHttpModule
    {
        //IHttpModule Vem antes Do IHttpHandler
        //<modules>
        //  <add name = "MyHttpModule" type="MVCSobrescrevendo.Custom.MyHttpModule" />
        //</modules>
        void IHttpModule.Dispose()
        {
            
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(end_request);
            context.BeginRequest += new EventHandler(begin_request);
            context.LogRequest += new EventHandler(log_request);
        }

        public void log_request(object sender, EventArgs e)
        {
            //Log operation goes here

            HttpContext context = ((HttpApplication)sender).Context;
            string url = context.Request.Path;
        }
        public void begin_request(object sender, EventArgs e)
        {
            //Log operation goes here
            HttpContext context = ((HttpApplication)sender).Context;
        }
        public void end_request(object sender, EventArgs e)
        {
            //Log operation goes here
            HttpContext context = ((HttpApplication)sender).Context;
        }
    }
}
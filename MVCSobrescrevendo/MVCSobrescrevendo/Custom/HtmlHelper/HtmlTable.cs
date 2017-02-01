using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc.Html;

namespace System.Web.Mvc.Html //<<<<
{
    public static class HtmlTable
    {

        public static MvcHtmlString Table<T>(this HtmlHelper html, IEnumerable<T> items)
        {
            var type = typeof(T);

            if (items == null)
            {
                items = new List<T>();
            }

            var table = new StringBuilder();

            table.Append(@"<table class='table table-bordered table-hovered'>");
            table.Append("<tr>");

            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttributes(typeof(DisplayAttribute),false).Any())
                {
                    var attr = prop.GetCustomAttributes(typeof(DisplayAttribute), false).First() as DisplayAttribute;
                    table.Append("<th>" + attr.Name + " </th>");
                }
                else
                {
                    table.Append("<th>" + prop.Name + " </th>");
                }
            }

            table.Append("<th> </th>");
            table.Append("<tr>");
            foreach (var item in items)
            {
                table.Append("<tr>");
                foreach (var prop in type.GetProperties())
                {
                    if (prop.GetCustomAttributes(typeof(DisplayFormatAttribute), false).Any())
                    {
                        var attr = prop.GetCustomAttributes(typeof(DisplayFormatAttribute), false).First() as DisplayFormatAttribute;
                        table.Append("<td>" +  String.Format(attr.DataFormatString, prop.GetValue(item)) + " </td>");
                    }
                    else
                    {
                        table.Append("<td>" + prop.GetValue(item).ToString() + " </td>");
                    }                    
                }

                table.Append(@"
                 <td>
                    " + html.ActionLink("Edit", "Edit").ToHtmlString() + " | " +
                        html.ActionLink("Details", "Details").ToHtmlString() + " | " +
                        html.ActionLink("Delete", "Delete").ToHtmlString() + " | " + 
                "</td>");
                table.Append("</tr>");
            }

            table.Append("<tr>");
            table.Append("</table>");
            return MvcHtmlString.Create(table.ToString());
        }

        public static MvcHtmlString Table<T>(this HtmlHelper html, IEnumerable<T> items, params string[] propriedades)
        {
            var type = typeof(T);

            if (items == null)
            {
                items = new List<T>();
            }

            var table = new StringBuilder();

            table.Append(@"<table class='table table-bordered table-hovered'>");
            table.Append("<tr>");

            foreach (var prop in type.GetProperties().Where(w => propriedades.ToList().Contains(w.Name)))
            {
                if (prop.GetCustomAttributes(typeof(DisplayAttribute), false).Any())
                {
                    var attr = prop.GetCustomAttributes(typeof(DisplayAttribute), false).First() as DisplayAttribute;
                    table.Append("<th>" + attr.Name + " </th>");
                }
                else
                {
                    table.Append("<th>" + prop.Name + " </th>");
                }
            }

            table.Append("<th> </th>");
            table.Append("<tr>");
            foreach (var item in items)
            {
                table.Append("<tr>");
                foreach (var prop in type.GetProperties().Where(w => propriedades.ToList().Contains(w.Name)))
                {
                    table.Append("<td>" + prop.GetValue(item).ToString() + " </td>");
                }
                table.Append(@"
                 <td>
                    " + html.ActionLink("Edit", "Edit").ToHtmlString() + " | " +
                        html.ActionLink("Details", "Details").ToHtmlString() + " | " +
                        html.ActionLink("Delete", "Delete").ToHtmlString() + " | " +
                "</td>");
                table.Append("</tr>");
            }

            table.Append("<tr>");
            table.Append("</table>");
            return MvcHtmlString.Create(table.ToString());
        }
    }
}
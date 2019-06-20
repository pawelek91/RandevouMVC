using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandevouMVC.Controllers
{
    public class AuthorizedOnlyAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string apiKey = null;
            var session = context.HttpContext.Session;
            if (session != null)
                apiKey = session.GetString("ApiKey");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                context.Result = new RedirectResult("/Authentication/");
                context.HttpContext.Response.Redirect("/Authentication/");
            }
        }
    }
}

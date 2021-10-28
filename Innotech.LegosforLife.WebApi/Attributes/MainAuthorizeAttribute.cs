using System;
using InnoTech.LegosForLife.Security.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InnoTech.LegosForLife.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MainAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var loginUser = context.HttpContext.Items["LoginUser"];
            if (loginUser == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
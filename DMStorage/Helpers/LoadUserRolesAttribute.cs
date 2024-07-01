using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace DMStorage.Helpers
{
    public class LoadUserRolesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var rolesString = httpContext.Session.GetString("UserRoles");
            var roles = rolesString != null ? new List<string>(rolesString.Split(',')) : new List<string>();

            if (context.Controller is Controller controller)
            {
                controller.ViewData["UserRoles"] = roles;
            }

            base.OnActionExecuting(context);
        }
    }
}
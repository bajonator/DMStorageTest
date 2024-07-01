using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DMStorage.Helpers
{
    public static class UserRoleHelper
    {
        public static List<string> GetUserRoles(HttpContext httpContext)
        {
            var rolesString = httpContext.Session.GetString("UserRoles");
            return rolesString != null ? new List<string>(rolesString.Split(',')) : new List<string>();
        }
    }
}

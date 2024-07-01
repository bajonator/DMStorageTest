using DMStorage.Core.Models.Domains;
using Microsoft.AspNetCore.Http;

namespace DMStorage.Helpers
{
    public class SetSession
    {
        public static void Session(HttpContext httpContext, User user)
        {
            var roles = user.Role != null ? user.Role.Name : string.Empty;
            httpContext.Session.SetString("UserRoles", roles);
            httpContext.Session.SetInt32("UserId", user.Id);
            httpContext.Session.SetString("UserName", user.Username);
            httpContext.Session.SetString("UserEmail", user.Email);
        }
    }
}

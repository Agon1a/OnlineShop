using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlineShop.Lib
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public CustomAuthorizationFilterAttribute() {}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorized(context.HttpContext.User))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
                return;
            }
        }

        /// <summary>
        /// Check is user Authorized
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool IsAuthorized(ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }
    }
}

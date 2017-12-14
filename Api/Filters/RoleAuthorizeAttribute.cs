using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.AspNet.Identity;

namespace Api.Filters
{
    public sealed class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var claimsIdentity = (ClaimsIdentity)actionContext.RequestContext.Principal.Identity;
            if (claimsIdentity.IsAuthenticated)
            {
                var roles = Roles.Split(',');
                string claimRole = claimsIdentity.FindFirstValue("RoleName");
                if (roles.Contains(claimRole))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
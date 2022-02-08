using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Happibook.Core.Constant;
using Happibook.Core.Infrastructure;
using UserPermission = Happibook.Core.Enum.UserPermissions;

namespace Happibook.Core.Attribute
{
    public class CanAccessAttribute : ActionFilterAttribute
    {
        private UserPermission[] userPermission;

        public CanAccessAttribute(params UserPermission[] userPermission)
        {
            this.userPermission = userPermission;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var loggedInUser = ((ClaimsIdentity)((ClaimsPrincipal)HttpContext.Current.User).Identity).Claims;
            var loggedInUserRole = loggedInUser.Where(c => c.Type == ClaimTypes.Role)
                                        .Select(c => c.Value)
                                        .FirstOrDefault();

            if (!Security.HasRights(this.userPermission, loggedInUserRole))
            {
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.Forbidden, Message.UnAuthrized);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Happibook.Core.Attribute
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private static string token = ConfigurationManager.AppSettings["AnonymousApiToken"].ToString();

        public CustomAuthorize()
        {
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
            {
                return;
            }

            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization == null)
            {
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }

            var token = actionContext.Request.Headers.Authorization.Parameter;
            var isAuthentic = ((System.Security.Claims.ClaimsIdentity)((System.Security.Claims.ClaimsPrincipal)HttpContext.Current.User).Identity).IsAuthenticated;

            if (!isAuthentic)
            {
                this.HandleUnauthorizedRequest(actionContext);
                return;
            }
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            actionContext.Response = challengeMessage;
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()) && Authorize(actionContext);
        }

        private static bool Authorize(HttpActionContext actionContext)
        {
            IEnumerable<string> values;
            try
            {
                if (actionContext.Request.Headers.GetValues("token") != null)
                {
                    if (actionContext.Request.Headers.TryGetValues("token", out values) && values.First() == token)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}

using System.Web.Http.Filters;
using Happibook.Common.Helper;

namespace Happibook.Core.Attribute
{
    public sealed class ValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            foreach (var item in actionContext.ActionArguments)
            {
                item.Value.IsValid();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}

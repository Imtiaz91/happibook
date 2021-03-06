using Happibook.Common.Helper;
using System.Web.Http.Filters;

namespace Happibook.Common.Attribute
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

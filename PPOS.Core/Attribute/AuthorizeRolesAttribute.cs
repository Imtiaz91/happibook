using System.Web.Http;
using Happibook.Core.Enum;

namespace Happibook.Core.Attribute
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserRoles[] roles)
            : base()
        {
            this.Roles = string.Join(",", roles);
        }
    }
}

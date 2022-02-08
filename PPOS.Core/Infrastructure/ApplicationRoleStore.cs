using Happibook.Core.DBContext;
using Happibook.Core.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Happibook.Core.Infrastructure
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, string, ApplicationUserRole>
    {
        public ApplicationRoleStore(HappibookContext context) : base(context)
        {
        }

        public ApplicationRoleStore(ISSHRequestInfo requestInfo) : base(requestInfo.Context)
        {
        }
    }
}

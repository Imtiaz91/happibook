using Happibook.Core.DBContext;
using Happibook.Core.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Happibook.Core.Infrastructure
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, ApplicationUserRole, IdentityUserClaim>
    {
        public ApplicationUserStore(ISSHRequestInfo requestInfo) : base(requestInfo.Context)
        {
        }

        public ApplicationUserStore(HappibookContext context) : base(context)
        {
        }
    }
}
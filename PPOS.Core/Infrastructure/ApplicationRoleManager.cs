using Happibook.Core.Entity;
using Microsoft.AspNet.Identity;

namespace Happibook.Core.Infrastructure
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore roleStore) : base(roleStore)
        {
        }
    }   
}

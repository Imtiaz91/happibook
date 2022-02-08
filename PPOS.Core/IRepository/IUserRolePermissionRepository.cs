using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface IUserRolePermissionRepository : IRepository<UserRolePermission, int>
    {
        Task<List<string>> GetUserPermissions(List<string> roles);

        bool IsUserPermitted(string roleId, List<int> permissionId);
    }
}

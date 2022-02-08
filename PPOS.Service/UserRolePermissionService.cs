using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class UserRolePermissionService : Service<IUserRolePermissionRepository, UserRolePermission, UserRolePermissionDTO, int>, IUserRolePermissionService
    {
        private ISSHUnitOfWork unitOfWork;

        public UserRolePermissionService(ISSHUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRolePermissionRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool GetUserPermissionsByRole(string roleId, List<int> permissionId)
        {
            var result = this.Repository.IsUserPermitted(roleId, permissionId);
            return result;
        }

        public async Task<string> GetUserRolePermissions(List<string> roles)
        {
            var result = await this.Repository.GetUserPermissions(roles);
            return string.Join(",", result.ToArray());
        }
        
        #region Private Function

        #endregion
    }
}

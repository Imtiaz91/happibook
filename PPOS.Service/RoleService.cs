using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class RoleService : Service<IRoleRepository, ApplicationRole, RoleDTO, string>, IRoleService
    {
        private ISSHRequestInfo requestInfo;
        private ApplicationRoleManager manager;
       private IPermissionService permissionService;
      //  private IUserRolePermissionService userRolePermissionService;
        private IExceptionHelper exceptionHelper;

        public RoleService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IPermissionService permissionService,
            IUserRolePermissionService userRolePermissionService,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.RoleRepository)
        {
            this.requestInfo = requestInfo;
            this.permissionService = permissionService;
            //this.userRolePermissionService = userRolePermissionService;
            this.exceptionHelper = exceptionHelper;
            this.manager = new ApplicationRoleManager(new ApplicationRoleStore(this.requestInfo));
        }

        public override async Task<IList<RoleDTO>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            
            return result
                .Where(x => 
                    x.Name.Trim() != UserRoles.None.ToString())
                    .ToList();
        }

        public override async Task<RoleDTO> CreateAsync(RoleDTO dtoObject)
        {
            RoleDTO result = new RoleDTO();
           var roleExists = await this.Repository.GetByName(dtoObject.Name);
            if (roleExists != null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.AlreadyExist, "Role"));
            }

            var isRoleCreated = await this.manager.CreateAsync(new ApplicationRole { Name = dtoObject.Name, RoleCategoryId = dtoObject.RoleCategoryId, CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow });
            if (isRoleCreated.Succeeded)
           {
                var role = await this.Repository.GetByName(dtoObject.Name);
                return dtoObject;
            }
                //this.exceptionHelper.ThrowAPIException(isRoleCreated.Errors.FirstOrDefault());
                return null;
        }

        public override async Task<RoleDTO> UpdateAsync(RoleDTO dtoObject)
        {
            var role = await this.Repository.GetAsync(dtoObject.Id);
            if (role == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Role"));
            }

            role.Name = dtoObject.Name;
            var isRoleUpdate = await this.manager.UpdateAsync(role);
            //if (isRoleUpdate.Succeeded)
            //{
            //    if (role.UserRolePermission != null && role.UserRolePermission.Count() > 0)
            //    {
            //        var userRolePermissionIds = role.UserRolePermission.Select(x => x.Id).ToList();
            //        await this.userRolePermissionService.DeleteAsync(userRolePermissionIds);
            //    }

            //    foreach (var item in dtoObject.UserRolePermissions)
            //    {
            //        item.RoleId = role.Id;
            //    }

            //    await this.userRolePermissionService.CreateAsync(dtoObject.UserRolePermissions);
            //    return dtoObject;
            //}

            this.exceptionHelper.ThrowAPIException(isRoleUpdate.Errors.FirstOrDefault());
            return null;
        }

        public async Task<IList<PermissionDTO>> GetPermissions()
        {
            return await this.permissionService.GetAllAsync();
        }
    }
}

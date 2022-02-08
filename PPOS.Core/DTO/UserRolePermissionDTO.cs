using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class UserRolePermissionDTO : DTO<UserRolePermission, int>
    {
        public int PermissionId { get; set; }

        public string RoleId { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(UserRolePermission entity)
        {
            base.ConvertFromEntity(entity);
            this.PermissionId = entity.PermissionID;
            this.RoleId = entity.RoleID;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override UserRolePermission ConvertToEntity(UserRolePermission entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.RoleID = this.RoleId;
            entity.PermissionID = this.PermissionId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}

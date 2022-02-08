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
    public class RoleDTO : DTO<ApplicationRole, string>
    {
        public string Name { get; set; }

        public int? RoleCategoryId { get; set; }

        public string RoleCategoryName { get; set; }

        //public List<UserRolePermissionDTO> UserRolePermissions { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(ApplicationRole entity)
        {
            base.ConvertFromEntity(entity);

            this.Id = entity.Id;
            this.Name = entity.Name;
            this.RoleCategoryId = entity.RoleCategoryId != null ? entity.RoleCategoryId : (int?)null;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            if (entity.RoleCategory != null)
            {
                this.RoleCategoryName = entity.RoleCategory.Name;
                //this.ApplicationUserDoctorContactNumber = entity.ApplicationUserDoctor.CellNumber;
            }
        }

        public override ApplicationRole ConvertToEntity(ApplicationRole entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.RoleCategoryId = this.RoleCategoryId;
            return entity;
        }
    }
}

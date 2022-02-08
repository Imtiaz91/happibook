using System;
using System.Threading.Tasks;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class RoleCategoryDTO : DTO<RoleCategory, int>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public string CreatedOn { get; set; }

        public override void ConvertFromEntity(RoleCategory entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.Active = entity.Active;
        }

        public override RoleCategory ConvertToEntity(RoleCategory entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Active = this.Active;
            return entity;
        }    
    }
}
using System;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class CityDTO : DTO<City, int>
    {
        public string Name { get; set; }

        public int? StateId { get; set; }

        public bool Active { get; set; }

        public override void ConvertFromEntity(City entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.StateId = entity.StateId; 
            this.Active = entity.Active;           
        }

        public override City ConvertToEntity(City entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.StateId = (this.StateId != null && this.StateId != null) ? this.StateId : null;
            entity.Active = this.Active;
          
            return entity;
        }
    }   
}

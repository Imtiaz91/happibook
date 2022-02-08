using System;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
   public class CountryDTO : DTO<Country, int>
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public override void ConvertFromEntity(Country entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Active = entity.Active;
        }

        public override Country ConvertToEntity(Country entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Active = this.Active;

            return entity;
        }
    }
}
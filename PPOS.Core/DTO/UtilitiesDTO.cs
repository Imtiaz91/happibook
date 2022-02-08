using System;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class UtilitiesDTO : DTO<Utilities, int>
    {
        public string Name { get; set; }

        public override void ConvertFromEntity(Utilities entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
        }

        public override Utilities ConvertToEntity(Utilities entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            return entity;
        }
    }
}
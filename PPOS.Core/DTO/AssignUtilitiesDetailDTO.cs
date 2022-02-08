using System;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class AssignUtilitiesDetailDTO : DTO<AssignUtilitiesDetail, int>
    {
        public int AssignUtilitiesId { get; set; }

        public int UtilitiesId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Charges { get; set; }

        public override void ConvertFromEntity(AssignUtilitiesDetail entity)
        {
            base.ConvertFromEntity(entity);
            this.AssignUtilitiesId = entity.AssignUtilitiesId;
            this.UtilitiesId = entity.UtilitiesId;
            this.Charges = entity.Charges;
            this.CreatedOn = entity.CreatedOn;
        }

        public override AssignUtilitiesDetail ConvertToEntity(AssignUtilitiesDetail entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.AssignUtilitiesId = this.AssignUtilitiesId;
            entity.Charges = this.Charges;
            entity.UtilitiesId = this.UtilitiesId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}
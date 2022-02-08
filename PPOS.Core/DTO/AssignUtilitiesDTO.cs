using System;
using System.Collections.Generic;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class AssignUtilitiesDTO : DTO<AssignUtilities, int>
    { 
        public int VechileId { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public IList<AssignUtilitiesDetailDTO> AssignUtilitiesDetail { get; set; }

        public override void ConvertFromEntity(AssignUtilities entity)
        {
            base.ConvertFromEntity(entity);
            this.AssignUtilitiesDetail = entity.AssignUtilitiesDetail != null ? AssignUtilitiesDetailDTO.ConvertEntityListToDTOList<AssignUtilitiesDetailDTO>(entity.AssignUtilitiesDetail) : null;
            this.VechileId = entity.VechileId;
            this.AssignDate = entity.AssignDate;
            this.CreatedOn = entity.CreatedOn;
        }

        public override AssignUtilities ConvertToEntity(AssignUtilities entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.AssignUtilitiesDetail = this.AssignUtilitiesDetail != null ? AssignUtilitiesDetailDTO.ConvertDTOListToEntity(this.AssignUtilitiesDetail) : null;
            entity.VechileId  = this.VechileId;
            entity.AssignDate = this.AssignDate;

            return entity;
        }
    }
}
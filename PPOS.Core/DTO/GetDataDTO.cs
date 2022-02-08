using System;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class GetDataDTO : DTO<UnitOfMeasurement, int> // this is use only for get data through EF
    {
        public string Candidate { get; set; }

        public string JobTitle { get; set; }

        public string HiringManager { get; set; }

        public string WorkFlow { get; set; }

        public double TotalPosition { get; set; }

        public DateTime CreatJobdate { get; set; }

        public DateTime LastDate { get; set; }

        public string Status { get; set; }

        public double TotalCandidate { get; set; }

        public override void ConvertFromEntity(UnitOfMeasurement entity)
        {
            base.ConvertFromEntity(entity);         
        }

        public override UnitOfMeasurement ConvertToEntity(UnitOfMeasurement entity)
        {
            entity = base.ConvertToEntity(entity);

            return entity;
        }
    }   
}

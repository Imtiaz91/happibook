using System;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class LisenceDTO : DTO<Lisence, int>
    {
        public string LicenceNumber { get; set; }

        public int? TempPincode { get; set; }

        public int? NoOfUsers { get; set; }

        public int? ValidityPeriod { get; set; }

        public DateTime? ExpirtDate { get; set; }

        public int? GracePeriod { get; set; }

        public CommonActiveStatus Status { get; set; }

        public override void ConvertFromEntity(Lisence entity)
        {
            base.ConvertFromEntity(entity);
            this.LicenceNumber = entity.LicenceNumber;
            this.TempPincode = entity.TempPincode;
            this.NoOfUsers = entity.NoOfUsers;
            this.ValidityPeriod = entity.ValidityPeriod;
            this.ExpirtDate = entity.ExpirtDate;
            this.GracePeriod = entity.GracePeriod;
            this.Status = (CommonActiveStatus)entity.Status;
        }

        public override Lisence ConvertToEntity(Lisence entity)
        {
            entity = base.ConvertToEntity(entity);
            //this.Status = CommonActiveStatus.InActive;
            entity.NoOfUsers = this.NoOfUsers;
            entity.ValidityPeriod = this.ValidityPeriod;
            entity.Status = (int)this.Status;

            return entity;
        }
    }
}
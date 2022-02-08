using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class Lisence : EntityBase<int>
    {
        public Lisence()
        {
        }

        public string LicenceNumber { get; set; }

        public int? TempPincode { get; set; }

        public int? NoOfUsers { get; set; }

        public int? ValidityPeriod { get; set; }

        public DateTime? ExpirtDate { get; set; }

        public int? GracePeriod { get; set; }

        public int Status { get; set; }
    }
}

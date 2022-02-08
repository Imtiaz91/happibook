using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class AssignUtilitiesDetail : EntityBase<int>
    {
        public AssignUtilitiesDetail()
        {
        }

        public int AssignUtilitiesId { get; set; }

        public virtual AssignUtilities AssignUtilities { get; set; }

        public int UtilitiesId { get; set; }

        public virtual Utilities Utilities { get; set; }

        public int Charges { get; set; }
    }
}

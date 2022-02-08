using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class AssignUtilities : EntityBase<int>
    {
        public AssignUtilities()
        {
        }

        public int VechileId { get; set; }

        public DateTime AssignDate { get; set; }
        
        public virtual IList<AssignUtilitiesDetail> AssignUtilitiesDetail { get; set; }
    }
}

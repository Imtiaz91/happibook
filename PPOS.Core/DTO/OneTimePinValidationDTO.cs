using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happibook.Core.Entity;

namespace Happibook.Core.DTO
{
    public class OneTimePinValidationDTO
    {
        public bool IsValid { get; set; }

        public ApplicationUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happibook.Core.DTO
{
    public class ChangeDeviceStatusDTO
    {
        public bool Status { get; set; }

        public List<DeviceIdDTO> DeviceIds { get; set; }
    }
}

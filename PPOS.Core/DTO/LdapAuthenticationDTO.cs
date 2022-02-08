using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happibook.Core.DTO
{
    public class LdapAuthenticationDTO
    {
        public bool IsAuthenticated { get; set; }

        public UserDTO UserDto { get; set; }
    }
}

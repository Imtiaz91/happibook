using Happibook.Core.DTO;
using Happibook.Core.Enum;

namespace Happibook.Test.Mock
{
    public class LdapAuthMock
    {

        public static AuthDTO LdapAuthDTO()
        {
            var authdto = new AuthDTO()
            {
                EmailId = "fh_saifullah.iqbal",
                Password = "admin"
            };

            return authdto;
        }
    }
}

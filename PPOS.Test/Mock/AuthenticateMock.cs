using Happibook.Core.DTO;

namespace Happibook.Test.Mock
{
    public static class AuthenticateMock
    {
        public static AuthDTO Authenticate()
        {
            var authenticate = new AuthDTO()
            {
                EmailId = "admin",
                Password = "admin",
                PhoneNumber = "353285062132261"
                // AuthType = AuthType.Sql
            };

            return authenticate;
        }
    }
}

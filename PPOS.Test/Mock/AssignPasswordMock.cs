using Happibook.Core.DTO;

namespace Happibook.Test.Mock
{
    public static class AssignPasswordMock
    {
        public static AssignPasswordDTO AssignPassword()
        {
            var assignPassword = new AssignPasswordDTO()
            {
                EmailId = "admin",
                Password = "admin"
            };

            return assignPassword;
        }
    }
}

using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Enum;
using Happibook.Core.IService;
using System;

namespace Happibook.Test.Mock
{
    public static class UserMock
    {
        public static UserDTO GetUser()
        {
            var user = new UserDTO
            {
                FirstName = "Unit1",
                LastName = "Test1",
                Password = "123456",
                Email = "unit1.test1@test.com",
                Roles = new System.Collections.Generic.List<UserRoleDTO> { new UserRoleDTO { Id = Roles.GetRoleId(UserRoles.Admin) } },
                CellNumber = "03219876543",
            };
            return user;
        }

        public static UserDTO CreateUser(IUserService userService)
        {
            var user = GetUser();
            var dbUser = userService.CreateAsync(user).Result;
            return dbUser;
        }

        public static string GetToken()
        {
            string token = "f9c25cbd-e134-4711-b871-e09067aa5808";
            return token;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Happibook.Core.Enum;

namespace Happibook.Core.Constant
{
    public static class Roles
    {
        private static Dictionary<UserRoles, string> userRoles = new Dictionary<UserRoles, string>();

        static Roles()
        {
            userRoles.Add(Enum.UserRoles.None, "22681f8d-0989-4d8e-a49b-a49d701d7101");
            userRoles.Add(Enum.UserRoles.Admin, "22681f8d-0989-4d8e-a49b-a49d701d7102");
        }

        public static string GetRoleId(UserRoles userRole)
        {
            return userRoles[userRole];
        }

        public static string GetRoleId(string userRole)
        {
            UserRoles role;
            System.Enum.TryParse(userRole, out role);
            return userRoles[role];
        }

        public static string GetRole(string roleId)
        {
            return userRoles.FirstOrDefault(x => x.Value == roleId).Key.ToString();
        }

        public static string GetRole(UserRoles role)
        {
            return userRoles.FirstOrDefault(x => x.Key == role).Key.ToString();
        }

        public static UserRoles GetRoleObject(string roleId)
        {
            return userRoles.FirstOrDefault(x => x.Value == roleId).Key;
        }

        public static bool IsRoleExists(string roleId)
        {
            return userRoles.Any(x => x.Value == roleId);
        }

        public static bool IsExists(string roleId)
        {
            return userRoles.ContainsValue(roleId);
        }
    }
}

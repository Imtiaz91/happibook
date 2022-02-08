using System.Threading.Tasks;
using Happibook.Core.DTO;
using Newtonsoft.Json.Linq;
using Recipe.Core.Attribute;
using Recipe.Core.Enum;

namespace Happibook.Core.IService
{
    public interface IAuthService
    {
        [AuditOperation(OperationType.Read)]
        Task<LdapAuthenticationDTO> AuthenticateAsync(AuthDTO loginDTO);

        [AuditOperation(OperationType.Authorization)]
        Task<JObject> LoginUserAsync(AuthDTO loginData);

        Task<JObject> RefreshTokenAsync(RefreshTokenDTO refreshTokenData);

        [AuditOperation(OperationType.Authorization)]
        Task<string> LogoutUserAsync();

        Task UpdateDeviceToken(UpdateDeviceTokenDTO dtoObject);
    }
}

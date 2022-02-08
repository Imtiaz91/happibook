using Happibook.Core.Enum;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.Infrastructure
{
    public interface ISSHRequestInfo : IRequestInfo
    {
        UserRoles UserRole { get; }
    }
}

using System.Data.Entity;
using System.Threading.Tasks;
using Happibook.Core.Infrastructure;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface ISSHUnitOfWork : IUnitOfWork
    {
        IRequestInfo RequestInfo { get; }

        IUserRepository UserRepository { get; }

        IAuditRepository AuditRepository { get; }

        IPermissionRepository PermissionRepository { get; }

        IPushNotificationRepository PushNotificationRepository { get; }

        // IEmailNotificationRepository EmailNotificationRepository { get; }

        ILOVRepository LOVRepository { get; }

        IExceptionHelper ExceptionHelper { get; }

        IUserRolePermissionRepository UserRolePermissionRepository { get; }

        IRoleRepository RoleRepository { get; }

        IUserSessionRepository UserSessionRepository { get; }

        ILisenceRepository LisenceRepository { get; }

        ISettingRepository SettingRepository { get; }

        ICityRepository CityRepository { get; }

        ICountryRepository CountryRepository { get; }

        ICurrencyRepository CurrencyRepository { get; }

        IRoleCategoryRepository RoleCategoryRepository { get; }

        Task<int> SaveAsync();

        int Save();

        DbContextTransaction BeginTransaction();
    }
}
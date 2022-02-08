using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;

using Recipe.Core.Base.Interface;

namespace Happibook.Repository
{
    public class UnitOfWork : ISSHUnitOfWork
    {
        private readonly ISSHRequestInfo sshRequestInfo;
        private readonly IUserRepository userRepository;
        private readonly IAuditRepository auditRepository;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ILOVRepository lovRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IRequestInfo requestInfo;
        private readonly IPushNotificationRepository pushNotificationRepository;
        private readonly IUserRolePermissionRepository userRolePermissionRepository;
        private readonly IUserSessionRepository userSessionRepository;
        private readonly ILisenceRepository lisenceRepository;
        private readonly ISettingRepository settingRepository;
        private readonly ICityRepository cityRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ICurrencyRepository currencyRepository;
        private readonly IRoleCategoryRepository roleCategoryRepository;

        public UnitOfWork(
            ISSHRequestInfo sshRequestInfo,
            IUserRepository userRepository,
            IAuditRepository auditRepository,
            IExceptionHelper exceptionHelper,
            IPermissionRepository permissionRepository,
            ILOVRepository lovRepository,
            ISSHRequestInfo requestInfo,
            IPushNotificationRepository pushNotificationRepository,
            IUserRolePermissionRepository userRolePermissionRepository,
            IRoleRepository roleRepository,
            IUserSessionRepository userSessionRepository,
            ILisenceRepository lisenceRepository,
            ISettingRepository settingRepository,
            ICityRepository cityRepository,
            ICountryRepository countryRepository,
            ICurrencyRepository currencyRepository,
            IRoleCategoryRepository roleCategoryRepository)
        {
            this.sshRequestInfo = sshRequestInfo;
            this.userRepository = userRepository;
            this.auditRepository = auditRepository;
            this.exceptionHelper = exceptionHelper;
            this.exceptionHelper = exceptionHelper;
            this.pushNotificationRepository = pushNotificationRepository;
            this.lovRepository = lovRepository;
            this.permissionRepository = permissionRepository;
            this.roleRepository = roleRepository;
            this.requestInfo = requestInfo;
            this.userRolePermissionRepository = userRolePermissionRepository;
            this.userSessionRepository = userSessionRepository;
            this.lisenceRepository = lisenceRepository;
            this.settingRepository = settingRepository;

            this.cityRepository = cityRepository;
            this.countryRepository = countryRepository;
            this.currencyRepository = currencyRepository;
            this.roleCategoryRepository = roleCategoryRepository;
        }

        public DbContext DBContext
        {
            get
            {
                return this.sshRequestInfo.Context;
            }
        }

        public ISSHRequestInfo SSHRequestInfo
        {
            get
            {
                return this.sshRequestInfo;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository;
            }
        }

        public IUserSessionRepository UserSessionRepository
        {
            get
            {
                return this.userSessionRepository;
            }
        }

        public IUserRolePermissionRepository UserRolePermissionRepository
        {
            get
            {
                return this.userRolePermissionRepository;
            }
        }

        public ILisenceRepository LisenceRepository
        {
            get
            {
                return this.lisenceRepository;
            }
        }

        public IAuditRepository AuditRepository
        {
            get
            {
                return this.auditRepository;
            }
        }

        public IPushNotificationRepository PushNotificationRepository
        {
            get
            {
                return this.pushNotificationRepository;
            }
        }

        public IPermissionRepository PermissionRepository
        {
            get
            {
                return this.permissionRepository;
            }
        }

        public ILOVRepository LOVRepository
        {
            get
            {
                return this.lovRepository;
            }
        }

        public IExceptionHelper ExceptionHelper
        {
            get
            {
                return this.exceptionHelper;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return this.roleRepository;
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                return this.cityRepository;
            }
        }

        public IRequestInfo RequestInfo
        {
            get
            {
                return this.requestInfo;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                return this.countryRepository;
            }
        }

        public ICurrencyRepository CurrencyRepository
        {
            get
            {
                return this.currencyRepository;
            }
        }

        public IRoleCategoryRepository RoleCategoryRepository
        {
            get
            {
                return this.roleCategoryRepository;
            }
        }

        public ISettingRepository SettingRepository
        {
            get
            {
                return this.settingRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await this.DBContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                this.exceptionHelper.ThrowAPIException(e.EntityValidationErrors.First().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        public int Save()
        {
            try
            {
                return this.DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.Entity.DbContextTransaction BeginTransaction()
        {
            return this.DBContext.Database.BeginTransaction();
        }
    }
}

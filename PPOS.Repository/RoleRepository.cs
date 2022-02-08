using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class RoleRepository : AuditableRepository<ApplicationRole, string>, IRoleRepository
    {
        private ApplicationRoleManager roleManager;
        private ISSHRequestInfo requestInfo;

        public RoleRepository(ISSHRequestInfo requestInfo, ApplicationRoleManager roleManager)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
            this.roleManager = new ApplicationRoleManager(new ApplicationRoleStore(requestInfo));
        }

        protected override IQueryable<ApplicationRole> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.RoleCategory).Where(x => x.IsDeleted == false);
            }
        }

        protected override IQueryable<ApplicationRole> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.RoleCategory).Where(x => x.IsDeleted == false);
            }
        }

        public async Task<ApplicationRole> GetByName(string name)
        {
            return await base.DefaultSingleQuery.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
